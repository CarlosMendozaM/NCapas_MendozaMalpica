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

        public static Cliente BuscarPorId(int id)
        {
            var clienteData = new ClienteData();
            return clienteData.BuscarPorId(id);
        }

        public static bool Insertar(Cliente cliente)
        {
            var clienteData = new ClienteData();
            return clienteData.Insertar(cliente);
        }
    }
}
