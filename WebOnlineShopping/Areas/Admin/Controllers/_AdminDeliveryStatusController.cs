using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebOnlineShopping.Models;

namespace WebOnlineShopping.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class _AdminDeliveryStatusController : Controller
    {
        private readonly MinimartDBContext _context;

        public _AdminDeliveryStatusController(MinimartDBContext context)
        {
            _context = context;
        }

        // GET: Admin/_AdminDeliveryStatus
        public async Task<IActionResult> Index()
        {
              return _context.DeliveryStatuses != null ? 
                          View(await _context.DeliveryStatuses.ToListAsync()) :
                          Problem("Entity set 'MinimartDBContext.DeliveryStatuses'  is null.");
        }

        // GET: Admin/_AdminDeliveryStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DeliveryStatuses == null)
            {
                return NotFound();
            }

            var deliveryStatus = await _context.DeliveryStatuses
                .FirstOrDefaultAsync(m => m.DeliveryStatusId == id);
            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return View(deliveryStatus);
        }

        // GET: Admin/_AdminDeliveryStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/_AdminDeliveryStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeliveryStatusId,Status,Decription")] DeliveryStatus deliveryStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deliveryStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deliveryStatus);
        }

        // GET: Admin/_AdminDeliveryStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DeliveryStatuses == null)
            {
                return NotFound();
            }

            var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);
            if (deliveryStatus == null)
            {
                return NotFound();
            }
            return View(deliveryStatus);
        }

        // POST: Admin/_AdminDeliveryStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DeliveryStatusId,Status,Decription")] DeliveryStatus deliveryStatus)
        {
            if (id != deliveryStatus.DeliveryStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deliveryStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryStatusExists(deliveryStatus.DeliveryStatusId))
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
            return View(deliveryStatus);
        }

        // GET: Admin/_AdminDeliveryStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DeliveryStatuses == null)
            {
                return NotFound();
            }

            var deliveryStatus = await _context.DeliveryStatuses
                .FirstOrDefaultAsync(m => m.DeliveryStatusId == id);
            if (deliveryStatus == null)
            {
                return NotFound();
            }

            return View(deliveryStatus);
        }

        // POST: Admin/_AdminDeliveryStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DeliveryStatuses == null)
            {
                return Problem("Entity set 'MinimartDBContext.DeliveryStatuses'  is null.");
            }
            var deliveryStatus = await _context.DeliveryStatuses.FindAsync(id);
            if (deliveryStatus != null)
            {
                _context.DeliveryStatuses.Remove(deliveryStatus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryStatusExists(int id)
        {
          return (_context.DeliveryStatuses?.Any(e => e.DeliveryStatusId == id)).GetValueOrDefault();
        }
    }
}
