using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFModel
{
    public class Products
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public string QuantityByUnit { get; set; }

        public double UnitPrice { get; set; }

        public int UnitsInStock { get; set; }

        public Products()
        {
            Category = new Category();
        }


    }
}
