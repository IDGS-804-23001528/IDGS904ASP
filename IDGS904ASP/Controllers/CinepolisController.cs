using IDGS904ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IDGS904ASP.Controllers
{
    public class CinepolisController : Controller
    {
        // GET: Cinepolis/Index
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Cinepolis cine)
        {
            // Definición de constantes
            const double PRECIO_BOLETO = 12.0; // Ajustado a un precio más real, cámbialo si es necesario
            double total = 0;

            // 1. Validación de límite de boletos (Máximo 7 por persona)
            if (cine.CantidadBoletos > (cine.CantidadCompradores * 7))
            {
                ViewBag.Error = "No se pueden comprar más de 7 boletos por persona.";
                return View(cine); // Retornamos el modelo para no borrar lo que el usuario escribió
            }

            // 2. Cálculo inicial
            total = cine.CantidadBoletos * PRECIO_BOLETO;

            // 3. Aplicación de descuentos por cantidad de boletos
            if (cine.CantidadBoletos > 5)
            {
                total -= (total * 0.15); // 15% de descuento
            }
            else if (cine.CantidadBoletos >= 3)
            {
                total -= (total * 0.10); // 10% de descuento
            }

            // 4. Descuento adicional por Tarjeta CINECO (acumulable)
            if (cine.Tarjeta)
            {
                total -= (total * 0.10); // 10% adicional sobre el total actual
            }

            // 5. Envío de resultados a la Vista
            ViewBag.Nombre = cine.Nombre;
            ViewBag.Total = total;

            return View(cine);
        }
    }
}