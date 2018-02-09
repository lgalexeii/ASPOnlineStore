using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPCart.Models
{
    public class Cupon
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public float Descuento { get; set; }
        public bool Valido { get; set; }
    }
}