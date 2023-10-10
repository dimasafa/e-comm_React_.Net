using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }
            

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Samsung A546B Galaxy A54 5G",
                    Description =
                        "All Carriers, 5G 128 GB (Awesome Graphite) ohne Simlock, ohne Branding",
                    Price = 34959,
                    PictureUrl = "/images/products/01.jpg",
                    Brand = "Samsung",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Samsung A336B/DSN Galaxy A33 5G",
                    Description = "Dual, Unlocked, 128GB 6GB RAM, Awesome Black",
                    Price = 26483,
                    PictureUrl = "/images/products/02.jpg",
                    Brand = "Samsung",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Samsung Galaxy A34",
                    Description =
                        "A346B 5G EU 6/128GB, Android, Awesome Silver",
                    Price = 27468,
                    PictureUrl = "/images/products/03.jpg",
                    Brand = "Samsung",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Samsung Galaxy A23 5G",
                    Description =
                        "Android Smartphone ohne Vertrag, 16,72 cm/6,6 Zoll TFT Display, 5.000 mAh Akku, 64 GB/4GB RAM, Handy in Black, inkl. 30 Monate Herstellergarantie",
                    Price = 18899,
                    PictureUrl = "/images/products/04.jpg",
                    Brand = "Samsung",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 14",
                    Description =
                        "(128 GB) - Mitternachtsblau",
                    Price = 79300,
                    PictureUrl = "/images/products/05.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 15",
                    Description =
                        "(128 GB) - Schwarz",
                    Price = 94294,
                    PictureUrl = "/images/products/06.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 14 Pro Max",
                    Description =
                        "(256 GB) - Space Schwarz",
                    Price = 127261,
                    PictureUrl = "/images/products/07.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone X",
                    Description =
                        " 64GB Space Grau (Generalüberholt)",
                    Price = 23989,
                    PictureUrl = "/images/products/08.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 12 mini",
                    Description =
                        "64GB, Schwarz - (Generalüberholt)",
                    Price = 34677,
                    PictureUrl = "/images/products/09.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Apple iPhone 13",
                    Description =
                        "(128 GB) - Blau",
                    Price = 1800,
                    PictureUrl = "/images/products/10.jpg",
                    Brand = "Apple",
                    Type = "IOS",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Huawei P30 Pro",
                    Description =
                        "128GB Handy, türkis/blau, Android 9.0 (Pie), Dual SIM",
                    Price = 57921,
                    PictureUrl = "/images/products/11.jpg",
                    Brand = "Huawei",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Huawei P40 lite",
                    Description =
                        "128GB Smartphone Crush Green Dual-SIM Android 10.0, Grün",
                    Price = 24775,
                    PictureUrl = "/images/products/12.jpg",
                    Brand = "Huawei",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Huawei Mate 10 lite",
                    Description =
                        "Dual-Sim Smartphone (14,97 cm (5,9 Zoll), 64GB interner Speicher, Android 7.0) graphite schwarz",
                    Price = 19800,
                    PictureUrl = "/images/products/13.jpg",
                    Brand = "Huawei",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "HONOR 90 Lite",
                    Description =
                        "Smartphone 5G, 8 GB + 256 GB, 6,7 Zoll (6,7 Zoll), 90 Hz, Dreifach-Rückkamera, 100 MP, Akku mit hoher Kapazität von 4500 mAh, Android 13, Dual-SIM",
                    Price = 22888,
                    PictureUrl = "/images/products/14.jpg",
                    Brand = "Honor",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Honor Smartphone Magic5 Pro",
                    Description =
                        "5G, 12 + 512 GB, Snapdragon 8 Gen 2, Display von 17,3 cm (6,81 Zoll) mit 120 Hz HDR Quad Curved, KI-Dreifachkamera mit 50 MP, riesiger 5100-mAh-Akku",
                    Price = 89900,
                    PictureUrl = "/images/products/15.jpg",
                    Brand = "Honor",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Motorola moto g54",
                    Description =
                        "5G (6,5'-FHD+-Display, 50-MP-Dual-Kamera, 8/256 GB, 5000 mAh, Android 13 Midnight Blue + KFZ-Adapter Exklusiv bei Amazon",
                    Price = 13499,
                    PictureUrl = "/images/products/16.jpg",
                    Brand = "Motorola",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "XIAOMI Redmi Note 12 Pro",
                    Description = "5G 256GB Handy, schwarz, Midnight Black, Android 12",
                    Price = 15000,
                    PictureUrl = "/images/products/17.jpg",
                    Brand = "Xiaomi",
                    Type = "Android",
                    QuantityInStock = 100
                },
                new Product
                {
                    Name = "Xiaomi POCO X5 Pro",
                    Description =
                        "5G Smartphone+Kopfhörer, 8+256GB Handy ohne Vertrag, 6.67' 120Hz FHD + AMOLED DotDisplay, 108MP Hauptkamera, 5000mAh, 67W Turbo Charge, Black (DE Version++2 Jahre Garantie)",
                    Price = 31599,
                    PictureUrl = "/images/products/18.jpg",
                    Brand = "Xiaomi",
                    Type = "Android",
                    QuantityInStock = 100
                },
            };
            
            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}