﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Model
{
    public class UserModel
    {
        public string Username { get; set; } = "Murdex";
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public string Email { get; set; } = "morujov48@gmail.com";
        public string PhoneNumber { get; set; } = "471777";

        public DateTime BirthDate { get; set; } = new DateTime(2006, 10, 9);
        public int SelectedOperator { get; set; } = 0;
    }
}
