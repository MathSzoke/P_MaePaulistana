namespace MaePaulistana.Models;

public class RegisterCallVO
{
	public int PacienteID { get; set; }
    public string? TelefoneResidencial { get; set; }
    public string? TelefoneCelular { get; set; }
    public string? TelefoneRecado { get; set; }
	public string? TelefoneUtilizado { get; set; }
	public DateTime? DataContatoLigacao { get; set; } = DateTime.Now;
    public short ContatoEfetivado { get; set; }
    public string? TipoContNaoEfetivadoID { get; set; }
}
