using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Interfaces
{
    public interface IMyNavigationService
    {
        public void NavigateTo<T>() where T : ViewModelBase;
    }
}
