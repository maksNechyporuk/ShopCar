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
    public class UserApiService : IUserService
    {
        private string _url = "https://localhost:44356/api/users";

        public List<UserVM> GetUser()
        {
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<UserVM>>(data);
            return list;
        }

        public Task<List<UserVM>> GetUserAsync()
        {
            return Task.Run(() => GetUser());
        }

        public int Login(UserLoginVM user)
        {
            try
            {
                var http = (HttpWebRequest)WebRequest.Create(new Uri(_url + "/login"));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";

                string parsedContent = JsonConvert.SerializeObject(user);
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }

        public int Register(UserRegisterVM user)
        {
            try
            {
                var http = (HttpWebRequest)WebRequest.Create(new Uri(_url + "/register"));
                http.Accept = "application/json";
                http.ContentType = "application/json";
                http.Method = "POST";

                string parsedContent = JsonConvert.SerializeObject(user);
                UTF8Encoding encoding = new UTF8Encoding();
                Byte[] bytes = encoding.GetBytes(parsedContent);
                Stream newStream = http.GetRequestStream();
                newStream.Write(bytes, 0, bytes.Length);
                newStream.Close();

                var response = http.GetResponse();
                var stream = response.GetResponseStream();
                var sr = new StreamReader(stream);
                var content = sr.ReadToEnd();
            }
            catch (Exception)
            {
                return 0;
            }
            return 1;
        }
    }
}
