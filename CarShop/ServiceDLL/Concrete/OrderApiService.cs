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
   public class OrderApiService : IOrderService
    {
        private string _url = "https://localhost:44381/api/orders";

        public string Create(OrderAddVM name)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "POST";

            string parsedContent = JsonConvert.SerializeObject(name);
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

        public Task<string> CreateAsync(OrderAddVM filter)
        {
            return Task.Run(() => Create(filter));
        }

        public List<OrderShowVM> GetOrders()
        {
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<OrderShowVM>>(data);
            return list;
        }

        public Task<List<OrderShowVM>> GetOrdersAsync()
        {
            return Task.Run(() => GetOrders());
        }
    }
}
