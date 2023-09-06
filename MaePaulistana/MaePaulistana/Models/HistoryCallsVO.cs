namespace MaePaulistana.Models;

public class HistoryCallsVO
{
	public int PacienteID { get; set; }
	public DateTime? DataContatoLigacao { get; set; }
	public string? ContatoNome { get; set; }
	public short ContatoEfetivado { get; set; }
	public string? MotivoNaoLocalizada { get; set; }
	public string? ObsLigacao { get; set; }
	public string? TelefoneUtilizado { get; set; }
	public string? NomeAtendente { get; set; }
}
