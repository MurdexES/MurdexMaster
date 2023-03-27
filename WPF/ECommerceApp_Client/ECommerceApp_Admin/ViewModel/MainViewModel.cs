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
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ECommerceApp_Admin.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyCollectionChanged
    {
        private readonly IMyNavigationService _navigationService;
        private readonly IMessenger _messenger;

        private string jsonGlobal_male;
        private string jsonGlobal_female;

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

        //Gender Lists
        private ObservableCollection<ProductModel> _productsMale = new();
        public ObservableCollection<ProductModel> ProductsMale
        {
            get { return _productsMale; }
            set
            {
                _productsMale = value;
            }
        }

        private ObservableCollection<ProductModel> _productsFemale = new();
        public ObservableCollection<ProductModel> ProductsFemale
        {
            get { return _productsFemale; }
            set
            {
                _productsFemale = value;
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

            int count = 0;
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].Title == product.Title)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                Products.Add(product);
            }
            else
            {
                MessageBox.Show("Invalid Product Details", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
            _navigationService = navigationService;

            _messenger.Register<NavigationMessage>(this, ReceiveNavigationMessage);
            _messenger.Register<DataMessage>(this, ReceiveDataMessage);
            _messenger.Register<ChangeMessage>(this, ReceiveChangeMessage);
            _messenger.Register<DeleteMessage>(this, ReceiveDeleteMessage);
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        protected void OnCollectionChange(NotifyCollectionChangedEventArgs e)
        {
            if ( CollectionChanged != null ) 
            { 
                CollectionChanged(this, e);
            }
        }

        public void MainOpen()
        {
            using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\male_products.json", FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr = new(fs);

            if (sr.ReadToEnd() != string.Empty)
            {
                fs.Position = 0;
                ProductsMale = JsonSerializer.Deserialize<ObservableCollection<ProductModel>>(sr.ReadToEnd());

                jsonGlobal_male = JsonSerializer.Serialize(ProductsMale);
            }

            using FileStream fs1 = new(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\female_products.json", FileMode.OpenOrCreate, FileAccess.Read);
            using StreamReader sr1 = new(fs1);

            fs1.Position = 0;

            if (sr1.ReadToEnd() != string.Empty)
            {
                fs1.Position = 0;
                ProductsFemale = JsonSerializer.Deserialize<ObservableCollection<ProductModel>>(sr1.ReadToEnd());

                jsonGlobal_female = JsonSerializer.Serialize(ProductsFemale);
            }

            for (int i = 0; i < ProductsMale.Count; i++)
            {
                Products.Add(ProductsMale[i]);
            }

            for (int i = 0; i < ProductsFemale.Count; i++)
            {
                Products.Add(ProductsFemale[i]);
            }
        }

        public void MainClose()
        { 
            for (int i = 0; i < Products.Count; i++)
            {
                if (Products[i].IsMale == true)
                {
                    ProductsMale.Add(Products[i]);
                }
                else if (Products[i].IsMale == false) 
                {
                    ProductsFemale.Add(Products[i]);
                }
            }

            var male_json = JsonSerializer.Serialize(ProductsMale);
            
            if (jsonGlobal_male != male_json)
            {
                using FileStream fs = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\male_products.json", FileMode.OpenOrCreate, FileAccess.Write);
                using StreamWriter sw = new(fs);

                sw.Write(male_json);
            }

            var female_json = JsonSerializer.Serialize(ProductsFemale);

            if (jsonGlobal_female != female_json)
            {
                using FileStream fs2 = new(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString()).ToString()).ToString() + "\\female_products.json", FileMode.OpenOrCreate, FileAccess.Write);
                using StreamWriter sw2 = new(fs2);

                sw2.Write(female_json);
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
