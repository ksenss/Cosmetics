using Cosmetics.Models;

namespace Cosmetics.Helpers
{
    public static class Seeder
    {
        public static IEnumerable<Product> GetProducts()
        {
            return new Product[] {
                new Product()
            {
                Id = 1,
                Name = "Maybeline lipstick",
                Price = 780,
                Category = "Cosmetics"
            },
            new Product()
            {
                Id = 2,
                Name = "glambee gloss",
                Price = 350,
                Category = "Cosmetics"
            },
            new Product()
            {
                Id = 3,
                Name = "Patricia ledo blush",
                Price = 500,
                Category = "Cosmetics"
            },
            new Product()
            {
                Id = 4,
                Name = "Gievanshy powder",
                Price = 4000,
                Category = "Cosmetics"
            },
            new Product()
            {
                Id = 5,
                Name = "Dior highlighter",
                Price = 999,
                Category = "Cosmetics"
            }
            };
        }
    }
}

