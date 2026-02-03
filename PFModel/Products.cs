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

        public double Rating { get; set; }

        public string ImageURL { get; set; }

        public Products()
        {
            Category = new Category();
            Rating = 5;
            ImageURL = "https://imgs.search.brave.com/bfcCOe2vAQ-nEjeLkViNIJGfh26jw75I2BPwC4y7x50/rs:fit:500:0:1:0/g:ce/aHR0cHM6Ly9wbGVh/dGVkLWplYW5zLmNv/bS93cC1jb250ZW50/L3VwbG9hZHMvMjAy/NC8xMC9mdW5ueS1j/YXQtbWVtZXMtMTAt/NC0yNC0yOC5qcGc";
        }


    }
}
