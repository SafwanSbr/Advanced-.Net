using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MidAssignment.Models
{
    public class ItemDTO
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public Nullable<int> Quantity { get; set; }
        
        [ExpireDateValidation(ErrorMessage ="Expire Date Must Be Atleast One Day Higher Then Request Date")]
        public DateTime ExpireDate { get; set; }
        public Nullable<int> RequestID { get; set; }
    }
}