using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpScheduler.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }

        public Customer() { }

        public Customer(int id, string name, string address, string address2, string postal, string phone)
        {
            CustomerId = id;
            Name = name;
            Address = address;
            Address2 = address2;
            PostalCode = postal;
            Phone = phone;
        }
    }
}


