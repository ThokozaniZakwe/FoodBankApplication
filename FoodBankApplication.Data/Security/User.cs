using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodBankApplication.Data.Security
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; }
        public string Salt { get; set; } = string.Empty;
        public string Email { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? lastLogin { get; set; }
        public int LoginAttempt { get; set; } = 0;
        public bool IsDeleted { get; set; } = false;
        public byte[]? Image { get; set; }

        public int? RoleId { get; set; }
        public virtual List<Role> Role { get; set; }


    }
}
