﻿using ECommerceApp_Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Admin.Services.Messages
{
    public class DeleteMessage
    {
        public object DeleteData { get; set; }
    }
}
