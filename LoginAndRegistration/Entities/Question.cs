using EasyForm.Enum;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int ApplicationPartId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public QuestionType Type { get; set; }

        public ApplicationPart Part { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public ICollection<QuestionItem> QuestionItems { get; set; }
    }
}
