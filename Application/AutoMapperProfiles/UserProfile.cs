using AutoMapper;
using Models.DTOs.UsersDTOs;
using Models.Entites;

namespace Application.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, SelectUserDTO>();

            CreateMap<CreateUserDTO, User>();

            CreateMap<UpdateUserDTO, User>()
                    .ForMember(dest => dest.UserId, opt => opt.Ignore());
        }
    }
}
