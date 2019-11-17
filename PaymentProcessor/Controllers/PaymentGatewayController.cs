using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using System.Collections;
using PaymentProcessor.Modals;
using System.Globalization;

namespace PaymentProcessor.Controllers
{
    //[Produces("application/json")]
    [Route("api/service/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        DBConnect objDB = new DBConnect();
        SqlCommand objCommand = new SqlCommand();

        // GET: api/service/paymentgateway
        [HttpGet]
        public string Get()
        {
            return "Got to Test Response!";
        }

        // GET: api/paymentgateway/GetTransactions
        [HttpGet("GetTransactions/{APIKey}/{MerhchantID}/{VirtualWalletID}/")]
        public List<Transaction> GetTransactions(string APIKey, string MerhchantID, string VirtualWalletID)
        {
            //verify there is an account based on parameters
            //take that vwid and return ds of transactions
          
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_GetTransactions";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", APIKey);
            objCommand.Parameters.AddWithValue("@MerchantID", MerhchantID);
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

        //// POST: api/PaymentGateway/CreateVirtualWallet
        //[HttpPost("CreateVirtualWallet")]
        //public string CreateVirtualWallet([FromBody] object AccountHolderInformation, string MerchantAccountID, string APIKey)
        //{
        //    return "Got to Test Response!";
        //}

        // POST: api/PaymentGateway/ProcessPayment
        [HttpPost("ProcessPayment")]
        public Boolean ProcessPayment([FromBody] string VirtualWalletIDSender, [FromBody] string VirtualWalletIDReceiver, [FromBody] float amount, [FromBody] string type, [FromBody] string MerchantID, [FromBody] string APIKey)
        {
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PP_ProcessPayment";
            objCommand.Parameters.Clear();

            objCommand.Parameters.AddWithValue("@API_Key", APIKey);
            objCommand.Parameters.AddWithValue("@MerchantID", MerchantID);
            objCommand.Parameters.AddWithValue("@VirtualWalletIDSender", VirtualWalletIDSender);
            objCommand.Parameters.AddWithValue("@VirtualWalletIDReceiver", VirtualWalletIDReceiver);
            objCommand.Parameters.AddWithValue("@Transaction_Type", type);
            objCommand.Parameters.AddWithValue("@Transaction_Amount", amount);

            DateTime dt = DateTime.Now;

            objCommand.Parameters.AddWithValue("@Transaction_DateTime", dt);;

            int returnValue = objDB.DoUpdateUsingCmdObj(objCommand);

            if (returnValue > 0)            
                return true;
            
            
            return false;
            
          
        }

        //// PUT: api/PaymentGateway/UpdatePaymentAccount
        //[HttpPut("UpdatePaymentAccount")]
        //public string UpdatePaymentAccount([FromBody] object VirtualWalletID, [FromBody] object AccountHolderInformation, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        //{
        //    return "Got to Test Response!";
        //}

        //// PUT: api/PaymentGateway/FundAccount
        //[HttpPut("FundAccount")]
        //public string FundAccount([FromBody] object VirtualWalletID, [FromBody] object amount, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        //{
        //    return "Got to Test Response!";
        //}
    }
}