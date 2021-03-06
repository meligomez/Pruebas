﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Dominio
{
    public class Domicilio
    {

        public int Id_Empresa { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public int piso { get; set; }
        public string dpto { get; set; }
        public string localidad { get; set; }
        public string ciudad { get; set; }
        public int cp { get; set; }
        public bool eliminado { get; set; }
        public DateTime? fechaEliminacion { get; set; }
    }
}
