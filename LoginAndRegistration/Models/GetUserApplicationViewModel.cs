using System;

namespace EasyForm.Models
{
    public class GetUserApplicationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public string Email { get; set; }
        public bool IsCompleted { get; set; }
    }
}
