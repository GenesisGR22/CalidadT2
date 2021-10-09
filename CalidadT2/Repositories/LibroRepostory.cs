using CalidadT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface ILibroRepository
    {
        public Libro DetallesPorLibro(int id);
        public void AddComentario(Comentario comentario, Usuario user);
        public Libro FindLibroById(Comentario comentario);
        public void AddPuntajePorLibro(Libro libro, Comentario comentario);
        public Usuario DevolverUsuarioLogueado(string claim);
        public List<Libro> RetornaLibrosConAutor();
    }
    public class LibroRepository : ILibroRepository
    {
        private readonly AppBibliotecaContext context;
        public LibroRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public Libro DetallesPorLibro(int id)
        {
            return context.Libros
                .Include("Autor")
                .Include("Comentarios.Usuario")
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
        public void AddComentario(Comentario comentario, Usuario user)
        {
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            context.Comentarios.Add(comentario);
            context.SaveChanges();
        }
        public Libro FindLibroById(Comentario comentario)
        {
            return context.Libros.Where(o => o.Id == comentario.LibroId).FirstOrDefault();
        }
        public void AddPuntajePorLibro(Libro libro, Comentario comentario)
        {
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;
        }
        public void GuardarCambios()
        {
            context.SaveChanges();
        }
        public Usuario DevolverUsuarioLogueado(string claim)
        {
            return context.Usuarios.Where(o => o.Username == claim).FirstOrDefault();
        }
        public List<Libro> RetornaLibrosConAutor()
        {
            return context.Libros.Include(o => o.Autor).ToList();
        }
    }
}
