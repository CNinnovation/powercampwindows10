using System;
using System.Collections.Generic;
using System.Text;
using BooksLib.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BooksLib.Services
{
    public class HttpBooksService : IBooksService
    {
        private HttpClient _client;
        public HttpBooksService()
        {
            _client = new HttpClient();
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            string json = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _client.PostAsync("http://localhost:52663/api/Books", content);
            resp.EnsureSuccessStatusCode();
            string resultjson = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Book>(resultjson);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            HttpResponseMessage resp = await _client.GetAsync("http://localhost:52663/api/Books");

            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();
            IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            return books;
        }
    }
}
