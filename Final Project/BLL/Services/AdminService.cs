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
    public class AdminService
    {
        public static List<AdminDTO> Get()
        {
            var data = DataAccessFactory.AdminData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<AdminDTO>>(data);
            return mapped;
        }
        public static AdminDTO GetById(int id)
        {
            var data = DataAccessFactory.AdminData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<AdminDTO>(data);
            return mapped;
        }
        public static bool Create(AdminDTO AdminDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Admin>(AdminDTO);

            var data = DataAccessFactory.AdminData().Create(mapped);
            if (data != null) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            bool operation = DataAccessFactory.AdminData().Delete(id);
            return operation;
        }

        public static AdminDTO Update(AdminDTO AdminDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<AdminDTO, Admin>();
            });
            var mapper = new Mapper(cfg);
            Admin Admin = mapper.Map<Admin>(AdminDTO);

            var data = DataAccessFactory.AdminData().Update(Admin);
            return mapper.Map<AdminDTO>(data);
        }
    }
}