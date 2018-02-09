using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPCart.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }
        [Required]
        public double Precio { get; set; }
        [DisplayName("Imagen")]
        public byte[] ImageFile { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Desde")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime FechaAlta { get; set; }
        public int Existencias { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}