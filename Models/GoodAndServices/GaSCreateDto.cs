using System;

namespace LawPanel.ApiClient.Models.GoodAndServices
{
    public class GaSCreateDto
    {
        public Guid     LanguageId      { get; set; }
        public Guid     SearchClassId   { get; set; }
        public string   Text            { get; set; }
    }
}
