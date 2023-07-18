using EasyForm.Enum;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EasyForm.Entities
{

    public class User : IdentityUser<int>
    {
        public UserRole Role { get; set; }
        public ICollection<UserApplication> Applications { get; set; }
    }
}
