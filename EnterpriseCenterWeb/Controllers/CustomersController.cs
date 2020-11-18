using EnterpriseCenterWeb.Models;
using EnterpriseCenterWeb.Services.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace EnterpriseCenterWeb.Controllers
{
    public class CustomersController : Controller
    {
        protected EnterpriseCenterContext ctx;
        protected ILogService logService;

        public CustomersController(EnterpriseCenterContext enterpriseCenterContext, ILogService inLogService)
        {
            ctx = enterpriseCenterContext;
            logService = inLogService;
        }

        public IActionResult Index()
        {
            var customers = ctx.Customers.Take(10).ToList();
            return View(customers);
        }
        
        public async Task<IActionResult> Details(decimal customerNumber)
        {
            var customer = await ctx.Customers.FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
            return customer == null ? NotFound() : View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert([Bind("CustomerNumber,CustomerName,CustomerLastName, ContactFirstName,Phone, AddressLine1")] Customer customer)
        {
            var customerFound = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customer.CustomerNumber);
            if (customerFound == null)
            {
                await ctx.Customers.AddAsync(customer);
            }
            else
            {
                ctx.Customers.Update(customer);
            }

            ctx.SaveChanges();
            return Ok(customer);
        }

        public async Task<IActionResult> Delete(decimal customerNumber)
        {
            var customer = await ctx.Customers.FirstOrDefaultAsync(x => x.CustomerNumber == customerNumber);
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
