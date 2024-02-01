using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public class Salaried : ISalaried
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public long Sin { get; set; }
        public string Dob { get; set; }
        public string Dept { get; set; }
        public double Salary { get; set; }

        public Salaried() { }

        public Salaried(string id, string name, string address, string phone, long sin, string dob, string dept, double salary)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Sin = sin;
            Dob = dob;
            Dept = dept;
            Salary = salary;
        }

        //Return the pay for Salaried employees
        public double GetPay()
        {
            return Salary;
        }
    }
}
