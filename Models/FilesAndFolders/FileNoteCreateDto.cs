namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileNoteCreateDto
    {
        public string   Note                    { get; set; }
        public string   CommunicationChannelId  { get; set; }
        public bool     SendCommunication       { get; set; }
    }
}
