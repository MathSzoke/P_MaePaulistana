using AutoMapper;
using GeoModel.Models;
using GeoModel.Models.Common;
using MaePaulistana.Data;
using MaePaulistana.Data.Patient;
using Microsoft.AspNetCore.Mvc;

namespace MaePaulistana.Controllers;

public class PatientController : ControllerBase
{
	private readonly IMapper _mapper;

	public PatientController(IMapper mapper)
	{
		_mapper = mapper;
	}

	[HttpPost]
	public async Task<IActionResult> NewPatient([FromBody] PatientVO pvo)
    {
        try
        {
			Paciente p = _mapper.Map<Paciente>(pvo);

			using var dbContext = new GeoSaudeDBContext();

			p.PacienteCPF = DataManager.RemoveFormattingFromCPF(pvo.PacienteCPF!);
			p.PacienteCNS = DataManager.RemoveFormattingFromCNS(pvo.PacienteCNS!);

			dbContext.Common_PacienteSet.Add(p);

			await dbContext.SaveChangesAsync();

			DataManager._patient.PacienteID = p.PacienteID;

			return Ok();
		}
		catch (Exception ex)
        {
            return BadRequest(ex.Message);
		}
	}

	[HttpPost]
	public async Task<IActionResult> NewTelephonePatient([FromBody] PatientVO pvo)
	{
		if (pvo == null)
		{
			return NoContent();
		}

		try
		{
			using var dbContext = new GeoSaudeDBContext();

			int patientID = DataManager.GetPatientID();

			PacienteTelefone pt = _mapper.Map<PacienteTelefone>(pvo);

			pt.PacienteID = patientID;
			pt.NumeroTelefone = DataManager.RemoveFormattingFromPhoneNumber(pvo.NumeroTelefone!);

			dbContext.Common_PacienteTelefoneSet.Add(pt);

			await dbContext.SaveChangesAsync();

			DataManager._telephone.TelefoneID = pt.TelefoneID;

			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}

	[HttpDelete]
	public async Task<IActionResult> RemoveTelephonePatient([FromBody] PacienteTelefone pt)
	{
		if (pt == null)
		{
			return NoContent();
		}

		try
		{
			using var db = new GeoSaudeDBContext();

			int telephoneID = DataManager.GetTelephoneID();

			var idTel = db.Common_PacienteTelefoneSet.Where(x => x.TelefoneID.Equals(telephoneID));

			db.Common_PacienteTelefoneSet.RemoveRange(idTel);

			await db.SaveChangesAsync();

			return Ok();
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}
