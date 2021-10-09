using CalidadT2.Controllers;
using CalidadT2.Models;
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
    class LibroControllerTest
    {
        [Test]
        public void VistaDetallesDeLibro()
        {
            var LibroMock = new Mock<ILibroRepository>();
            var cookieMock = new Mock<ICookieAuthService>();

            var controller = new LibroController(LibroMock.Object, cookieMock.Object);
            var view = controller.Details(It.IsAny<int>());
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void AddComentarioDeLibro()
        {
            var LibroMock = new Mock<ILibroRepository>();
            var cookieMock = new Mock<ICookieAuthService>();

            var controller = new LibroController(LibroMock.Object, cookieMock.Object);
            var view = controller.AddComentario(new Comentario());
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
