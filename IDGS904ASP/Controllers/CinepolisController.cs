using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IDGS904ASP.Models;

namespace IDGS904ASP.Controllers
{
    public class CinepolisController : Controller
    {
        
        public ActionResult Cinepolis()
        {
            return View(new Cinepolis());
        }

        
        [HttpPost]
        public ActionResult Cinepolis(Cinepolis datos)
        {
            
            const double COSTO_BOLETO = 12.00;
            double subtotal;
            double descuento = 0;
            double totalPagar;

           
            int limiteBoletos = datos.CantidadCompradores * 7;

            if (datos.CantidadBoletos > limiteBoletos)
            {
                ViewBag.Mensaje = $"La cantidad de boletos excede el límite permitido ({limiteBoletos} boletos max).";
                return View(datos); 
            }

           
            subtotal = datos.CantidadBoletos * COSTO_BOLETO;

            
            if (datos.CantidadBoletos >= 3 && datos.CantidadBoletos <= 5)
            {
                descuento = subtotal * 0.10; 
            }
            else if (datos.CantidadBoletos > 5)
            {
                descuento = subtotal * 0.15;
            }

            totalPagar = subtotal - descuento;

          
            if (datos.Tarjeta)
            {
                totalPagar -= (totalPagar * 0.10); 
            }

           
            ViewBag.Cliente = datos.Nombre;
            ViewBag.Resultado = totalPagar;

            return View(datos); 
        }
    }
}