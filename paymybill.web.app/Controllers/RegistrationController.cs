using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using paymybill.web.app.Models;

namespace paymybill.web.app.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Registration
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.RegisteredBills.Include(r => r.BillCompanies).Include(r => r.BillTypes);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Registration/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredBills = await _context.RegisteredBills
                .Include(r => r.BillCompanies)
                .Include(r => r.BillTypes)
                .FirstOrDefaultAsync(m => m.id == id);
            if (registeredBills == null)
            {
                return NotFound();
            }

            return View(registeredBills);
        }

        // GET: Registration/Create
        public IActionResult Create()
        {
            ViewData["CompanyId"] = new SelectList(_context.Set<BillCompanies>(), "id", "id");
            ViewData["TypeId"] = new SelectList(_context.Set<BillTypes>(), "id", "id");
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,TypeId,CompanyId,Amount,BillNick,ConsumerId,ReferenceNumber,isActive")] RegisteredBills registeredBills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registeredBills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Set<BillCompanies>(), "id", "id", registeredBills.CompanyId);
            ViewData["TypeId"] = new SelectList(_context.Set<BillTypes>(), "id", "id", registeredBills.TypeId);
            return View(registeredBills);
        }

        // GET: Registration/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredBills = await _context.RegisteredBills.FindAsync(id);
            if (registeredBills == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Set<BillCompanies>(), "id", "id", registeredBills.CompanyId);
            ViewData["TypeId"] = new SelectList(_context.Set<BillTypes>(), "id", "id", registeredBills.TypeId);
            return View(registeredBills);
        }

        // POST: Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,TypeId,CompanyId,Amount,BillNick,ConsumerId,ReferenceNumber,isActive")] RegisteredBills registeredBills)
        {
            if (id != registeredBills.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registeredBills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegisteredBillsExists(registeredBills.id))
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
            ViewData["CompanyId"] = new SelectList(_context.Set<BillCompanies>(), "id", "id", registeredBills.CompanyId);
            ViewData["TypeId"] = new SelectList(_context.Set<BillTypes>(), "id", "id", registeredBills.TypeId);
            return View(registeredBills);
        }

        // GET: Registration/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registeredBills = await _context.RegisteredBills
                .Include(r => r.BillCompanies)
                .Include(r => r.BillTypes)
                .FirstOrDefaultAsync(m => m.id == id);
            if (registeredBills == null)
            {
                return NotFound();
            }

            return View(registeredBills);
        }

        // POST: Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registeredBills = await _context.RegisteredBills.FindAsync(id);
            _context.RegisteredBills.Remove(registeredBills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegisteredBillsExists(int id)
        {
            return _context.RegisteredBills.Any(e => e.id == id);
        }
    }
}
