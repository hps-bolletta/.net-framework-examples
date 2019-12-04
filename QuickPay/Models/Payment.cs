using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace QuickPay.Models
{
    public class Payment
    {
        [DisplayName("Card Number")]
        public string card_number { get; set; }

        public string token_value { get; set; }
        public decimal Amount { get; internal set; }
        public decimal FeeAmount { get; internal set; }
    }
}