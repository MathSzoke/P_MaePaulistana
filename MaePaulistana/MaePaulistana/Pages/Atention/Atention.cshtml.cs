using GeoModel.Models;
using GeoModel.Models.Common;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.Atention;

public class AtentionModel : PageModel
{
    protected readonly GeoSaudeDBContext? geoSaudeDBContext;
    public List<Paciente>? DataAtention { get; private set; }
    public void OnGet(int pageNumber = 1, int pageSize = 10)
    {
        int skip = (pageNumber - 1) * pageSize;

        if(this.geoSaudeDBContext != null)
        {
            DataAtention = this.geoSaudeDBContext.Common_PacienteSet
                .Where(x => x.PacienteAtencao.Equals(true))
                .OrderBy(x => x.PacienteNome)
                .Skip(skip)
                .Take(pageSize)
                .Select(o => new Paciente
                {
                    PacienteNome = o.PacienteNome,
                    PacienteDataNascimento = o.PacienteDataNascimento,
                    PacienteObservacoes = o.PacienteObservacoes,
                    PacienteCNS = o.PacienteCNS
                }).ToList();
        }
    }
}
