using Microsoft.AspNetCore.Mvc;
using GeoModel.Models;
using MaePaulistana.Models;
using GeoModel.Models.MaePaulistana;
using AutoMapper;
using MaePaulistana.Data;

namespace MaePaulistana.Controllers;

public class ContactPatientController : Controller
{
	private readonly IMapper _mapper;

	public ContactPatientController(IMapper mapper)
	{
		_mapper = mapper;
	}

	/// <summary>
	/// Captura os dados do paciente para serem exibidos na tela de monitoramento <br />
	/// </summary>
	/// <param name="patientId"></param>
	/// <returns>
	/// Se o paciente existir, retorna Ok() <br />
	/// Se não existir, retorna NoContent()
	/// </returns>
	[HttpGet]
	public IActionResult GetDataPatients(int patientId)
	{
		if (patientId == 0) return NoContent();

		try
		{
			using var db = new GeoSaudeDBContext();

			// Verifica se existe dado de monitoramento para o paciente na tabela ContatoLigacao
			var monitoring = db.MaePaulistana_ContatoLigacaoSet.Where(x => x.PacienteID.Equals(patientId)).FirstOrDefault();
			
			// Verifica se o monitoring é maior que 1, se for, retorna status HTTP Ok, se não, retorna NoContent()
			if (monitoring != null) return Ok();
			else { return NoContent(); }
		}
		catch(Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	/// <summary>
	/// Registra a ligação feita com o paciente <br />
	/// </summary>
	/// <param name="rcVO"></param>
	/// <returns>
	/// Se tudo ocorrer bem, retorna Ok() <br/
	/// Se não, retorna BadRequest()
	/// ></returns>
	[HttpPost]
	public async Task<IActionResult> RegisterCall([FromBody] RegisterCallVO rcVO)
	{
		if (rcVO == null) return NoContent();

		try
		{
			rcVO.PacienteID = DataManager.GetPatientID();

			ContatoPaciente cp = _mapper.Map<ContatoPaciente>(rcVO);

			using var db = new GeoSaudeDBContext();

			cp.ContatoNome = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcVO.PacienteID)).Select(x => x.PacienteNome).FirstOrDefault();

			db.MaePaulistana_ContatoLigacaoSet.Add(cp);

			await db.SaveChangesAsync();

			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	/// <summary>
	/// Registra o contato feito com o paciente, mas não efetivado <br />
	/// </summary>
	/// <param name="rcvo"></param>
	/// <returns></returns>
	[HttpPost]
	public async Task<IActionResult> RegisterPatientContactNotEffected([FromBody] RegisterCallVO rcvo)
	{
		if(rcvo == null) return NoContent();

		try
		{
			using var db = new GeoSaudeDBContext();

			rcvo.PacienteID = DataManager.GetPatientID();

			Monitoramento m = new()
			{
				PacienteID = rcvo.PacienteID,
				ContatoEfetivado = rcvo.ContatoEfetivado,
				DataAgendada = DateTime.Now.AddHours(6),
				PacienteNome = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.PacienteNome).FirstOrDefault(),
				PacienteCNS = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.PacienteCNS).FirstOrDefault(),
				UnidadeAcompanhamento = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.UnidadeAcompanhamento.EstabelecimentoNome).FirstOrDefault(),
				TipoAtendimento = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.TipoAtendimento.DescTipoAtendimento).FirstOrDefault(),
				PrevisaoParto = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.PrevisaoParto).FirstOrDefault(),
				DataNascimento = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(rcvo.PacienteID)).Select(x => x.PacienteDataNascimento).FirstOrDefault(),
				TelefoneUtilizado = rcvo.TelefoneUtilizado,
				SupervisaoTecnicaId = 2,
				CoordenadoriaId = 2,
				EstabelecimentoID = 5,
				UltimaLigacao = DateTime.Now
			};

			ContatoPaciente cp = _mapper.Map<ContatoPaciente>(rcvo);


			db.MaePaulistana_MonitoramentoSet.Add(m);
			db.MaePaulistana_ContatoLigacaoSet.Add(cp);

			await db.SaveChangesAsync();

			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpPatch]
	public async Task<IActionResult> UpdateMonitoringUnlocalized([FromBody] MonitoringUnlocalizedVO muvo)
	{
		if (muvo == null) return NoContent();

		try
		{
			using var db = new GeoSaudeDBContext();

			Monitoramento m = _mapper.Map<Monitoramento>(muvo);

			db.MaePaulistana_MonitoramentoSet.Add(m);

			await db.SaveChangesAsync();

			return Ok();
		}
		catch(Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
