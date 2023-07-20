using EasyForm.Enum;
using EasyForm.Models;
using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class QuestionComplexModel
    {
        public int QuestionId { get; set; }
        public int ApplicationPartId { get; set; }
        public string Text { get; set; }
        public string Number { get; set; }
        public bool IsRequierd { get; set; }

        public QuestionType Type { get; set; }
        public string Answer { get; set; }
        public List<QuestionItemVm> Items { get; set; } = new List<QuestionItemVm>();
        public Table1 Table1 { get; set; }
        public Table2 Table2 { get; set; }
    }
}
