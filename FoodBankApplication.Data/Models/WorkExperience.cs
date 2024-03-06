using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class WorkExperience
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duties { get; set; }
        public string Position { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
