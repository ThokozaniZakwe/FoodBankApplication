using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Models
{
    public class Status
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
