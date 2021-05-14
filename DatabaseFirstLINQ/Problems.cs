using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using DatabaseFirstLINQ.Models;
using System.Collections.Generic;

namespace DatabaseFirstLINQ
{
    class Problems
    {
        private ECommerceContext _context;

        public Problems()
        {
            _context = new ECommerceContext();
        }
        public void RunLINQQueries()
        {
            //ProblemOne();
            //ProblemTwo();
            //ProblemThree();
            //ProblemFour();
            //ProblemFive();
            //ProblemSix();
            //ProblemSeven();
            //ProblemEight();
            //ProblemNine();
            //ProblemTen();
            //ProblemEleven();
            //ProblemTwelve();
            //ProblemThirteen();
            //ProblemFourteen();
            //ProblemFifteen();
            //ProblemSixteen();
            //ProblemSeventeen();
            //ProblemEighteen();
            //ProblemNineteen();
            //ProblemTwenty();
            //BonusOne();
            //BonusTwo();
            BonusThree();

        }

        // <><><><><><><><> R Actions (Read) <><><><><><><><><>
        private void ProblemOne()
        {
            // Write a LINQ query that returns the number of users in the Users table.
            // HINT: .ToList().Count
            var userCount = _context.Users.ToList().Count;
            Console.WriteLine("\n\n********** Problem 1 **********");
            Console.WriteLine($" There are currently {userCount} users.");
        }

        private void ProblemTwo()
        {
            // Write a LINQ query that retrieves the users from the User tables then print each user's email to the console.
            var users = _context.Users;

            Console.WriteLine("\n\n********** Problem 2 **********");
            foreach (User user in users)
            {
                Console.WriteLine(user.Email);
            }

        }

        private void ProblemThree()
        {
            // Write a LINQ query that gets each product where the products price is greater than $150.
            // Then print the name and price of each product from the above query to the console.
            var products = _context.Products.Where(p => p.Price > 150).ToList();

            Console.WriteLine("\n\n********** Problem 3 **********");
            foreach (var product in products)
            {
                Console.WriteLine($"Product {product.Name} has a price of ${product.Price}");
            }
        }

        private void ProblemFour()
        {
            // Write a LINQ query that gets each product that contains an "s" in the products name.
            // Then print the name of each product from the above query to the console.
            char searchChar = 's';
            var products = _context.Products.ToList().Where(p => p.Name.Contains(searchChar)).Select(p => p.Name);
            Console.WriteLine("\n\n********** Problem 4 **********");

            foreach(var p in products)
            {
                Console.WriteLine(p);
            }
        }

        private void ProblemFive()
        {
            // Write a LINQ query that gets all of the users who registered BEFORE 2016
            // Then print each user's email and registration date to the console.

            DateTime endDate = new DateTime(2016,01,01);

            var users = _context.Users.Where(u => u.RegistrationDate < endDate );

            Console.WriteLine("\n\n********** Problem 5 **********");
            foreach (var user in users)
            {
                Console.WriteLine($"User {user.Email} registered on {user.RegistrationDate}");
            }
        }

        private void ProblemSix()
        {
            // Write a LINQ query that gets all of the users who registered AFTER 2016 and BEFORE 2018
            // Then print each user's email and registration date to the console.
            DateTime endDate = new DateTime(2018, 01, 01);
            DateTime startDate = new DateTime(2016, 01, 01);

            var users = _context.Users.Where(u => (u.RegistrationDate > startDate && u.RegistrationDate < endDate));

            Console.WriteLine("\n\n********** Problem 6 **********");
            foreach (var user in users)
            {
                Console.WriteLine($"User {user.Email} registered on {user.RegistrationDate}");
            }
        }

        // <><><><><><><><> R Actions (Read) with Foreign Keys <><><><><><><><><>

        private void ProblemSeven()
        {
            // Write a LINQ query that retreives all of the users who are assigned to the role of Customer.
            // Then print the users email and role name to the console.
            var customerUsers = _context.UserRoles.Include(ur => ur.Role).Include(ur => ur.User).Where(ur => ur.Role.RoleName == "Customer");
            Console.WriteLine("\n\n********** Problem 7 **********");
            foreach (UserRole userRole in customerUsers)
            {
                Console.WriteLine($"Email: {userRole.User.Email} Role: {userRole.Role.RoleName}");
            }
        }

        private void ProblemEight()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "afton@gmail.com".
            // Then print the product's name, price, and quantity to the console.
            string email = "afton@gmail.com";
            var shoppingCart = _context.ShoppingCarts.Include(sc => sc.User).Where(u => u.User.Email == email).Include(sc => sc.Product);

