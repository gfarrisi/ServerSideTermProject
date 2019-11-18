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
using Utilities;

namespace PaymentGateway.Controllers
{
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
    }
}