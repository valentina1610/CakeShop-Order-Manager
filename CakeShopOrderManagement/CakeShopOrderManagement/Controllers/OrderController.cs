using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaExamen5.Models;
using PracticaExamen5.Views;
using Repository;

namespace PracticaExamen5.Controllers
{
    public class OrderController
    {
        private List<Order> ordersList = new();
        private ClientController cliController;
        private CakeController caController;

        public OrderController()
        {
            cliController = new ClientController();
            caController = new CakeController();
            Cargar();
        }

        private void Cargar()
        {
            ordersList = Repository<Order>.ObtenerTodos(Path.Combine("Repository", "Data", "data"));
        }

        private void Guardar()
        {
            Repository<Order>.GuardarLista(Path.Combine("Repository", "Data", "data"), ordersList);
        }

        public void AddOrder()
        {
            var newClient = cliController.AddClient();

            if (newClient == null)
            {
                OrderView.ShowMsg("[ERROR]: Empty client. Press a key to return");
                Console.ReadKey();
                return;
            }

            var newCakeList = caController.AddCakeList();

            if (newCakeList == null || newCakeList.Count == 0)
            {
                OrderView.ShowMsg("[ERROR]: Empty list. Press a key to return");
                Console.ReadKey();
                return;
            }

            Order newOrder = new()
            {
                client = newClient
            };

            newOrder.cakeList = newCakeList;

            ordersList.Add(newOrder);
            Guardar();
        }

        public void ShowOrder()
        {
            if (ordersList.Count == 0)
            {
                OrderView.ShowMsg("[ERROR]: Empty list. Press a key to return");
                return;
            }

            int index = 0;
            foreach (var i in ordersList)
            {
                OrderView.ShowMsg($"!!! Order of index {index} !!!");
                index++;
                cliController.ShowClient(i.client);
                caController.ShowCakeList(i.cakeList);
                OrderView.ShowMsg($"======== TOTAL: {i.TotalPrice()}$ | TOTAL(iva): {i.TotalWithIVA()}$ ========");
                OrderView.ShowMsg("");
            }
        }

        public void UpdateOrder()
        {
            if (ordersList.Count == 0)
            {
                OrderView.ShowMsg("[ERROR]: Empty list, press a key to return");
                return;
            }

            ShowOrder();
            OrderView.ShowMsg(">>>>>>>>>>>>>>>>>>>>>>> Enter the index of the order to UPDATE <<<<<<<<<<<<<<<<<<<<<<<");
            int index = int.Parse(OrderView.getValidInput(true));

            if (index < 0 || index >= ordersList.Count)
            {
                OrderView.ShowMsg("[ERROR]: No orders found with that index. Press a key to return");
                return;
            }

            var newClient = cliController.AddClient();

            var newCakeList = caController.AddCakeList();

            ordersList[index].client = newClient;
            ordersList[index].cakeList = newCakeList;

            Guardar();
            OrderView.ShowMsg("Order updated successfully ! Press a key to return");
        }

        public void DeleteOrder()
        {
            if (ordersList.Count == 0)
            {
                OrderView.ShowMsg("[ERROR]: Empty list, press a key to return");
                return;
            }

            ShowOrder();
            OrderView.ShowMsg(">>>>>>>>>>>>>>>>>>>>>>> Enter the index of the order to DELETE <<<<<<<<<<<<<<<<<<<<<<<");
            int index = int.Parse(OrderView.getValidInput(true));

            if (index < 0 || index >= ordersList.Count)
            {
                OrderView.ShowMsg("[ERROR]: No orders found with that index. Press a key to return");
                return;
            }

            ordersList.RemoveAt(index);
            Guardar();
            OrderView.ShowMsg("Order deleted successfully ! Press a key to return");
        }

    }
    
}
