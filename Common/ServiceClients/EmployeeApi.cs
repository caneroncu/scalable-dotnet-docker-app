using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Common.Model;
using RestSharp;

namespace scalable_web_api
{
    public interface IEmployeeApi
    {
        Task<List<Employee>> GetEmployees();
    }

    public class EmployeeApi : IEmployeeApi
    {
        public async Task<List<Employee>> GetEmployees()
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");

            var content2 = await client.GetStringAsync("https://scalable-web-app");

            Console.WriteLine(content2);

            var content = await client.GetStringAsync("https://scalable-web-api/employee");

            Console.WriteLine(content);

            var client2 = new RestClient("https://scalable-web-api");
            var request = new RestRequest("employee/", Method.GET);
            var queryResult = client2.Execute<List<Employee>>(request).Data;

            return queryResult;
        }
    }
}