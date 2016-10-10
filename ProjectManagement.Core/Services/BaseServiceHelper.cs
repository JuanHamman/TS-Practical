using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Services
{
    public class BaseServiceHelper
    {
        public static async Task<T> DoPost<T>(object dto, string url, string token = "")
        {
            try
            {
                string json = dto == null ? null : JsonConvert.SerializeObject(dto);

                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        c.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                    }

                    using (HttpResponseMessage response = await c.PostAsync(url, json == null ? null : new StringContent(json, Encoding.UTF8, "application/json")))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception("Web Request Failed!");
                        }

                        string result = await response.Content.ReadAsStringAsync();
                        T resObj = JsonConvert.DeserializeObject<T>(result);
                        return resObj;
                    }
                }
            }
            catch (WebException we)
            {
                throw;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        public static async Task<T> DoGet<T>(object dto, string url, string token = "")
        {
            try
            {
                string json = dto == null ? null : JsonConvert.SerializeObject(dto);

                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        c.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                    }

                    using (HttpResponseMessage response = await c.GetAsync(url))
                    {
                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            throw new Exception("Web Request Failed!");
                        }

                        string result = await response.Content.ReadAsStringAsync();
                        T resObj = JsonConvert.DeserializeObject<T>(result);
                        return resObj;
                    }
                }
            }
            catch (WebException we)
            {
                throw;
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
