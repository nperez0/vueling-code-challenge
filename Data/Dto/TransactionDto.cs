﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class TransactionDto
    {
        public string SKU { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }
    }
}
