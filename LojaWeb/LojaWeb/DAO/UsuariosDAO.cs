using LojaWeb.Entidades;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.DAO
{
    public class UsuariosDAO
    {
        private ISession session;

        public UsuariosDAO(ISession session)
        {
            this.session = session;
        }

        public void Adiciona(Usuario usuario)
        {
            session.Save(usuario);
        }

        public void Remove(Usuario usuario)
        {
            session.Delete(usuario.Id);
        }

        public void Atualiza(Usuario usuario)
        {
            session.SaveOrUpdate(usuario);
        }

        public Usuario BuscaPorId(int id)
        {
            return session.Get<Usuario>(id);
        }

        public IList<Usuario> Lista()
        {
            string hql = "from Usuario";
            IQuery query = session.CreateQuery(hql);
            query.SetCacheable(true);
            return query.List<Usuario>();
        }
    }
}