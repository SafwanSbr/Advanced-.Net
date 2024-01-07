using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TeamMemberService
    {
        public static List<TeamMemberDTO> Get()
        {
            var data = DataAccessFactory.TeamMemberData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamMember, TeamMemberDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<TeamMemberDTO>>(data);//Data going to convert into "List<EmployeeDTO>"
            return mapped;
        }
        public static TeamMemberDTO GetById(int id)
        {
            var data = DataAccessFactory.TeamData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<TeamMember, TeamMemberDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<TeamMemberDTO>(data);
            return mapped;
        }
        public static bool Create(TeamMemberDTO teamDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamMemberDTO, TeamMember>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Team>(teamDTO);

            var data = DataAccessFactory.TeamData().Create(mapped);
            if (data != null) return true;
            return false;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TeamData().Delete(id);
        }
        public static TeamMemberDTO Update(TeamMemberDTO teamMemberDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<TeamMember, TeamMemberDTO>();
            });
            var mapper = new Mapper(cfg);
            TeamMember team = mapper.Map<TeamMember>(teamMemberDTO);

            var data = DataAccessFactory.TeamMemberData().Update(team);
            return mapper.Map<TeamMemberDTO>(data);
        }
    }
}
