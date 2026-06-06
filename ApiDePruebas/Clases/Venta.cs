using System.Text.Json.Serialization;

namespace ApiDePruebas.Clases
{
    public class Venta
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
    public class VentaDTO
    {
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public int Cantidad { get; set; }
    }
}
