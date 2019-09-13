using Newtonsoft.Json;
using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public class ApiService : IApiService
    {
        
        /// <summary>
        /// AAAAAAAaaaAAAAAA
        /// </summary>
        /// <returns></returns>
        public object CallBPM(string mobile, string zip, string street)
        {
            //BpmOnlineHttpRequest bpmRequest = new BpmOnlineHttpRequest { Phone = "+44444444" };
            string baseURL = @"https://0834202-se-m-se-demo.bpmonline.com/0/ServiceModel/EntityDataService.svc/ContactCollection";
            string Parameter = "(guid'4f62ba51-3eb5-4860-a1df-63f7047d23d3')";
            string URL = $"{baseURL}{Parameter}";
            
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
            webRequest.ContentType = "application/json;odata=verbose";
            webRequest.Method = "PUT";
            webRequest.Accept = "application/json;odata=verbose";
            webRequest.PreAuthenticate = true;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MobilePhone", mobile);
            parameters.Add("Zip", zip);
            parameters.Add("Address", street);

            var serialized = JsonConvert.SerializeObject(parameters);
            byte[] body = Encoding.UTF8.GetBytes(serialized);
            webRequest.ContentLength = body.Length;

            Stream requestStream = webRequest.GetRequestStream();
            requestStream.Write(body, 0, body.Length);
            requestStream.Close();

            //NetworkCredential credential = new NetworkCredential("Supervisor", "Supervisor");
            //CredentialCache cache = new CredentialCache();
            //cache.Add(new Uri(URL), "Basic", credential);
            //webRequest.Credentials = cache;

            string encodedAuthorization = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes("Supervisor:Supervisor"));
            webRequest.Headers.Add("Authorization", $"Basic {encodedAuthorization}");

            string read = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                read = reader.ReadToEnd();
                reader.Close();
            }

            return read;
        }
    }
}
