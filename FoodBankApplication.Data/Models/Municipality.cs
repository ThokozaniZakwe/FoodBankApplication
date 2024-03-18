﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class Municipality
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
