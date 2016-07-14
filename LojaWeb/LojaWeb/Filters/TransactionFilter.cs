using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http.Filters;
using System.Web.Mvc;

namespace LojaWeb.Filters
{
    public class TransactionFilter: ActionFilterAttribute
    {
        private ISession session;
        public TransactionFilter(ISession session)
        {
            this.session = session;
        }
        //public override void OnActionExecuted(ActionExecutingContext context)
        //{
        //    this.transacao.Begin();   
        //}
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            this.session.BeginTransaction();
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            if (filterContext.Exception == null)
            {
                if (this.session.Transaction.IsActive) 
                {
                    this.session.Transaction.Commit();
                }
            }
            else
            {
                if (this.session.Transaction.IsActive)
                {
                    this.session.Transaction.Rollback();
                }
            }
            this.session.Close();
        }
    }
}