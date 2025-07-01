using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen5.Models;
using PracticaExamen5.Views;

namespace PracticaExamen5.Controllers
{
    public class ClientController
    {
        public Client AddClient() => ClientView.AddClient();

        public void ShowClient(Client c) => ClientView.ShowClient(c);
    }
}
