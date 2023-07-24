using EasyForm.Enum;

namespace EasyForm.ViewModel
{
    public class QuestionVm
    {
        public int Id { get; set; }
        public int ApplicationPartId { get; set; }
        public string Number { get; set; }
        public string SpanishText { get; set; }
        public string Text { get; set; }
        public bool IsRequierd { get; set; }
        public QuestionType Type { get; set; }
        public int? DisablerItemId { get; set; }
        public int? EnabblerItemId { get; set; }
        public int MaxLengh { get; set; }
        public int Minlengh { get; set; }
        public bool IsActive { get; set; }
        public int Priority { get; set; }
        public int PartId { get; set; }
        public string PartName { get; set; }
        public string SpanishPartName { get; set; }
        public string ApplicationName { get; set; }
        public string SpanishApplicationName { get; set; }
    }
}
