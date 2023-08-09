using GeoModel.Models.MaePaulistana;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaePaulistana.Pages.Monitoring;
public class Monitoring : PageModel
{
    private readonly ILogger<Monitoring> _logger;

    public Monitoring(ILogger<Monitoring> logger)
    {
        //_controller = controller;
        _logger = logger;
    }

    public List<Monitoramento> M { get; set; }

    public void OnGet()
    {
        //M = M.ToList();
        //M = _controller.Monitoring();
    }
}