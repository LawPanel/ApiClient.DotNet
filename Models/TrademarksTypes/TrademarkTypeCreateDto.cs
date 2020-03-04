using System;
using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.TrademarksTypes
{
    public class TrademarkTypeCreateDto : Dto
    {
        public Guid?    FirmId  { get; set; }
        [Required(ErrorMessage = "[[[Name is required]]]")]
        public string   Name    { get; set; } 
        public int      Code    { get; set; }
    }
}