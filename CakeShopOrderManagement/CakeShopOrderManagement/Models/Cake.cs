using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen5.Models
{
    public class Cake
    {
        public string type { get; set; }
        public string flavor { get; set; }

        public double price { get; set; }

        public Cake(string type, string flavor, double price)
        {
            this.type = type;
            this.flavor = flavor;
            this.price = price;
        }

        public double PriceWithIVA() => price * 1.21;
    }
}
