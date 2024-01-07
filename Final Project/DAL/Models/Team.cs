using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Employee")]
        public int? Head { get; set; }
        [Required]
        public string Status { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }//
        public virtual ICollection<TeamMember> TeamMembers { get; set; }//
        public Team()
        {
            Employees = new List<Employee>();//
            TeamMembers = new List<TeamMember>();//
        }


    }
}