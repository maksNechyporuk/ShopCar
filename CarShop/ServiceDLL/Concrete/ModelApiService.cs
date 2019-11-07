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
  public  class ModelApiService : IModelService
    {
        private string _url = "https://localhost:44381/api/model";

        public string Create(ModelAddVM model)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = JsonConvert.SerializeObject(model);
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
        public Task<string> CreateAsync(ModelAddVM make)
        {
            return Task.Run(() => Create(make));
        }

        public string Delete(ModelDeleteVM model)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

            string parsedContent = JsonConvert.SerializeObject(model);
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

        public Task<string> DeleteAsync(ModelDeleteVM make)
        {
            return Task.Run(() => Delete(make));
        }


        public List<ModelVM> GetModels(string make)
        {
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<ModelVM>>(data);
            return list;
        }

        public Task<List<ModelVM>> GetModelsAsync(string make)
        {
            return Task.Run(() => GetModels(make));
        }
        public string Update(ModelVM model)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "PUT";

            string parsedContent = JsonConvert.SerializeObject(model);
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

        public Task<string> UpdateAsync(ModelVM make)
        {
            return Task.Run(() => Update(make));
        }
    }
}
