namespace MaePaulistana.Models;

public class MonitoramentoVO
{
    public DateTime? DataAgendada { get; set; }
    public string? PacienteNome { get; set; }
    public string? PacienteCNS { get; set; }
    public string? UnidadeAcompanhamento { get; set; }
    public string? TipoAtendimento { get; set; }
    public DateTime? PrevisaoParto { get; set; }
    public DateTime? UltimaLigacao { get; set; }
    public string? NomeEnfermeira { get; set; }
    public bool PrecisaAtencao { get; set; } = false;

    /********************* AREA SEARCH ************************/

    public DateTime? DataNascimento { get; set; }
    /* Nome e CNS estão acima */
}
