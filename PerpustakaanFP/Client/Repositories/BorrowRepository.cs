using API.Model;
using API.Models;
using API.ViewModels;
using Newtonsoft.Json;
using System.Text;

namespace Client.Repositories
{
    public class BorrowRepository
    {
        private readonly string request;
        private readonly HttpContextAccessor contextAccessor;
        private readonly HttpClient httpClient;
        public BorrowRepository(string request = "Borrow/")
        {
            this.request = request;
            contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7173/api/")
            };
        }
        public async Task<ResponseDataVM<List<Borrow>>> Get()
        {
            ResponseDataVM<List<Borrow>> entityVM = null;
            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<List<Borrow>>>(apiResponse);
            }
            return entityVM;
        }
        //create
        public async Task<ResponseDataVM<string>> Post(Borrow borrow)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(borrow), Encoding.UTF8, "application/json");
            using (var response = httpClient.PostAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }
        //GetbyID
        public async Task<ResponseDataVM<Borrow>> Get(int id)
        {
            ResponseDataVM<Borrow> entity = null;

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Borrow>>(apiResponse);
            }
            return entity;
        }

        //Put - Edit
        public async Task<ResponseDataVM<string>> Put(int id, Borrow borrow)
        {
            ResponseDataVM<string> entityVM = null;
            StringContent content = new StringContent(JsonConvert.SerializeObject(borrow), Encoding.UTF8, "application/json");
            using (var response = httpClient.PutAsync(request, content).Result)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entityVM = JsonConvert.DeserializeObject<ResponseDataVM<string>>(apiResponse);
            }
            return entityVM;
        }

        //Delete
        public async Task<ResponseDataVM<Borrow>> Delete(int id)
        {
            ResponseDataVM<Borrow> entity = null;

            using (var response = await httpClient.DeleteAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<ResponseDataVM<Borrow>>(apiResponse);
            }
            return entity;
        }
    }
}