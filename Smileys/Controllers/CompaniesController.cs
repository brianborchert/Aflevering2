using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Smileys.Data;
using Smileys.Models;

namespace Smileys.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly SmileysContext _context;

        public CompaniesController(SmileysContext context)
        {
            _context = context;
        }

        // GET: Companies
        public async Task<IActionResult> Index()
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'SmileysContext.Company'  is null.");
            }

            List<Company> companies = await _context.Company.ToListAsync();
            List<string> urls = new List<string>().ToList();
            urls.Add("/images/smiley1.png");
            urls.Add("/images/smiley2.png");
            urls.Add("/images/smiley3.png");
            urls.Add("/images/smiley4.png");

            var companySmileyViewModel = new CompanySmileyViewModel
            {
                Companies = companies,
                Urls = urls
            };

            return View(companySmileyViewModel);
        }

        // VERSION 2
        //// GET: Companies
        //public async Task<IActionResult> Index()
        //{
        //    if (_context.Company == null)
        //    {
        //        return Problem("Entity set 'SmileysContext.Company'  is null.");
        //    }
        //    List<Company> companies = await _context.Company.ToListAsync();
        //    return View(companies);
        //}

        // VERSION 1
        //// GET: Companies
        //public async Task<IActionResult> Index()
        //{
        //    return _context.Company != null ?
        //                View(await _context.Company.ToListAsync()) :
        //                Problem("Entity set 'SmileysContext.Company'  is null.");
        //}

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CVR,Street,HouseNumber,ZipCode,City,Smileys")] Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Add(company);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company.FindAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CVR,Street,HouseNumber,ZipCode,City,Smileys")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(company);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Company == null)
            {
                return NotFound();
            }

            var company = await _context.Company
                .FirstOrDefaultAsync(m => m.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Company == null)
            {
                return Problem("Entity set 'SmileysContext.Company'  is null.");
            }
            var company = await _context.Company.FindAsync(id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(int id)
        {
          return (_context.Company?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
