using EasyForm.Models;
using X.PagedList;

namespace EasyForm.ViewModel
{
    public class UserApplicationWithPaginationVm
    {
        public DataGridSearch dataGridSearch { get; set; }
        public IPagedList<GetUserApplicationViewModel> UserApplication { get; set; }
    }
}
