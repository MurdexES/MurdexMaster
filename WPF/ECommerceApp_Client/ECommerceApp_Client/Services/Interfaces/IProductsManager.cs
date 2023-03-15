using ECommerceApp_Client.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Interfaces
{
    public interface IProductsManager
    {
        public void ProductDelete<T>(T product) where T : ProductModel;

        public void ProductAdd<T>(T product) where T : ProductModel;
    }
}
