using System;
using System.ComponentModel.DataAnnotations;

namespace Infopulse.Core.Model
{
    public class Customer : Entity<Int64>
    {
        [Required]
        public String Name { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public DateTime? LastOrderDate { get; set; } 
    }
}
