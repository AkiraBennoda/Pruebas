using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Formatting;


namespace API.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

            var request = clienteHttp.GetAsync("api/Alumnos").Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var listado = JsonConvert.DeserializeObject<List<Models.Alumnos>>(resultString);

                return View(listado);
            }

            return View(new List<Models.Alumnos>());
        }

        /*Metodo para insertar*/
        [HttpGet]
        public ActionResult NuevoAlumno() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult NuevoAlumno(Models.Alumnos alumno)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

            var request = clienteHttp.PostAsync("api/Alumnos", alumno, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var infoCorrecta = JsonConvert.DeserializeObject<Models.Alumnos>(resultString);

                
                    return RedirectToAction("Index");
            

                //return View(alumno);
            }

            return View(alumno);
        }

        /*Metodo de actualizado*/
        [HttpGet]
        public ActionResult ActualizarAlumno(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

            var request = clienteHttp.GetAsync("api/Alumnos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var infoAct = JsonConvert.DeserializeObject<Models.Alumnos>(resultString);

               
                return View(infoAct);
            }

            return View();
      
        }

        [HttpPost]
        public ActionResult ActualizarAlumno(Models.Alumnos alumno)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

        

            var request = clienteHttp.PutAsync("api/Alumnos?id=" + alumno.ID, alumno, new JsonMediaTypeFormatter()).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var infoCorrecta = JsonConvert.DeserializeObject<Models.Alumnos>(resultString);



                return RedirectToAction("Index");
            }

            return View(alumno);
        }


        /*Metodo para eliminar*/
        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

            var request = clienteHttp.DeleteAsync("api/Alumnos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var infoDel = JsonConvert.DeserializeObject<Models.Alumnos>(resultString);

               
                return RedirectToAction("Index");

            }

            return View();
        }

        /*MEtodo de detalle : Selecciona un alumno en especifico*/
        [HttpGet]
        public ActionResult DetalleAlumno(int id)
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("https://localhost:44312/");

            var request = clienteHttp.GetAsync("api/Alumnos?id=" + id).Result;

            if (request.IsSuccessStatusCode)
            {
                var resultString = request.Content.ReadAsStringAsync().Result;
                var infoSel = JsonConvert.DeserializeObject<Models.Alumnos>(resultString);


                return View(infoSel);
            }

            return View();

        }


    }
}