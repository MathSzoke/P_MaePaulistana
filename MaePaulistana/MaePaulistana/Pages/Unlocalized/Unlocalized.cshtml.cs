using GeoModel.Models;
using GeoModel.Models.MaePaulistana;
using MaePaulistana.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.Unlocalized;

public class UnlocalizedModel : PageModel
{
    public List<Monitoramento>? DataUnlocalized { get; private set; }

    public void OnGet(int pageNumber = 1, int pageSize = 10)
    {
        using var db = new GeoSaudeDBContext();

        int recordsToSkip = (pageNumber -1 ) * pageSize;

        if(db != null)
        {
            DataUnlocalized = db.MaePaulistana_MonitoramentoSet
            .Where(x => x.ContatoEfetivado.Equals(0))
            .OrderBy(x => x.PacienteNome)
            .Skip(recordsToSkip)
            .Take(pageSize)
            .Select(x => new Monitoramento
            {
                PacienteID = x.PacienteID,
                DataAgendada = x.DataAgendada,
                PacienteNome = x.PacienteNome,
                PacienteCNS = DataManager.FormatCNS(x.PacienteCNS),
                UnidadeAcompanhamento = x.UnidadeAcompanhamento,
                TipoAtendimento = x.TipoAtendimento,
                PrevisaoParto = x.PrevisaoParto,
                UltimaLigacao = x.UltimaLigacao,
                CriadoPor = x.CriadoPor
            })
            .ToList();
        }        
    }
}
