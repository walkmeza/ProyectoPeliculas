using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CartelPeliculas.Entidades;

namespace CartelPeliculas.MVC.Models
{
    public class PeliculasModel
    {
        public List<PeliculasEnt> ListaPeliculas { get; set; }
        public string TituloCriterio { get; set; }
        public PeliculasEnt PeliculaSel { get; set; }
    }
}