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


            int count = 0;
            while (count != 3)
            {


                Console.WriteLine("\nProvide email: ");
                string email = Console.ReadLine();
                Console.WriteLine("\nProvide password: ");
                string password = Console.ReadLine();
                var userCreds = _context.Users.Where(e => e.Email == email && e.Password == password).SingleOrDefault();

                
                this.email = email;
                this.password = password;
                if (userCreds != null)
                {
                    Console.WriteLine("\n*** Signed In! ***");
                    count = 3;
                }
                else
                {
                    Console.WriteLine("\nLog In Failed. Try Again.");
                    count++;
                    if (count == 1)
                    {
                        Console.WriteLine("2 Attempts remaining");
                    }
                    if (count == 2)
                    {
                        Console.WriteLine("1 Attempt remaining");
                    }

                }

            }

        }
    
        public void ViewShoppingCart()
        {
            //var userId = _context.Users.Where(u => u.Email == email).Select(u => u.Id));
            var shoppingCart = _context.ShoppingCarts.Include(u => u.User).Include(p => p.Product).Where(u => u.User.Email == email).Select(p => new { p.UserId, p.Product, p.Quantity } ).ToList();

            Console.WriteLine("\n***User Shopping Cart***");
            foreach (var p in shoppingCart)
            {
                Console.WriteLine($"{p.Product.Name} with a quantity of -{p.Quantity}- is in your cart");
            }
        }

        public void ViewAllProducts()
        {
            var products = _context.Products.ToList();

            Console.WriteLine("***Available Products***");
            int choice = 0;
            foreach ( var p in products)
            {
                
                choice++;
                Console.Write($"\n Product# {choice} - {p.Name}\t${p.Price}\n\t{p.Description}\n");
            }
        }

        public void AddProductsToCart()
        {
            Console.WriteLine("***Enter selection 1 thru 8 for product: ***");
            int selection = Int16.Parse(Console.ReadLine());

            var userId = _context.Users.Where(u => u.Email == email).Select(u => u.Id).SingleOrDefault();
            var productId = _context.Products.Where(p => p.Id == selection).Select(p => p.Id).SingleOrDefault();
            var selectedItem = _context.Products.Where(p => p.Id == selection);

            // Check for existing data
            var productData = _context.ShoppingCarts.Where(p => p.UserId == userId && p.ProductId == productId).SingleOrDefault();

            if (productData != null)
            {
                productData.Quantity = productData.Quantity + 1;
                _context.ShoppingCarts.Update(productData);
                _context.SaveChanges();
            }
            else
            {
                ShoppingCart newProduct = new ShoppingCart()
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.ShoppingCarts.Add(newProduct);
                _context.SaveChanges();
            }


            foreach (var item in selectedItem)
            {
                Console.WriteLine($"***{item.Name} has been added to your shopping cart.");
            }
        }

        public void RemoveProducts()
        {
            Console.WriteLine("***Enter selection 1 thru 8 to remove product from your cart.***");
            int selection = Int16.Parse(Console.ReadLine());
            var product = _context.ShoppingCarts.Include(p => p.Product)
                .Include(u => u.User)
                .Where(p => p.ProductId == selection && p.User.Email == email)
                .SingleOrDefault();

            if (product.Quantity > 1)
            {
                product.Quantity = product.Quantity - 1;
                _context.ShoppingCarts.Update(product);
                _context.SaveChanges();
            }
            else
            {
                _context.ShoppingCarts.Remove(product);
                _context.SaveChanges();
            }

            Console.WriteLine($"***{product.Product.Name} has been removed from your cart.");

        }

    }
}
