using CartelPeliculas.CapaDatos;
using CartelPeliculas.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CartelPeliculas.WebAPI.Controllers
{
    public class PeliculasAPIController : ApiController
    {
        private Datos data = new Datos();
        List<PeliculasEnt> CriterioRespuesta = new List<PeliculasEnt>();
        // GET api/values
        public async Task<List<PeliculasEnt>> Get(string criterio, string nombre = "")
        {
            if(criterio == "ultimas")
            {
                CriterioRespuesta = await data.Async_ListaUltimasPeliculas();
            }
            else if(criterio == "mejorCalificadas")
            {
                CriterioRespuesta = await data.Async_ListaMejorCalificadas();
            }
            else if (criterio == "masPopulares")
            {
                CriterioRespuesta = await data.Async_ListaMasPopularesPeliculas();
            }
            else if (criterio == "buscar")
            {
                CriterioRespuesta = await data.Async_BuscarPeliculaXNombre(nombre);
            }

            return CriterioRespuesta;
        }

        public async Task<PeliculasEnt> Get(int idPelicula)
        {
            PeliculasEnt respuestaPelicula = await data.obtenerPeliculaAsync(idPelicula);

            return respuestaPelicula;
        }
    }
}
