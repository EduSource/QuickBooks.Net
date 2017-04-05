namespace QuickBooks.Net.Data.Models.Authorization
{
    public class AuthTokenInfo
    {
        public string OAuthToken { get; set; }

        public string OAuthTokenSecret { get; set; }

        public string AuthorizeUrl 
        {
            get { return $"{_accessTokenUrl}?oauth_token={OAuthToken}"; }
        }

        private readonly string _accessTokenUrl;

        public AuthTokenInfo(string accessTokenUrl)
        {
            _accessTokenUrl = accessTokenUrl;
        }
    }
}