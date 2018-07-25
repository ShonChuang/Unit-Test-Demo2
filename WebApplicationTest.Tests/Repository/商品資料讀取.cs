using System;
using System.Collections.Generic;
using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApplicationTest.Models;
using WebApplicationTest.Repository;
using System.Linq;

namespace WebApplicationTest.Tests.Repository
{
    [TestClass]
    public class 商品資料讀取
    {
        [TestMethod]
        public void 首頁_商品_讀取全部資料()
        {
            //Arrange
            var ProductRepository = Substitute.For<IRepository>();
            Fixture fixture = new Fixture();
            var ProductList = fixture.CreateMany<Product>(10)
                .ToList();
            //List<Product> ProductList = new List<Product>()
            //{
            //     new Product{ Id=1, Name="商品1", IsEnable=true, Price=100 },
            //     new Product{ Id=1, Name="商品2", IsEnable=true, Price=100 },
            //     new Product{ Id=1, Name="商品3", IsEnable=true, Price=100 }
            //};
            ProductRepository.GetAllProduct().Returns(ProductList);
            //Act
            var Result = ProductRepository.GetAllProduct();
            //Assert
            Assert.AreEqual(ProductList, Result);
        }
        [TestMethod]
        public void 首頁_商品_讀取單筆資料()
        {
            //Arrange
            var ProductRepository = Substitute.For<IRepository>();
            Product product = new Product() { Id = 1, Name = "商品1", IsEnable = true, Price = 100 };
            ProductRepository.GetProductById(Arg.Any<int>()).Returns(product);
            //Act
            var Result = ProductRepository.GetProductById(1);
            //Assert
            ProductRepository.Received().GetProductById(Arg.Any<int>());
            ProductRepository.Received(1).GetProductById(Arg.Any<int>());
            ProductRepository.ReceivedWithAnyArgs().GetProductById(Arg.Is<int>(0));
            Assert.IsNotNull(Result);
            Assert.AreEqual(product, Result);
        }
    }
}
