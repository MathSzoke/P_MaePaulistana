namespace MaePaulistana.Data.Patient;

public class PatientVO
{
	public int PacienteID { get; set; }
	public string? PacienteNome { get; set; } // Nome da paciente
	public DateTime? PacienteDataNascimento { get; set; } // Data de nascimento
	public int UnidadeAcompanhamentoID { get; set; } // Unidade de acompanhamento ID
	public string? TipoAtendimentoID { get; set; } // Tipo de atendimento ID
	public int QualificacaoMunicipeID { get; set; } // ID da qualificação da munícipe
	public string? PacienteCNS { get; set; } // Carteira nacional de saude
	public string? PacienteCPF { get; set; } // Carteira nacional de saude
	public DateTime? DUM { get; set; } // Data da ultima menstruação
	public DateTime? PrevisaoParto { get; set; } // Data de previsão do parto
	public string? NumeroTelefone { get; set; } // Número do telefone da paciente
	public string? TipoTelefoneID { get; set; } // ID do tipo do telefone
	public string? ObsTelefone { get; set; } // Observações do telefone
}
