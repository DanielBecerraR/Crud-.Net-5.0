using MaratonProgramacion.Data;
using MaratonProgramacion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MaratonProgramacion.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        //HTTP Get Index
        public IActionResult Index()
        {
            IEnumerable<Usuario> ListaUsuarios = _context.Usuario;
            return View(ListaUsuarios);
        }

        //Exportar 
        //public IActionResult GenerarCSV()
        //{
        //    IEnumerable<Usuario> ListaUsuarios = _context.Usuario;
        //    bool resultado = Archivos.GenerarArchivoCSV(ListaUsuarios);
        //    if (resultado)
        //    {
        //        TempData["mensaje"] = "El archivo se descargo de manera exitosa";
        //        return RedirectToAction("Index");
        //    }
        //    TempData["mensaje"] = "Ocurrio un erro al momento de descargar el archivo";
        //    return RedirectToAction("Index");
        //}

        //HTTP Get Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST CREATE
        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();
                TempData["mensaje"] = "El usuario fue registrado de manera exitosa";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var usuario = _context.Usuario.Find(Id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        //HTTP POST Edit
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuario.Update(usuario);
                _context.SaveChanges();
                TempData["mensaje"] = "El usuario fue actualizado de manera exitosa";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var usuario = _context.Usuario.Find(Id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        [HttpPost]
        public IActionResult DeleteUsuario(int? id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            _context.Usuario.Remove(usuario);
            _context.SaveChanges();
            TempData["mensaje"] = "El usuario fue actualizado de manera exitosa";
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? Id)
        {
            if (Id == null)
                return NotFound();

            var usuario = _context.Usuario.Find(Id);
            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        public IActionResult VerArchivo()
        {
            try
            {
                TempData["mensaje"] = "El archivo se podra ver de manera correcta";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["mensaje"] = "Ocurrio un error al abrir el archivo";
                return RedirectToAction("Index");
            }
        }
    }

    #region DESCARGA ARCHIVOS    
    //public class Archivos
    //{
    //    public static bool GenerarArchivoCSV(IEnumerable<Usuario> ListaUsuarios)
    //    {
    //        try
    //        {
    //            string ruta = @"Reportes\ReporteUsuarios.csv";
    //            string separador = ",";
    //            string cadena = string.Empty;
    //            StringBuilder salida = new StringBuilder();
    //            IEnumerable<Usuario> listado = ListaUsuarios;
    //            List<String> lista = new List<string>();

    //            foreach (var item in listado)
    //            {
    //                cadena = $"Nombres:{item.Nombre} -" +
    //                    $" Apellidos: {item.Apellido} -" +
    //                    $"Identificacion: {item.Identificacion} -" +
    //                    $"Correo: {item.Correo} -" +
    //                    $"Lenguaje Programacion: {item.LenguajeProgramacion} -" +
    //                    $"Lider: {item.Lider},";                    
    //                    salida.AppendLine(string.Join(separador, cadena));
    //            }
    //            bool result = File.Exists(ruta);
    //            if (result)
    //                File.Delete(ruta);
    //            File.AppendAllText(ruta, salida.ToString());

    //            return true;
    //        }
    //        catch
    //        {
    //            return false;
    //        }

    //    }

    //}
    #endregion
}
