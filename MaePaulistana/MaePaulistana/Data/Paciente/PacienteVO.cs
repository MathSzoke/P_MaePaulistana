namespace MaePaulistana.Data.Paciente;

public class PacienteVO
{
    public string? PacienteNome { get; set; } // Nome da paciente
    public DateTime? PacienteDataNascimento { get; set; } // Data de nascimento
    public string? UnidadeAcompanhamento { get; set; } // Unidade de acompanhamento
    public string? TipoAtendimento { get; set; } // Tipo de atendimento
    public string? _qualificacaoMunicipe { get; set; }
    public string? QualificacaoMunicipe
    { 
        get => _qualificacaoMunicipe;
        set
        {
            if (value == "Gestante" || value == "Puerpera" || value == "RN")
            {
                _qualificacaoMunicipe = value;
            }
            else
            {
                throw new ArgumentException("O valor do campo CitizenQualification deve ser uma das seguintes opções: Gestante, Puérpera, RN ou Pai.");
            }
        }
    } // Qualificação da Paciente
    public string? PacienteCNS { get; set; } // Carteira nacional de saude
    public DateTime? DUM { get; set; } // Data da ultima menstruação
    public List<string>? PacienteTelefone { get; set; } // Telefones da paciente

    /*------------------------ Dados do fichário --------------------------*/

    public string? ParametroSituacaoEscolar { get; set; } // Situação escolar da paciente
    public string? PacienteObservacoes { get; set; } // Observações sobre a paciente
    public string? PacienteEmail { get; set; } // Email da paciente
    public bool? PacienteObito { get; set; } // Informação sobre o óbito da paciente
    public string? PacienteRG { get; set; } // Registro geral da paciente
    public string? PacienteCPF { get; set; } // Certidão Pessoa Fisica da paciente
    public string? PacienteEndereco { get; set; } // Endereço da paciente
    public string? ParametroSexo { get; set; } // Sexo da paciente
    public string? ParametroEtnia { get; set; } // Etnia da paciente
}
