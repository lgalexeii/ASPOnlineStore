using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace ASPCart.Models
{
    public class OnlineStoreInitializer : DropCreateDatabaseAlways<OnlineStoreContext>
    {
        protected override void Seed(OnlineStoreContext context)
        {
            base.Seed(context);

            var categorias = new List<Categoria>
            {
                new Categoria
                {
                    Nombre = "Kittens"
                }
            };

            categorias.ForEach(s => context.Categorias.Add(s));
            context.SaveChanges();

            var productos = new List<Producto>
            {
                new Producto
                {
                    Nombre = "Mini Hunter",
                    Descripcion ="Super cute, ready for haunt all mice at your home",
                    Precio = 34.99,
                    ImageFile = getFileBytes("\\Images\\kitten1.jpg"),
                    FechaAlta = DateTime.Now,
                     Existencias = 2,
                     CategoriaId = 1
                },
                new Producto
                {
                    Nombre = "Short Legged",
                    Descripcion ="Awesome and super nice, his tenderness is inversely propor to his shortness... ",
                    Precio = 33.50,
                    ImageFile = getFileBytes("\\Images\\kitten2.jpg"),
                    FechaAlta = DateTime.Now,
                     Existencias = 3,
                     CategoriaId = 1
                },
                new Producto
                {
                    Nombre = "Big cat",
                    Descripcion ="Enough as your necessities of love",
                    Precio = 99.99,
                    ImageFile = getFileBytes("\\Images\\kitten3.jpg"),
                    FechaAlta = DateTime.Now,
                     Existencias = 1,
                     CategoriaId = 1
                }
            };

            productos.ForEach(s => context.Productos.Add(s));
            context.SaveChanges();

            Cupon cupon = new Cupon
            {
                Codigo = "NN50",
                Descuento = 0.5f,
                Valido = true
            };

            context.Cupones.Add(cupon);
            context.SaveChanges();
        }

        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}