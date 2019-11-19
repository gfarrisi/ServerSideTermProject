using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGateway.Models
{
    public class VirtualWallet
    {
        public String API_Key { get; set; }
        public String MerchantID { get; set; }
        public String VirtualWalletID { get; set; }

        public VirtualWallet()
        {

        }

        public VirtualWallet(String api_key, String merchantID, String virtualWalletID)
        { 
            this.API_Key = api_key;
            this.MerchantID = merchantID;
            this.VirtualWalletID = virtualWalletID;
        }
    }
}
