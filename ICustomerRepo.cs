using FoodOrdering.Models;
using System.Collections.Generic;

namespace FoodOrdering._context
{
    public interface ICustomerRepo
    {
        
            List<Customers> GetAllCustomers();
        Customers GetCustomersById(int id);
            //List<Customers> GetCustomerseByGender(string Gender);
            string AddnewCustomers(Customers customers);
            string UpdateCustomers(Customers customers);
            string DeleteCustomers(int Custid);

        
    }
}
