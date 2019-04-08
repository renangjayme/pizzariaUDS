using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Site;
using Site.Controllers;

namespace Site.Tests.Controllers
{
    [TestClass]
    public class PedidoControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            PedidoController controller = new PedidoController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void InserirPedido()
        //{
        //    // Arrange
        //    PedidoController controller = new PedidoController();

        //    // Act
        //    ViewResult result = controller.InserirPedido(new Site.Models.PedidoViewModel()) as ViewResult;

        //    // Assert
        //    Assert.AreEqual("InserirPedido.", result.ViewBag.Message);
        //}

        //[TestMethod]
        //public void FinalizarPedido()
        //{
        //    // Arrange
        //    PedidoController controller = new PedidoController();

        //    // Act
        //    ViewResult result = controller.FinalizarPedido(new Site.Models.PedidoViewModel()) as ViewResult;

        //    // Assert
        //    Assert.AreEqual("FinalizarPedido.", result.ViewBag.Message);
        //}
    }
}
