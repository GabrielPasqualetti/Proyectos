using FinalProgIII.AccesoDatos;
using FinalProgIII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProgIII.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            GestorDB gestor = new GestorDB();

            return View(gestor.ListadoExamen());
        }

        public ActionResult Alta()
        {
            GestorDB gestor = new GestorDB();
            VMExamenes vm = new VMExamenes();

            vm.materiaModel = gestor.ListaMaterias();

            return View(vm);
        }

        [HttpPost]
        public ActionResult Alta(VMExamenes examen)
        {
            GestorDB gestor = new GestorDB();
            gestor.InsertarExamen(examen.examenModel);
            return View("Index", gestor.ListadoExamen());
        }

        public ActionResult Reportes()
        {
            GestorDB gestor = new GestorDB();

            return View(gestor.reportePromedioNotas());
        }


    }
}
