using log4net;
using LojaWeb.DAO;
using LojaWeb.Entidades;
using LojaWeb.Infra;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaWeb.Controllers
{
    public class ProdutosController : Controller
    {
        //
        // GET: /Produtos/
        private ProdutosDAO dao;
        public ProdutosController(ProdutosDAO Dao)
        {
            this.dao = Dao;
        }
        public ActionResult Index()
        {
            return View(this.dao.Lista());
        }

        public ActionResult Form()
        {
            return View();
        }

        public ActionResult Adiciona(Produto produto)
        {
            if (produto.Categoria.Id == 0) { produto.Categoria = null; }
            dao.Adiciona(produto);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Visualiza(int id)
        {
            Produto p = new Produto();
            return View(p);
        }

        public ActionResult Atualiza(Produto produto)
        {
            if (produto.Categoria.Id == 0) { produto.Categoria = null; }
            dao.Atualiza(produto);
            return RedirectToAction("Index");
        }

        public ActionResult ProdutosComPrecoMinimo(double? preco)
        {
            IList<Produto> produtos = this.dao.ProdutosComPrecoMaiorDoQue(preco);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoria(string nomeCategoria)
        {
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = this.dao.ProdutosDaCategoria(nomeCategoria);
            return View(produtos);
        }

        public ActionResult ProdutosDaCategoriaComPrecoMinimo(double? preco, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.NomeCategoria = nomeCategoria;
            IList<Produto> produtos = this.dao.ProdutosDaCategoriaComPrecoMaiorDoQue(preco, nomeCategoria);
            return View(produtos);
        }

        public ActionResult BuscaDinamica(double? preco, string nome, string nomeCategoria)
        {
            ViewBag.Preco = preco;
            ViewBag.Nome = nome;
            ViewBag.NomeCategoria = nomeCategoria;

            IList<Produto> produtos = dao.BuscaPorPrecoCategoriaENome(preco, nome, nomeCategoria);
            return View(produtos);
        }
        public ActionResult ListaPaginada(int? pagina)
        {
            int paginaAtual = pagina.GetValueOrDefault(1);
            ViewBag.Pagina = paginaAtual;
            return View(dao.ListaPaginada(paginaAtual));
        }
    }
}
