using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdering.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        //public ICollection<Customers> Customers { get; set; }
        public ICollection<Items> Items { get; set; }
        //public Registration Registration { get; set; }
        //public Items Items { get; set; } 


    }
}
