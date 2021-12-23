using CarRental.Models;
using CarRental.ViewModel;
using LeaveClient.Base.Urls;
using LeaveClient.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalClient.Repository.Data
{
    public class RentRepository : GeneralRepository<Rent, int>
    {
        private readonly Address address;
        private readonly HttpClient httpClient;
        private readonly string request;

        public RentRepository(Address address, string request = "Rents/") : base(address, request)
        {
            this.address = address;
            this.request = request;
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address.link)
            };
        }

        public HttpStatusCode Post(RentVM entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address.link + request + "AddRental", content).Result;
            return result.StatusCode;
        }
        public async Task<List<RentVM>> GetRental(string id)
        {
            List<RentVM> entities = new List<RentVM>();

            using (var response = await httpClient.GetAsync(request + "GetIdRental/" + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<List<RentVM>>(apiResponse);
            }
            return entities;
        }
    }
}
