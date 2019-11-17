using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentProcessor.Modals
{
    public class Transaction
    {
        public String API_Key { get; set; }
        public String MerchantID { get; set; }
        public String VirtualWalletSenderID { get; set; }
        public String VirtualWalletReceiverID { get; set; }
        public String Transaction_Type { get; set; }
        public float Transaction_Amount { get; set; }
        public DateTime Transaction_DateTime { get; set; }

        public Transaction()
        {
                      
        }

        public Transaction(String api_key, String merchantID, String virtualWalletSenderID, String virtualWalletReceiverID, String transaction_type, float transaction_amount, DateTime transaction_dateTime)
        {
            this.API_Key = api_key;
            this.MerchantID = merchantID;
            this.VirtualWalletSenderID = virtualWalletSenderID;
            this.VirtualWalletReceiverID = virtualWalletReceiverID;
            this.Transaction_Amount = transaction_amount;
            this.Transaction_Type = transaction_type;
            this.Transaction_DateTime = transaction_dateTime;
        }
    }
}
