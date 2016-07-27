using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class VendasDAO
    {
        private ISession session;
        public VendasDAO(ISession session)
        {
            this.session = session;
        }
        
        public void Adiciona(Venda venda)
        {
            this.session.SaveOrUpdate(venda);
        }

        public IList<Venda> Lista()
        {
            string hql = "from Venda";
            IQuery query = this.session.CreateQuery(hql);
            return query.List<Venda>();
        }
    }
}