using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Admin.Services.Interfaces
{
    public interface IMyNavigationService
    {
        public void NavigateTo<T>(object? data = null) where T : ViewModelBase;
        public void NavigateDataTo<T>(object data) where T : ViewModelBase;
        public void NavigateChangeTo<T>(object data) where T : ViewModelBase;
    }
}
