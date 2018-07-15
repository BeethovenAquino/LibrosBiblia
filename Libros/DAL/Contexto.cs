using Libros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Libros.DAL
{
    public class Contexto : DbContext
    {
            public DbSet<LibrosBiblia> Libros { get; set; }
            public Contexto() : base("ConStr") { }
    }
}
