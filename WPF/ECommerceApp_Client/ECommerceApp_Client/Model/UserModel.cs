using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Confirmation { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }
        public int SelectedOperator { get; set; }
    }
}
