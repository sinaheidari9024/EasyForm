using System;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class UserApplication
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
