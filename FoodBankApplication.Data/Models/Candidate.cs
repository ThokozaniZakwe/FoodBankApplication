using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModified { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
    }
}
