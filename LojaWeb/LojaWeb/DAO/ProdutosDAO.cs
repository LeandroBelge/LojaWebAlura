using LojaWeb.Entidades;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class ProdutosDAO
    {
        private ISession session;

        public ProdutosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Produto produto)
        {
            session.Save(produto);
        }

        public void Remove(Produto produto)
        {
            session.Delete(produto);
        }

        public void Atualiza(Produto produto)
        {
            session.Merge(produto);
        }

        public Produto BuscaPorId(int id)
        {
            return session.Get<Produto>(id);
        }

        public IList<Produto> Lista()
        {
            string hql = "from Produto";
            IQuery query = session.CreateQuery(hql);
            query.SetCacheable(true);
            IList<Produto> produtos = query.List<Produto>();
            return produtos;
        }

        public IList<Produto> ProdutosComPrecoMaiorDoQue(double? preco)
        {
            string hql = "from Produto p where p.Preco > :precoMinimo";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("precoMinimo", preco.GetValueOrDefault(0));
            return query.List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoria(string nomeCategoria)
        {
            string hql = "from Produto p where p.Categoria.Nome = :nomeCategoria";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nomeCategoria", nomeCategoria);
            return query.List<Produto>();
        }

        public IList<Produto> ProdutosDaCategoriaComPrecoMaiorDoQue(double? preco, string nomeCategoria)
        {
            string hql = "from Produto p where p.Categoria.Nome = :nomeCategoria and p.Categoria.Preco > :preco";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nomeCategoria", nomeCategoria);
            query.SetParameter("preco", preco.GetValueOrDefault(0.0));
            return query.List<Produto>();
        }

        public IList<Produto> ListaPaginada(int paginaAtual)
        {
            string hbl = "from produtos";
            IQuery query = session.CreateQuery(hbl);
            query.SetFirstResult((paginaAtual + 10) - 10);
            query.SetMaxResults(10);
            return query.List<Produto>();
        }

        public IList<Produto> BuscaPorPrecoCategoriaENome(double? preco, string nomeCategoria, string nome)
        {
            ICriteria criteria = session.CreateCriteria<Produto>();
            if (!String.IsNullOrEmpty(nome))
            {
                criteria.Add(Restrictions.Eq("Nome", nome));
            }
            if (preco > 0.00)
            {
                criteria.Add(Restrictions.Ge("Preco", preco));
            }
            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                ICriteria criteriaCategoria = criteria.CreateCriteria("Categoria");
                criteriaCategoria.Add(Restrictions.Eq("Nome", nomeCategoria));
            }

            return criteria.List<Produto>();
        }
    }
}