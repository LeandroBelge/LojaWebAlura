using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entidades
{
    public class PessoaFisica : Usuario
    {
        public virtual string CPF { get; set; }
    }
}