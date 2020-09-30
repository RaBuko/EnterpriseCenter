using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EnterpriseCenterApp.Model;

namespace EnterpriseCenterApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly EnterpriseCenterContext _context;

        public CustomersController(EnterpriseCenterContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var enterpriseCenterContext = _context.Customers.Include(c => c.SalesrepemployeenumberNavigation);
            return View(await enterpriseCenterContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.SalesrepemployeenumberNavigation)
                .FirstOrDefaultAsync(m => m.Customernumber == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["Salesrepemployeenumber"] = new SelectList(_context.Employees, "Employeenumber", "Email");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customernumber,Customername,Contactlastname,Contactfirstname,Phone,Addressline1,Addressline2,City,State,Postalcode,Country,Salesrepemployeenumber,Creditlimit")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Salesrepemployeenumber"] = new SelectList(_context.Employees, "Employeenumber", "Email", customers.Salesrepemployeenumber);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers.FindAsync(id);
            if (customers == null)
            {
                return NotFound();
            }
            ViewData["Salesrepemployeenumber"] = new SelectList(_context.Employees, "Employeenumber", "Email", customers.Salesrepemployeenumber);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Customernumber,Customername,Contactlastname,Contactfirstname,Phone,Addressline1,Addressline2,City,State,Postalcode,Country,Salesrepemployeenumber,Creditlimit")] Customers customers)
        {
            if (id != customers.Customernumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomersExists(customers.Customernumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Salesrepemployeenumber"] = new SelectList(_context.Employees, "Employeenumber", "Email", customers.Salesrepemployeenumber);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customers = await _context.Customers
                .Include(c => c.SalesrepemployeenumberNavigation)
                .FirstOrDefaultAsync(m => m.Customernumber == id);
            if (customers == null)
            {
                return NotFound();
            }

            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var customers = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomersExists(decimal id)
        {
            return _context.Customers.Any(e => e.Customernumber == id);
        }
    }
}
