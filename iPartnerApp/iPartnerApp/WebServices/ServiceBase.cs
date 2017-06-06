using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Plugin.Connectivity;
using iPartnerApp.WebServices.Responses;

namespace iPartnerApp
{

    public class ServiceBase
    {
		protected string BaseUrl = "http://www.gmggasbooking.com/";

        public async Task<T> MakePostRequest<T>(string url, string serializedDataString, bool isJson = true)
            where T : Response
        {
            using (var client = new HttpClient())
            using (
                var response =
                    await
                        client.PostAsync(url, new StringContent(serializedDataString, Encoding.UTF8, isJson? "application/json" : ""))
                )
            using (var content = response.Content)
            {
                // ... Read the string.
                var result = content.ReadAsStringAsync().Result;

                var respe = JsonConvert.DeserializeObject<T>(result);
                return respe;
            }
        }
       
        public async Task<T> MakePostRequestUrlEncodedAsync<T>(string url, List<KeyValuePair<string, string>> keyValues)
		{
			if (!CrossConnectivity.Current.IsConnected)
				return default(T);
			using (var client = new HttpClient())
			using (
				var response =
				await
				client.PostAsync(url, new FormUrlEncodedContent(keyValues))
			)
			using (var content = response.Content)
			{
				// ... Read the string.
				var result = content.ReadAsStringAsync().Result;
                try
                {
                    var respe = JsonConvert.DeserializeObject<T>(result);
                    return respe;
                }
                catch {
                    return Activator.CreateInstance<T>();
                }
			}
		}

        public T MakeGetRequest<T>(string url) where T : Response
        {
            using (var client = new HttpClient())
            using (
                var response =
                    client.GetAsync(url)
                        .Result)
            using (var content = response.Content)
            {
                // ... Read the string.
                var result = content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public string SerializeContent(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }

        public object DeserializeContent<T>(string stringToDeserialize)
        {
            var ser = new DataContractJsonSerializer(typeof (List<T>));
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(stringToDeserialize));
            return (List<T>) ser.ReadObject(stream);
        }
    }

    


    /*public class Login :Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string ErrorNo { get; set; }
    }

	public class Logout :Response
	{
		public string Status { get; set; }
		public string Message { get; set; }
		public string ErrorNo { get; set; }
	}

    public class Home : Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string ErrorNo { get; set; }
    }

    public class SignUp :Response
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string ErrorNo { get; set; }
    }*/
}
