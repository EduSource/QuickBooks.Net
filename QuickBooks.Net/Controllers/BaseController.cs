using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;
using OAuth;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http;
using QuickBooks.Net.Exceptions;
using QuickBooks.Net.Data.Error_Responses;
using System.Text;
using QuickBooks.Net.Data.Models;
using QuickBooks.Net.Data.Models.Batch;
using QuickBooks.Net.Utilities;
using QuickBooks.Net.Data.Models.Query;
using System.Linq;
using MoreLinq;

namespace QuickBooks.Net.Controllers
{
    public abstract class BaseController
    {

        #region Url Constants

        private const string QbSandboxUrlV3 = "https://sandbox-quickbooks.api.intuit.com/v3";
        private const string QbUrlV3 = "https://quickbooks.api.intuit.com/v3";

        #endregion

        protected abstract string ObjectName { get; }
        private readonly string _oAuthVersion;

        private string Url
        {
            get
            {
                var baseUrl = Client.SandboxMode ? QbSandboxUrlV3 : QbUrlV3;
                return $"{baseUrl}/company/{Client.RealmId}/";
            }
        }

        protected QuickBooksClient Client;

        protected BaseController(QuickBooksClient client, string oAuthVersion)
        {
            Client = client;
            _oAuthVersion = oAuthVersion;
        }

        protected async Task<int> GetObjectCount<T>()
        {
            var content = new StringContent($"Select Count(*) From {ObjectName}", Encoding.UTF8, "application/text");
            var result = await MakeRequest<QueryResponse<T>>("query", HttpMethod.Post, content, isQuery: true);
            return result.Count;
        }

        protected async Task<IEnumerable<T>> QueryRequest<T>(string query, int startPosition = 1, int maxResult = 100, bool overrideOptions = false)
            where T : QuickBooksBaseModel
        {
            var additionalQuery = overrideOptions ? "" : $" startposition {startPosition} maxresults {maxResult}";
            var content = new StringContent(query + additionalQuery, Encoding.UTF8, "application/text");

            var result = await MakeRequest<QueryResponse<T>>("query", HttpMethod.Post, content, isQuery: true);
            return result.Data;
        }

        protected async Task<IEnumerable<T>> QueryRequestString<T>(string query, int startPosition = 1, int maxResult = 100, bool overrideOptions = false)
            where T : QuickBooksBaseModelString
        {
            var additionalQuery = overrideOptions ? "" : $" startposition {startPosition} maxresults {maxResult}";
            var content = new StringContent(query + additionalQuery, Encoding.UTF8, "application/text");

            var result = await MakeRequest<QueryResponse<T>>("query", HttpMethod.Post, content, isQuery: true);
            return result.Data;
        }

        protected async Task<T> GetRequest<T>(object entityId) where T : QuickBooksBaseModel
        {
            return await MakeRequest<T>(ObjectName.ToLower() + $"/{entityId}", HttpMethod.Get);
        }

        protected async Task<T> GetRequestString<T>(object entityId) where T : QuickBooksBaseModelString
        {
            return await MakeRequest<T>(ObjectName.ToLower() + $"/{entityId}", HttpMethod.Get);
        }

        internal QuickBooksBaseModel GetReturnObject<T>(T item, BatchOperation operation) where T : QuickBooksBaseModel
        {
            switch (operation)
            {
                case BatchOperation.Create:
                    return item.CreateReturnObject();
                case BatchOperation.Update:
                    return item.UpdateReturnObject();
                default:
                    return item.DeleteReturnObject();
            }
        }

        internal QuickBooksBaseModelString GetReturnObjectString<T>(T item, BatchOperation operation) where T : QuickBooksBaseModelString
        {
            switch (operation)
            {
                case BatchOperation.Create:
                    return item.CreateReturnObject();
                case BatchOperation.Update:
                    return item.UpdateReturnObject();
                default:
                    return item.DeleteReturnObject();
            }
        }

        protected async Task<IBatchResponse<T>> BatchRequest<T>(IEnumerable<T> items, BatchOperation operation) where T : QuickBooksBaseModel
        {
            if (items.Count() <= 30)
            {
                var request = new BatchItemRequest(
                    items.Select(x => GetReturnObject(x, operation)).ToList(),
                    operation
                );

                var response = await MakeRequest<BatchResponse<T>>("batch", HttpMethod.Post, content: request, batchRequest: true);
                return response;
            }

            var multiBatchResponse = new MultiBatchResponse<T>();
            var itemBatches = items.Batch(30);

            itemBatches.ForEach((batch) =>
            {
                var request = new BatchItemRequest(
                    batch.Select(x => GetReturnObject(x, operation)).ToList(),
                    operation
                );

                var response = MakeRequest<BatchResponse<T>>("batch", HttpMethod.Post, content: request, batchRequest: true).Result;

                multiBatchResponse.responses.Add(response);
            });

            return multiBatchResponse;
        }

        protected async Task<IBatchResponse<T>> BatchRequestString<T>(IEnumerable<T> items, BatchOperation operation) where T : QuickBooksBaseModelString
        {
            if (items.Count() <= 30)
            {
                var request = new BatchItemRequest(
                    items.Select(x => GetReturnObjectString(x, operation)).ToList(),
                    operation
                );

                var response = await MakeRequest<BatchResponse<T>>("batch", HttpMethod.Post, content: request, batchRequest: true);
                return response;
            }

            var multiBatchResponse = new MultiBatchResponse<T>();
            var itemBatches = items.Batch(30);

            itemBatches.ForEach((batch) =>
            {
                var request = new BatchItemRequest(
                    batch.Select(x => GetReturnObjectString(x, operation)).ToList(),
                    operation
                );

                var response = MakeRequest<BatchResponse<T>>("batch", HttpMethod.Post, content: request, batchRequest: true).Result;

                multiBatchResponse.responses.Add(response);
            });

            return multiBatchResponse;
        }

