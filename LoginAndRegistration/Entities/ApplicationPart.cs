using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class ApplicationPart
    {
        [Key]
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Application Application { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
