using API.Model;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class BookRepository
    {
        private readonly string request;
        private readonly HttpClient httpClient;

        public BookRepository(string request = "Book/")
        {
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7173/api/")
            };
        }
        public async Task<ResponseDataVM<List<Book>>> Get()
        {
            ResponseDataVM<List<Book>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Book>>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Book>> Get(string id)
        {
            ResponseDataVM<Book> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Book>>(apiResponse);
            }
            return entity;
        }

        public async Task<ResponseDataVM<Book>> Post(Book book)
        {
            ResponseDataVM<Book> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PostAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Book>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Book>> Put(Book book)
        {
            ResponseDataVM<Book> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");
            using (var response = await httpClient.PutAsync(request, content))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Book>>(apiResponse);
            }
            return entityVM;
        }

        public async Task<ResponseDataVM<Book>> Delete(string id)
        {
            ResponseDataVM<Book> entityVM = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<Book>>(apiResponse);
            }
            return entityVM;
        }
    }
}