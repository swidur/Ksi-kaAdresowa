using Caliburn.Micro;
using KsiążkaAdresowaGUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KsiążkaAdresowaGUI.ViewModels
{
    class EditContactViewModel : Screen, IHandle<EditContactEventModel>
    {
        private string _firstName;
        private string _lastName;
        private string _areaCode;
        private string _street;
        private string _city;
        private string _houseNumber;
        private string _flatNumber;
        private string _sex;
        private string _age;
        private string _phone;
        private string _email;
        private string _comment;
        private IEventAggregator _events;

        public EditContactViewModel(IEventAggregator events)
        {
            _events = events;
            _events.Subscribe(this);
        }
        public string FirstName
        {
            get { return _firstName; }
            set 
            { 
                _firstName = value;
                NotifyOfPropertyChange(() => FirstName);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set 
            {
                _lastName = value;
                NotifyOfPropertyChange(() => LastName);
            }
        }
        public string AreaCode
        {
            get { return _areaCode; }
            set 
            {
                _areaCode = value;
                NotifyOfPropertyChange(() => AreaCode);
            }
        }
        public string Street
        {
            get { return _street; }
            set 
            {
                _street = value;
                NotifyOfPropertyChange(() => Street);
            }
        }
        
        public string City
        {
            get { return _city; }
            set 
            {
                _city = value;
                NotifyOfPropertyChange(() => City);
            }
        }
        public string HouseNumber
        {
            get { return _houseNumber; }
            set 
            {
                _houseNumber = value;
                NotifyOfPropertyChange(() => HouseNumber);
            }
        }
        public string FlatNumber
        {
            get { return _flatNumber; }
            set 
            {
                _flatNumber = value;
                NotifyOfPropertyChange(() => FlatNumber);
            }
        }
        public string Sex
        {
            get { return _sex; }
            set 
            {
                _sex = value;
                NotifyOfPropertyChange(() => Sex);
            }
        }
        public string Age
        {
            get { return _age; }
            set 
            {
                _age = value;
                NotifyOfPropertyChange(() => Age);
            }
        }
        
        public string Phone
        {
            get { return _phone; }
            set 
            {
                _phone = value;
                NotifyOfPropertyChange(() => Phone);
            }
        }
        
        public string Email
        {
            get { return _email; }
            set 
            {
                _email = value;
                NotifyOfPropertyChange(() => Email);
            }
        }
        public string Comment
        {
            get { return _comment; }
            set 
            {
                _comment = value;
                NotifyOfPropertyChange(() => Comment);
            }
        }

        public void Handle(EditContactEventModel message)
        {
            FirstName = message.selectedContact.FirstName;
            LastName = message.selectedContact.LastName;
            AreaCode = message.selectedContact.AreaCode;
            Street = message.selectedContact.Street;
            City = message.selectedContact.City;
            HouseNumber = message.selectedContact.HouseNumber;
            FlatNumber = message.selectedContact.FlatNumber;
            Sex = message.selectedContact.Sex;
            Age = message.selectedContact.Age.ToString();
            Phone = message.selectedContact.Phone;
            Email = message.selectedContact.Email;
            Comment = message.selectedContact.Comment;
        }
    }
}
