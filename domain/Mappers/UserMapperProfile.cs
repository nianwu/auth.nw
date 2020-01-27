using System.Security.Claims;
using AutoMapper;
using domain.Models;

namespace domain.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<EntityFramework.Storage.Entities.UserClaim, Claim>(MemberList.None)
                .ConstructUsing(x=>new Claim(x.Type, x.Value, ClaimValueTypes.String))
                .ReverseMap();

            CreateMap<EntityFramework.Storage.Entities.User, User>()
                .ReverseMap();
        }
    }
}