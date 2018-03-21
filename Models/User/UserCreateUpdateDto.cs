namespace LawPanel.ApiClient.Models.User
{
    public class UserCreateUpdateDto : UserDto
    {
        public string   ClaimsId        { get; set; }

        public UserCreateUpdateDto()
        {
            ClaimsId = "[]";
        }
        
    }
}
