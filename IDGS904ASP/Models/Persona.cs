using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IDGS904ASP.Models
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Edad { get; set; }
        public bool Empleado { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}