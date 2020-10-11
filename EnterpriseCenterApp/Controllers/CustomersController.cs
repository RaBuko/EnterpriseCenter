using EnterpriseCenterApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        protected EnterpriseCenterContext ctx;

        public CustomersController(EnterpriseCenterContext enterpriseCenterContext)
        {
            ctx = enterpriseCenterContext;
        }

        [HttpGet]
        public ActionResult Index()
        {        
            return Ok(ctx.Customers.ToList());
        }

        [HttpGet("{customerNumber}")]
        public ActionResult Details(decimal customerNumber)
        {
            var customer = ctx.Customers.FirstOrDefault(c => c.CustomerNumber == customerNumber);
            return Ok(customer);
        }

        [HttpPost]
        public ActionResult Upsert([FromBody] Customer customer)
        {
            var customerFound = ctx.Customers.FirstOrDefault(x => x.CustomerNumber == customer.CustomerNumber);
            if (customerFound == null)
            {
                ctx.Customers.Add(customer);
            }
            else
            {
                ctx.Customers.Update(customer);
            }

            ctx.SaveChanges();
            return Ok(customer);
        }

        [HttpDelete]
        [Route("{customerNumber}")]
        public ActionResult Delete(decimal customerNumber)
        {
            var customer = ctx.Customers.FirstOrDefault(x => x.CustomerNumber == customerNumber);
            if (customer == null)
            {
                return NotFound();
            }

            ctx.Customers.Remove(customer);
            ctx.SaveChanges();
            return Ok();
        }
    }
}
