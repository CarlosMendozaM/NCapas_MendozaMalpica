using System;
using System.Collections.Generic;
using System.Text;
using Financiera.Dominio;
using Financiera.Data;

namespace Financiera.Logic
{
    public static class TipoClienteBL
    {
        public static List<TipoCliente> Listar()
        {
            var tipoClienteData = new TipoClienteData();
            return tipoClienteData.Listar();
        }
    }
}
