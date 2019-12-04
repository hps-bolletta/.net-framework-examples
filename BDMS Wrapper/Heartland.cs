using BDMS_Wrapper.HeartlandServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDMS_Wrapper
{
    public class Heartland
    {
        public BillingDataManagementServiceClient BDMSClient { get; }
        public readonly int BollettaVersion = 3095;

        public Heartland()
        {
            this.BDMSClient = new BillingDataManagementServiceClient("BasicHttpBinding_IBillingDataManagementService");
        }

        public async Task<GetConvenienceFeeResponse> GetConvenienceFeeAsync(GetConvenienceFeeRequest request)
        {
            return await this.BDMSClient.GetConvenienceFeeAsync(request);
        }

        public async Task<MakePaymentResponse> MakeQuickPayBlindPaymentAsync(MakeQuickPayPaymentRequest request)
        {
            return await this.BDMSClient.MakeQuickPayBlindPaymentAsync(request);
        }

        public MerchantCredentials GetCredential(int ApplicationID)
        {
            return new MerchantCredentials()
            {
                ApplicationID = ApplicationID,
                MerchantName = "LeeCo",
                UserName = "HeartlandAPI",
                Password = "$Test1234",
            };
        }
    }
}
