using EasyForm.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EasyForm.ViewModel
{
    public class CreateApplicationPartVm
    {
        public int Id { get; set; }
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
        public Application Application { get; set; }
        public List<SelectListItem> Applications { get; set; } = new List<SelectListItem>();
    }
}
