using System;
using System.ComponentModel.DataAnnotations;

namespace InfopulseWebApi.Customers
{
    public class CustomerDto
    {
        public Int32 Id { get; set; }
        [Required]
        public String Name { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public DateTime? LastOrderDate { get; set; } 
    }
}
