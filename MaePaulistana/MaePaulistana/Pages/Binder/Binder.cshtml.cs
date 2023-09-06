using GeoModel.Models;
using GeoModel.Models.Common;
using GeoModel.Models.MaePaulistana;
using MaePaulistana.Data;
using MaePaulistana.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.Binder;

public class BinderModel : PageModel
{
	public int IDPatient { get; set; }

	/* Propriedades da área Monitoramento da gestação */
	public string? PatientName { get; set; }
	public string? PatientCNS { get; set; }
	public string? PatientCPF { get; set; }
	public string? CurrentAge { get; set; }
	public string? PatientSupervision { get; set; }
	public string? RefHighRisk { get; set; }
	public string? PatientAccompaniment { get; set; }
	public DateTime? PatientImportation { get; set; } // ???
	public string? IGImportation { get; set; }
	public string? TypeContact { get; set; }
	public string? GestationalAge { get; set; }
	public DateTime? PrevisionForecast { get; set; }
	public string? GestationalCycle { get; set; }
	public List<string>? PatientRisks { get; set; }
	public int PatientSisPreNatal { get; set; }

	/* Propriedades da área de Dados da ligação Ativa */
	public bool IsPregnant { get; set; }

	/* Propriedades de monitoramento a serem definidas */

	public List<QualificacaoMunicipe>? QualificationCitizen { get; set; }
	public List<Estabelecimento>? Establishment { get; set; }
	public List<SupervisaoTecnica>? SupervisionTec { get; set; }
	public List<Coordenadoria>? Coordination { get; set; }
	public List<TipoFonteDados>? SouceData { get; set; }

	public void OnGet()
	{
		IDPatient = DataManager.GetPatientID();
		using var db = new GeoSaudeDBContext();

		int isPregnant = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(x => x.QualificacaoMunicipeID).FirstOrDefault();

		IsPregnant = isPregnant == 1;

		QualificationCitizen = db.MaePaulistana_QualificacaoMunicipeSet.ToList();
		Establishment = db.Common_EstabelecimentoSet.ToList();
		SupervisionTec = db.Common_SupervisaoTecnicaSet.ToList();
		Coordination = db.Common_CoordenadoriaSet.ToList();
		SouceData = db.Common_TipoFonteDadosSet.ToList();

		MonitoringPregnant();
	}

	public void MonitoringPregnant()
	{
		using var db = new GeoSaudeDBContext();

		DateTime? birthdate = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(o => o.PacienteDataNascimento).FirstOrDefault();

		PatientName = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(x => x.PacienteNome).FirstOrDefault();
		PatientCNS = DataManager.FormatCNS(db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(x => x.PacienteCNS).FirstOrDefault());
		PatientCPF = DataManager.FormatCPF(db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(x => x.PacienteCPF).FirstOrDefault());

		CurrentAge = GetFictitiousAge(birthdate);
		PatientSupervision = db.Common_PacienteSet.Where(x => x.PacienteID.Equals(IDPatient)).Select(x => x.PacienteCNS).FirstOrDefault();
	}
	private static string GetFictitiousAge(DateTime? birthdate)
	{
		if (birthdate.HasValue)
		{
			DateTime currentDate = DateTime.Now;
			DateTime birthdateValue = birthdate.Value;

			int years = currentDate.Year - birthdateValue.Year;
			int months = currentDate.Month - birthdateValue.Month;
			int days = currentDate.Day - birthdateValue.Day;

			if (days < 0)
			{
				months--;
				days += DateTime.DaysInMonth(currentDate.Year, currentDate.Month - 1);
			}

			if (months < 0)
			{
				years--;
				months += 12;
			}

			string ageString = $"{years}a {months}m {days}d";
			return ageString;
		}
		else
		{
			return "";
		}
	}
}
