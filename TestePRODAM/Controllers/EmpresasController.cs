using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestePRODAM.Data;
using TestePRODAM.Models;

namespace TestePRODAM.Controllers
{
    public class EmpresasController : Controller
    {
        private readonly TesteProdamContext _context;

        public EmpresasController(TesteProdamContext context)
        {
            _context = context;
        }

        // GET: Empresas
        [Route("lista-de-empresas")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Empresas.ToListAsync());
        }

        // GET: Empresas/Details/5
        [Route("dados-da-empresa/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // GET: Empresas/Create
        [Route("nova-empresa")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Empresas/Create
        [Route("nova-empresa")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empresa empresa)
        {
            if (ModelState.IsValid)
            {                
                _context.Add(empresa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(empresa);
        }

        // GET: Empresas/Edit/5
        [Route("editar-empresa/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }
            return View(empresa);
        }

        // POST: Empresas/Edit/5     
        [Route("editar-empresa/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Empresa empresa)
        {
            if (id != empresa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaExists(empresa.Id))
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
            return View(empresa);
        }

        // GET: Empresas/Delete/5
        [Route("excluir-empresa/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empresa = await _context.Empresas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (empresa == null)
            {
                return NotFound();
            }

            return View(empresa);
        }

        // POST: Empresas/Delete/5
        [Route("excluir-empresa/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaExists(Guid id)
        {
            return _context.Empresas.Any(e => e.Id == id);
        }
    }
}
