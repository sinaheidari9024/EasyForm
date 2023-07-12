using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class UserApplication
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ApplicationId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
        public Application Application { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
