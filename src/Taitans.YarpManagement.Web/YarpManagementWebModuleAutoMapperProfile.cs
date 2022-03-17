using AutoMapper;
using Taitans.YarpManagement.Dtos;
using Taitans.YarpManagement.Web.Pages.YarpManagement.ProxyConfigs;

namespace Taitans.YarpManagement.Web;

public class YarpManagementWebModuleAutoMapperProfile : Profile
{
    public YarpManagementWebModuleAutoMapperProfile()
    { 
        //List
        CreateMap<ProxyConfigDto, EditModalModel.ProxyConfigInfoModel>();

        //CreateModal
        CreateMap<CreateModalModel.ProxyConfigInfoModel, CreateProxyConfigDto>();

        //EditModal
        CreateMap<EditModalModel.ProxyConfigInfoModel, CreateProxyConfigDto>();
    }
}
