using AutoMapper;
using Taitans.YarpManagement.Dtos;

namespace Taitans.YarpManagement
{
    public class YarpManagementApplicationAutoMapperProfile : Profile
    {
        public YarpManagementApplicationAutoMapperProfile()
        {
            CreateMap<ProxyConfig, ProxyConfigDto>();
        }
    }
}