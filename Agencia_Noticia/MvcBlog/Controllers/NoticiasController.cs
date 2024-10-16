using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using MvcBlogNoticias.Web.Services;
using MvcBlogNoticias.Web.Data.Dto;
using MvcBlogNoticias.Models;
using System.Net.Http.Json;
using System.Diagnostics;



namespace MvcBlogNoticias.Controllers
{
    public class NoticiasController : Controller
    {        
        private readonly MvcBlogNoticiasContext _context;
        
        private readonly INoticiaService _noticiaService;
       
        //public NoticiasController(INoticiaService noticiaService)
        //{
        //    _noticiaService = noticiaService;           
        //}

        public NoticiasController(INoticiaService noticiaService, MvcBlogNoticiasContext context)
        {
            _noticiaService = noticiaService;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var viewModel = _noticiaService.ObterNoticias().Result.ToList();
            return View(viewModel);
        }

            
        // GET: Noticias
        //public async Task<IActionResult> Index(string filmeGenero,string criterioBusca)
        //{
        //    IQueryable<string> consultaGenero = from m in _context.Filme
        //                                        orderby m.Genero
        //                                        select m.Genero;

        //    var filmes = from m in _context.Filme
        //                 select m;

        //    if (!String.IsNullOrEmpty(criterioBusca))
        //    {
        //        filmes = filmes.Where(s => s.Titulo.Contains(criterioBusca));
        //    }

        //    if (!String.IsNullOrEmpty(filmeGenero))
        //    {
        //        filmes = filmes.Where(x => x.Genero == filmeGenero);
        //    }

        //    var filmeGeneroVM = new NoticiaGeneroViewModel();
        //    filmeGeneroVM.generos = new SelectList(await consultaGenero.Distinct().ToListAsync());
        //    filmeGeneroVM.filmes = await filmes.ToListAsync();

        //    return View(filmeGeneroVM);

        //}

        // GET: Noticias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var noticiaViewModel = _noticiaService.ObterNoticiasPorId((int)id).Result;

            if (noticiaViewModel == null)
            {
                return NotFound();
            }

            return View(noticiaViewModel);

            //var filme = await _context.Filme
            //    .SingleOrDefaultAsync(m => m.ID == id);
            //if (filme == null)
            //{
            //    return NotFound();
            //}

            //return View(filme);
        }

        // GET: Noticias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Noticias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Titulo,Lancamento,Genero,Preco,Classificacao")] CriarNoticiaDto informacao_blog)
        {
            var noticia = _noticiaService.CadastrarNoticia(informacao_blog);

            if (noticia != null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(noticia);

            //if (ModelState.IsValid)
            //{
            //    _context.Add(filme);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}
            //return View(filme);
        }

        // GET: Noticias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }
            return View(filme);
        }

        // POST: Noticias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Titulo,Lancamento,Genero,Preco,Classificacao")] Noticia filme)
        {
            if (id != filme.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmeExists(filme.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(filme);
        }

        // GET: Noticias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var filme = await _context.Filme
                .SingleOrDefaultAsync(m => m.ID == id);
            if (filme == null)
            {
                return NotFound();
            }

            return View(filme);
        }

        // POST: Noticias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var filme = await _context.Filme.SingleOrDefaultAsync(m => m.ID == id);
            _context.Filme.Remove(filme);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool FilmeExists(int id)
        {
            return _context.Filme.Any(e => e.ID == id);
        }
    }
}