        protected async Task<T> PostRequest<T>(T content, bool update = false, bool delete = false,
            Dictionary<string, string> additionalParams = null) where T : QuickBooksBaseModel
        {
            return await MakeRequest<T>(ObjectName.ToLower(), HttpMethod.Post, content,
                update: update, delete: delete, additionalParams: additionalParams);
        }

        protected async Task<T> PostRequestString<T>(T content, bool update = false, bool delete = false,
            Dictionary<string, string> additionalParams = null) where T : QuickBooksBaseModelString
        {
            return await MakeRequest<T>(ObjectName.ToLower(), HttpMethod.Post, content,
                update: update, delete: delete, additionalParams: additionalParams);
        }

        protected async Task<T> SendEmailRequest<T>(string resourceUrl, Dictionary<string, string> additionalParams = null)
            where T : QuickBooksBaseModel
        {
            return await MakeRequest<T>($"{ObjectName.ToLower()}/{resourceUrl}", HttpMethod.Post,
                new StringContent("", Encoding.UTF8, "application/octet-stream"), additionalParams: additionalParams,
                emailRequest: true);
        }

        protected async Task<T> SendEmailRequestString<T>(string resourceUrl, Dictionary<string, string> additionalParams = null)
            where T : QuickBooksBaseModelString
        {
            return await MakeRequest<T>($"{ObjectName.ToLower()}/{resourceUrl}", HttpMethod.Post,
                new StringContent("", Encoding.UTF8, "application/octet-stream"), additionalParams: additionalParams,
                emailRequest: true);
        }

        protected async Task<byte[]> DownloadFile(string resourceUrl, string contentType)
        {
            return await MakeRequest<byte[]>(resourceUrl, HttpMethod.Get, acceptType: contentType, fileDownload: true);
        }

        private async Task<T> MakeRequest<T>(string resourceUrl, HttpMethod requestMethod, object content = null, string acceptType = null,
            Dictionary<string, string> additionalParams = null, bool isQuery = false, bool update = false, bool delete = false,
            bool fileDownload = false, bool emailRequest = false, bool batchRequest = false)
        {
            var queryParams = additionalParams ?? new Dictionary<string, string>();

            var url = Url + resourceUrl;

            if (update)
            {
                queryParams.Add("operation", "update");
            }
            else if (delete)
            {
                queryParams.Add("operation", "delete");
            }

            queryParams.Add("minorversion", Client.MinorVersion);

            url = url.SetQueryParams(queryParams);

            var accept = Client.AcceptType;
            if (!string.IsNullOrEmpty(acceptType))
            {
                accept += $", {acceptType}";
            }

            var client = url.WithHeaders(new
            {
                Accept = accept,
                Authorization = GetAuthHeader(url, requestMethod, queryParams)
            });

            try
            {
                if (requestMethod == HttpMethod.Get)
                {
                    if (fileDownload)
                    {
                        return (T)Convert.ChangeType(await client.GetBytesAsync(), typeof(T));
                    }

                    var objectResponse = await client.GetJsonAsync<JObject>();
                    return objectResponse[ObjectName].ToObject<T>();
                }

                if (requestMethod == HttpMethod.Post)
                {
                    var response = !emailRequest && !isQuery
                        ? await client.PostJsonAsync(content)
                        : await client.PostAsync((HttpContent)content);

                    if (isQuery)
                    {
                        var queryContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(queryContent);
                    }

                    if (batchRequest)
                    {
                        var batchContent = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<T>(batchContent);
                    }

                    var responseContentString = await response.Content.ReadAsStringAsync();
                    var responseContent = JsonConvert.DeserializeObject<JObject>(responseContentString);
                    return responseContent[ObjectName].ToObject<T>();
                }

                return default(T);
            }
            catch (FlurlHttpTimeoutException ex)
            {
                throw new QuickBooksTimeoutException("The QuickBooks request timed out.", ex.Message);
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.Response == null)
                {
                    throw new Exception(
                        "The request failed to get a response. You may need to check your internet connection.");
                }

                //The XML parsing is because QuickBooks only returns XML on unauthorized exceptions
                if (ex.Call.Response.Content.Headers.ContentType.MediaType == "text/xml")
                {
                    var xml = XmlHelper.ParseXmlString(ex.Call.Response.Content.ReadAsStringAsync().Result);
                    var errorCode = xml["Message"].Split(';')[1].Split('=')[1];
                    throw new QuickbooksAuthorizationException($"QuickBooks application authentication failed. Message: {xml["Message"]}",
                        xml["Detail"], errorCode);
                }

                var response =
                    JsonConvert.DeserializeObject<QuickBooksErrorResponse>(
                        ex.Call.Response.Content.ReadAsStringAsync().Result);

                throw new QuickBooksException("A Quickbooks exception occurred.", response);
            }
        }


        private string GetAuthHeader(string url, HttpMethod method, IDictionary<string, string> queryParams)
        {
            return new OAuthRequest
            {
                Version = _oAuthVersion,
                SignatureMethod = OAuthSignatureMethod.HmacSha1,
                ConsumerKey = Client.ConsumerKey,
                ConsumerSecret = Client.ConsumerSecret,
                Token = Client.AccessToken,
                TokenSecret = Client.AccessTokenSecret,
                Method = method.ToString(),
                RequestUrl = url
            }
            .GetAuthorizationHeader(queryParams);
        }
    }
}