using CalidadT2.Controllers;
using CalidadT2.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestCalidadT2
{
    class HomeControllerTest
    {
        [Test]
        public void RetornaLibrosConAutor()
        {
            var mockHome = new Mock<ILibroRepository>();
            var controller = new HomeController(mockHome.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }
    }
}
