namespace Fabrica.Dominio
{
    public class DetallePedido
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
    }
}