using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using LojaWeb.Models;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class CategoriasController : Controller
    {
        //
        // GET: /Categorias/
        private CategoriasDAO dao;

        public CategoriasController(CategoriasDAO Dao)
        {
            this.dao = Dao;
        }

        public ActionResult Index()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Categoria categoria)
        {
            dao.Adiciona(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
     
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            var categoria = dao.BuscaPorId(id);
            return View(categoria);
        }

        public ActionResult Atualiza(Categoria categoria)
        {
            dao.Atualiza(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult CategoriasEProdutos()
        {
            IList<Categoria> categorias = new List<Categoria>();
            return View(categorias);
        }

        public ActionResult BuscaPorNome(string nome)
        {
            ViewBag.Nome = nome;

            IList<Categoria> categorias = this.dao.BuscaPorNome(nome);
            return View(categorias);
        }

        public ActionResult NumeroDeProdutosPorCategoria()
        {
            IList<ProdutosPorCategoria> produtosPorCategoria = this.dao.ListaNumeroDeProdutosPorCategoria();
            return View(produtosPorCategoria);
        }
    }
}
