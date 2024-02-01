using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public interface IEmployee
    {
        string Id { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        long Sin { get; set; }
        string Dob { get; set; }
        string Dept { get; set; }

        double GetPay();
    }
}
