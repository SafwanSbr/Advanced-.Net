using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MidAssignment.Models
{
    public class RequestDTO
    {
        public int ID { get; set; }
        public string RequestTime { get; set; }
        public string CollectionTime { get; set; }
        public string Status { get; set; }
        public Nullable<int> ResturantID { get; set; }
        public Nullable<int> EmployeeID { get; set; }

    }
}