using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string Status { get; set; }
        [ForeignKey("Hall")]
        public int? HallId { get; set; }
        [ForeignKey("Decoration")]
        public int? DecorationId { get; set; }
        public int AdvanceAmount { get; set; }
        public int TotalAmount { get; set; }
        public virtual Hall Hall { get; set; }
        public virtual Decoration Decoration { get; set; }
        public virtual ICollection<EventFood> EventFoods { get; set; }//
        public virtual ICollection<EventEmployee> EventEmployees { get; set; }//
        public Order()
        {
            EventFoods = new List<EventFood>();//
            EventEmployees = new List<EventEmployee>();//
        }
    }
}