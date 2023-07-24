using EasyForm.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.ViewModel
{
    public class CreateQuestionVm
    {
        public int Id { get; set; }
        public int ApplicationPartId { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public string Text { get; set; }
        [Required] 
        public string SpanishText { get; set; }
        [Required]
        public bool IsRequierd { get; set; }
        [Required]
        public QuestionType Type { get; set; }
        public int MaxLengh { get; set; }
        public int Minlengh { get; set; }
        [Required]
        public int Priority { get; set; }
        public List<SelectListItem> Parts { get; set; } = new List<SelectListItem>();

    }
}