            Console.WriteLine("\n\n********** Problem 8 **********");
            Console.WriteLine("Customer afton@gmail.com is ordering:");
            foreach(var item in shoppingCart)
            {
                Console.WriteLine($"{item.Quantity} items of '{item.Product.Name}' at a price of ${item.Product.Price} each.");
            }
        }

        private void ProblemNine()
        {
            // Write a LINQ query that retreives all of the products in the shopping cart of the user who has the email "oda@gmail.com" and returns the sum of all of the products prices.
            // HINT: End of query will be: .Select(sc => sc.Product.Price).Sum();
            // Then print the total of the shopping cart to the console.
            string email = "afton@gmail.com";
            var shoppingCart = _context.ShoppingCarts.Include(sc => sc.User).Where(u => u.User.Email == email).Include(sc => sc.Product).Select(sc => sc.Product.Price).Sum();

            Console.WriteLine("\n\n********** Problem 9 **********");
            Console.WriteLine($"Total Cost: ${shoppingCart}");
        }

        private void ProblemTen()
        {

            var userId = _context.UserRoles.Include(u => u.User).Where(u => u.RoleId == 2).Select(u => u.User).ToList();
            var shoppingCart = _context.ShoppingCarts.Include(u => u.Product).Include(u => u.User.UserRoles).Select(u => new {u.User, u.Product, u.Quantity, u.User.UserRoles }).ToList();


            Console.WriteLine("\n\n********** Problem 10 **********");
            foreach (var u in shoppingCart)
            {
                if (userId.Contains(u.User))
                {
                    Console.WriteLine($"{u.User.Email} has bought {u.Quantity} of {u.Product.Name} for ${u.Product.Price} each.");
                }
            }
        }

        // <><><><><><><><> CUD (Create, Update, Delete) Actions <><><><><><><><><>

        // <><> C Actions (Create) <><>

        private void ProblemEleven()
        {
            // Create a new User object and add that user to the Users table using LINQ.
            Console.WriteLine("\n\n********** Problem 11 **********");
            User newUser = new User()
            {
                Email = "david@gmail.com",
                Password = "DavidsPass123"
            };
            _context.Users.Add(newUser);
            _context.SaveChanges();

            Console.WriteLine($"New user added {newUser.Email}");
        }

        private void ProblemTwelve()
        {
            // Create a new Product object and add that product to the Products table using LINQ.
            Console.WriteLine("\n\n********** Problem 12 **********");
            Product newProduct = new Product()
            {
                Name = "From Idea To Launch",
                Description = "Book: About Take Your Great Ideas To Profitable Reality",
                Price = 100
            };
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            Console.WriteLine($"New product added {newProduct.Name}");
        }

        private void ProblemThirteen()
        {
            // Add the role of "Customer" to the user we just created in the UserRoles junction table using LINQ.
            var roleName = "Customer";
            var email = "david@gmail.com";
            var roleId = _context.Roles.Where(r => r.RoleName == roleName).Select(r => r.Id).SingleOrDefault();
            var userId = _context.Users.Where(u => u.Email == email).Select(u => u.Id).SingleOrDefault();

            UserRole newUserRole = new UserRole()
            {
                UserId = userId,
                RoleId = roleId
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();

            Console.WriteLine("\n\n********** Problem 13 **********");
            Console.WriteLine($"User {email} classified as a {roleName}");
        }

        private void ProblemFourteen()
        {
            // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
                // Add the product you create to the user we created in the ShoppingCart junction table using LINQ.
                var userId = _context.Users.Where(u => u.Email == "david@gmail.com").Select(u => u.Id).SingleOrDefault();
                var productId = _context.Products.Where(p => p.Name == "From Idea To Launch").Select(p => p.Id).SingleOrDefault();
                Console.WriteLine("\n\n********** Problem 14 **********");
                ShoppingCart newProduct = new ShoppingCart()
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = 1
                };
                _context.ShoppingCarts.Add(newProduct);
                _context.SaveChanges();

                Console.WriteLine("Product Added to Shopping Cart.");
        }

        // <><> U Actions (Update) <><>

        private void ProblemFifteen()
        {
            // Update the email of the user we created to "mike@gmail.com"
            string email = "david@gmail.com";
            var user = _context.Users.Where(u => u.Email == email).SingleOrDefault();
            user.Email = "mike@gmail.com";
            _context.Users.Update(user);
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 15 **********");
            Console.WriteLine($"User email {email} has been updated to {user.Email}.");
        }

        private void ProblemSixteen()
        {
            // Update the price of the product you created to something different using LINQ.

            var product = _context.Products.Where(p => p.Name == "From Idea To Launch").SingleOrDefault();
            product.Price = 50;
            _context.Products.Update(product);
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 16 **********");
            Console.WriteLine($"Product {product.Name}'s price has been changed to {product.Price}.");

        }

