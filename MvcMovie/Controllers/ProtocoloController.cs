using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class ProtocoloController : Controller
    {
        private readonly MvcMovieContext _context;

        public ProtocoloController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Protocolo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Protocolo.ToListAsync());
        }

        // GET: Protocolo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // GET: Protocolo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Protocolo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,CodigoPaciente")] Protocolo protocolo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(protocolo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(protocolo);
        }

        // GET: Protocolo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo.FindAsync(id);
            if (protocolo == null)
            {
                return NotFound();
            }
            return View(protocolo);
        }

        // POST: Protocolo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,CodigoPaciente")] Protocolo protocolo)
        {
            if (id != protocolo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(protocolo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProtocoloExists(protocolo.Id))
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
            return View(protocolo);
        }

        // GET: Protocolo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var protocolo = await _context.Protocolo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (protocolo == null)
            {
                return NotFound();
            }

            return View(protocolo);
        }

        // POST: Protocolo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var protocolo = await _context.Protocolo.FindAsync(id);
            _context.Protocolo.Remove(protocolo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolo.Any(e => e.Id == id);
        }
    }
}
