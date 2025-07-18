using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Base
{
    public static class URL
    {
        public static String login => "/login";
        public static String signup => "/signup";
        public static String created => "/account_created";
        public static String deleted => "delete_account";
        public static String payment => "/payment";
        public static String paymentdone => "/payment_done";
        public static String cart => "/view_cart";
        public static String product => "/products";
        public static String contact => "/contact_us";
        public static String checkOut => "/checkout";
    }
}
