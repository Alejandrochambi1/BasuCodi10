using Microsoft.AspNetCore.Mvc;
using Farmacia2.Models;
using Farmacia2.DAO;

namespace Farmacia2.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductoDAO _dao = new ProductoDAO();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(producto.Nombre))
                    ModelState.AddModelError("Nombre", "El nombre es obligatorio");

                if (producto.Precio <= 0)
                    ModelState.AddModelError("Precio", "El precio debe ser mayor a 0");

                if (producto.Stock < 0)
                    ModelState.AddModelError("Stock", "El stock no puede ser negativo");

                if (producto.IdProveedor <= 0)
                    ModelState.AddModelError("IdProveedor", "ID de proveedor inválido");

                if (!ModelState.IsValid)
                    return View(producto);

                bool guardado = _dao.Insertar(producto);

                if (guardado)
                {
                    TempData["Mensaje"] = "✅ Producto registrado correctamente";
                    return RedirectToAction("Create");
                }
                else
                {
                    ViewBag.Error = "No se pudo guardar el producto";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Error: " + ex.Message;
            }

            return View(producto);
        }
    }
}