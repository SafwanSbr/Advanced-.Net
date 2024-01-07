using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class EmployeeWithOrderDTO:EmployeeDTO
    {
        public List<EventEmployeeDTO> EventEmployees { get; set; }
        public EmployeeWithOrderDTO() {
            EventEmployees = new List<EventEmployeeDTO>();
        }
    }
}
