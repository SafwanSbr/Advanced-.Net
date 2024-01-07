using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeamMemberRepo: Repo, IRepo<TeamMember, int, TeamMember>
    {
        public TeamMember Create(TeamMember teamMember)
        {
            db.TeamMembers.Add(teamMember);
            if (db.SaveChanges() > 0) return teamMember;
            return null;
        }

        public bool Delete(int id)
        {
            var teamMember = Read(id);
            db.TeamMembers.Remove(teamMember);
            if (db.SaveChanges() > 0) return true;
            return false;
        }

        public List<TeamMember> Read()
        {
            var teamMember = db.TeamMembers.ToList();
            return teamMember;
        }

        public TeamMember Read(int id)
        {
            var teamMember = db.TeamMembers.Find(id);
            return teamMember;
        }

        public TeamMember Update(TeamMember teamMember)
        {
            var dbteamMember = Read(teamMember.Id);
            if(dbteamMember != null)
            {
                dbteamMember.TeamId = teamMember.Id;
                dbteamMember.MemberId = teamMember.MemberId;
                db.SaveChanges();
            }
            return dbteamMember;
        }
    }
}
