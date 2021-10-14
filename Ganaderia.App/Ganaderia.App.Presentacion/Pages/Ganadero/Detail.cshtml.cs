using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;

namespace Ganaderia.App.Presentacion.Pages
{
    public class DetailModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());

        public Ganadero ganaderoEncontrado { get; set; }
        public void OnGet()
        {
            // Console.WriteLine("Ganadero a buscar: " + ganaderoId);
            Console.WriteLine("TEMDATA ID: " + TempData["ganadero"].ToString());


            ganaderoEncontrado = _repoGanadero.GetGanadero(Int32.Parse(TempData["ganadero"].ToString()));


        }
    }
}
