using ECommerceApp_Admin.Model;
using ECommerceApp_Admin.Services.Interfaces;
using ECommerceApp_Admin.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Admin.Services.Classes
{
    public class MyNavigationService : IMyNavigationService
    {
        private readonly IMessenger _messenger;

        public MyNavigationService(IMessenger messenger)
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
                _messenger.Send(new DataMessage()
                {
                    Data = data
                });
            }
        }

        public void NavigateDataTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new DataMessage()
            {
                Data = data
            });
        }

        public void NavigateChangeTo<T>(object data) where T : ViewModelBase
        {
            _messenger.Send(new ChangeMessage()
            {
                ChangeData = data
            });
        }
    }
}
