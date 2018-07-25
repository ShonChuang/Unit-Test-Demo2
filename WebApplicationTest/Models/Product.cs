using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationTest.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Decimal Price { get; set; }
        public bool IsEnable { get; set; }
    }
}