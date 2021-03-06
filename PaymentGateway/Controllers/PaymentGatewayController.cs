using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Modals;
using PaymentGateway.Models;
using Utilities;

namespace PaymentGateway.Controllers
{
    //[Produces("application/json")]
    [Route("api/service/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        DBConnect objDB = new DBConnect(true);
        SqlCommand objCommand = new SqlCommand();

        // GET: api/service/paymentgateway
        [HttpGet]
        public string Get()
        {
            return "Got to Test Response!";
        }

        // GET: api/paymentgateway/GetTransactions
        [HttpGet("GetTransactions/{APIKey}/{MerchantID}/{VirtualWalletID}/")]
        public List<Transaction> GetTransactions(string APIKey, string MerchantID, string VirtualWalletID)
        {
            //verify there is an account based on parameters
            //take that vwid and return ds of transactions           

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_GetTransactions";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", APIKey);
            objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", VirtualWalletID);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            List<Transaction> transactions = new List<Transaction>();

            Transaction transaction;

            foreach (DataRow record in myDS.Tables[0].Rows)
            {
                transaction = new Transaction();
                transaction.API_Key = record["API_Key"].ToString();
                transaction.MerchantID = record["MerchantID"].ToString();
                transaction.VirtualWalletSenderID = record["VirtualWalletSenderID"].ToString();
                transaction.VirtualWalletReceiverID = record["VirtualWalletReceiverID"].ToString();
                transaction.Transaction_Type = record["Transaction_Type"].ToString();
                transaction.Transaction_Amount = float.Parse(record["Transaction_Amount"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                transaction.Transaction_DateTime = Convert.ToDateTime(record["Transaction_DateTime"].ToString());

                transactions.Add(transaction);
            }

            return transactions;
        }

        // GET: api/paymentgateway/GetBalance/4LOX60BD4P7F/Locals123/HoneyGrow
        [HttpGet("GetBalance/{APIKey}/{MerchantID}/{VirtualWalletID}/")]
        public decimal GetBalance(string APIKey, string MerchantID, string VirtualWalletID)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_GetVirtualWalletBalance";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", APIKey);
            objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", VirtualWalletID);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            decimal balance = Convert.ToDecimal(myDT.Rows[0]["Balance"].ToString());
            return balance;
        }

        // POST: api/PaymentGateway/ProcessPayment
        [HttpPost]
        [Route("ProcessPayment")]      
        public String ProcessPayment([FromBody] Transaction transaction)
        {

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_GetVirtualWalletBalance";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", transaction.API_Key);
            objCommand.Parameters.AddWithValue("@MerchantID", transaction.MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", transaction.VirtualWalletSenderID);
            DataSet myDS = objDB.GetDataSetUsingCmdObj(objCommand);
            DataTable myDT = myDS.Tables[0];
            if(myDS.Tables[0].Rows.Count > 0)
            {
                string balancestring = myDS.Tables[0].Rows[0]["Balance"].ToString();
                float balance = Convert.ToSingle(balancestring);
                if (balance < transaction.Transaction_Amount)
                {
                    return "Insufficiant Funds";
                }
                else
                {
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.CommandText = "PP_ProcessPayment";
                    objCommand.Parameters.Clear();

                    objCommand.Parameters.AddWithValue("@API_Key", transaction.API_Key);
                    objCommand.Parameters.AddWithValue("@MerchantID", transaction.MerchantID);
                    objCommand.Parameters.AddWithValue("@VirtualWalletIDSender", transaction.VirtualWalletSenderID);
                    objCommand.Parameters.AddWithValue("@VirtualWalletIDReceiver", transaction.VirtualWalletReceiverID);
                    objCommand.Parameters.AddWithValue("@Transaction_Type", transaction.Transaction_Type);
                    objCommand.Parameters.AddWithValue("@Transaction_Amount", transaction.Transaction_Amount);

                    DateTime dt = DateTime.Now;

                    objCommand.Parameters.AddWithValue("@Transaction_DateTime", dt); ;

                    int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

                    if (returnValue > 0)
                    {
                        return "true";
                    }
                    else
                    {
                        return "false";
                    }

                }
            }
           
            return "false";
        }


        // PUT: api/PaymentGateway/CreateVirtualWallet
        [HttpPut("CreateVirtualWallet")]
        public Boolean CreateVirtualWallet( [FromBody] AccountHolder AccountHolderInformation)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_RegisterVirtualWallet";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", AccountHolderInformation.API_Key);
            objCommand.Parameters.AddWithValue("@MerchantID", AccountHolderInformation.MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", AccountHolderInformation.VirtualWalletID);
            objCommand.Parameters.AddWithValue("@AccountHolder_Name", AccountHolderInformation.AccountHolder_Name);
            objCommand.Parameters.AddWithValue("@AccountHolder_AccountType", AccountHolderInformation.AccountHolder_AccountType);
            objCommand.Parameters.AddWithValue("@AccountHolder_AccountNumber", AccountHolderInformation.AccountHolder_AccountNumber);
            objCommand.Parameters.AddWithValue("@Balance", AccountHolderInformation.Balance);
         
            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

            if (returnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
           
        }

        //PUT: api/PaymentGateway/UpdatePaymentAccount
       [HttpPut("UpdatePaymentAccount")]
        public Boolean UpdatePaymentAccount([FromBody] AccountHolder AccountHolderInformation)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_UpdatePaymentAccount";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", AccountHolderInformation.API_Key);
            objCommand.Parameters.AddWithValue("@MerchantID", AccountHolderInformation.MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", AccountHolderInformation.VirtualWalletID);
            objCommand.Parameters.AddWithValue("@AccountHolder_Name", AccountHolderInformation.AccountHolder_Name);
            objCommand.Parameters.AddWithValue("@AccountHolder_AccountType", AccountHolderInformation.AccountHolder_AccountType);
            objCommand.Parameters.AddWithValue("@AccountHolder_AccountNumber", AccountHolderInformation.AccountHolder_AccountNumber);
            objCommand.Parameters.AddWithValue("@Balance", AccountHolderInformation.Balance);

            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

            if (returnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // it will take in transaction object where instead of heaving a different sender and reciever it is the same
        // it will add the the fund as a transaction and update the balance of the user

        // PUT: api/PaymentGateway/FundAccount
        [HttpPut("FundAccount")]
        public Boolean FundAccount([FromBody] Transaction transaction)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_FundAccount";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", transaction.API_Key);
            objCommand.Parameters.AddWithValue("@MerchantID", transaction.MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletID", transaction.VirtualWalletSenderID);
            objCommand.Parameters.AddWithValue("@Transaction_Type", transaction.Transaction_Type);
            objCommand.Parameters.AddWithValue("@Transaction_Amount", transaction.Transaction_Amount);

            DateTime dt = DateTime.Now;

            objCommand.Parameters.AddWithValue("@Transaction_DateTime", dt); ;

            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

            if (returnValue > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }


    }
}