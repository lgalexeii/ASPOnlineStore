using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ASPCart.Models
{
    [DataContract(IsReference = true)]
    public class Carrito
    {
        public int Id { get; set; }
        public ICollection<ItemCarrito> Productos { get; set; }
        public double Total { get; set; }
        public int CuponId { get; set; }
    }
}