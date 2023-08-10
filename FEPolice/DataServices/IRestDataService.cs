using FEPolice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FEPolice.DataServices
{
    public interface IRestDataService
    {
        Task<List<Person>> GetAllPersonAsync();
        Task<Person> GetPersonByIdAsync(int userId);
        Task AddPersonAsync(Person user);
        Task DeletePersonAsync(int id);
        Task UpdatePersonAsync(Person user);
        Task<Person> LoginAsync(string kullaniciAdi, string password);

        Task<List<Policys>> GetAllPolicysAsync();
        Task<Policys> GetPolicysByNumberAsync(int policyNumber);
        Task AddPolicysAsync(Policys policy);
        Task DeletePolicysAsync(int policyNumber);
        Task UpdatePolicysAsync(Policys policy);


        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetProductByNumberAsync(int id);
        Task AddProductAsync(Product product);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(Product product);
    }
}
