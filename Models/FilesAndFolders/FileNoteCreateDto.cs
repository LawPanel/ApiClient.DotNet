namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileNoteCreateDto
    {
        public FileNoteCreateDto()
        {
            ForceNotCommunication = false;
        }
        public string   Note                    { get; set; }
        public string   CommunicationChannelId  { get; set; }
        public bool     SendCommunication       { get; set; }
        public bool     ForceNotCommunication   { get; set; }
    }
}
