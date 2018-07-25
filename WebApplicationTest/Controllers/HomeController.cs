using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationTest.Repository;

namespace WebApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;
        public HomeController(IRepository repository)
        {
            _repository = repository;
        }
        public HomeController()
        {
            this._repository = new ProductRepository();
        }
        public ActionResult GetProduct()
        {
           var Product =  this._repository.GetAllProduct();
            return View(Product);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}