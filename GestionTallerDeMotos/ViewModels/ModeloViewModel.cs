using GestionTallerDeMotos.Models.ModelosDeDominio;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionTallerDeMotos.ViewModels
{
    public class ModeloViewModel
    {
        public IEnumerable<Marca> Marcas { get; set; }

        public byte Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Display(Name = "Marca")]
        public byte MarcaId { get; set; }

        public string Titulo {
            get
            {
                return Id != 0 ? "Editar Modelo" : "Nuevo Modelo";
            }
        }

        public ModeloViewModel()
        {

        }

        public ModeloViewModel(Modelo modelo)
        {
            Id = modelo.Id;
            Nombre = modelo.Nombre;
            MarcaId = modelo.MarcaId;
        }
    }
}