using AutoMapper;
using Net.PC.Contacts.Repository.Entities;
using Net.PC.Contacts.WebApi.Models;

namespace Net.PC.Contacts.WebApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
            CreateMap<Contact, ContactRequest>();
            CreateMap<ContactRequest, Contact>();
            CreateMap<SubCategoryRequest, SubCategory>();
        }
    }
}
