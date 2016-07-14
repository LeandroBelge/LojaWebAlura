using LojaWeb.Entidades;
using LojaWeb.Models;
using NHibernate;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class CategoriasDAO
    {
        private ISession session;

        public CategoriasDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Categoria categoria)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Save(categoria);
            transacao.Commit();
        }

        public void Remove(Categoria categoria)
        {

        }

        public void Atualiza(Categoria categoria)
        {
            ITransaction transacao = session.BeginTransaction();
            session.Merge(categoria);
            transacao.Commit();
        }

        public Categoria BuscaPorId(int id)
        {
            return session.Get<Categoria>(id);
        }

        public IList<Categoria> Lista()
        {
            string hql = "from Categoria c join fetch c.Produtos";
            IQuery query = session.CreateSQLQuery(hql);
            return query.List<Categoria>();
        }

        public IList<Categoria> BuscaPorNome(string nome)
        {
            string hql = "from Categoria c where c.Nome = :nome";
            IQuery query = session.CreateQuery(hql);
            query.SetParameter("nome", nome);
            return query.List<Categoria>();
        }

        public IList<ProdutosPorCategoria> ListaNumeroDeProdutosPorCategoria()
        {
            string hql = "select p.Categoria as Categoria, count(p) as NumeroDeProdutos " +
                         "from Produto p group by p.Categoria";
            IQuery query = session.CreateSQLQuery(hql);
            query.SetResultTransformer(Transformers.AliasToBean<ProdutosPorCategoria>());
            return query.List<ProdutosPorCategoria>();
        }
    }

}