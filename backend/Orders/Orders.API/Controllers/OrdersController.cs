using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Orders.Domain;
using Orders.Model;
using System;

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