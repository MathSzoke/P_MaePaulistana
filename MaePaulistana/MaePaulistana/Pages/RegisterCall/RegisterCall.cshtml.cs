using GeoModel.Models;
using GeoModel.Models.MaePaulistana;
using MaePaulistana.Data;
using MaePaulistana.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.RegisterCall;

public class RegisterCallModel : PageModel
{
    public int? PatientID { get; set; }

    public string? TypeContactNotEffectedID { get; set; }
	public string? DescTypeContactNotEffected { get; set; }
	public string? HomePhone { get; set; }
    public string? MobilePhone { get; set; }
    public string? MessagePhone { get; set; }
    public List<HistoryCallsVO>? HistoryCallsProp { get; set; }
    public List<TiposContatoNaoEfetivado>? TypesContactNotEffected { get; set; }

    public void OnGet(int patientId)
    {
        PatientID = patientId == 0 ? DataManager.GetPatientID() : DataManager.SetPatientID(patientId);
        using var dbContext = new GeoSaudeDBContext();
        var telephones = dbContext.Common_PacienteTelefoneSet;

        HomePhone = telephones.Where(p => p.PacienteID == PatientID && p.TipoTelefoneID == "RS").Select(t => t.NumeroTelefone).FirstOrDefault();
        MobilePhone = telephones.Where(p => p.PacienteID == PatientID && p.TipoTelefoneID == "CE").Select(t => t.NumeroTelefone).FirstOrDefault();
        MessagePhone = telephones.Where(p => p.PacienteID == PatientID && p.TipoTelefoneID == "RE").Select(t => t.NumeroTelefone).FirstOrDefault();

		HomePhone = DataManager.FormatPhoneNumber(HomePhone);
		MobilePhone = DataManager.FormatPhoneNumber(MobilePhone);
		MessagePhone = DataManager.FormatMessagePhoneNumber(MessagePhone);

		TypeContactNotEffectedID = dbContext.MaePaulistana_TiposContatoNaoEfetivadoSet.Select(x => x.TipoContNaoEfetivadoID).FirstOrDefault();
        DescTypeContactNotEffected = dbContext.MaePaulistana_TiposContatoNaoEfetivadoSet.Where(x => x.TipoContNaoEfetivadoID.Equals(TypeContactNotEffectedID)).Select(x => x.DescTipoContNaoEfetivado).FirstOrDefault();
		TypesContactNotEffected = dbContext.MaePaulistana_TiposContatoNaoEfetivadoSet.ToList();
		HistoryCalls();
	}

    public void HistoryCalls()
    {
        using var dbContext = new GeoSaudeDBContext();
		HistoryCallsProp = dbContext.MaePaulistana_ContatoLigacaoSet.Where(c => c.PacienteID == PatientID)
            .Select(c => new HistoryCallsVO
            {
                DataContatoLigacao = c.DataContatoLigacao,
                ContatoNome = c.ContatoNome,
                ContatoEfetivado = c.ContatoEfetivado,
                MotivoNaoLocalizada = c.TiposContato.DescTipoContNaoEfetivado,
                ObsLigacao = c.ObsLigacao,
                TelefoneUtilizado = c.TelefoneUtilizado,
                NomeAtendente = c.CriadoPor
            }).ToList();
    }
}
