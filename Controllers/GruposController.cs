using MaratonProgramacion.Data;
using MaratonProgramacion.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace MaratonProgramacion.Controllers
{
    public class GruposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GruposController(ApplicationDbContext context)
        {
            _context = context;
        }
        //HTTP Get Index
        public IActionResult Index()
        {
            IEnumerable<Grupo> ListaGrupos = _context.Grupo;
            return View(ListaGrupos);
        }

        //HTTP Get Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //HTTP POST CREATE
        [HttpPost]
        public IActionResult Create(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Grupo.Add(grupo);
                _context.SaveChanges();
                EnvioCorreo envio = new EnvioCorreo();
                envio.EnvioCorreoTexto(grupo.CorreoLider, "Este correo fue enviado de manera automatica", "Usted fue registrado en el grupo de maratones de programación y fue asignado cómo lider");
                if (!string.IsNullOrEmpty(grupo.CorreoIntegrante2))
                    envio.EnvioCorreoTexto(grupo.CorreoIntegrante2, "Este correo fue enviado de manera automatica", "Usted fue registrado en el grupo de maratones de programación y fue asignado cómo participante");
                if (!string.IsNullOrEmpty(grupo.CorreoIntegrante3))
                    envio.EnvioCorreoTexto(grupo.CorreoIntegrante3, "Este correo fue enviado de manera automatica", "Usted fue registrado en el grupo de maratones de programación y fue asignado cómo participante");

                TempData["mensaje"] = "El grupo fue registrado de manera exitosa y fueron notificados a los correos registrados";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET Edit
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var grupo = _context.Grupo.Find(Id);
            if (grupo == null)
                return NotFound();

            return View(grupo);
        }

        //HTTP GET Details
        public IActionResult Details(int? Id)
        {
            if (Id == null)
                return NotFound();

            var grupo = _context.Grupo.Find(Id);
            if (grupo == null)
                return NotFound();

            return View(grupo);
        }

        //HTTP POST Edit
        [HttpPost]
        public IActionResult Edit(Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Grupo.Update(grupo);
                _context.SaveChanges();
                TempData["mensaje"] = "El grupo fue actualizado de manera exitosa";
                return RedirectToAction("Index");
            }
            return View();
        }

        //HTTP GET Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var grupo = _context.Grupo.Find(Id);
            if (grupo == null)
                return NotFound();

            return View(grupo);
        }

        [HttpPost]
        public IActionResult DeleteGrupo(int? id)
        {
            var grupo = _context.Grupo.Find(id);

            if (grupo == null)
                return NotFound();

            _context.Grupo.Remove(grupo);
            _context.SaveChanges();
            TempData["mensaje"] = "El grupo fue eliminado de manera exitosa";
            return RedirectToAction("Index");
        }

        //Exportar 
        public IActionResult GenerarCSV()
        {
            IEnumerable<Grupo> ListaGrupos = _context.Grupo;
            bool resultado = Archivos.GenerarArchivoCSV(ListaGrupos);
            if (resultado)
            {
                TempData["mensaje"] = "El archivo se descargo de manera exitosa";
                return RedirectToAction("Index");
            }
            TempData["mensaje"] = "Ocurrio un erro al momento de descargar el archivo";
            return RedirectToAction("Index");
        }
    }

    #region DESCARGA ARCHIVOS    
    public class Archivos
    {
        public static bool GenerarArchivoCSV(IEnumerable<Grupo> ListaGrupos)
        {
            try
            {
                string ruta = @"Reportes\ReporteUsuarios.csv";
                string separador = ",";
                string cadena = string.Empty;
                StringBuilder salida = new StringBuilder();
                IEnumerable<Grupo> listado = ListaGrupos;
                List<String> lista = new List<string>();

                foreach (var item in listado)
                {
                    cadena = $"Nombre Grupo:{item.NombreGrupo} -" +
                        $" Estado: {item.Estado} -" +
                        $"Fecha Creacion: {item.FechaCreacion} -" +
                        $"Nombre Lider: {item.NombreLider} -" +
                        $"Apellido Lider: {item.ApellidoLider} -" +
                        $"Identificacion Lider: {item.IdentificacionLider}-" +
                        $"Correo Lider: {item.CorreoLider}-" +
                        $"Lenguaje De Programacion Lider: {item.LenguajeProgramacionLider}-" +

                            $"Nombre Integrante 2: {item.NombreIntegrante2} -" +
                            $"Apellido Integrante 2: {item.ApellidoIntegrante2} -" +
                            $"Identificacion Integrante 2: {item.IdentificacionIntegrante2}-" +
                            $"Correo Integrante 2: {item.CorreoIntegrante2}-" +
                            $"Lenguaje De Programacion Integrante 2: {item.CorreoIntegrante2}-" +

                            $"Nombre Integrante 3: {item.NombreIntegrante3} -" +
                            $"Apellido Integrante 3: {item.ApellidoIntegrante3} -" +
                            $"Identificacion Integrante 3: {item.IdentificacionIntegrante3}-" +
                            $"Correo Integrante 3: {item.CorreoIntegrante3}-" +
                            $"Lenguaje De Programacion Integrante 3: {item.LenguajeProgramacionIntegrante3},";
                    salida.AppendLine(string.Join(separador, cadena));
                }
                bool result = File.Exists(ruta);
                if (result)
                    File.Delete(ruta);
                File.AppendAllText(ruta, salida.ToString());

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    #endregion

    #region envioCorreo
    public class EnvioCorreo
    {
        public string EnvioCorreoTexto(string to, string asunto, string body)
        {
            string msge = "Error al enviar este correo. Por favor verifique los datos o intente más tarde.";
            string from = "maratonprogramacion@outlook.com";
            string displayName = "Registro Grupos programación";
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(to);

                mail.Subject = asunto;
                mail.Body = body;
                mail.IsBodyHtml = true;


                SmtpClient client = new SmtpClient("smtp.office365.com", 587); 
                client.Credentials = new NetworkCredential(from, "Pruebas123");
                client.EnableSsl = true;


                client.Send(mail);
                msge = "¡Correo enviado exitosamente! Pronto te contactaremos.";

            }
            catch (Exception ex)
            {
                msge = ex.Message + ". Por favor verifica tu conexión a internet y que tus datos sean correctos e intenta nuevamente.";
            }

            return msge;
        }
    }
    #endregion

}
