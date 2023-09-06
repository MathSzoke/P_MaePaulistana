namespace MaePaulistana.Models;

public class PatientEvolutionVO
{
	public DateTime DataEvolucao { get; set; }
	public int IGEntrevista { get; set; }
	public short PAMax { get; set; }
	public short PAMin { get; set; }
    public short PesoPaciente { get; set; }
    public short AlturaPaciente { get; set; }
	public string? IMCPaciente { get; set; }
	public short GlicemiaPaciente { get; set; }
	public short SaturacaoPaciente { get; set; }
	public string? Medicamentos { get; set; }
}
