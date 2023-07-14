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
        public bool IsRequierd { get; set; }
        public QuestionType Type { get; set; }
        public int? DisablerItemId { get; set; }
        public int? EnabblerItemId { get; set; }
        public int MaxLengh { get; set; }
        public int Minlengh { get; set; }

        public QuestionItem DisablerItem { get; set; }
        public QuestionItem EnabblerItem { get; set; }
        public ApplicationPart Part { get; set; }
        public ICollection<Answer> Answer { get; set; }
        public ICollection<QuestionItem> QuestionItems { get; set; }
    }
}
