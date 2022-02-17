using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using System;

namespace Catalyte.Apparel.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            var productFactory = new ProductFactory();

            modelBuilder.Entity<Product>().HasData(productFactory.GenerateRandomProducts(1000));

            var lineItem = new LineItem()
            {
                Id = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ProductId = 1,
                Quantity = 1,
                PurchaseId = 1
            };

            modelBuilder.Entity<LineItem>().HasData(lineItem);

            var purchase = new Purchase()
            {
                Id = 1,
                BillingCity = "Atlanta",
                BillingEmail = "customer@home.com",
                BillingPhone = "(714) 345-8765",
                BillingState = "GA",
                BillingStreet = "123 Main",
                BillingStreet2 = "Apt A",
                BillingZip = "31675",
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                DeliveryCity = "Birmingham",
                DeliveryState = "AL",
                DeliveryStreet = "123 Hickley",
                DeliveryZip = "43690",
                DeliveryFirstName = "Max",
                DeliveryLastName = "Space",
                CardHolder = "Max Perkins",
                CardNumber = "1435678998761234",
                Expiration = "11/21",
                CVV = "456",
                OrderDate = new DateTime(2021, 5, 4)
            };

            modelBuilder.Entity<Purchase>().HasData(purchase);

            ShippingRate[] shippingRate =
            {
                new ShippingRate 
                {  
                Id = 1,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Alabama"
                },
                new ShippingRate
                {
                Id = 2,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 10,
                State = "Alaska"
                },
                new ShippingRate
                {
                Id = 3,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "American Samoa"
                },
                new ShippingRate
                {
                Id = 4,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Arizona"
                },
                new ShippingRate
                {
                Id = 5,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Arkansas"
                },
                new ShippingRate
                {
                Id = 6,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "California"
                },
                new ShippingRate
                {
                Id = 7,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Colorado"
                },
                new ShippingRate
                {
                Id = 8,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Connecticut"
                },
                new ShippingRate
                {
                Id = 9,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Delaware"
                },
                new ShippingRate
                {
                Id = 10,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "District of Columbia"
                },
                new ShippingRate
                {
                Id = 11,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Federated States of Micronesia"
                },
                new ShippingRate
                {
                Id = 12,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Florida"
                },
                new ShippingRate
                {
                Id = 13,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Georgia"
                },
                new ShippingRate
                {
                Id = 14,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Guam"
                },
                new ShippingRate
                {
                Id = 15,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 10,
                State = "Hawaii"
                },
                new ShippingRate
                {
                Id = 16,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Idaho"
                },
                new ShippingRate
                {
                Id = 17,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Illinois"
                },
                new ShippingRate
                {
                Id = 18,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Indiana"
                },
                new ShippingRate
                {
                Id = 19,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Iowa"
                },
                new ShippingRate
                {
                Id = 20,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Kansas"
                },
                new ShippingRate
                {
                Id = 21,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Kentucky"
                },
                new ShippingRate
                {
                Id = 22,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Louisiana"
                },
                new ShippingRate
                {
                Id = 23,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Maine"
                },
                new ShippingRate
                {
                Id = 24,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Marshall Islands"
                },
                new ShippingRate
                {
                Id = 25,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Maryland"
                },
                new ShippingRate
                {
                Id = 26,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Massachusetts"
                },
                new ShippingRate
                {
                Id = 27,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Michigan"
                },
                new ShippingRate
                {
                Id = 28,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Minnesota"
                },
                new ShippingRate
                {
                Id = 29,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Mississippi"
                },
                new ShippingRate
                {
                Id = 30,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Missouri"
                },
                new ShippingRate
                {
                Id = 31,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Montana"
                },
                new ShippingRate
                {
                Id = 32,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Nebraska"
                },
                new ShippingRate
                {
                Id = 33,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Nevada"
                },
                new ShippingRate
                {
                Id = 34,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "New Hampshire"
                },
                new ShippingRate
                {
                Id = 35,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "New Jersey"
                },
                new ShippingRate
                {
                Id = 36,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "New Mexico"
                },
                new ShippingRate
                {
                Id = 37,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "New York"
                },
                new ShippingRate
                {
                Id = 38,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "North Carolina"
                },
                new ShippingRate
                {
                Id = 39,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "North Dakota"
                },
                new ShippingRate
                {
                Id = 40,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Northern Mariana Islands"
                },
                new ShippingRate
                {
                Id = 41,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Ohio"
                },
                new ShippingRate
                {
                Id = 42,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Oklahoma"
                },
                new ShippingRate
                {
                Id = 43,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Oregon"
                },
                new ShippingRate
                {
                Id = 44,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Palau"
                },
                new ShippingRate
                {
                Id = 45,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Pennsylvania"
                },
                new ShippingRate
                {
                Id = 46,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Puerto Rico"
                },
                new ShippingRate
                {
                Id = 47,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Rhode Island"
                },
                new ShippingRate
                {
                Id = 48,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "South Carolina"
                },
                new ShippingRate
                {
                Id = 49,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "South Dakota"
                },
                new ShippingRate
                {
                Id = 50,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Tennessee"
                },
                new ShippingRate
                {
                Id = 51,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Texas"
                },
                new ShippingRate
                {
                Id = 52,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Utah"
                },
                new ShippingRate
                {
                Id = 53,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Vermont"
                },
                new ShippingRate
                {
                Id = 54,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Virgin Islands"
                },
                new ShippingRate
                {
                Id = 55,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Virginia"
                },
                new ShippingRate
                {
                Id = 56,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Washington"
                },
                new ShippingRate
                {
                Id = 57,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "West Virginia"
                },
                new ShippingRate
                {
                Id = 58,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Wisconsin"
                },
                new ShippingRate
                {
                Id = 59,
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                ShippingCost = 5,
                State = "Wyoming"
                },
            };
            modelBuilder.Entity<ShippingRate>().HasData(shippingRate);

            
        }
    }
}
