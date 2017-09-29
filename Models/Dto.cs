using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models
{
    public abstract class Dto
    {
        [Display(Name = "[[[Created]]]")]
        public DateTime CreatedAt   { get; set; }
        public bool     Enable      { get; set; }
    }
}
