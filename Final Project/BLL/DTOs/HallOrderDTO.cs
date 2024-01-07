using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class HallOrderDTO : HallDTO
    {
        public List<OrderDTO> Orders { get; set; }
        public HallOrderDTO()
        {
            Orders = new List<OrderDTO>();
        }
    }
}