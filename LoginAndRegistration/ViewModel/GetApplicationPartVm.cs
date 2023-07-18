using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class GetApplicationPartVm
    {
        public int ApplicationId { get; set; }
        public List<ApplicationPartVm> Parts { get; set; } = new List<ApplicationPartVm>();
    }
}
