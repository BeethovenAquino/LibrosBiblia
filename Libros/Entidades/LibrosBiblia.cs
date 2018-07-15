using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Libros.Entidades
{
    public class LibrosBiblia
    {
        [Key]
        public int LibroId { get; set; }
        public string Descripcion { get; set; }
        public string Siglas { get; set; }
        public string Tipo { get; set; }


        public LibrosBiblia()
        {
            LibroId = 0;
            Descripcion = string.Empty;
            Siglas = string.Empty;
            Tipo = string.Empty;
        }
    }
}
