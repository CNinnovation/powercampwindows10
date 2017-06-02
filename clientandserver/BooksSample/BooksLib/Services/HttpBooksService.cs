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
        private const string booksUrl = "http://etcbooksservice.azurewebsites.net/api/Books";
        private HttpClient _client;
        public HttpBooksService()
        {
            _client = new HttpClient();
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            string json = JsonConvert.SerializeObject(book);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _client.PostAsync(booksUrl, content);
            resp.EnsureSuccessStatusCode();
            string resultjson = await resp.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Book>(resultjson);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            HttpResponseMessage resp = await _client.GetAsync(booksUrl);

            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();
            IEnumerable<Book> books = JsonConvert.DeserializeObject<IEnumerable<Book>>(json);
            return books;
        }
    }
}
