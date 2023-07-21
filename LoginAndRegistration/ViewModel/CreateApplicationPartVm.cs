using EasyForm.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class CreateApplicationPartVm
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Title { get; set; }
        public string SpanishTitle { get; set; }
        public string Description { get; set; }
        public Application Application { get; set; }
        public List<SelectListItem> Applications { get; set; } = new List<SelectListItem>();
    }
}
