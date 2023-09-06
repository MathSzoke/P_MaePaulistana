using GeoModel.Models;
using GeoModel.Models.Common;
using GeoModel.Models.MaePaulistana;
using MaePaulistana.Data.Patient;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.NewPatient;

public class NewPatient : PageModel
{
	public List<TipoAtendimento>? TiposAtendimento { get; set; }
	public List<Estabelecimento>? Estabelecimentos { get; set; }
	public List<TipoTelefone>? TipoTelefoneList { get; set; }
	public List<QualificacaoMunicipe>? QualificacaoMunicipes { get; set; }

	public void OnGet()
	{
		using var dbContext = new GeoSaudeDBContext();

        TiposAtendimento = dbContext.MaePaulistana_TipoAtendimentoSet.ToList();
		Estabelecimentos = dbContext.Common_EstabelecimentoSet.ToList();
		TipoTelefoneList = dbContext.Common_TipoTelefoneSet.ToList();
		QualificacaoMunicipes = dbContext.MaePaulistana_QualificacaoMunicipeSet.ToList();
	}
}
