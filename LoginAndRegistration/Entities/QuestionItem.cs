using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class QuestionItem
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }

        public Question Question { get; set; }
        public ICollection<Question> EnableQuestion { get; set; }
        public ICollection<Question> DisableQuestion { get; set; }

    }
}
