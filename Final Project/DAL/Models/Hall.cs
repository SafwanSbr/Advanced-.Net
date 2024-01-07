using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Hall
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Email { get; set; }
        public string Details { get; set; }
        public int Costing { get; set; }
        public virtual ICollection<Order> Orders { get; set; }//
        public Hall()
        {
            Orders = new List<Order>();//
        }

    }
}