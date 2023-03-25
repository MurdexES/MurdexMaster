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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Admin.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyCollectionChanged
    {
        private readonly IMyNavigationService _navigationService;
        private readonly IMessenger _messenger;
        private ViewModelBase _currentViewModel;

        private ObservableCollection<ProductModel> _products = new();
        public ObservableCollection<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
            }
        }

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
            ProductModel product = message.Data as ProductModel;
            Products.Add(product);
            
            OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Products));
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

        public void ReceiveDeleteMessage(DeleteMessage message)
        {
            var data = message.DeleteData as string[];
            int count = 0;

            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Title == data[1])
                {
                    if (Products[i].Brand == data[0])
                    {
                        Products.RemoveAt(i);

                        OnCollectionChange(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, Products));
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                MessageBox.Show("There no Product with this title and brand!!");
            }
            else if (count >= 1)
            {
                _navigationService.NavigateTo<AddViewModel>();
            }
        }

        public MainViewModel(IMessenger messenger, IMyNavigationService navigationService)
        {
            CurrentViewModel = App.Container.GetInstance<AddViewModel>();

            _messenger = messenger;

            _messenger.Register<NavigationMessage>(this, ReceiveNavigationMessage);
            _messenger.Register<DataMessage>(this, ReceiveDataMessage);
            _messenger.Register<ChangeMessage>(this, ReceiveChangeMessage);
            _messenger.Register<DeleteMessage>(this, ReceiveDeleteMessage);

            _navigationService = navigationService;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChange(NotifyCollectionChangedEventArgs e)
        {
            if ( CollectionChanged != null ) 
            { 
                CollectionChanged(this, e);
            }
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
