﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabrica.Dominio
{
    public class Producto
    {
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public string Imagen { get; set; }
        public float Precio { get; set; }
        public float Costo { get; set; }
        public override string ToString()
        {
            return Nombre;
        }

    }
}
