using EasyForm.Entities.Configuration;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{

    public class User : IdentityUser<int>
    {
        public ICollection<UserApplication> Applications { get; set; }
    }
}
