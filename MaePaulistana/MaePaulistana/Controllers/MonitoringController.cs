using AutoMapper;
using GeoModel.Models;
using MaePaulistana.Models;
using MaePaulistana.Pages.Monitoring;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeoModel.Controllers;

/// <summary>
/// Controller de monitoramento
/// </summary>
[ApiController]
[Route("[controller]")]
public class MonitoringController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IMapper _mapper;

    public MonitoringController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna lista de pacientes em monitoramento por nome ou data de nascimento ou cns
    /// </summary>
    /// <returns>Json de dados sobre monitoramento das pacientes</returns>
    [HttpGet("MonitoringSearch")]
    public async Task<ActionResult<IList<MonitoringVO>>> MonitoringSearch([FromQuery(Name = "name")] string? name, [FromQuery(Name = "birthdate")] DateTime? bD, [FromQuery(Name = "cns")] string? cns)
    {
        using var db = new GeoSaudeDBContext();

		Monitoring m = new(_mapper);

        if (db == null)
        {
            return BadRequest("Sem conexão ao banco de dados, por favor, tente novamente mais tarde.");
        }

        try
        {
            var query = db.MaePaulistana_MonitoramentoSet.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.PacienteNome.Contains(name) && x.PrecisaAtencao.Equals(false));
            }

            if (bD.HasValue)
            {
                query = query.Where(x => x.DataNascimento == bD.Value && x.PrecisaAtencao.Equals(false));
            }

            if (!string.IsNullOrEmpty(cns))
            {
                query = query.Where(x => x.PacienteCNS.Equals(cns) && x.PrecisaAtencao.Equals(false));
            }

            var results = await query.OrderBy(x => x.PacienteNome).ToListAsync();

            return Json(_mapper!.Map<IList<MonitoringVO>>(results));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
