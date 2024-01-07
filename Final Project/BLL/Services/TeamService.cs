using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TeamService
    {
        public static List<TeamDTO> Get()
        {
            var data = DataAccessFactory.TeamData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamDTO>>(data);//Data going to convert into "List<EmployeeDTO>"
            return mapped;
        }
        public static TeamDTO GetById(int id)
        {
            var data = DataAccessFactory.TeamData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamDTO>(data);
            return mapped;
        }
        public static TeamDTO GetByIdWithMembers(int id)
        {
            var data = DataAccessFactory.TeamData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamWithMembersDTO>();
                c.CreateMap<TeamMember,  TeamMemberDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamWithMembersDTO>(data);
            return mapped;
        }
        public static bool Create(TeamDTO teamDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamDTO, Team>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Team>(teamDTO);

            var data = DataAccessFactory.TeamData().Create(mapped);
            if (data != null) return true;
            return false;
        }

        public static bool DeleteOnlyTeam(int id)
        {
            var data = DataAccessFactory.TeamData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Team, TeamWithMembersDTO>();
                c.CreateMap<TeamMember, TeamMemberDTO>();
                c.CreateMap<Employee, EmployeeDTO>();
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamWithMembersDTO>(data);
            var team = mapped;
            var teammembers = team.TeamMembers.ToList();
            int teamId = team.Id;

            foreach (TeamMemberDTO member in teammembers)
            {
                var emp = DataAccessFactory.EmployeeData().Read(member.MemberId);
                var mapped2 = mapper.Map<EmployeeDTO>(emp);
                mapped2.TeamId = null; // Assuming you want to remove the team association
                var updatedemp = mapper.Map<Employee>(mapped2);
                DataAccessFactory.EmployeeData().Update(updatedemp);
                DataAccessFactory.TeamMemberData().Delete(member.Id);
            }

            // Now that all members are deleted, delete the team
            return DataAccessFactory.TeamData().Delete(id);
        }


        public static TeamDTO Update(TeamDTO teamDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Team, TeamDTO>();
                c.CreateMap<TeamDTO, Team>(); // Add this line for mapping in the other direction
            });
            var mapper = new Mapper(cfg);
            Team team = mapper.Map<Team>(teamDTO);

            var data = DataAccessFactory.TeamData().Update(team);
            return mapper.Map<TeamDTO>(data);
        }

    }
}
