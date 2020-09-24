using RecuperatorioProg06_07.AccesoDatos;
using RecuperatorioProg06_07.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecuperatorioProg06_07.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: Default
        public ActionResult Index()//lista
        {
            GestorDB gestor = new GestorDB();

            return View(gestor.ListadoMediciones());
        }

        public ActionResult Alta()//muestra el formulario
        {
            GestorDB gestor = new GestorDB();
            VMAgencia vm = new VMAgencia();

            vm.estacionesModel = gestor.ListadoEstaciones();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Alta(VMAgencia medir)//manda el formulario a la base
        {

            GestorDB gestor = new GestorDB();
            gestor.InsertarMedicion(medir.medicionModel);
            return View("Index", gestor.ListadoMediciones());
        }

        public ActionResult Reportes()
        {
            GestorDB gestor = new GestorDB();

            return View(gestor.PromTempYHums());
        }

        public ActionResult ReporteTemp()
        {
            GestorDB gestor = new GestorDB();

            return View(gestor.TemperatuaMaxima());
        }
    }

}
   