using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class PartTime : IPartTime
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }
        public double Rate { get; set; }
        public double Hours { get; set; }


        public PartTime() { }

        public PartTime(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
            Rate = rate;
            Hours = hours;
        }

        //Calculate and return the pay for Part-Time employees
        public double GetPay()
        {
            return Rate * Hours;
        }
    }
}
