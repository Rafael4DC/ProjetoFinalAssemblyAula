using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFModel.Utils
{
    public class Filters
    {
        public string Name { get; set; }
        public double PriceMax { get; set; }
        public double PriceMin { get; set; }

        public List<string> Categories { get; set; }

        public bool HasStock {  get; set; }
    }
}
