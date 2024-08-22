using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistance;

namespace Restaurants.Infrastructure.Seeders;

public class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaurants();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaurants()
    {
        List<Restaurant> restaurants = new()
    {
        new Restaurant
        {
            Name = "Le Gourmet",
            Description = "A fine dining restaurant with a variety of exquisite dishes.",
            Category = "French",
            HasDelivery = true,
            ContactEmail = "contact@legourmet.com",
            ContactNumber = "+33 1 23 45 67 89",
            Address = new Address
            {
                City = "Paris",
                Street = "123 Rue de la Paix",
                PostalCode = "75001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Coq au Vin",
                    Description = "A classic French dish made with chicken, wine, mushrooms, and onions.",
                    Price = 25.50m,
                },
                new Dish
                {
                    Name = "Bouillabaisse",
                    Description = "A traditional Provençal fish stew with saffron and garlic.",
                    Price = 30.00m,
                }
            }
        },
        new Restaurant
        {
            Name = "Bella Italia",
            Description = "Authentic Italian cuisine with homemade pasta and pizza.",
            Category = "Italian",
            HasDelivery = false,
            ContactEmail = "info@bellaitalia.it",
            ContactNumber = "+39 02 123 4567",
            Address = new Address
            {
                City = "Rome",
                Street = "45 Via Roma",
                PostalCode = "00100"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Margherita Pizza",
                    Description = "Classic pizza with tomato, mozzarella, and fresh basil.",
                    Price = 12.00m,
                },
                new Dish
                {
                    Name = "Spaghetti Carbonara",
                    Description = "Pasta with pancetta, egg, and Parmesan cheese.",
                    Price = 15.00m,
                }
            }
        },
        new Restaurant
        {
            Name = "Sushi Zen",
            Description = "Traditional Japanese sushi and sashimi prepared with fresh ingredients.",
            Category = "Japanese",
            HasDelivery = true,
            ContactEmail = "sushi@zen.jp",
            ContactNumber = "+81 3 1234 5678",
            Address = new Address
            {
                City = "Tokyo",
                Street = "10 Shibuya",
                PostalCode = "150-0001"
            },
            Dishes = new List<Dish>
            {
                new Dish
                {
                    Name = "Sashimi Platter",
                    Description = "A selection of the finest raw fish served with soy sauce and wasabi.",
                    Price = 40.00m
                },
                new Dish
                {
                    Name = "Tempura",
                    Description = "Lightly battered and deep-fried seafood and vegetables.",
                    Price = 20.00m,
                }
            }
        }
    };

        return restaurants;
    }

}
