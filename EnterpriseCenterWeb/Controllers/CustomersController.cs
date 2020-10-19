using EnterpriseCenterWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Controllers
{
    public class CustomersController : Controller
    {
        protected EnterpriseCenterContext ctx;

        public CustomersController(EnterpriseCenterContext enterpriseCenterContext)
        {
            ctx = enterpriseCenterContext;
        }

        public IActionResult Index()
        {
            var customers = ctx.Customers.ToList();
            return View(customers);
        }
        
        public async Task<IActionResult> Details(decimal customerNumber)
        {
            var customer = await ctx.Customers.FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
            return customer == null ? NotFound() : View(customer);
        }

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
