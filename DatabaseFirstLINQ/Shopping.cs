using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;
using System.Collections.Generic;

namespace DatabaseFirstLINQ
{
    class Shopping
    {
        public ECommerceContext _context;
        public string email;
        public string password;

        public Shopping()
        {
            _context = new ECommerceContext();

        }

        public void GetCredentials()
        {
            Console.WriteLine("Provide email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Provide password: ");
            string password = Console.ReadLine();


            var userCreds = _context.Users.Where(e => e.Email == email && e.Password == password);
            if (userCreds.Count() != 0)
            {
                Console.WriteLine("Signed In!");
                this.email = email;
                this.password = password;
            }
            else
            {
                Console.WriteLine("Log In Failed. Try Again.");
            }
        }

        public void ViewProducts()
        {
            //var userId = _context.Users.Where(u => u.Email == email).Select(u => u.Id));
            var shoppingCart = _context.ShoppingCarts.Include(u => u.User).Include(p => p.Product).Where(u => u.User.Email == email).Select(p => new { p.UserId, p.Product } ).ToList();

            Console.WriteLine("\n***User Shopping Cart***");
            foreach (var p in shoppingCart)
            {
                Console.WriteLine($"{p.Product.Name} is in {email}'s cart");
            }
        }

        public void ViewAllProducts()
        {
            var products = _context.Products.ToList();

            Console.WriteLine("\n***Available Products***");
            int choice = 0;
            foreach ( var p in products)
            {
                
                choice++;
                Console.Write($"\n\n{choice} - {p.Name} {p.Description} ${p.Price}");
            }
        }

        public void AddProductsToCart()
        {
            Console.WriteLine("\n\nEnter selection 1 thru 8 for product");
            int selection = Int16.Parse(Console.ReadLine());

            var userId = _context.Users.Where(u => u.Email == email).Select(u => u.Id).SingleOrDefault();
            var productId = _context.Products.Where(p => p.Id == selection).Select(p => p.Id).SingleOrDefault();
            var selectedItem = _context.Products.Where(p => p.Id == selection);

            
            ShoppingCart newProduct = new ShoppingCart()
            {
                UserId = userId,
                ProductId = productId,
                Quantity = 1
            };
            _context.ShoppingCarts.Add(newProduct);
            _context.SaveChanges();

            foreach (var item in selectedItem)
            {
                Console.WriteLine($"{item.Name} has been added to {email}'s shopping cart.");
            }
        }

        public void RemoveProducts()
        {
            Console.WriteLine("\n\nEnter selection 1 thru 8 to remove product from cart.");
            int selection = Int16.Parse(Console.ReadLine());

            var productId = _context.Products.Where(p => p.Id == selection).Select(p => p.Id).SingleOrDefault();
            var product = _context.ShoppingCarts.Include(p => p.Product).Where(p => p.Product.Id == selection).SingleOrDefault();
            _context.ShoppingCarts.Remove(product);
            _context.SaveChanges();

            Console.WriteLine($"{product.Product.Name} has been removed from {email}'s cart.");

        }



    }
}
