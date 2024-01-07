using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EmployeeDTO>>(data);//Data going to convert into "List<EmployeeDTO>"
            return mapped;
        }
        public static EmployeeDTO GetById(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeDTO>(data);
            return mapped;
        }
        public static EmployeeDTO GetByIdWithOrders(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Employee, EmployeeWithOrderDTO>();
                c.CreateMap<EventEmployee, EventEmployeeDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EmployeeWithOrderDTO>(data);
            return mapped;
        }
        public static bool Create(EmployeeDTO employeeDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EmployeeDTO,Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Employee>(employeeDTO);

            var data = DataAccessFactory.EmployeeData().Create(mapped);
            if(data != null) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            return DataAccessFactory.TeamData().Delete(id);
        }

        public static EmployeeDTO Update(EmployeeDTO employeeDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Employee, EmployeeDTO>();
                c.CreateMap<EmployeeDTO, Employee>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Employee>(employeeDTO);

            var data = DataAccessFactory.EmployeeData().Update(mapped);
            return mapper.Map<EmployeeDTO>(data);
        }
        
    }
}
