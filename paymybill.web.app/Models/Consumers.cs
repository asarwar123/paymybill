using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace paymybill.web.app.Models
{
    public class Consumers
    {
        public int id { get; set; }
        public string MobileNumber { get; set; }
        public string email { get; set; }
        public string Name { get; set; }
    }
}
