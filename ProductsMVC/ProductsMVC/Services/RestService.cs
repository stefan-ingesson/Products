using Newtonsoft.Json;
using ProductsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ProductsMVC.Services
{
    public class RestService
    {
        readonly string uri = "http://localhost:65184//API/Products/";

        public async Task<List<Product>> GetProductsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<List<Product>>(
                    await httpClient.GetStringAsync(uri)
                    );
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {


            using (HttpClient httpClient = new HttpClient())
            {
                return JsonConvert.DeserializeObject<Product>(
                    await httpClient.GetStringAsync(uri + id.ToString()));
            }
        }






       

         
        //using (HttpClient httpClient = new HttpClient())
        //{
        //    Task<String> response = httpClient.GetStringAsync(baseuri);
        //    return JsonConvert.DeserializeObjectAsync<Car>(response.Result).Result;
        //}
            

    }
}