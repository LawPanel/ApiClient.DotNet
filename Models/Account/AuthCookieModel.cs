namespace LawPanel.ApiClient.Models.Account
{
    public class AuthCookieModel
    {
        public string Value     { get; set; }
        public string Domain    { get; set; }
        public string Path      { get; set; }
        public string Expires   { get; set; }
        public string Secure    { get; set; }
    }
}
