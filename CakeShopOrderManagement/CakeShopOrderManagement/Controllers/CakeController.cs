using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen5.Models;
using PracticaExamen5.Views;

namespace PracticaExamen5.Controllers
{
    public class CakeController
    {
        public List<Cake> AddCakeList() => CakeView.AddCakeList();

        public void ShowCakeList(List<Cake> list) => CakeView.ShowCakeList(list);
    }
}
