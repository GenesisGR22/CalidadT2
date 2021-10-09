using CalidadT2.Constantes;
using CalidadT2.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalidadT2.Repositories
{
    public interface IBibliotecaRepository
    {
        public List<Biblioteca> BibliotecaDeUsuarioPorAutor(Usuario user);
        public void AniadirLibroABiblioteca(int libro, Usuario user);
        public Usuario DevolverUsuarioLogueado(string claim);
        public Biblioteca RetornarBiblioteca(int libroId, Usuario user);
        public void SetTempData(ITempDataDictionary tempData);
        public void GuardarCambiosLeyendo(Biblioteca libro);
        public void GuardarCambiosTerminado(Biblioteca libro);
    }
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly AppBibliotecaContext context;
        private ITempDataDictionary tempData;
        public BibliotecaRepository(AppBibliotecaContext context)
        {
            this.context = context;
        }
        public void SetTempData(ITempDataDictionary tempData)
        {
            this.tempData = tempData;
        }
        public List<Biblioteca> BibliotecaDeUsuarioPorAutor(Usuario user)
        {
            return context.Bibliotecas
                .Include(o => o.Libro.Autor)
                .Include(o => o.Usuario)
                .Where(o => o.UsuarioId == user.Id)
                .ToList();
        }
        public void AniadirLibroABiblioteca(int libro, Usuario user)
        {
            var biblioteca = new Biblioteca
            {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            context.Bibliotecas.Add(biblioteca);
            context.SaveChanges();
            tempData["SuccessMessage"] = "Se añadio el libro a su biblioteca";
        }
        public Usuario DevolverUsuarioLogueado(string claim)
        {
            return context.Usuarios.Where(o => o.Username == claim).FirstOrDefault();
        }
        public Biblioteca RetornarBiblioteca(int libroId, Usuario user)
        {
            return context.Bibliotecas
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();
        }
        public void GuardarCambiosLeyendo(Biblioteca libro)
        {

            libro.Estado = ESTADO.LEYENDO;
            context.SaveChanges();
            tempData["SuccessMessage"] = "Se marco como leyendo el libro";
        }
        public void GuardarCambiosTerminado(Biblioteca libro)
        {
            libro.Estado = ESTADO.TERMINADO;
            context.SaveChanges();
            tempData["SuccessMessage"] = "Se marco como libro terminado";
        }
    }
}