        private void ProblemSeventeen()
        {
            // Change the role of the user we created to "Employee"
            // HINT: You need to delete the existing role relationship and then create a new UserRole object and add it to the UserRoles table
            // See problem eighteen as an example of removing a role relationship
            var email = "mike@gmail.com";
            var roleName = "Employee";
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == email).SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            UserRole newUserRole = new UserRole()
            {
                UserId = _context.Users.Where(u => u.Email == email).Select(u => u.Id).SingleOrDefault(),
                RoleId = _context.Roles.Where(r => r.RoleName == roleName).Select(r => r.Id).SingleOrDefault()
            };
            _context.UserRoles.Add(newUserRole);
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 17 **********");
            Console.WriteLine($"{email} role has been changed to {roleName}.");
        }

        // <><> D Actions (Delete) <><>

        private void ProblemEighteen()
        {
            // Delete the role relationship from the user who has the email "oda@gmail.com" using LINQ.
            var email = "oda@gmail.com";
            var userRole = _context.UserRoles.Where(ur => ur.User.Email == email).SingleOrDefault();
            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 18 **********");
            Console.WriteLine($"{email} role has been removed.");
        }

        private void ProblemNineteen()
        {
            // Delete all of the product relationships to the user with the email "oda@gmail.com" in the ShoppingCart table using LINQ.
            // HINT: Loop
            var email = "oda@gmail.com";
            var shoppingCartProducts = _context.ShoppingCarts.Where(sc => sc.User.Email == email);
            foreach (ShoppingCart userProductRelationship in shoppingCartProducts)
            {
                _context.ShoppingCarts.Remove(userProductRelationship);
            }
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 19 **********");
            Console.WriteLine($"The shopping care for {email} has been removed.");
        }

        private void ProblemTwenty()
        {
            // Delete the user with the email "oda@gmail.com" from the Users table using LINQ.
            var email = "oda@gmail.com";
            var user = _context.Users.Where(ur => ur.Email == email).SingleOrDefault();
            _context.Users.Remove(user);
            _context.SaveChanges();
            Console.WriteLine("\n\n********** Problem 20 **********");
            Console.WriteLine($"The user with the email of '{email}' has been removed.");
        }
    

        // <><><><><><><><> BONUS PROBLEMS <><><><><><><><><>

        private void BonusOne()
        {
            // Prompt the user to enter in an email and password through the console.
            // Take the email and password and check if the there is a person that matches that combination.
            // Print "Signed In!" to the console if they exists and the values match otherwise print "Invalid Email or Password.".
            Console.WriteLine("\n\n********** Bonus One **********");
            Console.WriteLine("Provide email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Provide password: ");
            string password = Console.ReadLine();
           

            var userCreds = _context.Users.Where(e => e.Email == email && e.Password == password);         
            if (userCreds.Count() != 0)
            {
                Console.WriteLine("Signed In!");
            }
            else
            {
                Console.WriteLine("Try Again.");
            }
        }

        private void BonusTwo()
        {
            // Write a query that finds the total of every users shopping cart products using LINQ.
            // Display the total of each users shopping cart as well as the total of the toals to the console.

            var shoppingCart = _context.ShoppingCarts
                .Include(sc => sc.Product)
                .Select(sc => new {sc.UserId, sc.Product, sc.Quantity, })
                .GroupBy(sc => sc.UserId)
                .Select(sc => new {
                    UserIdK = sc.Key,
                    Count = sc.Count(),
                    Subtotal = sc.Sum(st => st.Quantity * st.Product.Price),
                }
                ).ToList();

            Console.WriteLine("\n\n********** Bonus Two **********");
            decimal AllCartsTotal = 0;
            foreach (var item in shoppingCart)
            {
                Console.WriteLine($"User ID: {item.UserIdK} has {item.Count} items for a total of ${item.Subtotal}");
                AllCartsTotal += (decimal)item.Subtotal; 
            }
            Console.WriteLine($"\n\n Total for All Shopping Carts is ${AllCartsTotal}");
  
        }

        // BIG ONE
        private void BonusThree()
        {
            // 1. Create functionality for a user to sign in via the console
            // 2. If the user succesfully signs in
            // a. Give them a menu where they perform the following actions within the console
            // View the products in their shopping cart
            // View all products in the Products table
            // Add a product to the shopping cart (incrementing quantity if that product is already in their shopping cart)
            // Remove a product from their shopping cart
            // 3. If the user does not succesfully sign in
            // a. Display "Invalid Email or Password"
            // b. Re-prompt the user for credentials

            Console.WriteLine("\n\n********** Bonus Three **********");
            


            Simulation.RunSimulation();

        }
    }

    
}
