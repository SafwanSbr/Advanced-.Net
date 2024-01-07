using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TeamRepo : Repo, IRepo<Team, int?, Team>
    {
        public Team Create(Team team)
        {
            db.TeamsMember.Add(team);
            if (db.SaveChanges() > 0) return team;
            return null;
        }

        public bool Delete(int? id)
        {
            var team = Read(id);
            if(team != null)
            {
                db.TeamsMember.Remove(team);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Team> Read()
        {
            var teams = db.TeamsMember.ToList();
            return teams;
        }

        public Team Read(int? id)
        {
            var team = db.TeamsMember.Find(id);
            return team;
        }

        public Team Update(Team team)
        {
            var dbteam = Read(team.Id);
            if(dbteam != null)
            {
                dbteam.Head = team.Head;
                dbteam.Status = team.Status;
                db.SaveChanges();
            }
            return dbteam;
        }
        /*
        public bool RemoveFullTeam(int id)
        {
            var team = Read(id);
            if( team != null)
            {
                var teamId = team.Id;
                var teamMember = db.TeamMembers.FirstOrDefault(x => x.TeamId == teamId);
                while(teamMember != null)
                {
                    db.TeamMembers.Remove(teamMember);
                    db.SaveChanges();
                    teamMember = db.TeamMembers.FirstOrDefault(x => x.TeamId == teamId);
                }
                db.TeamsMember.Remove(Read(teamId));
                db.SaveChanges();
                return true;
            }
            return false;
        }*/
    }
}
