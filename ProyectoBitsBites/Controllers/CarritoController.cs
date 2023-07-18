using ProyectoBitsBites.Models.TableViewModel;
using ProyectoBitsBites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitsBites.Controllers
{
    public class CarritoController : Controller
{
    private static List<Productos> carrito = new List<Productos>();

    public ActionResult AgregarProducto(int id)
    {
        // Lógica para agregar el producto al carrito
        using (var db = new RestauranteBitsBitesEntities1())
        {
            var producto = db.Productos.FirstOrDefault(p => p.id_producto == id);
            if (producto != null)
            {
                carrito.Add(producto);
            }
        }

        return RedirectToAction("ProductHamburguesas", "Product");
    }

        public ActionResult MostrarCarrito()
        {
            int cantidadProductos = carrito.Count;

            ViewBag.CantidadProductosCarrito = cantidadProductos;
            ViewBag.ImagenCarrito = "https://cdn-icons-png.flaticon.com/512/107/107831.png?w=740&t=st=1689597510~exp=1689598110~hmac=0f0d8907415e059249a0c16e998d643e3960eaeef34f98353d93589532b3356f";

            return PartialView("_CarritoIcono");
        }

    }
}