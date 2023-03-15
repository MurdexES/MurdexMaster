using ECommerceApp_Client.Services.Messages;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp_Client.Services.Interfaces;

namespace ECommerceApp_Client.Services.Classes
{
    internal class NavigationService : IMyNavigationService
    {
        private readonly IMessenger _messenger;

        public NavigationService(IMessenger messenger)
        {
            _messenger = messenger;
        }

        public void NavigateTo<T>(object? data = null) where T : ViewModelBase
        {
            _messenger.Send(new NavigationMessage()
            {
                ViewModelType = typeof(T)
            });

            if (data != null) 
            {
                _messenger.Send(new DataMessages()
                {
                    Data = data
                });
            }
        }

        public void NavigateDataTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new DataMessages()
            {
                Data = data
            });
        }
    }
}
