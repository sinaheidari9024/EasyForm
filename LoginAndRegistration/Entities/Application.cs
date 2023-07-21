using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
        public ICollection<UserApplication> UserApplications { get; set; }
        public ICollection<ApplicationPart> ApplicationParts { get; set; }
    }
}
