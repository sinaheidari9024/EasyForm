using EasyForm.Entities;
using System;
using System.Collections.Generic;

namespace EasyForm.ViewModel
{
    public class ApplicationPartsVm
    {
        public int UserApplicationId { get; set; }
        public DateTime CreationDate { get; set; }
        public List<PartsVm> Parts { get; set; }
    }
}
