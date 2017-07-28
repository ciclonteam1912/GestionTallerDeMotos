using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Collections.Generic;

namespace GestionTallerDeMotos.ViewModels
{
    public class ClienteViewModel
    {
        public Cliente Cliente { get; set; }

        public IEnumerable<TipoDocumento> TiposDocumentos { get; set; }

        public IEnumerable<Personeria> Personerias { get; set; }
    }
}