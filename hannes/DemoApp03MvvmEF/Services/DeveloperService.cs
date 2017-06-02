using Interfaces;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DeveloperServiceDummy : IDeveloperService
    {
        private IList<Developer> _devs;

        public DeveloperServiceDummy()
        {
            IList<Developer> ld = new List<Developer>();

            for ( int i = 0; i < 100; i++ )
            {
                Developer d = new Developer();

                d.Name = $"Developer {i}";
                d.EMail = $"developer{i}@demo.com";
                
                ld.Add(d);
            }

            _devs = ld;
        }

        public Task<Developer> AddDeveloperAsync(Developer dev) => throw new NotImplementedException();

        public Task<IEnumerable<Developer>> GetDevelopersAsync() => Task.FromResult<IEnumerable<Developer>>(_devs);
    }

    public class DeveloperService : IDeveloperService
    {
        private HttpClient _client;
        public DeveloperService()
        {
            _client = new HttpClient();
        }

        private const string _uri = "http://localhost:50353/api/Developers";

        public async Task<Developer> AddDeveloperAsync(Developer dev)
        {
            string json = JsonConvert.SerializeObject(dev);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _client.PostAsync(_uri, content);
            resp.EnsureSuccessStatusCode();
            string resultjson = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Developer>(resultjson);
        }

        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
        {
            HttpResponseMessage resp = await _client.GetAsync(_uri);

            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();
            IEnumerable<Developer> devs = JsonConvert.DeserializeObject<IEnumerable<Developer>>(json);
            return devs;
        }
    }

}
