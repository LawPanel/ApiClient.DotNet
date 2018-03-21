using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LawPanel.ApiClient.Models
{
    public abstract class Dto
    {
        [Display(Name = "[[[Created]]]")]
        [JsonIgnore]
        public          DateTime    CreatedAt               { get; set; }
        public          bool        Enable                  { get; set; }
        public virtual  bool        ShouldSerializeEnable() { return true; }
    }
}
