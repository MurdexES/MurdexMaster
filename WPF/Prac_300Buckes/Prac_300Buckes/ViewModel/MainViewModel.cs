using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Prac_300Buckes.ViewModel;
using System.Windows.Input;
using System.Data;
using Prac_300Buckes.Services;
using System.ComponentModel;

namespace Prac_300Buckes.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand UpdateViewCommand { get; set; }

        //public RelayCommand FirstCommand { get; private set; }
        //public RelayCommand SecondCommand { get; private set; }
        //public RelayCommand ThirdCommand { get; private set; }

        public MainViewModel()
        {
            //this.FirstCommand = new RelayCommand(this.FirstCommandFunc);
            //this.SecondCommand = new RelayCommand(this.SecondCommandFunc);
            //this.ThirdCommand = new RelayCommand(this.ThirdCommandFunc);
            UpdateViewCommand = new UpdateViewCommand(this);
        }

        
    }
}
