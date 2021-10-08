using System;
using Ganaderia.App.Dominio;
using Ganaderia.App.Persistencia;
using System.Collections.Generic;

namespace Ganaderia.App.Consola
{
    class Program
    {

        private static IRepositorioGanadero _repoGanadero = new RepositorioGanadero(new Persistencia.AppContext());
        private static IRepositorioVeterinario _repoVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        private static IRepositorioGanado _repoGanado = new RepositorioGanado(new Persistencia.AppContext());

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddGanadero();
            //GetAllGanaderos();
            //UpdateGanadero();
            //DeleteGanadero(1003);
            //GetGanadero(1);
            //AddVeterinario();
            // AddGanado();
            //AddGanadoConVeterinario(1008);
            // AddVeterinarioaGanado(1008,7);
            // GetVeterinariodeGanado(5);
        }

        private static void AddGanadero() 
        {
            var ganadero = new Ganadero
            {
                Nombres = "Cesar",
                Apellidos = "Araujo",
                NumeroTelefono = "3148596563",
                Direccion = "Kra 4 #45-12",
                Correo = "sergio.mintic@ucaldas.edu.co",
                Password = "123456",
                Latitude = 7455,
                Longitud = 5333
            };
            _repoGanadero.AddGanadero(ganadero);
        }

        private static void GetAllGanaderos()
        {
            var ganaderos = _repoGanadero.GetAllGanaderos();
            foreach(Ganadero item in ganaderos)
            {
                Console.WriteLine(item.Nombres);
            }
        }

        private static void UpdateGanadero()
        {
            var ganadero = new Ganadero
            {
                Id = 2,
                Nombres = "Pedro",
                Apellidos = "Sanchez",
                NumeroTelefono = "3148596563",
                Direccion = "Kra 4 #45-12",
                Correo = "sergio.mintic@ucaldas.edu.co",
                Password = "123456",
                Latitude = 7455,
                Longitud = 5333
            };

            _repoGanadero.UpdateGanadero(ganadero);
        }

        private static void DeleteGanadero(int idGanadero)
        {
            //var response = _repoGanadero.DeleteGanadero(idGanadero);
            string message = _repoGanadero.DeleteGanadero(idGanadero) ? "El ganadero se ha eliminado correctamemte" : "El ganadero no ha sido encontrado";
            Console.WriteLine(message);
            // if (response) 
            // {
            //     Console.WriteLine("El ganadero se ha eliminado correctamemte");
            // } else
            // {
            //     Console.WriteLine("El ganadero no ha sido encontrado");
            // }
        }

        private static void GetGanadero(int idGanadero)
        {
            var ganadero = _repoGanadero.GetGanadero(idGanadero);
            Console.WriteLine("El nombre del ganadero es: " + ganadero.Nombres);
        }

        private static void AddVeterinario() 
        {
            var veterinario = new Veterinario
            {
                Nombres = "David",
                Apellidos = "Ospina",
                NumeroTelefono = "3125653211",
                Direccion = "Kra 1 #98-96",
                Correo = "juan@ucaldas.edu.co",
                Password = "987654",
                Especialidad = "Médico general",
                NumeroTarjeta = "2563256"

            };
            _repoVeterinario.AddVeterinario(veterinario);
        }

        public static void AddGanado()
        {

            var veterinarioEncontrado = _repoVeterinario.GetVeterinario(1006);
            Console.WriteLine("El nombre del veteriario es: " + veterinarioEncontrado.Nombres);

            // Veterinario veterinario = new Veterinario
            // {
            //     Nombres = "Falcao",
            //     Apellidos = "Gracía",
            //     NumeroTelefono = "312352322",
            //     Direccion = "Kra23 # 13-34",
            //     Correo = "falcao@veter.com.co",
            //     Password = "25632563",
            //     Especialidad = "Especialista en bovinos",
            //     NumeroTarjeta = "123"
            // };

            // List<Vacuna> vacunas = new List<Vacuna>();

            // Vacuna vacuna =  new Vacuna
            // {
            //     Descripcion = "Para la rabia",
            //     Lote = "L-2563",
            //     Nombre = "Pirisicila",
            //     Fabricante = "MK",
            //     FechaAplicacion = DateTime.Now
            // };

            // Vacuna vacuna2 =  new Vacuna
            // {
            //     Descripcion = "Para las infecciones",
            //     Lote = "L-856",
            //     Nombre = "Cortis",
            //     Fabricante = "MK",
            //     FechaAplicacion = DateTime.Now
            // };

            // Vacuna vacuna3 =  new Vacuna
            // {
            //     Descripcion = "Vacuna para los dolores",
            //     Lote = "L-7844",
            //     Nombre = "Doloren",
            //     Fabricante = "Heinson",
            //     FechaAplicacion = DateTime.Now
            // };

            // vacunas.Add(vacuna);
            // vacunas.Add(vacuna2);
            // vacunas.Add(vacuna3);


            Ganado ganado = new Ganado
            {
                Raza = "Pecuario",
                Alias = "Ganado cerca del rio",
                Cantidad = 10,
                Veterinario = null,
                Vacunas = null
            };

            var ganadoCreado = _repoGanado.AddGanado(ganado);
        }

        public static void AddGanadoConVeterinario(int idVeterinario) 
        {
            Ganado ganado = new Ganado
            {
                Raza = "Porcino",
                Alias = "Ganado cerca del rio",
                Cantidad = 10,
                Veterinario = null,
                Vacunas = null
            };
            var ganadoCreado = _repoGanado.AddGanado(ganado);
            Console.WriteLine("El id del ganado es: " + ganadoCreado.Id);
            AddVeterinarioaGanado(idVeterinario, ganadoCreado.Id);
        }

        public static void AddVeterinarioaGanado(int idVeterinario, int idGanado)
        {
            var veterinarioEncontrado = _repoVeterinario.GetVeterinario(idVeterinario);
            var ganadoEncontrado = _repoGanado.GetGanado(idGanado);
            Console.WriteLine("El nombre del veteriario es: " + veterinarioEncontrado.Nombres);
            Console.WriteLine("La raza del ganado es: " + ganadoEncontrado.Raza);
            ganadoEncontrado.Veterinario = veterinarioEncontrado;
            _repoGanado.UpdateGanado(ganadoEncontrado);
        }

        public static void GetVeterinariodeGanado(int idGanado)
        {
            var ganadoEncontrado = _repoGanado.GetGanado(idGanado);
            Console.WriteLine("La raza del ganado es: " + ganadoEncontrado.Raza);
            Console.WriteLine("La raza del alias es: " + ganadoEncontrado.Alias);
            Console.WriteLine("La raza del cantidad es: " + ganadoEncontrado.Cantidad);
            Console.WriteLine("veterinario: " + ganadoEncontrado.Veterinario);
            if (ganadoEncontrado.Vacunas != null) {
                Console.WriteLine("Veternario asignado");
            } else {
                Console.WriteLine("No se ha asignado un vetrinario");   
            }          

        }
    }
}
