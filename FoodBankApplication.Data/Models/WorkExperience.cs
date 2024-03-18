﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Duties { get; set; }
        public string Position { get; set; }
        public int CandidateId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
