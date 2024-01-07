using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        [ForeignKey("Employee")]
        public int? MemberId { get; set; }
        public virtual Team Team { get; set; }
        public virtual Employee Employee { get; set; }

    }
}