using ECommerceApp_Admin.Model;
using ECommerceApp_Admin.Services.Interfaces;
using ECommerceApp_Admin.Services.Messages;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Admin.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IMyNavigationService _navigationService;
        private readonly IMessenger _messenger;
        private ViewModelBase _currentViewModel;

        public List<ProductModel> Products { get; set; } = new()
        {
            new ProductModel("title", 14.99f, "description", 5, "brand", "productImage", 2),
            new ProductModel("tii", 14.99f, "descdfdfription", 5, "brafdfdnd", "producfdftImage", 2)
        };

    public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                Set(ref  _currentViewModel, value);
            }
        }
        public void ReceiveNavigationMessage(NavigationMessage message)
        {
            CurrentViewModel = App.Container.GetInstance(message.ViewModelType) as ViewModelBase;
        }

        public void ReceiveDataMessage(DataMessage message)
        {
            Products.Add(message.Data as ProductModel);
        }

        public void ReceiveChangeMessage(ChangeMessage message)
        {
            var data = message.ChangeData as ProductModel;
            int count = 0;

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Title == data.Title)
                {
                    Products[i].Category = data.Category;
                    Products[i].CategorySelect = data.CategorySelect;
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("There no Product with this title!!");
            }
        }

        public MainViewModel(IMessenger messenger, IMyNavigationService navigationService)
        {
            CurrentViewModel = App.Container.GetInstance<AddViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveNavigationMessage);
            _messenger.Register<DataMessage>(this, ReceiveDataMessage);
            _messenger.Register<ChangeMessage>(this, ReceiveChangeMessage);

            _navigationService = navigationService;
        }

        public RelayCommand AddCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<AddViewModel>();
            });
        }

        public RelayCommand DeleteCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<DeleteViewModel>();
            });
        }

        public RelayCommand ChangeCommand
        {
            get => new(() =>
            {
                _navigationService.NavigateTo<ChangeViewModel>();
            });
        }
    }
}
