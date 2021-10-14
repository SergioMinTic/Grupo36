using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;
using System.Security.Cryptography;

namespace Ganaderia.App.Presentacion.Pages
{

    public class RegisterModel : PageModel
    {
        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());
        public IEnumerable<Ganadero> ganaderos { get; private set; }
        public List<Ganadero> Ganaderos { get; set; }

        public Ganadero ganaderoEncontrado { get; set; }

        public String tipoPerfil = "Veterinario";
        public void OnGet()
        {
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

            // var ganadero2 = new Ganadero
            // {
            //     Nombres = "Pedro",
            //     Apellidos = "Rodriguez",
            //     NumeroTelefono = "3148596563",
            //     Direccion = "Kra 4 #45-12",
            //     Correo = "Pedro@ucaldas.edu.co",
            //     Password = "123456",
            //     Latitude = 7455,
            //     Longitud = 5333
            // };

            // var ganadero3 = new Ganadero
            // {
            //     Nombres = "James",
            //     Apellidos = "Sanchez",
            //     NumeroTelefono = "3148596563",
            //     Direccion = "Kra 4 #45-12",
            //     Correo = "James@ucaldas.edu.co",
            //     Password = "123456",
            //     Latitude = 7455,
            //     Longitud = 5333
            // };

            // Ganaderos = new List<Ganadero>();
            // Ganaderos.Add(ganadero);
            // Ganaderos.Add(ganadero2);
            // Ganaderos.Add(ganadero3);

            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public void OnPostAdd(Ganadero ganadero)
        {
            Console.WriteLine("Password: " + ganadero.Password);
            Console.WriteLine("MD5: " + ObtenerMd5(ganadero.Password));

            ganadero.Password = ObtenerMd5(ganadero.Password);
            
            if (ganadero != null)
            {
                _repoGanadero.AddGanadero(ganadero);
            }
            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public void OnPostEditAdd(Ganadero ganadero)
        {
            Console.WriteLine("ID" + ganadero.Id);
            if (ganadero.Id > 0)
            {
                Console.WriteLine("Voy a editar");
                _repoGanadero.UpdateGanadero(ganadero);
            } else 
            {
                Console.WriteLine("Voy a adicionar");
                _repoGanadero.AddGanadero(ganadero);
            }

            tipoPerfil = "Se ha hecho la operación correctamente";

            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public void OnPostDel(int id)
        {
            if (id > 0)
            {
                Console.WriteLine("Ganadero a borrar: " + id);
                _repoGanadero.DeleteGanadero(id);
            }
            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public IActionResult OnPostDetail(int id)
        {
            TempData["ganadero"] = id;
            return Redirect("/Ganadero/Detail");
        }

        public void OnPostSearchGanadero(int id, int password)
        {
            if (id > 0)
            {
                Console.WriteLine("Ganadero a buscar: " + id);
                ganaderoEncontrado = _repoGanadero.GetGanadero(id);

                ganaderoEncontrado.Password = "";
            }

            ganaderos = _repoGanadero.GetAllGanaderos();
        }

        public String ObtenerMd5(String input)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(input);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToLower());
            }
            String hash = s.ToString();
            return hash;
        }


    }
}
