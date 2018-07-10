using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Orders.Domain;
using Orders.Model;

namespace Orders.Controllers
{
    [Produces("application/json")]
    [Route("api/Orders")]
    public class OrdersController : Controller
    {
        private readonly APIOptions _apiOptions;
        public OrdersController(IOptions<APIOptions> apiOptons)
        {
            _apiOptions = apiOptons.Value;
        }


        [HttpGet("{order}")]
        public string Get(string order)
        {
            try
            {
                var orderDomain = new OrderDomain(_apiOptions, order);
                orderDomain.ValidateOrderDomain();
                return orderDomain.ProcessOrder();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            
        }
    }
}