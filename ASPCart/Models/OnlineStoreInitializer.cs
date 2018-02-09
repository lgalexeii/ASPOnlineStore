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
                    Descripcion ="Super cute",
                    Precio = 899.99,
                    ImageFile = getFileBytes("\\Images\\kitten1.jpg"),
                    FechaAlta = DateTime.Now,
                     Existencias = 2,
                     CategoriaId = 1
                },
                new Producto
                {
                    Nombre = "Short Leg",
                    Descripcion ="Awsome and super nice",
                    Precio = 899.99,
                    ImageFile = getFileBytes("\\Images\\kitten2.jpg"),
                    FechaAlta = DateTime.Now,
                     Existencias = 2,
                     CategoriaId = 1
                }
            };

            productos.ForEach(s => context.Productos.Add(s));
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