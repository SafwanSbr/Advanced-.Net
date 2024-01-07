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
    public class DecorationService
    {
        public static List<DecorationDTO> GET()
        {
            var data = DataAccessFactory.DecorationData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Decoration, DecorationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DecorationDTO>>(data);
            return mapped;
        }
        public static DecorationDTO Get(int id)
        {
            var data = DataAccessFactory.DecorationData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Decoration, DecorationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<DecorationDTO>(data);
            return mapped;
        }
        public static bool Delete(int id)
        {
            bool operation = DataAccessFactory.DecorationData().Delete(id);
            return operation;
        }
        public static DecorationDTO Update(DecorationDTO decorationDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DecorationDTO, Decoration>();
                c.CreateMap<Decoration, DecorationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Decoration>(decorationDTO);

            var data = DataAccessFactory.DecorationData().Update(mapped);
            var mapper2 = mapper.Map<DecorationDTO>(data);
            return mapper2;
        }
        public static bool Create(DecorationDTO decorationDTO)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<DecorationDTO, Decoration>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<Decoration>(decorationDTO);

            var data = DataAccessFactory.DecorationData().Create(mapped);
            return data;
        }
        public static List<DecorationDTO> GetDecorationsByColors(string color)
        {
            var data = DataAccessFactory.DecorationData().Read();

            // Filter halls based on the specified location
            var filteredData = from d in data
                               where d.Colors == color
                               select d;

            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Decoration, DecorationDTO>();
            });

            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DecorationDTO>>(filteredData.ToList());
            return mapped;
        }
    }
}