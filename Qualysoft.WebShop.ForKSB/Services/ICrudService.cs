
using Qualysoft.WebShop.ForKSB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public interface ICrudService
    {
        Task<ICollection<Product>> GetProducts();
        Task<Account> Login(string email, string password);
        Task<Account> Register(string username,string password,string email);
        Task<int> CreateRelation(int visitorId , int productId);
        Task<int> AddToCart(int userId, int productId);
        Task<List<Product>> GetMyProducts(int userId);
        Task<Account> GetAccountDetails(int id);
    }
}
