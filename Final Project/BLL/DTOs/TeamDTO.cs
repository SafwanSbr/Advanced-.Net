using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TeamDTO
    {
        public int Id { get; set; }
        public int? Head { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
