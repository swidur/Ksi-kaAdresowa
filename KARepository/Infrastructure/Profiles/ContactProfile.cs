using AutoMapper;
using KARepository.DTOs;
using KADataAccess.Models;

namespace KARepository.Infrastructure.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactCreateDTO>();
            CreateMap<ContactCreateDTO, Contact>();

            CreateMap<Contact, ContactReadDTO>();
            CreateMap<ContactReadDTO, Contact>();
        }
    }
}
