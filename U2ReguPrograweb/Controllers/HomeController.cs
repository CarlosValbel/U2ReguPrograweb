using Microsoft.AspNetCore.Mvc;
using U2ReguPrograweb.Models;
using U2ReguPrograweb.Models.ViewModels;

namespace U2ReguPrograweb.Controllers
{
    public class HomeController : Controller
    {
        NeatContext context = new NeatContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Menu1(int id)
        {
            var menu = context.Menus.Find(id);
            return View(menu);
        }
        public IActionResult Menu2()
        {
            var menus = context.Menus.OrderBy(x => x.Nombre).Select(x => new MenuViewModel
            {
              Id = x.Id,
              IdClasificacion = x.IdClasificacion,
              NombreClasificacion = x.IdClasificacionNavigation.Nombre,
              Nombre = x.Nombre,
              Precio = x.Precio,
              Descripción = x.Descripción
            });
             return View(menus);
        }
        public IActionResult Menu3(int id) 
        {
            var menu = context.Menus.Find(id);
            if (menu == null)
            {
                return RedirectToAction(nameof(Index));
            }
            MenuViewModel menuvm = new();
            menuvm.Nombre = menu.Nombre;
            menuvm.Id = menu.Id;
            menuvm.Precio = menu.Precio;
            menuvm.Descripción = menu.Descripción;
            menuvm.Menus = context.Menus.ToList();
            return View(menuvm);
        }    
    }
}
