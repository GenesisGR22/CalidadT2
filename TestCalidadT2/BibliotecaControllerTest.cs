using CalidadT2.Controllers;
using CalidadT2.Repositories;
using CalidadT2.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCalidadT2
{
    class BibliotecaControllerTest
    {
        [Test]
        public void MostrarTodosLosLibrosConAutor()
        {
            var MockAuth = new Mock<IBibliotecaRepository>();
            var cookie = new Mock<ICookieAuthService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.Index();

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AniadirLibroHP5ABibliotecaUsuario()
        {
            var MockAuth = new Mock<IBibliotecaRepository>();
            var cookie = new Mock<ICookieAuthService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.Add(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void MarcarComoTerminado()
        {
            var MockAuth = new Mock<IBibliotecaRepository>();

            var cookie = new Mock<ICookieAuthService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.MarcarComoTerminado(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
        [Test]
        public void MarcarComoLeyendo()
        {
            var MockAuth = new Mock<IBibliotecaRepository>();

            var cookie = new Mock<ICookieAuthService>();
            var controller = new BibliotecaController(MockAuth.Object, cookie.Object);

            var view = controller.MarcarComoLeyendo(It.IsAny<int>());

            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
