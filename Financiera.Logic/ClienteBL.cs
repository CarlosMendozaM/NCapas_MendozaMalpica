using System;
using System.Collections.Generic;
using System.Text;
using Financiera.Dominio;
using Financiera.Data;

namespace Financiera.Logic
{
    public static class ClienteBL
    {
        public static List<Cliente> Listar()
        {
            var clienteData = new ClienteData();
            return clienteData.Listar();
        }
    }
}
