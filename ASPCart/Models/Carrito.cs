using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPCart.Models
{
    public class Carrito
    {
        public ICollection<ItemCarrito> Productos { get; set; }
        public double Total { get; set; }
        public int CuponId { get; set; }
    }
}