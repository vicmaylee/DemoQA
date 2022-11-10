using DemoQA.API;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoQA.APIPageObject
{
    public class PageObjectChain
    {
        //create global variable

        private RestClient restClient;
        private RestRequest restRequest;
        //private RestResponse restResponse;
        public string baseUrl = "https://reqres.in";
        public string FixtureUrl = "http://localhost:3000";
        //private string endpoint = "/api/users";

        //Create Methods to use the client and request

        public PageObjectChain SetUrl()
        {
            restClient = new RestClient(baseUrl);
            return this;
        }

        public PageObjectChain GetRequest(string endpoint, Method method)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json"); 
            return this; 
        }

        public PageObjectChain DeleteRequest(string endpoint, Method method, object payload)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(payload);
            return this;
        }

        public PageObjectChain PostRequest(string endpoint, Method method, object payload)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", restRequest.AddJsonBody(payload),
                ParameterType.RequestBody);
            restRequest.AddJsonBody(payload);
            return this;
        }

        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
          
            return client.Execute(request);
        }

        public RestResponse GetMyResponse()
        {

            return restClient.Execute(restRequest);
        }
        public DTO GetDeserializedContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO deserializedObject = JsonConvert.DeserializeObject<DTO>(content);
            return deserializedObject;
        }

        public T Build <T>()
        {
            var resp = restClient.Execute(restRequest);
            var content = resp.Content;
            T deserializedObject = JsonConvert.DeserializeObject<T>(content);
            return deserializedObject;
        }

        public RestResponse SendRequest(string url, string endpoint, Method method
            , object payload = null, Dictionary<string , string > header = null, Dictionary<string , string> param  = null)
        {
            restClient = new RestClient();
            restRequest = new RestRequest(url + endpoint, method);
            if (payload != null)
            {
                restRequest.AddBody(payload);
            }

            if (header != null)
            {
                foreach (var key in header.Keys)
                {
                    restRequest.AddParameter(key, header[key]);
                }
            }

            if (param != null)
            {
                foreach (var key in param.Keys)
                {
                    restRequest.AddParameter(key, param[key]);
                }
            }
            return restClient.Execute(restRequest);
        }

        public T SendRequest <T>(string endpoint, Method method
           , object payload = null, Dictionary<string, string> header = null, Dictionary<string, string> param = null)
        {
            restClient = new RestClient();
            restRequest = new RestRequest(baseUrl + endpoint, method);
            if (payload != null)
            {
                restRequest.AddBody(payload);
            }

            if (header != null)
            {
                foreach (var key in header.Keys)
                {
                    restRequest.AddParameter(key, header[key]);
                }
            }

            if (param != null)
            {
                foreach (var key in param.Keys)
                {
                    restRequest.AddParameter(key, param[key]);
                }
            }
            return restClient.Execute<T>(restRequest).Data;
        }
    }
}
