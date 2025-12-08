using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpScheduler
{
    public class Appointment
    {
        public int AppointmentId { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Contact { get; set; }
        public string Type { get; set; }
        public DateTime StartUTC { get; set; }
        public DateTime EndUTC { get; set; }
    }


}
