using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodOrdering.Models
{
    public class Feedback
    {
        [Key]
        public int Fid { get; set; }
        
        [ForeignKey("Customer")]
        public int CustId { get; set; }
        public string CustomerName { get; set; }
        public int rating { get; set; }
        public ICollection<Customers> Customers { get; set; }
    }
}
