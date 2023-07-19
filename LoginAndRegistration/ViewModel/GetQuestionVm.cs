using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class GetQuestionVm
    {
        public int PartId { get; set; }
        public List<QuestionVm> Questions { get; set; } = new List<QuestionVm>();

    }
}
