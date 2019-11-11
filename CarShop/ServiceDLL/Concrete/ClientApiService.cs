using Newtonsoft.Json;
using ServiceDLL.Interfaces;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Concrete
{
    public class ClientApiService : IClientService
    {
        private string _url = "https://localhost:44381/api/clients";

       public string Create(ClientAddVM client)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = JsonConvert.SerializeObject(client);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;          
        }
        public Task<string> CreateAsync(ClientAddVM client)
        {
            return Task.Run(() => Create(client));
        }

        public string Delete(ClientDeleteVM client)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

            string parsedContent = JsonConvert.SerializeObject(client);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }
        public Task<string> DeleteAsync(ClientDeleteVM client)
        {
            return Task.Run(() => Delete(client));
        }
        public List<ClientVM> GetClients(ClientVM client)
        {
            if (client == null)
            {
                var webclient = new WebClient();
                webclient.Encoding = ASCIIEncoding.UTF8;
                string data = webclient.DownloadString(_url);
                var list = JsonConvert.DeserializeObject<List<ClientVM>>(data);
                return list;
            }
            else
            {
                string _url = "https://localhost:44381/api/clients/search/?";
                var webclient = new WebClient();
                webclient.Encoding = ASCIIEncoding.UTF8;
                string data = webclient.DownloadString(_url + $"Name={client.Name}&Phone={client.Phone}&Email={client.Email}");
                var list = JsonConvert.DeserializeObject<List<ClientVM>>(data);
                return list;
            }
        }
        public Task<List<ClientVM>> GetClientsAsync(ClientVM client)
        {
            return Task.Run(() => GetClients(client));
        }

        public string Update(ClientVM client)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "PUT";

            string parsedContent = JsonConvert.SerializeObject(client);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content;
        }
        public Task<string> UpdateAsync(ClientVM client)
        {
            return Task.Run(() => Update(client));
        }

    }
}
