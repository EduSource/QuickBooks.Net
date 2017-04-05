using OAuth;
using QuickBooks.Net.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using QuickBooks.Net.Controllers;
using Flurl.Http;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Authorization;
using QuickBooks.Net.Utilities;

namespace QuickBooks.Net
{
    public class QuickBooksClient : IQuickBooksClient
    {

        #region URL Constants

        private const string AuthorizeUrl = "https://appcenter.intuit.com/Connect/Begin";
        private const string RequestTokenUrl = "https://oauth.intuit.com/oauth/v1/get_request_token";
        private const string AccessTokenUrl = "https://oauth.intuit.com/oauth/v1/get_access_token";
        private const string CurrentUserUrl = "https://appcenter.intuit.com/api/v1/user/current";
        private const string DisconnectUrl = "https://appcenter.intuit.com/api/v1/connection/disconnect";
        private const string ReconnectUrl = "https://appcenter.intuit.com/api/v1/connection/reconnect";

        #endregion

        private const string OAuthVersion = "1.0";

        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        public string CallbackUrl { get; set; }
        public bool SandboxMode { get; set; } = true;
        public string RealmId { get; set; }
        public string MinorVersion { get; set; } = "4";
        public string AcceptType { get; set; } = "application/json";

        public ICustomerController Customers { get; }
        public ICompanyInfoController CompanyInfo { get; }
        public IInvoiceController Invoices { get; }
        public IPaymentController Payments { get; }
        public IDepositController Deposits { get; }

        public QuickBooksClient()
        {
            Customers = new CustomerController(this, OAuthVersion);
            CompanyInfo = new CompanyInfoController(this, OAuthVersion);
            Invoices = new InvoiceController(this, OAuthVersion);
            Payments = new PaymentController(this, OAuthVersion);
            Deposits = new DepositController(this, OAuthVersion);
        }

        public QuickBooksClient(string consumerKey, string consumerSecret, string accessToken, string accessTokenSecret, 
                string callbackUrl, bool sandboxMode, string realmId, string minorVersion) : this()
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            AccessToken = accessToken;
            AccessTokenSecret = accessTokenSecret;
            CallbackUrl = callbackUrl;
            SandboxMode = sandboxMode;
            RealmId = realmId;
            MinorVersion = minorVersion;
        }

        public async Task<QuickBooksUser> GetCurrentUser()
        {
            var authRequest = new OAuthRequest
            {
                Method = "GET",
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                Token = AccessToken,
                TokenSecret = AccessTokenSecret,
                RequestUrl = CurrentUserUrl,
                Version = OAuthVersion
            };

            var client = CurrentUserUrl.WithHeaders(new
            {
                Accept = AcceptType,
                Authorization = authRequest.GetAuthorizationHeader()
            });

            try
            {
                var response = await client.GetAsync();
                var xml = XmlHelper.ParseXmlString(response.Content.ReadAsStringAsync().Result);
                return new QuickBooksUser
                {
                    FirstName = xml["FirstName"],
                    LastName = xml["LastName"],
                    EmailAddress = xml["EmailAddress"],
                    ScreenName = xml["ScreenName"],
                    IsVerified = bool.Parse(xml["IsVerified"])
                };
            }
            catch (FlurlHttpException ex)
            {
                throw new QuickBooksException("Unable to retrieve current user.", ex.Message);
            }
        }

        // Haven't actually tested this out yet
        public async Task DisconnectAccount()
        {
            var authRequest = new OAuthRequest
            {
                Method = "GET",
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                Token = AccessToken,
                TokenSecret = AccessTokenSecret,
                RequestUrl = DisconnectUrl,
                Version = OAuthVersion
            };

            var client = DisconnectUrl.WithHeaders(new
            {
                Accept = AcceptType,
                Authorization = authRequest.GetAuthorizationHeader()
            });

            try
            {
                await client.GetAsync();
            }
            catch (FlurlHttpException ex)
            {
                throw new QuickBooksException("Unable to disconnect account.", ex.Message);
            }
        }

        // Haven't actually tested this out yet
        public async Task ReconnectAccount()
        {
            var authRequest = new OAuthRequest
            {
                Method = "GET",
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                Token = AccessToken,
                TokenSecret = AccessTokenSecret,
                RequestUrl = ReconnectUrl,
                Version = OAuthVersion
            };

            var client = ReconnectUrl.WithHeaders(new
            {
                Accept = AcceptType,
                Authorization = authRequest.GetAuthorizationHeader()
            });

            try
            {
                await client.GetAsync();
            }
            catch (FlurlHttpException ex)
            {
                throw new QuickBooksException("Unable to reconnect account.", ex.Message);
            }
        }

        public async Task<AuthTokenInfo> GetAuthTokens()
        {
            var authRequest = new OAuthRequest
            {
                Method = "GET",
                CallbackUrl = CallbackUrl,
                Type = OAuthRequestType.RequestToken,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = ConsumerKey,
                ConsumerSecret = ConsumerSecret,
                RequestUrl = RequestTokenUrl,
                Version = OAuthVersion
            };

            try
            {
                var request = await (authRequest.RequestUrl + "?" + authRequest.GetAuthorizationQuery()).GetAsync();
                var result = await request.Content.ReadAsStringAsync();
                var tokens = result.Split('&').Select(x => x.Split('=')).ToDictionary(split => split[0], split => split[1]);
                return new AuthTokenInfo(AuthorizeUrl) { OAuthToken = tokens["oauth_token"], OAuthTokenSecret = tokens["oauth_token_secret"] };
            }
            catch(FlurlHttpException ex)
            {
                throw new UnauthorizedQuickBooksClientException(
                    "QuickBooks returned with an unauthorized response. Be sure your consumer key and consumer secret are correct.", 
                    ex.InnerException);
            }
        }

        public async Task<AccessTokenInfo> RequestAccessTokens(string authToken, string authTokenSecret, string oauthVerifier)
        {
            var oauthRequest = OAuthRequest.ForAccessToken(
                ConsumerKey,
                ConsumerSecret,
                authToken,
                authTokenSecret,
                oauthVerifier
            );

            oauthRequest.RequestUrl = AccessTokenUrl;
            oauthRequest.Version = OAuthVersion;

            try
            {
                var request = await (oauthRequest.RequestUrl + "?" + oauthRequest.GetAuthorizationQuery()).GetAsync();
                var result = await request.Content.ReadAsStringAsync();
                var accessTokens = result.Split('&').Select(x => x.Split('=')).ToDictionary(split => split[0], split => split[1]);
                return new AccessTokenInfo { AccessToken = accessTokens["oauth_token"], AccessTokenSecret = accessTokens["oauth_token_secret"] };
            }
            catch(FlurlHttpException ex)
            {
                throw new UnauthorizedQuickBooksClientException(
                    "Unable to get access tokens.", 
                    ex.InnerException);
            }
        }

    }
}