﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models.Interfaces
{
    public interface ICustomerRepository
    {
        Customer LoadCustomer(int ID);
    }
}
