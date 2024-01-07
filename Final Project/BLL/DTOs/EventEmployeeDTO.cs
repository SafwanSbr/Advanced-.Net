using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EventEmployeeDTO
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? EmployeeId { get; set; }
    }
}
