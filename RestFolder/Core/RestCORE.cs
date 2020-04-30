using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace Jenkins2.RestFolder.Core
{
	public abstract class RestCORE
	{
		private RestClient _restClient;
		private RestRequest _restRequest;
		private string _baseUrl = "https://reqres.in/";

		/// <summary>
		/// Set uri to bate url
		/// </summary>
		/// <param name="resourceUri"></param>
		protected RestClient SetUri(string resourceUri)
		{
			return _restClient = new RestClient(Path.Combine(_baseUrl, resourceUri));
		}

		/// <summary>
		/// Adds body parameters to request
		/// </summary>
		/// <param name="key">Key of the parameter</param>
		/// <param name="value">Parameters value</param>
		protected RestRequest AddParameter(string key, string value)
		{
			_restRequest.AddParameter(key, value);
			return _restRequest;
		}

		/// <summary>
		/// Creates post request
		/// </summary>
		protected RestRequest CreatePostRequest()
		{
			_restRequest = new RestRequest(Method.POST);
			_restRequest.AddHeader("Accept", "application/json");
			return _restRequest;
		}

		/// <summary>
		/// Creates patch request
		/// </summary>
		protected RestRequest CreatePatchRequest()
		{
			_restRequest = new RestRequest(Method.PATCH);
			_restRequest.AddHeader("Accept", "application/json");
			return _restRequest;
		}

		/// <summary>
		/// Execute request and return response from server
		/// </summary
		public IRestResponse GetResponse()
		{
			return _restClient.Execute(_restRequest);
		}

		/// <summary>
		/// Deserialize response from server into DTO
		/// </summary>
		public DTO GetContent<DTO>(IRestResponse response)
		{
			return JsonConvert.DeserializeObject<DTO>(response.Content);
		}
	}
}
