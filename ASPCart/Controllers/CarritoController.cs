using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPCart.Models;

namespace ASPCart.Controllers
{
    public class CarritoController : Controller
    {
        private OnlineStoreContext db = new OnlineStoreContext();

       // GET: Carrito/Details/5
        public ActionResult Details()
        {
           
            Carrito carrito = (Carrito)Session["carrito"];
            if (carrito == null)
            {
                carrito = new Carrito
                {
                    Productos = new List<ItemCarrito>()
                };
            }
            //carrito.Productos = db.I
            return View(carrito);
        }

        // GET: Carrito/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Carrito/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Total,CuponId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Carrito.Add(carrito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carrito);
        }

        // GET: Carrito/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // POST: Carrito/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Total,CuponId")] Carrito carrito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carrito);
        }

        // GET: Carrito/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carrito carrito = db.Carrito.Find(id);
            if (carrito == null)
            {
                return HttpNotFound();
            }
            return View(carrito);
        }

        // POST: Carrito/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carrito carrito = db.Carrito.Find(id);
            db.Carrito.Remove(carrito);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AddToCart(int? productoId)
        {
            Producto producto = db.Productos.Find(productoId);
            if(producto == null || producto.Existencias == 0)
            {
                return this.Json(new {
                    status = "fail",
                    message = "No se encontro el producto"
                });
            }

            //getting cart from session and validating it
            Carrito carrito = (Carrito)Session["carrito"];
            carrito = carrito ?? new Carrito {
                Productos = new List<ItemCarrito>()
            };

            carrito.Productos.Add(new ItemCarrito {
                ProductoId = producto.Id,
                Cantidad = 1,
                Total = producto.Precio,
                Producto = producto
            });

            carrito.Total += producto.Precio;

            //updating carrito in Session
            Session["carrito"] = carrito;

            return this.Json(new
            {
                status = "success",
                response = new { cantidad = carrito.Productos.Count , total = carrito.Total }
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
