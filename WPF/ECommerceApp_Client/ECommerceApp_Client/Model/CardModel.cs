using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp_Client.Model
{
    public enum CardTypes
    {
       MasterCard,
       Visa,
       AnotherCard
    }
    public class CardModel
    {
        public CardTypes CardType { get; set; }
        public string CardNumber { get; set; }
        public string CardCVV { get; set; }
        public DateTime CardExpireDate { get; set; }
    }
}
