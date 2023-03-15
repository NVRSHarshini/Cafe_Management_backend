using FoodOrdering.Models;
using System.Collections.Generic;

namespace FoodOrdering._context
{
    public interface IOrdersRepo
    {
        List<Orders> GetAllOrders();
        Orders GetOrdersById(int id);
        string AddnewOrder(Orders orders);

        //Items GetOderById(int id);        
        //List<Items> GetItemseByGender(string Gender);
        //string UpdateOrder(Items Items);
        //string DeleteOrder(int Custid);
    }
}
