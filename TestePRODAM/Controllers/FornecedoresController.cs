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
    public class FornecedoresController : Controller
    {
        private readonly TesteProdamContext _context;

        public FornecedoresController(TesteProdamContext context)
        {
            _context = context;
        }

        // GET: Fornecedores
        [Route("lista-de-fornecedores")]
        public async Task<IActionResult> Index(string busca)
        {
            var fornecedores = from f in _context.Fornecedores.Include("Empresa")                              
                               select f;

            if (!String.IsNullOrEmpty(busca))
            {
                fornecedores = fornecedores.Where(
                    s => s.Nome.Contains(busca) || 
                    s.Documento.Contains(busca));                
            }          

            return View(await fornecedores.ToListAsync());
            //var testeProdamContext = _context.Fornecedores.Include(f => f.Empresa);
            //return View(await testeProdamContext.ToListAsync());
        }

        // GET: Fornecedores/Details/5
        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // GET: Fornecedores/Create
        [Route("novo-fornecedor")]
        public IActionResult Create()
        {
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome");
            return View();
        }

        // POST: Fornecedores/Create        
        [Route("novo-fornecedor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {            
            if (ModelState.IsValid)
            {                
                _context.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Edit/5
        [Route("editar-fornecedor/{id:guid}")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Nome", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // POST: Fornecedores/Edit/5
        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedorExists(fornecedor.Id))
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
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Documento", fornecedor.EmpresaId);
            return View(fornecedor);
        }

        // GET: Fornecedores/Delete/5
        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedor = await _context.Fornecedores
                .Include(f => f.Empresa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            return View(fornecedor);
        }

        // POST: Fornecedores/Delete/5
        [Route("excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedorExists(Guid id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
