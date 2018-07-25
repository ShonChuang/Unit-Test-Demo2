using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplicationTest.Models;

namespace WebApplicationTest.Repository
{
    public interface IRepository
    {
        List<Product> GetAllProduct();
        Product GetProductById(int Id);
    }
}
