using System.ComponentModel.DataAnnotations;

namespace EasyForm.ViewModel
{
    public class ApplicationPartVm
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
        public string ApplicationName { get; set; }
        public string ApplicationSpanishName { get; set; }
        public string ApplicationId { get; set; }
    }
}
