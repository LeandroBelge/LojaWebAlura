using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace LojaWeb.Infra
{
    public class NHibernateHelper
    {
        private static ISessionFactory factory = RecuperaConfiguracao().BuildSessionFactory();

        public static Configuration RecuperaConfiguracao()
        {    
            Configuration cfg = new Configuration();
            cfg.Configure();
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            return cfg;
        }

        public static ISession AbreSession()
        {
            new SchemaUpdate(RecuperaConfiguracao()).Execute(true, true);
            return factory.OpenSession();
        }
    }
}