namespace LawPanel.ApiClient.Models.FilesAndFolders
{
    public class FileStandardLetterUsRegistrationDto : FileStandardLetterApplicationEmailDto
    {
        public string RenewalDate                   { get; set; }
        public string RegistrationDatePlusFiveYears { get; set; }
        public string RegistrationDatePlusSixYears  { get; set; }
        public string RenewalDateMinusOneYear       { get; set; }
    }
}