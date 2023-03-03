using GalaSoft.MvvmLight.Command;
using Prac_300Buckes.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Prac_300Buckes.Services
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        bool ICommand.CanExecute(object? parameter)
        {
            return true;
        }

        void ICommand.Execute(object parameter)
        {
            Console.WriteLine("tmp");
            if(parameter.ToString() == "FirstView")
            {
                viewModel.CurrentViewModel = new FirstViewModel();
            }
            else if (parameter.ToString() == "SecondView")
            {
                viewModel.CurrentViewModel = new SecondViewModel();
            }
            else if (parameter.ToString() == "ThirdView")
            {
                viewModel.CurrentViewModel = new ThirdViewModel();
            }
        }
    }
}
