using System.ComponentModel.DataAnnotations;

namespace EasyForm.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Answers { get; set; }// todo 
        public int QuestionId { get; set; }
        public int UserApplicationId { get; set; }

        public Question Question { get; set; }
        public UserApplication UserApplication { get; set; }

    }
}
