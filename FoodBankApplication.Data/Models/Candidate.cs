using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Surname { get; set; }
        [Required]
        [MinLength(3)]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        [MinLength(3)]
        public string PostalCode { get; set; }
        public string Region { get; set; }
        [Required]
        [MinLength(3)]
        public string Comment { get; set; }
        public string Gender { get; set; }
        [Required]
        public bool IsDisabled { get; set; }
        public string IDNumber { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "dd-MMM-yyyy")]
        public DateTime? DOB { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? LastModified { get; set; } = DateTime.Now;
        [Required]
        public bool DriverLicense { get; set; }
        [Required]
        public bool Disability { get; set; }
        public string ContactNumber { get; set; }
        public bool ChildSupportGrant { get; set; }
        public string OtherGrant { get; set; } = "";
        public string DesiredCareerPathComment { get; set; } = "";

        public int? StatusId { get; set; }
        public Status? Status { get; set; } = null;

        [Required]
        public int? HighSchoolGradeId { get; set; }
        public HighSchoolGrade? HighSchoolGrade { get; set; } = null;
        [Required]
        public int? MunicipalityId { get; set; }
        public Municipality? Municipality { get; set; } = null;
        public List<WorkExperience?> WorkExperiences { get; set; } = null;

        [Required]
        public int? CityId { get; set; } = null;
        public City? City { get; set; } = null;

        [Required]
        public int? ProvinceId { get; set; } = null;
        public Province? Province { get; set; } = null;
    }
}
