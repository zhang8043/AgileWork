using AutoMapper;
using Volo.Abp.TenantManagement;

namespace Agile.Abp.TenantManagement
{
    public class AbpTenantManagementApplicationAutoMapperProfile : Profile
    {
        public AbpTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<TenantConnectionString, TenantConnectionStringDto>();

            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}
