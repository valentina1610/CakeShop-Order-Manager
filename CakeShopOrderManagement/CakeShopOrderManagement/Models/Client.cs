using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaExamen5.Models
{
    public class Client
    {
        public string name { get; set; }
        public string address { get; set; }
        public string ID { get; set; }
        public string email { get; set; }

        public Client(string name, string address, string ID, string email)
        {
            this.name = name;
            this.address = address;
            this.ID = ID;
            this.email = email;
        }
    }
}
