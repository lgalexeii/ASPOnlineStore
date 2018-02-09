namespace ASPCart.Models
{
    public class ItemCarrito
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Total { get; set; }
        public Producto Producto { get; set; }
    }
}