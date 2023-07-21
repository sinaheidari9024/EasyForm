using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class PartsVm
    {
        public string Title { get; set; }
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public List<QuestionComplexModel> Questions { get; set; } = new List<QuestionComplexModel>();
    }
}
