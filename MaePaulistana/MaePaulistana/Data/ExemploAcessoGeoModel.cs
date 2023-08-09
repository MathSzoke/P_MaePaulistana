using GeoModel;
using GeoModel.Models.Common;

namespace MaePaulistana.Data;

public static class ExemploAcessoGeoModel
{
    public static ICollection<GeoModel.Models.Common.Paciente> ListarPacientes()
    {
        using(var contexto = new GeoModel.Models.GeoSaudeDBContext())
        {
            var pacientes = contexto.Common_PacienteSet.ToList();

            return pacientes;
        }
    }
}
