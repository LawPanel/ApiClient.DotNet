namespace LawPanel.ApiClient.Constants
{
    public static class Auth
    {
        public const string CookieName = ".LawPanel.AuthCookie"; //  ".AspNet.ApplicationCookie";
        public const string ApiUrl = "https://api.lawpanel.com/v1/firms/";
        public const string ApiUrlForApps = "https://api-ipv6.azureedge.net/v1/"; // We need to use it due to IPV6 Apple requirements
    }
}
