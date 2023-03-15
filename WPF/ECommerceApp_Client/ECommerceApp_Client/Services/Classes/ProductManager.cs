using ECommerceApp_Client.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Services.Classes
{
    public class ProductManager : IProductsManager
    {
        void IProductsManager.ProductAdd<T>(T product)
        {
            throw new NotImplementedException();
        }

        void IProductsManager.ProductDelete<T>(T product)
        {
            throw new NotImplementedException();
        }
    }
}
