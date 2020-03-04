using System.ComponentModel.DataAnnotations;

namespace LawPanel.ApiClient.Models.User
{
    public class UserSettingsDto
    {
        public string UrlsWithoutHelpMessage { get; set; } // separated by commas
        public string FirstPageToShow { get; set; }

        [Display(Name = "[[[Send public notes to clients]]]")]
        public bool SendPublicNoteToClient { get; set; }
    }
}
