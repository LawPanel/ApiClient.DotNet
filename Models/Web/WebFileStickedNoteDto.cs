using LawPanel.ApiClient.Interfaces;

namespace LawPanel.ApiClient.Models.Web
{
    public class WebFileStickedNoteDto : Dto, IIdentifiableDto
    {
        public string   Id          { get; set; }
        public int      PositionX   { get; set; }
        public int      PositionY   { get; set; }
        public string   FileId      { get; set; }
        public string   FileEventId { get; set; }
    }
}
