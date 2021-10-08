using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GanaderoController : ControllerBase
    {

        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());

        public List<Ganadero> Ganaderos { get; set; }
        public GanaderoController()
        {            
        }

        [HttpGet]
        public IEnumerable<Ganadero> Get()
        {
            // var rng = new Random();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = rng.Next(-20, 55),
            //     Summary = Summaries[rng.Next(Summaries.Length)]
            // })
            // .ToArray();

            // var ganadero = new Ganadero
            // {
            //     Nombres = "Mario",
            //     Apellidos = "Herrera",
            //     NumeroTelefono = "3148596563",
            //     Direccion = "Kra 4 #45-12",
            //     Correo = "sergio.mintic@ucaldas.edu.co",
            //     Password = "123456",
            //     Latitude = 7455,
            //     Longitud = 5333
            // };

            // Ganaderos = new List<Ganadero>();
            // Ganaderos.Add(ganadero);

            // return Ganaderos;

            var ganaderos = _repoGanadero.GetAllGanaderos();

            return ganaderos;

            // var ganadoEncontrado = _repoGanado.GetGanado(5);

            // return ganadoEncontrado;
        }

        [HttpPost]
        public ActionResult<String> Post(String metodo)
        {
            if (metodo.Equals("Agregar")) {

            } else if (metodo.Equals("Editar")) {

            }

            return Ok("Petición recibida" + metodo);
        }

    }
}
