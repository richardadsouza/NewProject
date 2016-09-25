using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AisleShelfName
    {
        public string AisleTopID { get; set; }
        public string AisleTopName { get; set; }
        public string AisleID { get; set; }
        public string AisleName { get; set; }
        public string ShelfID { get; set; }
        public string ShelfName { get; set; }
    }

    public class ShoppingCart
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
    }

    public class UserLoginDetails
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AccountFunds { get; set; }
    }

    public class ShoppingCartVariables
    {
        public int ID { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal FoodTax { get; set; }
        public decimal NonFoodTax { get; set; }
        public decimal MinOrderSize { get; set; }
        public int NoOfTimeSlot { get; set; }
        public decimal DeliveryFeeCutOff { get; set; }
        public string CustomerServiceEmail { get; set; }
        public string ContactEmail { get; set; }
        public string InfoEmail { get; set; }
        public string Location { get; set; }
        public string StateShortName { get; set; }
        public string StateLongName { get; set; }
        public string ShortCompanyName { get; set; }
        public string LongCompanyName { get; set; }
        public string URL { get; set; }
        public decimal FirstOrderGift { get; set; }
        public decimal MemberDeliveryFee { get; set; }
    }

    public class Coupon
    {
        public string CouponID { get; set; }
        public string CouponCode { get; set; }
        public int CouponType { get; set; }
        public decimal Amount { get; set; }
    }
}
