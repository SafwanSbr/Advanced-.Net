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
    public class FoodService
    {
        public static List<FoodDTO> Get()
        {
            var data = DataAccessFactory.FoodData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<FoodDTO>>(data);
            return mapped;
        }
        public static FoodDTO GetById(int id)
        {
            var data = DataAccessFactory.FoodData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Food, FoodDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<FoodDTO>(data);
            return mapped;
        }
        public static bool Create(FoodDTO FoodDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodDTO, Food>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Food>(FoodDTO);

            var data = DataAccessFactory.FoodData().Create(mapped);
            if (data != null) return true;
            return false;
        }

        public static bool Delete(int id)
        {
            bool operation = DataAccessFactory.FoodData().Delete(id);
            return operation;
        }

        public static FoodDTO Update(FoodDTO FoodDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<FoodDTO, Food>();
            });
            var mapper = new Mapper(cfg);
            Food Food = mapper.Map<Food>(FoodDTO);

            var data = DataAccessFactory.FoodData().Update(Food);
            return mapper.Map<FoodDTO>(data);
        }
    }
}