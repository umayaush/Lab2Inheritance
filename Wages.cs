using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class Wages : IWages
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

        public Wages() { }

        public Wages(string id, string name, string address, string phone, long sin, string dob, string dept, double rate, double hours)
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

        //Calculate and return the pay for wage employees
        public double GetPay()
        {
            double overtimeHours = Math.Max(Hours - 40, 0);
            double regularHours = Hours - overtimeHours;
            return (regularHours * Rate) + (overtimeHours * Rate * 1.5);
        }
    }
}
