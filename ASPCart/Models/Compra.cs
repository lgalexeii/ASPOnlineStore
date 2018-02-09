using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCart.Models
{
    public class Compra:Carrito
    {
        public int Id { get; set; }
        [DisplayName("Fecha de Compra")]
        public DateTime FechaCompra { get; set; }
    }
}