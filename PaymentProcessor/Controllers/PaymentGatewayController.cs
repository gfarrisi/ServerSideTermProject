using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PaymentProcessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentGatewayController : ControllerBase
    {
        // GET: api/PaymentGateway
        [HttpGet]
        public string Get()
        {
            return "Got to Test Response!";
        }

        // GET: api/PaymentGateway/GetTransactions
        [HttpGet("GetTransactions")]
        public string GetTransactions([FromBody] object VirtualWalletID, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        {
            return "Got to Test Response!";
        }

        // POST: api/PaymentGateway/CreateVirtualWallet
        [HttpPost("CreateVirtualWallet")]
        public string CreateVirtualWallet([FromBody] object AccountHolderInformation, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        {
            return "Got to Test Response!";
        }

        // POST: api/PaymentGateway/ProcessPayment
        [HttpPost("ProcessPayment")]
        public string ProcessPayment([FromBody] object VirtualWalletID, [FromBody] object amount, [FromBody] object type, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        {
            return "Got to Test Response!";
        }

        // PUT: api/PaymentGateway/UpdatePaymentAccount
        [HttpPut("UpdatePaymentAccount")]
        public string UpdatePaymentAccount([FromBody] object VirtualWalletID, [FromBody] object AccountHolderInformation, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        {
            return "Got to Test Response!";
        }

        // PUT: api/PaymentGateway/FundAccount
        [HttpPut("FundAccount")]
        public string FundAccount([FromBody] object VirtualWalletID, [FromBody] object amount, [FromBody] object MerchantAccountID, [FromBody] object APIKey)
        {
            return "Got to Test Response!";
        }
    }
}