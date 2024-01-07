using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string Identity { get; set; }
        public int Salary { get; set; }
        [ForeignKey("Team")]
        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<EventEmployee> EventEmployees { get; set; }//
        public virtual ICollection<TeamMember> TeamMembers { get; set; }//
        public Employee()
        {
            EventEmployees = new List<EventEmployee>();//
            TeamMembers = new List<TeamMember>();//
        }
    }
}