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
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string ContactNumbers { get; set; }
        public string Region { get; set; }
        public string Comment { get; set; }
        public string Gender { get; set; }
        public bool IsDisabled { get; set; }
        public string IDNumber { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModified { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public int HighShcoolGradeId { get; set; }
        public HighSchoolGrade HighSchoolGrade { get; set; }

        public int MunicipalityId { get; set; }
        public Municipality Municipality { get; set; }
    }
}
