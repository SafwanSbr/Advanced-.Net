using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerName { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string Status { get; set; }
        public int? HallId { get; set; }
        public int? DecorationId { get; set; }
        public int AdvanceAmount { get; set; }
        public int TotalAmount { get; set; }
    }
}