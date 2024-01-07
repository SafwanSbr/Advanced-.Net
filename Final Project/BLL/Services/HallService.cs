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
    public class HallService
    {
        public static List<HallDTO> GET()
        {
            var data = DataAccessFactory.HallData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Hall, HallDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<HallDTO>>(data);
            return mapped;
        }
        public static HallDTO Get(int id)
        {
            var data = DataAccessFactory.HallData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Hall, HallDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<HallDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            bool operation = DataAccessFactory.HallData().Delete(id);
            return operation;
        }
        public static HallDTO Update(HallDTO hallDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<HallDTO, Hall>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Hall>(hallDTO);

            var data = DataAccessFactory.HallData().Update(mapped);
            return mapper.Map<HallDTO>(data);
        }
        public static bool Create(HallDTO hallDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<HallDTO, Hall>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Hall>(hallDTO);

            var data = DataAccessFactory.HallData().Create(mapped);
            return data;
        }
        public static HallOrderDTO GetWithOrders(int id)
        {
            var data = DataAccessFactory.HallData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Hall, HallOrderDTO>();
                c.CreateMap<Order, OrderDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<HallOrderDTO>(data);
            return mapped;
        }
        public static List<HallDTO> GetHallsByLocation(string location)
        {
            var data = DataAccessFactory.HallData().Read();

            // Filter halls based on the specified location
            var filteredData = from h in data
                               where h.Location == location
                               select h;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Hall, HallDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<HallDTO>>(filteredData.ToList());
            return mapped;
        }


    }
}