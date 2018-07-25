using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApplicationTest;
using WebApplicationTest.Controllers;
using WebApplicationTest.Models;
using WebApplicationTest.Repository;

namespace WebApplicationTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void 商品列表讀取 ()
        {
            var ProductRepository = Substitute.For<IRepository>();
            Fixture fixture = new Fixture();
            var ProductList = fixture.CreateMany<Product>(10)
                .ToList();
          
            ProductRepository.GetAllProduct().Returns(ProductList);
            var ProductWhere = ProductList.Where(d => d.IsEnable).ToList();
            //Act
            HomeController controller = new HomeController(ProductRepository);
            ViewResult Result = controller.GetProduct() as ViewResult;
            var model = Result.Model as IEnumerable<Product>;
            //var Result = ProductRepository.GetAllProduct().Where(d => d.IsEnable).ToList();
            //Assert 
            // Assert.AreEqual(ProductWhere, Result);
            Assert.AreEqual(ProductWhere.Count(), model.Count());
        }
    }
}
