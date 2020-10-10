using AutoMapper;
using KsiążkaAdresowaGUI.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using KADataAccess.Models;

namespace KsiążkaAdresowaGUI.Profiles
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
