﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOS.MODELS.Responses
{
    public class OrderDisplayResponse : Response
    {
        public List<Order> Orders { get; set; }
    }
}
