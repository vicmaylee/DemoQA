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
    public class APIAssignment
    {
        //create global variable

        private RestClient restClient;
        private RestRequest restRequest;
        private string baseUrl = "http://localhost:3000/fixtures";
        

        public RestClient SetUrl()
        {
            restClient = new RestClient(baseUrl);
            return restClient;
        }

        public RestRequest GetRequest(string endpoint, Method method)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json"); 
            return restRequest; 
        }

        public RestRequest DeleteRequest(string endpoint, Method method, object payload)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody(payload);
            return restRequest;
        }

        public RestRequest PostRequest(string endpoint, Method method, object payload)
        {
            restRequest = new RestRequest(endpoint, method);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", restRequest.AddJsonBody(payload),
                ParameterType.RequestBody);
            restRequest.AddJsonBody(payload);
            return restRequest;
        }

        public RestResponse GetResponse(RestClient client, RestRequest request)
        {
          
            return client.Execute(request);
        }

        public DTO GetDeserializedContent<DTO>(RestResponse response)
        {
            var content = response.Content;
            DTO deserializedObject = JsonConvert.DeserializeObject<DTO>(response.Content);
            return deserializedObject;
        }
    }
}
