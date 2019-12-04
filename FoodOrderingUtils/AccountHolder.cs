using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodOrderingUtils
{
    public class AccountHolder
    {
        public String API_Key { get; set; }
        public String MerchantID { get; set; }
        public String VirtualWalletID { get; set; }
        public String AccountHolder_Name { get; set; }
        public String AccountHolder_AccountType { get; set; }
        public int AccountHolder_AccountNumber { get; set; }
        public float Balance { get; set; }

        public AccountHolder()
        {

        }

        public AccountHolder(String api_key, String merchantID, String virtualWalletID, String accountHolder_Name, String accountHolder_AccountType, int accountHolder_AccountNumber, float balance)
        {
            this.API_Key = api_key;
            this.MerchantID = merchantID;
            this.VirtualWalletID = virtualWalletID;
            this.AccountHolder_Name = accountHolder_Name;
            this.AccountHolder_AccountType = accountHolder_AccountType;
            this.AccountHolder_AccountNumber = accountHolder_AccountNumber;
            this.Balance = balance;
        }
    }
}
