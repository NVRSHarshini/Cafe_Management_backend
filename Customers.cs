//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FoodOrdering.Models
{
    public class Customers 
    {    

        [Key]
        [Required]
        public int ID { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }             

        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }
        [Required]
        //[MaxLength(10)]
       //[Range(10,10)]
        public long Phone { get; set; }


        //[ForeignKey("Items")]
        //public int? ItemsId { get; set; }
        //[ForeignKey("Orders")]
        //public int? OrdersOrderId { get; set; }

        //[ForeignKey("Bill")]
        //public int? BillId { get; set; }
        //[ForeignKey("Feedback")]
        //public int? FeedbackFid { get; set; }

    }
}