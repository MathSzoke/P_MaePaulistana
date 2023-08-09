using AutoMapper;

namespace MaePaulistana.Data.MapperMonitoramento;

public class MonitoramentoVO : Profile
{
    public MonitoramentoVO() => CreateMap<GeoModel.Models.MaePaulistana.Monitoramento, MonitoramentoVO>();
}
