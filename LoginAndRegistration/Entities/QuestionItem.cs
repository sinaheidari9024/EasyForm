using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class QuestionItem
    {
        [Key]
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string SpanishTitle { get; set; }
        public bool IsActive { get; set; }

        public Question Question { get; set; }
    }
}
