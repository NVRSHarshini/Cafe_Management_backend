using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodOrdering.Models
{
    public class Items
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
