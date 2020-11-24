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

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var customers = from x in ctx.Customers
                            select x;

            if (!string.IsNullOrWhiteSpace(searchString) && searchString.Length > 2)
            {
                customers = customers.Where(x => (x.CustomerName + x.ContactFirstName + x.ContactLastName).Contains(searchString));
            }
            else
            {
                customers = customers.Take(10);
            }

            return View(await customers.ToListAsync());
        }
        
        [HttpGet]
        public async Task<IActionResult> Details(decimal customerNumber)
        {
            var customer = await ctx.Customers
                .Include(o => o.Orders)
                    .ThenInclude(od => od.OrderDetails)
                .FirstOrDefaultAsync(c => c.CustomerNumber == customerNumber);
                
            return customer == null ? NotFound() : View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerNumber,CustomerName,CustomerLastName,ContactFirstName,Phone,AddressLine1,City,Country")] Customer customer)
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

        [HttpDelete]
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
