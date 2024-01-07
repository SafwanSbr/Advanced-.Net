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
    public class EventFoodService
    {
        public static List<EventFoodDTO> Get()
        {
            var data = DataAccessFactory.EventFoodData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EventFood, EventFoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<EventFoodDTO>>(data);
            return mapped;
        }
        public static EventFoodDTO GetById(int id)
        {
            var data = DataAccessFactory.EventFoodData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<EventFood, EventFoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EventFoodDTO>(data);
            return mapped;
        }
        public static bool Create(EventFoodDTO EventFoodDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EventFoodDTO, EventFood>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<EventFood>(EventFoodDTO);

            var data = DataAccessFactory.EventFoodData().Create(mapped);
            if (data != null) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            bool operation = DataAccessFactory.EventFoodData().Delete(id);
            return operation;
        }

        public static EventFoodDTO Update(EventFoodDTO EventFoodDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<EventFoodDTO, Team>();
            });
            var mapper = new Mapper(cfg);
            EventFood EventFood = mapper.Map<EventFood>(EventFoodDTO);

            var data = DataAccessFactory.EventFoodData().Update(EventFood);
            return mapper.Map<EventFoodDTO>(data);
        }
    }
}