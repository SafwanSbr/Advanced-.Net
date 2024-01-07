using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Costing { get; set; }
        public string Details { get; set; }
        public virtual ICollection<EventFood> EventFoods { get; set; }//
        public Food()
        {
            EventFoods = new List<EventFood>();//
        }
    }
}