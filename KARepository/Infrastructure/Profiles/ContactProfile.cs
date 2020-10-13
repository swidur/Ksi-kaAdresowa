using AutoMapper;
using KADataAccess.Models;
using KARepository.Infrastructure.DTOs;

namespace KARepository.Infrastructure.Profiles
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
