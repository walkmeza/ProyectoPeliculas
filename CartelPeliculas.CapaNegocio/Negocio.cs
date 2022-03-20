using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CartelPeliculas.Entidades;
using Newtonsoft.Json;

namespace CartelPeliculas.CapaNegocio
{
    public class Negocio
    {
        public static HttpClient Client = new HttpClient();
        private string webAPI = "https://localhost:44387/api/";

        /////OBTENER LAS ÚLTIMAS PELICULAS
        public async Task<List<PeliculasEnt>> Async_ListaPeliculas(string criterioBusqueda)
        {
            string variableCont = "";
			
            Uri recursos = new Uri(webAPI + "peliculasapi?criterio=" + criterioBusqueda);

            HttpResponseMessage response = await Client.GetAsync(recursos);
            if (response.IsSuccessStatusCode)
            {
                variableCont = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<PeliculasEnt>>(variableCont);
        }

        public async Task<List<PeliculasEnt>> Async_BuscarPelicula(string nombrePelicula)
        {
            string variableCont = "";

            Uri uri = new Uri(webAPI + "peliculasapi?criterio=buscar&nombre=" + nombrePelicula);

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                variableCont = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<List<PeliculasEnt>>(variableCont);
        }

        public async Task<PeliculasEnt> Async_ObtenerDetalle(int idPelicula)
        {
            string variableCont = "";

            Uri uri = new Uri(webAPI + "peliculasapi?idPelicula=" + idPelicula);

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                variableCont = await response.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<PeliculasEnt>(variableCont); ;
        }
    }
}

