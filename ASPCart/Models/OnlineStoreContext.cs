using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ASPCart.Models
{
    public class OnlineStoreContext : DbContext
    {
        public OnlineStoreContext() : base()
        {
            this.Database.CommandTimeout = 180;
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Cupon> Cupones { get; set; }
        public DbSet<Carrito> Carrito { get; set; }
    }
}