using AutoMapper;
using GeoModel.Models;
using GeoModel.Models.Common;
using GeoModel.Models.MaePaulistana;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeoModel.Controllers;

/// <summary>
/// Controller de monitoramento
/// </summary>
public class MonitoramentoController : Controller
{
    /// <summary>
    /// 
    /// </summary>
    private readonly IMapper _mapper;

    /// <summary>
    /// 
    /// </summary>
    protected readonly GeoSaudeDBContext geoSaudeDBContext;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    public MonitoramentoController(IMapper mapper)
    {
        _mapper = mapper;
    }

    /// <summary>
    /// Retorna lista de pacientes em monitoramento por nome ou data de nascimento ou cns
    /// </summary>
    /// <returns>Json de dados sobre monitoramento das pacientes</returns>
    [HttpGet]
    public List<Monitoramento> Monitoring()
    {
        var dataMonitoring = this.geoSaudeDBContext.MaePaulsistana_MonitoramentoSet.Where(x => x.ContatoEfetivado.Equals(1)).OrderBy(x => x.PacienteNome).Select(x => new Monitoramento
        {
            DataAgendada = x.DataAgendada,
            PacienteNome = x.PacienteNome,
            PacienteCNS = x.PacienteCNS,
            TipoAtendimento = x.TipoAtendimento,
            PrevisaoParto = x.PrevisaoParto,
            UltimaLigacao = x.UltimaLigacao,
            NomeEnfermeira = x.NomeEnfermeira
        }).ToList();

        return dataMonitoring;
    }

    /// <summary>
    /// Retorna lista de pacientes em monitoramento por nome ou data de nascimento ou cns
    /// </summary>
    /// <returns>Json de dados sobre monitoramento das pacientes</returns>
    [HttpGet]
    public IActionResult MonitoringSearch(Paciente nome, DateTime? dataNascimento, string cns)
    {
        var query = this.geoSaudeDBContext.MaePaulsistana_MonitoramentoSet.AsQueryable();

        if (nome != null)
        {
            query = query.Where(x => x.PacienteNome.Contains(nome));
        }

        if (dataNascimento.HasValue)
        {
            query = query.Where(x => x.DataNascimento == dataNascimento.Value);
        }

        if (!string.IsNullOrEmpty(cns))
        {
            query = query.Where(x => x.PacienteCNS.Equals(cns));
        }

        var dataMonitoring = query.OrderBy(x => x.PacienteNome).Select(x => new Monitoramento
            {
                DataAgendada = x.DataAgendada,
                PacienteNome = x.PacienteNome,
                PacienteCNS = x.PacienteCNS,
                TipoAtendimento = x.TipoAtendimento,
                PrevisaoParto = x.PrevisaoParto,
                UltimaLigacao = x.UltimaLigacao,
                NomeEnfermeira = x.NomeEnfermeira
            }).ToList();

        return Ok(dataMonitoring);
    }

    /// <summary>
    /// Retorna uma lista de pacientes que não foram localizadas, ou, que não obteve o contato efetivado.
    /// </summary>
    /// <returns>Json de dados sobre pacientes não localizadas.</returns>
    [HttpGet]
    public IActionResult Unlocalized()
    {
        var dataMonitoring = this.geoSaudeDBContext.MaePaulsistana_MonitoramentoSet.Where(x => x.ContatoEfetivado.Equals(0)).OrderBy(x => x.PacienteNome).Select(x => new Monitoramento
        {
            DataAgendada = x.DataAgendada,
            PacienteNome = x.PacienteNome,
            PacienteCNS = x.PacienteCNS,
            TipoAtendimento = x.TipoAtendimento,
            PrevisaoParto = x.PrevisaoParto,
            UltimaLigacao = x.UltimaLigacao,
            NomeEnfermeira = x.NomeEnfermeira
        }).ToList();

        return Ok(dataMonitoring);
    }
}
