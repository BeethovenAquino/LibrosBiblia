using Libros.DAL;
using Libros.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Libros.BLL
{
    public class LibrosBLL
    {
        public static bool Guardar(LibrosBiblia Libro)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Libros.Add(Libro) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Modificar(LibrosBiblia Libros)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(Libros).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();

            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                LibrosBiblia Libro = contexto.Libros.Find(id);

                if (Libro != null)
                {
                    contexto.Entry(Libro).State = EntityState.Deleted;
                }

                if (contexto.SaveChanges() > 0)
                {
                    contexto.Dispose();
                    paso = true;
                }


            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public static LibrosBiblia Buscar(int id)
        {
            Contexto contexto = new Contexto();
            LibrosBiblia Libros = new LibrosBiblia();
            try
            {
                Libros = contexto.Libros.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libros;
        }

        public static List<LibrosBiblia> GetList(Expression<Func<LibrosBiblia, bool>> expression)
        {
            List<LibrosBiblia> Libros = new List<LibrosBiblia>();
            Contexto contexto = new Contexto();
            try
            {
                Libros = contexto.Libros.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libros;
        }
    }
}
