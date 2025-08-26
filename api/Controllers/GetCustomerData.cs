using Microsoft.AspNetCore.Mvc;
using SalesforceApi.Services;
using System.Threading.Tasks;

namespace SalesforceApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GetCustomerDataController : ControllerBase
    {
        private readonly SalesforceService _sfService;

        public GetCustomerDataController()
        {
            _sfService = new SalesforceService();
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            string username = "elvisdcosta44-gpnf@force.com";
            string password = "Qwerty1234";
            string securityToken = "zujNoMkKVDKHkn5vShwNSAFv";

            await _sfService.AuthenticateAsync(username, password, securityToken);

            // Example SOQL query to fetch Account Name and Id
            var records = await _sfService.QueryAsync("SELECT Customer, Document Name, Expiry Date FROM Document");
            return Ok(records);
        }
    }
}
