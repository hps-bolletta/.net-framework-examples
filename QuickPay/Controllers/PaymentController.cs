using BDMS_Wrapper.HeartlandServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BDMS_Wrapper;
using QuickPay.Models;

namespace QuickPay.Controllers
{
    public class PaymentController : Controller
    {
        public Heartland Heartland { get; }

        public PaymentController()
        {
             Heartland = new Heartland();
        }

        // GET: Payment
        [HttpGet]
        public ActionResult Index()
        {
            var model = new Payment()
            {
                card_number = "5454545454545454",
                Amount = 100m,
                FeeAmount = 0m
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(Payment model)
        {
             var request = new MakeQuickPayPaymentRequest()
            {
                BollettaVersion = Heartland.BollettaVersion,
                Credential = Heartland.GetCredential(21),
                QuickPayCardToCharge = new QuickPayCardToCharge()
                {
                    Amount = 100,
                    ExpectedFeeAmount = 1m,
                    ExpirationMonth = 1,
                    ExpirationYear = 2030,
                    QuickPayToken = model.token_value,
                    CardProcessingMethod = CardProcessingMethod.Credit,
                    CardHolderData = new CardHolderData ()
                    {
                        Zip = "12345"
                    }
                },
                Transaction = new Transaction() { Amount = 100, FeeAmount = 1m, PayorFirstName = "Willma", PayorLastName = "Flintstone", PayorAddress = "123 Main Street" },
                BillTransactions = new[] { new BillTransaction() { BillType = "Tax Payments", ID1 = "2135479121", AmountToApplyToBill = 100 } },
            };
            var result = await Heartland.MakeQuickPayBlindPaymentAsync(request);

            return View(model);
        }
    }
}