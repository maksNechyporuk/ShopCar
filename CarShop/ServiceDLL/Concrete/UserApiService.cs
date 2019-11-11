using Newtonsoft.Json;
using ServiceDLL.Data;
using ServiceDLL.Interfaces;
using ServiceDLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
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

        public List<UserVM> GetUser(UserVM user)
        {
            if (user == null)
            {
                var client = new WebClient();
                client.Encoding = ASCIIEncoding.UTF8;
                string data = client.DownloadString(_url);
                var list = JsonConvert.DeserializeObject<List<UserVM>>(data);
                return list;
            }
            else
            {
                string _url = "https://localhost:44381/api/user/search/?";
                var client = new WebClient();
                client.Encoding = ASCIIEncoding.UTF8;
                string data = client.DownloadString(_url+$"Name={user.Name}&Email={user.Email}");
                var list = JsonConvert.DeserializeObject<List<UserVM>>(data);
                return list;
            }
        }

        public Task<List<UserVM>> GetUserAsync(UserVM user)
        {
            return Task.Run(() => GetUser(user));
        }

        public string Login(UserLoginVM user)
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
            //DbConnection connection = GetConnection("jon");
            using (var context = new EFContext())
            {
                Credential credential = new Credential
                {
                    Token = tokenObject.token,
                    DateCreate = DateTime.Now,
                    DateExtToken = 12342134,
                    UserName=tokenS.Claims.ToArray()[1].Value
                };
                context.Credentials.Add(credential);
                //context.Dependants.Add(new Dependant() { Description = "Dependant description", MainEntity = new EF6.Migrations.Test.Model01.Entity() { Description = "Entity description" } });
                context.SaveChanges();

            }
            return content;
        }

        private DbConnection GetConnection(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName + ".db3");
            DbConnection connection = new SQLiteConnection(string.Format("Data Source={0};Version=3;", filePath));
            return connection;
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
            var tokenObject = JsonConvert.DeserializeAnonymousType(content, new
            {
                token = ""
            });

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(tokenObject.token);
            var tokenS = handler.ReadToken(tokenObject.token) as JwtSecurityToken;
            //DbConnection connection = GetConnection("jon");
            using (var context = new EFContext())
            {
                Credential credential = new Credential
                {
                    Token = tokenObject.token,
                    DateCreate = DateTime.Now,
                    DateExtToken = 12342134,
                    UserName = tokenS.Claims.ToArray()[1].Value
                };
                context.Credentials.Add(credential);
                //context.Dependants.Add(new Dependant() { Description = "Dependant description", MainEntity = new EF6.Migrations.Test.Model01.Entity() { Description = "Entity description" } });
                context.SaveChanges();

            }
            return content;
        }

        public Task<string> RegisterAsync(UserRegisterVM user)
        {
            return Task.Run(() => Register(user));
        }

        public string Delete(UserDeleteVM user)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "DELETE";

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
            return content.ToString();
        }

        public Task<string> DeleteAsync(UserDeleteVM user)
        {
            return Task.Run(() => Delete(user));
        }

        public string Update(UserUpdateVM user)
        {
            var http = (HttpWebRequest)WebRequest.Create(new Uri(_url));
            http.Accept = "application/json";
            http.ContentType = "application/json";
            http.Method = "PUT";

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
            return content.ToString();
        }

        public Task<string> UpdateAsync(UserUpdateVM user)
        {
            return Task.Run(() => Update(user));
        }
    }
}
