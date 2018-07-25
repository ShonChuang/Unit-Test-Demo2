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
            var ProductWhere = ProductList.Where(d => d.IsEnable).ToList();
            //Act
            var Result = ProductRepository.GetAllProduct().Where(d => d.IsEnable).ToList();
            //Assert 
            // Assert.AreEqual(ProductWhere, Result);
            CollectionAssert.AreEqual(ProductWhere, Result);
        }
        [TestMethod]
        public void 首頁_商品_讀取單筆資料()
        {
            //Arrange
            var ProductRepository = Substitute.For<IRepository>();
            Fixture fixture = new Fixture();
            var product = fixture.Build<Product>()
                .With(x => x.Price, 150)
                .Create();

            //Product product = new Product() { Id = 1, Name = "商品1", IsEnable = true, Price = 100 };
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
        [TestMethod]
        public void 客製化欄位測試()
        {
            Fixture fixture = new Fixture();
            var newData = fixture.Create<Product>();
            var MyMokedata = fixture.Build<MokeData>()
                .Without(x=>x.ProductList)
                .Do(x => x.ProductList.Add(newData))
                .With(x => x.SelectProduct, newData)
                .Create();

        }
    }

    public class MokeData
    {
        private List<Product> _ProductList = new List<Product>();

        public List<Product> ProductList
        {
            get { return _ProductList; }
            set { _ProductList = value; }
        }

        //public List<Product> ProductList { get; set; }
        public Product SelectProduct { get; set; }
    }
}
