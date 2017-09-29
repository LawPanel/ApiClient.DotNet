using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Templates
{
    public class TemplateDto : Dto, IIdentifiableDto
    {
        public string Id                    { get; set; }
        public string CommunicationActor    { get; set; }
        public string CommunicationActorId  { get; set; }

        [Display(Name = "[[[Communication type]]]"), Required(ErrorMessage = "[[[Communication type is required]]]", AllowEmptyStrings = false)]
        public string CommunicationType     { get; set; }

        [Display(Name = "[[[Communication channel]]]"), Required(ErrorMessage = "[[[Communication channel is required]]]", AllowEmptyStrings = false)]
        public string CommunicationChannel  { get; set; }
        public string Language              { get; set; }
        public string LanguageId            { get; set; }

        [Display(Name = "[[[Summary]]]"), Required(ErrorMessage = "[[[Summary is required]]]", AllowEmptyStrings = false)]
        public string SummaryDefinition     { get; set; }
        public string SummaryDefinitionId   { get; set; }

        [Display(Name = "[[[Contents]]]"), Required(ErrorMessage = "[[[Contents is required]]]", AllowEmptyStrings = false)]
        public string ContentsDefinition    { get; set; }
        public string ContentsDefinitionId  { get; set; }

        public override string ToString()
        {
            return $"{CommunicationType}/{CommunicationChannel}/{Language}";
        }

        
        
    }
}
