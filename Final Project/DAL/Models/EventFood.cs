using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class EventFood
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        [ForeignKey("Food")]
        public int? FoodId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Food Food { get; set; }

    }
}