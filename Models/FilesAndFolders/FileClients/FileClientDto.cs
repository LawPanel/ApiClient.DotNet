using System.ComponentModel.DataAnnotations;
using LawPanel.ApiClient.Interfaces;
using LawPanel.ApiClient.Models.Clients;

namespace LawPanel.ApiClient.Models.FilesAndFolders.FileClients
{
    public class FileClientDto : Dto, IIdentifiableDto
    {
        public string               Id              { get; set; }
        
        public FileDto              File            { get; set; }
        
        [Display(Name = "[[[Company]]]")]
        public ClientDto            Client          { get; set; }

        [Display(Name = "[[[Role]]]")]
        public FileClientRoleDto    FileClientRole  { get; set; }
        
        [Display(Name = "[[[Contact]]]")]
        public ClientUserDto        ClientUser      { get; set; } 

        [Display(Name = "[[[Reference]]]")]
        public string               Reference       { get; set; }


        public FileClientDto()
        {
            ClientUser = new ClientUserDto();
            FileClientRole = new FileClientRoleDto();
            Client = new ClientDto();
            File = new FileDto();
        }
    }
}