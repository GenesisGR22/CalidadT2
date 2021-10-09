using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;

namespace TestExamenT2
{
    class AuthControllerTest
    {

        [Test]
        public void probarInicioDeSesionExitoso()
        {
            var MockAuth = new Mock<IUserrepository>();
            MockAuth.Setup(o => o.FindUserByNameAndPassword("admin", It.IsAny<String>()))
                .Returns(new Usuario());

            var cookie = new Mock<ICookieAuthService>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Login("admin", "admin");
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }

        [Test]
        public void probarInicioDeSesionFallido()
        {
            var MockAuth = new Mock<IUserrepository>();
            MockAuth.Setup(o => o.FindUserByNameAndPassword("admin", It.IsAny<String>()));

            var cookie = new Mock<ICookieAuthService>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Login("admin", "admin");
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void LogOutExitoso()
        {
            var MockAuth = new Mock<IUserrepository>();
            var cookie = new Mock<ICookieAuthService>();
            var controller = new AuthController(MockAuth.Object, cookie.Object);

            var view = controller.Logout();
            Assert.IsInstanceOf<RedirectToActionResult>(view);
        }
    }
}
