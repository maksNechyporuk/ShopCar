﻿using Newtonsoft.Json;
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
    public class CarApiService : ICarService
    {
        private string _url = "https://localhost:44381/api/cars";

        public string Create(CarAddVM model)
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
            return content.ToString();
        }

        public Task<string> CreateAsync(CarAddVM model)
        {
            return Task.Run(() => Create(model));
        }

        public string Delete(CarDeleteVM model)
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
            return content.ToString();
        }

        public Task<string> DeleteAsync(CarDeleteVM model)
        {
            return Task.Run(() => Delete(model));
        }

        public List<CarsByFilterVM> GetCars()
        {
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<CarsByFilterVM>>(data);
            return list;
        }

        public Task<List<CarsByFilterVM>> GetCarsAsync()
        {
            return Task.Run(() => GetCars());
        }

        public List<CarsByFilterVM> GetCarsByFilters(int[] id)
        {
        
            string path = "?value=" + id[0];
            for (int i = 1; i < id.Length; i++)
            {
                path += "&value=" + id[i];
            }
            string _url = @"https://localhost:44381/api/cars/CarsByFilter/" + path;
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<CarsByFilterVM>>(data);
            return list;
        }

        public Task<List<CarsByFilterVM>> GetCarsByFiltersAsync(int[] id)
        {
            if (id.Length ==0)
            return Task.Run(() => GetCars()); 
            return Task.Run(() => GetCarsByFilters(id));
        }

        public CarVM GetCarsByName(string Name)
        {
            string path = "?name=" + Name;           
            string _url = @"https://localhost:44381/api/cars/CarsByName/" + path;
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var car = Newtonsoft.Json.JsonConvert.DeserializeObject<CarVM>(data);
            return car;
        }

        public Task<CarVM> GetCarsByNameAsync(string Name)
        {
            return Task.Run(() => GetCarsByName(Name));
        }

        public List<string> GetImagesBySize(string path, string size)
        {
            var url = $"https://localhost:44381/api/carsimages/?path={path}/Photo&size={size}";

            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(url);
            var imgs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<string>>(data);
            return imgs;
        }

        public Task<List<string>> GetImagesBySizeAsync(string path, string size)
        {
            return Task.Run(() => GetImagesBySize(path, size));
        }

        public List<FNameViewModel> GetModelsByMake(int id)
        {
            string path = "?id=" + id;         
            string _url = @"https://localhost:44381/api/filters/GetModelsByMake" + path;
            var client = new WebClient();
            client.Encoding = ASCIIEncoding.UTF8;
            string data = client.DownloadString(_url);
            var list = JsonConvert.DeserializeObject<List<FNameViewModel>>(data);
            return list;
        }

        public List<FNameViewModel> GetModelsByMakeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public string Update(CarVM model)
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
            return content.ToString();
        }

        public Task<string> UpdateAsync(CarVM model)
        {
            return Task.Run(() => Update(model));
        }
    }
}
