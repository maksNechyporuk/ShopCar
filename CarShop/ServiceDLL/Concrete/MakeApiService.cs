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
  public  class MakeApiService : IMakeService
    {
        private string _url = "https://localhost:44381/api/make";

        public string Create(MakeAddModel make)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = JsonConvert.SerializeObject(make);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content.ToString();
        }

        public Task<string> CreateAsync(MakeAddModel make)
        {
            return Task.Run(() => Create(make));
        }

        public string Delete(MakelDeleteVM make)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

            string parsedContent = JsonConvert.SerializeObject(make);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();
            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content.ToString();
        }

        public Task<string> DeleteAsync(MakelDeleteVM make)
        {
            return Task.Run(() => Delete(make));
        }

        public int GetMakeByModels(int model)
        {
            string _url = $"https://localhost:44381/api/filters/GetMakeByModels?id={model}";
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<int>(data);
            return list;
        }

        public Task<int> GetMakeByModelsAsync(int model)
        {
            return Task.Run(() => GetMakeByModelsAsync(model));
        }

        public List<MakeVM> GetMakes(string make)
        {
            if (make == "")
            {
                var client = new WebClient();
                client.Encoding = ASCIIEncoding.UTF8;
                string data = client.DownloadString(_url);
                var list = JsonConvert.DeserializeObject<List<MakeVM>>(data);
                return list;
            }
            else
            {
                string path = "?Name=" + make;
                string _url = @"https://localhost:44381/api/make/" + path;
                var client = new WebClient();
                client.Encoding = ASCIIEncoding.UTF8;
                string data = client.DownloadString(_url);
                var list = JsonConvert.DeserializeObject<List<MakeVM>>(data);
                return list;
            }
        }

        public Task<List<MakeVM>> GetMakesAsync(string make = null)
        {
            return Task.Run(() => GetMakes(make)); 
        }       
        public string Update(MakeVM make)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "PUT";

            string parsedContent = JsonConvert.SerializeObject(make);
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] bytes = encoding.GetBytes(parsedContent);
            Stream newStream = http.GetRequestStream();
            newStream.Write(bytes, 0, bytes.Length);
            newStream.Close();

            var response = http.GetResponse();
            var stream = response.GetResponseStream();
            var sr = new StreamReader(stream);
            var content = sr.ReadToEnd();
            return content.ToString(); 

        }

        public Task<string> UpdateAsync(MakeVM make)
        {
            return Task.Run(() => Update(make));

        }
    }
}
