using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TeamWithMembersDTO : TeamDTO
    {
        public List<TeamMemberDTO> TeamMembers { get; set; }
        public TeamWithMembersDTO() {
            TeamMembers = new List<TeamMemberDTO>();
        }
    }
}
