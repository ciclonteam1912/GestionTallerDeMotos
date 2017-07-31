namespace GestionTallerDeMotos.Dtos
{
    public class ModeloDto
    {
        public byte Id { get; set; }

        public string Nombre { get; set; }

        public MarcaDto Marca { get; set; }

        public byte MarcaId { get; set; }
    }
}