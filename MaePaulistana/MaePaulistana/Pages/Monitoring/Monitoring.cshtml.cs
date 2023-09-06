using AutoMapper;
using GeoModel.Models;
using GeoModel.Models.MaePaulistana;
using MaePaulistana.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MaePaulistana.Pages.Monitoring;
public class Monitoring : PageModel
{
    protected readonly GeoSaudeDBContext? geoSaudeDBContext;
    public IList<MonitoringVO> DataMonitoring { get; set; } = new List<MonitoringVO>();

    private readonly IMapper? _mapper;

    public Monitoring(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task OnGetAsync()
    {
        await LoadData();
    }

    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public bool PrevPage => PageIndex > 1;
    public bool NextPage => PageIndex < TotalPages;

    private async Task LoadData(int pageIndex = 1, int pageSize = 10)
    {
        int recordsToSkip = (pageIndex - 1) * pageSize;

        if (geoSaudeDBContext != null)
        {
            var query = geoSaudeDBContext.MaePaulistana_MonitoramentoSet
                .Where(x => x.ContatoEfetivado.Equals(1) && x.PrecisaAtencao.Equals(false))
                .OrderBy(x => x.PacienteNome)
                .Skip(recordsToSkip)
                .Take(pageSize)
                .Select(x => new Monitoramento
                 {
                     DataAgendada = x.DataAgendada,
                     PacienteNome = x.PacienteNome,
                     PacienteCNS = x.PacienteCNS,
                     TipoAtendimento = x.TipoAtendimento,
                     PrevisaoParto = x.PrevisaoParto,
                     UltimaLigacao = x.UltimaLigacao,
                     CriadoPor = x.CriadoPor
                 });
            var results = await query.ToListAsync();

            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(results.Count / (double)pageSize);

            DataMonitoring = _mapper.Map<List<MonitoringVO>>(results);
        }
    }
}