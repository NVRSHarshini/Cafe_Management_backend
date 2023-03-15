using FoodOrdering.Models;
using System.Collections.Generic;
using System.Linq;

namespace FoodOrdering._context
{
    public class MenuRepo:IMenuRepo
    {
        private DBContext context;
        public MenuRepo(DBContext _context)
        {
            context = _context;
        }
        public List<Items> GetAllItems()
        {
            return context.Items.ToList();
        }
        public Items GetItemsById(int id)
        {
            Items Items = context.Items.Find(id);
            return Items;
        }
        //public string AddnewItems(Items Items)
        //{
        //    int count = context.Items.Count();
        //    context.Items.Add(Items);
        //    context.SaveChanges();
        //    int newCount = context.Items.Count();
        //    if (newCount > count)
        //    {
        //        return "Item inserted successfully";
        //    }
        //    else
        //        return "oops something went wrong while inserting the record";
        //}





        //public List<Items> GetItemsByGender(string gender)
        //{
        //    List<Items> Items = context.Items.Where(d => d.Gender == gender).ToList();
        //    return Items;
        //}



        //public string UpdateItems(Items Items)
        //{
        //    Items updateItems= context.Items.Find(Items.Id);
        //    if (updateItems!= null)
        //    {
        //        updateItems.Name = Items.Name;

        //        context.Items.Update(updateItems);
        //        context.SaveChanges();
        //        return "Item details updated successfully";
        //    }
        //    else
        //    {
        //        return "Given item is not available to update";
        //    }
        //}
        //public string DeleteItems(int empid)
        //{
        //    Items emp = context.Items.Find(empid);
        //    if (emp != null)
        //    {
        //        context.Items.Remove(emp);
        //        context.SaveChanges();
        //        return "Items removed from Database";

        //    }
        //    else
        //        return "Given Items is not available";
        //}
    }
}

