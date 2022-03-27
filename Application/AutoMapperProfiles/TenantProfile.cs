using AutoMapper;
using Models.DTOs.TenantsDTOs;
using Models.Entites;

namespace Application.AutoMapperProfiles
{
    public class TenantProfile : Profile
    {

        public TenantProfile()
        {
            CreateMap<Tenant, SelectTenantDTO>();

            CreateMap<CreateTenantDTO, Tenant>();

            CreateMap<UpdateTenantDTO, Tenant>();
        }
    }
}
