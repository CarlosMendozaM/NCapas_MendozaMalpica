using System;
using System.Collections.Generic;
using System.Text;
using Financiera.Dominio;
using Financiera.Data;

namespace Financiera.Logic
{
    public static class TipoDocumentoBL
    {
        public static List<TipoDocumento> Listar()
        {
            var tipoDocumentoData = new TipoDocumentoData();
            return tipoDocumentoData.Listar();
        }
    }
}
