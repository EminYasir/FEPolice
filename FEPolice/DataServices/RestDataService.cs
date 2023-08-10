using FEPolice.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FEPolice.DataServices
{
    public class RestDataService : IRestDataService
    {
        private HttpClient _httpClient;
        private readonly string _baseAddress;
        private readonly string _url;
        private readonly JsonSerializerOptions _jsonSerializeroptions;
        Person user;
        public RestDataService()
        {

            _httpClient = CreateHttpClient();

            _baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5047" : "https://localhost:7267";
            _url = $"{_baseAddress}/api";

            _jsonSerializeroptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }
        public HttpClient CreateHttpClient()
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicysErrors) =>
                {
                    return true;
                }
            };

            return new HttpClient(httpClientHandler);
        }

        public async Task AddPolicysAsync(Model.Policys police)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonPolicys = System.Text.Json.JsonSerializer.Serialize<Policys>(police, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonPolicys, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PostAsync($"{_url}/Policys", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task AddPersonAsync(Model.Person user)
        {

            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonUser = System.Text.Json.JsonSerializer.Serialize<Model.Person>(user, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PostAsync($"{_url}/Person", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task DeletePolicysAsync(int PolicysNumber)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------> No Internet Access");
                return;
            }
            try
            {
                HttpResponseMessage message = await _httpClient.DeleteAsync($"{_url}/Policys/{PolicysNumber}");
                if (message.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task DeletePersonAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------> No Internet Access");
                return;
            }
            try
            {
                HttpResponseMessage message = await _httpClient.DeleteAsync($"{_url}/Person/{id}");
                if (message.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task<List<Policys>> GetAllPolicysAsync()
        {
            List<Policys> policysList = new List<Policys>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");
                return policysList;
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Policys");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    policysList = System.Text.Json.JsonSerializer.Deserialize<List<Policys>>(content, _jsonSerializeroptions);
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return policysList;
        }

        public async Task<List<Person>> GetAllPersonAsync()
        {
            List<Model.Person> users = new List<Person>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return users;
            }
            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Person");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();

                    users = System.Text.Json.JsonSerializer.Deserialize<List<Model.Person>>(content, _jsonSerializeroptions);

                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }

            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
            return users;
        }

        public async Task<Model.Policys> GetPolicysByNumberAsync(int PolicysNumber)
        {
            Model.Policys police = null;
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");
                return police;
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Policys/{PolicysNumber}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    police = System.Text.Json.JsonSerializer.Deserialize<Model.Policys>(content, _jsonSerializeroptions);
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return police;
        }

        public async Task<Model.Person> GetPersonByIdAsync(int userId)
        {
            Model.Person user = null;
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");
                return user;
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Person/{userId}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    user = System.Text.Json.JsonSerializer.Deserialize<Model.Person>(content, _jsonSerializeroptions);
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return user;
        }

        public async Task UpdatePolicysAsync(Model.Policys police)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonPolice = System.Text.Json.JsonSerializer.Serialize<Model.Policys>(police, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonPolice, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PutAsync($"{_url}/Policys/{police.PolicyNumber}", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task UpdatePersonAsync(Model.Person user)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonUser = System.Text.Json.JsonSerializer.Serialize<Model.Person>(user, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PutAsync($"{_url}/Person{user.PersonId}", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }

        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            List<Product> productList = new List<Product>();
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");
                return productList;
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Product");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    productList = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(content, _jsonSerializeroptions);
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return productList;
        }

        public async Task<Product> GetProductByNumberAsync(int id)
        {
            Product product = null;
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");
                return product;
            }

            try
            {
                HttpResponseMessage httpResponse = await _httpClient.GetAsync($"{_url}/Product/{id}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    string content = await httpResponse.Content.ReadAsStringAsync();
                    product = System.Text.Json.JsonSerializer.Deserialize<Product>(content, _jsonSerializeroptions);
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return product;
        }

        public async Task AddProductAsync(Product product)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonPolicys = System.Text.Json.JsonSerializer.Serialize<Product>(product, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonPolicys, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PostAsync($"{_url}/Product", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------> No Internet Access");
                return;
            }
            try
            {
                HttpResponseMessage message = await _httpClient.DeleteAsync($"{_url}/Product/{id}");
                if (message.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("-----> No Internet");

                return;
            }
            try
            {
                string jsonPolice = System.Text.Json.JsonSerializer.Serialize<Product>(product, _jsonSerializeroptions);
                StringContent content = new StringContent(jsonPolice, Encoding.UTF8, "application/json");

                HttpResponseMessage responseMessage = await _httpClient.PutAsync($"{_url}/Policys/{product.ProductId}", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }
        }

        public async Task<Person> LoginAsync(string kullaniciAdi, string password)
        {
            
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                Debug.WriteLine("------> No Internet Access");
                return null;
            }

            var model = new LoginM { KullaniciAdi = kullaniciAdi, Password = password };

            Person p = new Person();
            try
            {
                HttpResponseMessage message = await _httpClient.PostAsJsonAsync($"{_url}/Person/login", model);

                if (message.IsSuccessStatusCode)
                {
                    var responseContent = await message.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(responseContent);

                    JObject userObject = (JObject)responseObject["user"];
                    user = userObject.ToObject<Person>();
                    Debug.WriteLine("Succesfully created User");
                }
                else
                {
                    Debug.WriteLine("-----> Non Http 2xx response");

                }
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"Whoops :{ex.Message}");
            }

            return user;
        }
    }
}
