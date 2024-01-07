using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventFoodDTO
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? FoodId { get; set; }
    }
}