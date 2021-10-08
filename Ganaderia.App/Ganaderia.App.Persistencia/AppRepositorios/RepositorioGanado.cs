using System;
using Ganaderia.App.Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Ganaderia.App.Persistencia
{
    public class RepositorioGanado : IRepositorioGanado
    { 

        private readonly AppContext _appContext;

        public RepositorioGanado(AppContext appContext)
        {
            _appContext = appContext;
        }

        Ganado IRepositorioGanado.AddGanado(Ganado ganado)
        {
            var ganadoAdicionado = _appContext.Ganado.Add(ganado);
            _appContext.SaveChanges();
            return ganadoAdicionado.Entity;
        }

        // IEnumerable<Ganado> IRepositorioGanado.GetAllGanados()
        // {
        //     return _appContext.Ganados;
        // }

        Ganado IRepositorioGanado.UpdateGanado(Ganado ganado)
        {
            var ganadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.Id == ganado.Id);
            if (ganadoEncontrado != null)
            {
                ganadoEncontrado.Raza = ganado.Raza;
                ganadoEncontrado.Alias = ganado.Alias;
                ganadoEncontrado.Cantidad = ganado.Cantidad;
                ganadoEncontrado.Veterinario = ganado.Veterinario;
                ganadoEncontrado.Vacunas = ganado.Vacunas;
                ///////////////
                _appContext.SaveChanges();
            }
            return ganadoEncontrado;
        }

        // Boolean IRepositorioGanado.DeleteGanado(int idGanado) {
        //     var ganadoEncontrado = _appContext.Ganados.FirstOrDefault(g => g.Id == idGanado);
        //     if (ganadoEncontrado != null)
        //     {
        //         _appContext.Ganados.Remove(ganadoEncontrado);
        //         _appContext.SaveChanges();

        //         return true;
        //     } 
        //     return false;
        // }

        Ganado IRepositorioGanado.GetGanado(int idGanado) 
        {
            var ganadoEncontrado = _appContext.Ganado.FirstOrDefault(g => g.Id == idGanado);
            return ganadoEncontrado;
        }
    }
}