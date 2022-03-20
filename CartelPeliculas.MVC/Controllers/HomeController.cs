using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CartelPeliculas.Entidades;
using CartelPeliculas.CapaNegocio;
using CartelPeliculas.MVC.Models;

namespace CartelPeliculas.MVC.Controllers
{
    public class HomeController : Controller
    {
        Negocio capaNegocio = new Negocio();

        ///Al iniciar el sitio web se deben listar las películas más recientes
        public async Task<ActionResult> Index()
        {
            List<PeliculasEnt> lista = await capaNegocio.Async_ListaPeliculas("ultimas");

            var model = new PeliculasModel
            {
                ListaPeliculas = lista.OrderByDescending(s => s.release_date).ToList(),
                TituloCriterio = "Últimas Peliculas"
            };

            return View("~/Views/Peliculas/ListadoPeliculas.cshtml", model);

        }

        public async Task<ActionResult> MejorCalificadas()
        {
            List<PeliculasEnt> lista = await capaNegocio.Async_ListaPeliculas("mejorCalificadas");

            var model = new PeliculasModel
            {
                ListaPeliculas = lista.OrderByDescending(s => s.vote_average).ToList(),
                TituloCriterio = "Peliculas Mejor Calificadas"
            };

            return View("~/Views/Peliculas/ListadoPeliculas.cshtml", model);
        }

        public async Task<ActionResult> MasPopulares()
        {
            List<PeliculasEnt> lista = await capaNegocio.Async_ListaPeliculas("masPopulares");

            var model = new PeliculasModel
            {
                ListaPeliculas = lista.OrderByDescending(s => s.popularity).ToList(),
                TituloCriterio = "Más Populares"
            };

            return View("~/Views/Peliculas/ListadoPeliculas.cshtml", model);
        }

        public async Task<ActionResult> BuscarPelicula(string nombrePelicula)
        {
            List<PeliculasEnt> listaPelicula = await capaNegocio.Async_BuscarPelicula(nombrePelicula);

            var model = new PeliculasModel
            {
                TituloCriterio = "Resultado: " + nombrePelicula,
                ListaPeliculas = listaPelicula
            };

            return View("~/Views/Peliculas/ListadoPeliculas.cshtml", model);
        }

        public async Task<ActionResult> BuscarDetalle(int idPelicula)
        {
            PeliculasEnt pelicula = await capaNegocio.Async_ObtenerDetalle(idPelicula);

            var model = new PeliculasModel
            {
                PeliculaSel = pelicula
            };

            return View("~/Views/Peliculas/DetallePelicula.cshtml", model);
        }
    }
}