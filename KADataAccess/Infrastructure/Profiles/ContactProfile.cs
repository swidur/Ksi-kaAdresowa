using AutoMapper;
using KADataAccess.Models;
using KADataAccess.Infrastructure.DTOs;

namespace KADataAccess.Infrastructure.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactReadDTO>();
            CreateMap<ContactReadDTO, Contact>();

            CreateMap<Contact, ContactCreateDTO>();
            CreateMap<ContactCreateDTO, Contact>();
        }
    }
}
