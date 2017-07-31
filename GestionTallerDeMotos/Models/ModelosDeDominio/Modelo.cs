namespace GestionTallerDeMotos.Models.ModelosDeDominio
{
    public class Modelo
    {
        public byte Id { get; set; }

        public string Nombre { get; set; }

        public Marca Marca { get; set; }

        public byte MarcaId { get; set; }
    }
}