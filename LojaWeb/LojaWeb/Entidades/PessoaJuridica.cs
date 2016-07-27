using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaWeb.Entidades
{
    public class PessoaJuridica : Usuario
    {
        public virtual string CNPJ { get; set; }
    }
}