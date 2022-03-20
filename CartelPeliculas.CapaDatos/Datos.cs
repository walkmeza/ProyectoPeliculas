using CartelPeliculas.Entidades;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CartelPeliculas.CapaDatos
{
    public class Datos
    {
        public static HttpClient Client = new HttpClient();

        public async Task<List<PeliculasEnt>> Async_ListaUltimasPeliculas()
        {
            string content = "";
            List<PeliculasEnt> lista = new List<PeliculasEnt>();

            Uri uri = new Uri("https://api.themoviedb.org/3/movie/now_playing?api_key=a142647e543dfecd8fade57f8e543479&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(content);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                lista = JsonConvert.DeserializeObject<List<PeliculasEnt>>(json["results"].ToString(), settings);
            }

            return lista;
        }


        public async Task<List<PeliculasEnt>> Async_ListaMejorCalificadas()
        {
            string content = "";
            List<PeliculasEnt> lista = new List<PeliculasEnt>();

            Uri uri = new Uri("https://api.themoviedb.org/3/movie/top_rated?api_key=a142647e543dfecd8fade57f8e543479&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(content);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                lista = JsonConvert.DeserializeObject<List<PeliculasEnt>>(json["results"].ToString(), settings);
            }

            return lista;
        }


        public async Task<List<PeliculasEnt>> Async_ListaMasPopularesPeliculas()
        {
            string content = "";
            List<PeliculasEnt> lista = new List<PeliculasEnt>();

            Uri uri = new Uri("https://api.themoviedb.org/3/movie/popular?api_key=a142647e543dfecd8fade57f8e543479&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(content);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                lista = JsonConvert.DeserializeObject<List<PeliculasEnt>>(json["results"].ToString(), settings);
            }

            return lista;
        }


        public async Task<List<PeliculasEnt>> Async_BuscarPeliculaXNombre(string nombrePelicula)
        {
            string content = "";
            List<PeliculasEnt> lista = new List<PeliculasEnt>();

            Uri uri = new Uri("https://api.themoviedb.org/3/search/movie?include_adult=true&query=" + nombrePelicula + "&api_key=a142647e543dfecd8fade57f8e543479&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var json = JObject.Parse(content);

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                lista = JsonConvert.DeserializeObject<List<PeliculasEnt>>(json["results"].ToString(), settings);
            }

            return lista;
        }

        public async Task<PeliculasEnt> obtenerPeliculaAsync(int idPelicula)
        {
            string content = "";
            PeliculasEnt peliculaDetalle = new PeliculasEnt();

            Uri uri = new Uri("https://api.themoviedb.org/3/movie/" + idPelicula.ToString() + "?api_key=a142647e543dfecd8fade57f8e543479&language=es-ES&page=1");

            HttpResponseMessage response = await Client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                content = await response.Content.ReadAsStringAsync();

                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                peliculaDetalle = JsonConvert.DeserializeObject<PeliculasEnt>(content, settings);
            }

            return peliculaDetalle;
        }
    }
}
