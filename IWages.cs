﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Inheritance
{
    public interface IWages : IEmployee
    {
        double Rate { get; set; }
        double Hours { get; set; }
    }
}
