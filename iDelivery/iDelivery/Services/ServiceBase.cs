using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using iDelivery.Services;

namespace iDelivery
{

    public abstract class ServiceBase
    {
		protected string BaseUrl = "http://www.jaimayakali.com/";

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


		public async Task<T> MakePostRequestUrlEncoded<T>(string url, List<KeyValuePair<string, string>> keyValues)
		{
            using (var client = new HttpClient())
            using (
                var response =
                    await client.PostAsync(url, new FormUrlEncodedContent(keyValues)))
            using (var content = response.Content)
            {
                try
                {
                    //deserialize object
                    return JsonConvert.DeserializeObject<T>(content.ReadAsStringAsync().Result);
                }
                catch (Exception ex)
                {
                    return Activator.CreateInstance<T>();
                }
            }
		}
        /// <summary>
        /// Костылирование получения результата
        /// </summary>
        public async Task<T> MakePostRequestUrlEncodedWithCostyl<T>(string url, List<KeyValuePair<string, string>> keyValues)
        {
            using (var client = new HttpClient())
            using (
                var response =
                    await client.PostAsync(url, new FormUrlEncodedContent(keyValues)))
            using (var content = response.Content)
            {
                try
                {
                    // ... Read the string.
                    var result = content.ReadAsStringAsync().Result;
                    if (!string.IsNullOrEmpty(result))
                    {
                        result = result.Replace("[[", "[").Replace(",null", string.Empty).Replace("}],", "},").Replace(",[{", ",{").Replace("]]", "]");
                    }
                    var respe = JsonConvert.DeserializeObject<T>(result);
                    return respe;
                }
                catch (Exception ex)
                {
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

   
}
