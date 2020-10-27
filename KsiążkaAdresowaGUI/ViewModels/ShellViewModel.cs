using AutoMapper;
using Caliburn.Micro;
using KADataAccess.Infrastructure.DTOs;
using KADataAccess.Infrastructure.Profiles;
using KADataAccess.Infrastructure.Repositories.Implementations;
using KADataAccess.Infrastructure.Repositories.Interfaces;
using KsiążkaAdresowaGUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KsiążkaAdresowaGUI.ViewModels
{
    class ShellViewModel : Screen
    {
        private readonly IWindowManager _manager;
        private readonly IEventAggregator _events;
        private readonly EditContactViewModel _editContact;
        private IMapper _mapper;
        private IContactRepo _repo;
        private string _serachBox = "";
        private bool _showActiveContacts = true;
        private BindableCollection<ContactReadDTO> _contacts = new BindableCollection<ContactReadDTO>();
        public ShellViewModel(IWindowManager manager, IEventAggregator events, EditContactViewModel editContact, IMapper mapper, IContactRepo repo)
        {
            _manager = manager;
            _events = events;
            _editContact = editContact;
            _mapper = mapper;
            _repo = repo;
            Contacts = new BindableCollection<ContactReadDTO>(_mapper.Map<IEnumerable<ContactReadDTO>>(_repo.GetAllContacts(SearchBox)));
        }

        public BindableCollection<ContactReadDTO> Contacts
        {
            get { return _contacts; }
            set 
            { 
                _contacts = value;
                NotifyOfPropertyChange(() => Contacts);
            }
        }

        public string SearchBox
        {
            get { return _serachBox; }
            set
            { 
                _serachBox = value;
                NotifyOfPropertyChange(() => SearchBox);
                Contacts = UnicornGetData();
            }
        }

        public bool ShowActiveContacts
        {
            get { return _showActiveContacts; }
            set
            {
                _showActiveContacts = value;
                NotifyOfPropertyChange(() => ShowActiveContacts);
                NotifyOfPropertyChange(() => CanActiveContacts);
                NotifyOfPropertyChange(() => CanDeletedContacts);
            }
        }

        public bool CanDeletedContacts
        {
            get { return ShowActiveContacts; }
        }
        public void DeletedContacts()
        {
            ShowActiveContacts = false;
            Contacts = UnicornGetData();
        }
        public bool CanActiveContacts
        {
            get { return !ShowActiveContacts; }
        }
        public void ActiveContacts()
        {
            ShowActiveContacts = true;
            Contacts = UnicornGetData();
        }

        public BindableCollection<ContactReadDTO> UnicornGetData()
        {
            //change repo method to pass isDeleted as an argument
            if (ShowActiveContacts)
            {
               return new BindableCollection<ContactReadDTO>(_mapper.Map<IEnumerable<ContactReadDTO>>(_repo.GetAllContacts(SearchBox)));
            } 
            else
            {
                return new BindableCollection<ContactReadDTO>(_mapper.Map<IEnumerable<ContactReadDTO>>(_repo.GetAllDeletedContacts(SearchBox)));
            }
        }

        public void AddContact()
        {
            var selected = new ContactReadDTO() { Age = 21, FirstName = "Alfonse" };
            _manager.ShowWindow(_editContact, null, null);
            _events.PublishOnUIThread(new EditContactEventModel() { selectedContact = selected });
        }

    }
}
