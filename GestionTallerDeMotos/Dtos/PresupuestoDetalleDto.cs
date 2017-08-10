namespace GestionTallerDeMotos.Dtos
{
    public class PresupuestoDetalleDto
    {
        public int Id { get; set; }

        public int PresupuestoId { get; set; }

        public int ProductoId { get; set; }

        public byte Cantidad { get; set; }

        public int Precio { get; set; }

        public int Iva { get; set; }

        public int SubTotal { get; set; }
    }
}