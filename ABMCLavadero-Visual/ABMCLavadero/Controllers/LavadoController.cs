using ABMCLavadero.AccesoDatos;
using ABMCLavadero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ABMCLavadero.Controllers
{
    public class LavadoController : Controller
    {
        // GET: Lavado
        public ActionResult Index()
        {
            GestorBD gestor = new GestorBD();
            List<DTOLavado> lista = gestor.ListadoLavados();
            return View(lista);
        }

        public ActionResult Alta()
        {
            GestorBD gestor = new GestorBD();
            VMLavado vm = new VMLavado();

            //List<Tipo> tipos = gestor.ListadoTipos();
            //vm.TiposLavado = tipos;
            
            vm.TiposLavado = gestor.ListadoTipos();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Alta(VMLavado lavado)
        {
            GestorBD gestor = new GestorBD();
            gestor.InsertarLavado(lavado.LavadoModel);
            return View("Index", gestor.ListadoLavados());
        }

        public ActionResult Edicion(int idLavado)
        {
            GestorBD gestor = new GestorBD();
            var lavado = gestor.BuscarLavado(idLavado);
            return View(lavado);
        }

        [HttpPost]
        public ActionResult Edicion(Lavado lavado)
        {
            GestorBD gestor = new GestorBD();
            gestor.EditarLavado(lavado);
            return RedirectToAction("Index");
        }

        public ActionResult Eliminar(int idLavado)
        {
            GestorBD gestor = new GestorBD();
            var lavado = gestor.BuscarLavado(idLavado);
            return View(lavado);
        }

        [HttpPost]
        public ActionResult Eliminar(Lavado lavado)
        {
            GestorBD gestor = new GestorBD();
            gestor.EliminarLavado(lavado);
            return RedirectToAction("Index");
        }

        public ActionResult Reportes()
        {
            GestorBD gestor = new GestorBD();
            List<DTOCantidadPorTipo> lista = gestor.CantidadLavadosPorTipo();
            var ultimo = gestor.UltimoTaxiHabitual();

            VMReportes vm = new VMReportes();
            vm.CantidadPorTipo = lista;
            vm.UltimoLavado = ultimo;

            return View(vm);
        }
    }
}