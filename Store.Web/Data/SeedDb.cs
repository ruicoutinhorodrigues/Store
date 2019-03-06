using Microsoft.AspNetCore.Identity;
using Store.Web.Data.Entities;
using Store.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }


        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("ruirodrigues@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Rui",
                    LastName = "Rodrigues",
                    Email = "ruirodrigues@gmail.com",
                    UserName = "ruirodrigues@gmail.com",
                    PhoneNumber = "212345676"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("Equipamento oficial SCP", user);
                this.AddProduct("Chuteiras oficiais", user);
                this.AddProduct("Leão pequeno", user);

                await this.context.SaveChangesAsync();
            }
        }

        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(200),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }
    }
}
