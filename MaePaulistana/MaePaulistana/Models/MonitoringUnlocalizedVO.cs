namespace MaePaulistana.Models;

public class MonitoringUnlocalizedVO
{
    public int PacienteID { get; set; }
    public DateTime? DataAgendada { get; set; }
    public string? PacienteNome { get; set; }
	public string? PacienteCNS { get; set; }
	public string? UnidadeAcompanhamento { get; set; }
	public string? TipoAtendimento { get; set; }
    public DateTime? PrevisaoParto { get; set; }
    public DateTime? UltimaLigacao { get; set; }
    public string? AlteradoPor { get; set; }
}
