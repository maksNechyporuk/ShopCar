using Newtonsoft.Json;
using ServiceDLL.Interfaces;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDLL.Concrete
{
    public class UserApiService : IUserService
    {
        private string _url = "https://localhost:44381/api/user";

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

        public string Login(UserLoginVM user)
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
                var tokenObject = JsonConvert.DeserializeAnonymousType(content, new
                {
                    token = ""
                });

                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(tokenObject.token);
                var tokenS = handler.ReadToken(tokenObject.token) as JwtSecurityToken;
                return "";
                //foreach (var item in tokenS.Claims)
                //{
                //    MessageBox.Show($"{item.Value}", item.Type);
                //}
                //MessageBox.Show(token);
            }
            catch (WebException wex)
            {
                string returnMess = "";
                if (wex.Response != null)
                {
                    using (var errorResponse = (HttpWebResponse)wex.Response)
                    {
                        using (var reader = new StreamReader(errorResponse.GetResponseStream()))
                        {
                            var error = reader.ReadToEnd();
                            var mes = JsonConvert.DeserializeAnonymousType(error, new
                            {
                                invalid = ""
                            });
                            returnMess = mes.invalid;
                        }
                    }
                }
                return returnMess;
            }
        }

        public Task<string> LoginAsync(UserLoginVM user)
        {
            return Task.Run(() => Login(user));
        }

        public string Register(UserRegisterVM user)
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
            return content;
        }

        public Task<string> RegisterAsync(UserRegisterVM user)
        {
            return Task.Run(() => Register(user));
        }
    }
}
