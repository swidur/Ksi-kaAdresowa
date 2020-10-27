using AutoMapper;
using Caliburn.Micro;
using KADataAccess.Infrastructure.Profiles;
using KADataAccess.Infrastructure.Repositories.Implementations;
using KADataAccess.Infrastructure.Repositories.Interfaces;
using KsiążkaAdresowaGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace KsiążkaAdresowaGUI
{
    class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>();

            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith("ViewModel"))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));

            _container.
                PerRequest<IContactRepo, ContactEFRepo>();
            //_container.
            //    PerRequest<IMapper, Mapper>();

            MapperConfiguration config = new MapperConfiguration(cfg => cfg.AddProfile(
                new ContactProfile())
            );

            _container.RegisterInstance(
                typeof(IMapper),
                "automapper",
                config.CreateMapper()
    );
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            return _container.GetInstance(serviceType, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return _container.GetAllInstances(serviceType);
        }
        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
