using AutoMapper;
using KsiążkaAdresowaGUI.DTOs;
using KADataAccess.Models;

namespace KARepository.Infrastructure.Profiles
{
    class ContactProfile : Profile
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
