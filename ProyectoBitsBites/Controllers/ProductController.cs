using ProyectoBitsBites.Models;
using ProyectoBitsBites.Models.TableViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoBitsBites.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult ProductHamburguesas()
        {
            List<ProductoTableViewModel> lst = null;
            using (RestauranteBitsBitesEntities1 db = new RestauranteBitsBitesEntities1())
            {
                lst = (from d in db.Productos
                       where d.id_categoria == 4
                       orderby d.nombre_producto
                       select new ProductoTableViewModel
                       {
                           Nombre = d.nombre_producto,
                           Descripcion = d.descripcion,
                           Precio = d.precio,
                           Categoria = (int)d.id_categoria,
                           Imagen = d.imagen
                       }).ToList();
            }

            return View(lst);
        }
    }


}
