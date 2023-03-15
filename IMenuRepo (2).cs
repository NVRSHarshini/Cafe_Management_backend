﻿using FoodOrdering.Models;
using System.Collections.Generic;

namespace FoodOrdering._context
{
    public interface IMenuRepo
    {
        List<Items> GetAllItems();
        Items GetItemsById(int id);
        //List<Items> GetItemseByGender(string Gender);
        //string AddnewItems(Items Items);
        //string UpdateItems(Items Items);
        //string DeleteItems(int Custid);
    }
}
