using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Qualysoft.WebShop.ForKSB.Database;
using Qualysoft.WebShop.ForKSB.Models;

namespace Qualysoft.WebShop.ForKSB.Services
{
    public class CrudService : ICrudService
    {

        private QualysoftContext _context;

        public CrudService(QualysoftContext context)
        {
            _context = context;
        }

        public async Task<int> CreateRelation(int visitorId, int productId)
        {
            RelationProducts relation = new RelationProducts
            {
                ProductId = productId,
                Visitor = visitorId
            };
            await _context.Relations.AddAsync(relation);
            return await _context.SaveChangesAsync();
        }
        public async Task<ICollection<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Account> Login(string password, string email)
        {
            var response = await _context.Accounts.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
            return response;
        }

        public async Task<Account> Register(string username, string password, string email)
        {
            Account visitor = new Account { Email = email, Username = username, Password = password };
            if (await _context.Accounts.AnyAsync(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Username already in use");
            else if (await _context.Accounts.AnyAsync(x => x.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
                throw new Exception("Email already in use");
            else
            {
                await _context.Accounts.AddAsync(visitor);
                int created = await _context.SaveChangesAsync();

            }

            return visitor;
        }

        public async Task<int> AddToCart(int userId,int productId)
        {
            RelationProducts relation = new RelationProducts
            {
                ProductId = productId,
                Visitor = userId
            };

            await _context.Relations.AddAsync(relation);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetMyProducts(int userId)
        {
            List<RelationProducts> myProducts = await _context.Relations.Where(x => x.Visitor == userId).ToListAsync();
            List<Product> products = new List<Product>();
            foreach (var prod in myProducts)
            {
                products.Add(await _context.Products.FirstOrDefaultAsync(x => x.Id == prod.ProductId)); 
            }

            return products;
        }

        public async Task<Account> GetAccountDetails(int id)
        {
            return await _context.Accounts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAccount(Account acc)
        {
            _context.Accounts.Update(acc);
            return await _context.SaveChangesAsync();
        }


        /*
        public async Task<int> Delete(int userId, int productId)
        {
            RelationProducts relation = new RelationProducts
            {
                ProductId = productId,
                Visitor = userId
            };

            await _context.Relations.AddAsync(relation);
            return await _context.SaveChangesAsync();
        }
        */
    }
}
