using System.ComponentModel.DataAnnotations;

namespace EasyForm.ViewModel
{
    public class ApplicationVm
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
    }
}
