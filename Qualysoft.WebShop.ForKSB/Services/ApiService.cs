using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public class ApiService : IApiService
    {
        
        /// <summary>
        /// AAAAAAAaaaAAAAAA
        /// </summary>
        /// <returns></returns>
        public object CallBPM()
        {
            BpmOnlineHttpRequest bpmRequest = new BpmOnlineHttpRequest { Phone = "+31923912939" };
            string baseURL = @"https://2-4101138-se-m-se-demo.bpmonline.com/0/ServiceModel/EntityDataService.svc/ContactCollection";
            string Parameter = "(guid'c38d46fd-e405-491a-a508-01bb9760eecc')";
            string URL = $"{baseURL}{Parameter}";

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
            webRequest.ContentType = "application/json;odata=verbose";
            webRequest.Method = "PUT";
            webRequest.Accept = "application/json;odata=verbose";
            NetworkCredential credential = new NetworkCredential("Supervisor", "Supervisor");
            CredentialCache cache = new CredentialCache();
            cache.Add(new Uri(URL), "Basic", credential);
            webRequest.Credentials = cache;
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
