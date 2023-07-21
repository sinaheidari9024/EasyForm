using EasyForm.Enum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class CreateQuestionVm
    {
        public int Id { get; set; }
        public int ApplicationPartId { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public string SpanishText { get; set; }
        public bool IsRequierd { get; set; }
        public QuestionType Type { get; set; }
        public int MaxLengh { get; set; }
        public int Minlengh { get; set; }
        public int Priority { get; set; }
        public List<SelectListItem> Parts { get; set; } = new List<SelectListItem>();

    }
}
