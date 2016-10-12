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
                string json = dto == null ? null : JsonConvert.SerializeObject(dto, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd" });

                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        c.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                    }

                    using (HttpResponseMessage response = await c.PostAsync(url, json == null ? null : new StringContent(json, Encoding.UTF8, "application/json")))
                    {
                        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created )
                        {
                            string exceptionMessage = await response.Content.ReadAsStringAsync();
                            throw new Exception(exceptionMessage);
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
                            string exceptionMessage = await response.Content.ReadAsStringAsync();
                            throw new Exception(exceptionMessage);
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

        public static async Task DoDelete(string url, string token = "")
        {
            try
            {
                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        c.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                    }

                    using (HttpResponseMessage response = await c.DeleteAsync(url))
                    {
                        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
                        {
                            string exceptionMessage = await response.Content.ReadAsStringAsync();
                            throw new Exception(exceptionMessage);
                        }

                        string result = await response.Content.ReadAsStringAsync();
                        string res2 = result;
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

        public static async Task<T> DoPut<T>(object dto, string url, string token = "")
        {
            try
            {
                string json = dto == null ? null : JsonConvert.SerializeObject(dto, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd" });

                using (HttpClient c = new HttpClient())
                {
                    c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(token))
                    {
                        c.DefaultRequestHeaders.Add("Authorization", "Token " + token);
                    }

                    using (HttpResponseMessage response = await c.PutAsync(url, json == null ? null : new StringContent(json, Encoding.UTF8, "application/json")))
                    {
                        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Created)
                        {
                            string exceptionMessage = await response.Content.ReadAsStringAsync();
                            throw new Exception(exceptionMessage);
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
