using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TeamMemberDTO
    {
        public int Id { get; set; }
        public int? TeamId { get; set; }
        public int? MemberId { get; set; }
    }
}
