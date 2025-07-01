using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen5.Models
{
    public class Order
    {
        public List<Cake> cakeList { get; set; } = new();
        public Client client { get; set; }

        public double TotalPrice() => cakeList.Sum(c => c.price);
        public double TotalWithIVA() => TotalPrice() * 1.21;
    }
}
