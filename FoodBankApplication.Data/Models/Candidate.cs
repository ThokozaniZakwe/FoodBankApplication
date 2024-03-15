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
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string Comment { get; set; }
        public string Gender { get; set; }
        public bool IsDisabled { get; set; }
        public string IDNumber { get; set; } = string.Empty;
        public DateTime? DOB { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModified { get; set; } = DateTime.Now;
        public bool DriverLicense { get; set; }
        public bool Disability { get; set; }
        public string ContactNumber { get; set; }
        public bool ChildSupportGrant { get; set; }
        public string OtherGrant { get; set; } = "";
        public string DesiredCareerPathComment { get; set; } = "";

        public int? StatusId { get; set; }
        public Status? Status { get; set; } = null;

        public int? HighSchoolGradeId { get; set; }
        public HighSchoolGrade? HighSchoolGrade { get; set; } = null;
        public int? MunicipalityId { get; set; }
        public Municipality? Municipality { get; set; } = null;
        public List<WorkExperience?> WorkExperiences { get; set; } = null;

        public int? CityId { get; set; } = null;
        public City? City { get; set; } = null;

        public int? ProvinceId { get; set; } = null;
        public Province? Province { get; set; } = null;
    }
}
