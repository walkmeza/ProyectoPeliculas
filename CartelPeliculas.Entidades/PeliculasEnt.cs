﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartelPeliculas.Entidades
{
    public class PeliculasEnt
    {
        public int id { get; set; }
        public string title { get; set; }
        public int vote_count { get; set; }
        public decimal vote_average { get; set; }
        public decimal popularity { get; set; }
        public string poster_path { get; set; }
        public DateTime release_date { get; set; }
        public string overview { get; set; }
        public string original_title { get; set; }
        public string homepage { get; set; }
    }
}
