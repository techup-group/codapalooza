using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TampaInnovation.Models
{
    public class UserRegistration
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public int FamilyCount { get; set; }
    }
}
