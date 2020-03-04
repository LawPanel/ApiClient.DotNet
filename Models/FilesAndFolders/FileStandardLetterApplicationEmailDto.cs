namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileStandardLetterApplicationEmailDto : FileStandardLetterDto
    {
        
        public string ApplicationDate       { get; set; }
        public string ApplicationNumber     { get; set; }
        public string PriorityDeadLine      { get; set; }
        public string Country               { get; set; }
        public string Mark                  { get; set; }
        public string Classes               { get; set; }
        public string Applicant             { get; set; }
        public string FileReferenceNumber   { get; set; }
    }
}