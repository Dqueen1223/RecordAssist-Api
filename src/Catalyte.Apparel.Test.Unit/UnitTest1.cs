using Catalyte.Apparel.Data.SeedData;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Catalyte.Apparel.Test.Unit
{

    public class ProductFactoryTests
    {
        /// <summary>
        /// The following several tests check for empty properties of the product objects
        /// </summary>
        [Fact]
        public void ProductFactoryReturnsNonNullObjects()
        {
            //Arrange
            var productFactory = new ProductFactory();

            //Act
            var products = productFactory.GenerateRandomProducts(250);

            //Assert
            Assert.NotNull(products);
        }

        [Fact]
        public void ProductFactoryReturnsCategory()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Category);
            }
        }

        [Fact]
        public void ProductFactoryReturnsType()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Type);
            }
        }

        [Fact]
        public void ProductFactoryReturnsSku()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Sku);
            }
        }

        [Fact]
        public void ProductFactoryReturnsDemographic()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Demographic);
            }
        }

        [Fact]
        public void ProductFactoryReturnsGlobalProductCode()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.GlobalProductCode);
            }
        }

        [Fact]
        public void ProductFactoryReturnsStyleCode()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.StyleNumber);
            }
        }

        [Fact]
        public void ProductFactoryGivesValidCreatedDate()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.DateCreated);
            }
        }

        [Fact]
        public void ProductFactoryGivesValidDateModified()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.DateModified);
            }
        }
        [Fact]
        public void ProductFactoryReturnsActive()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Active);
            }
        }

        [Fact]
        public void ProductFactoryReturnsDescription()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Description);
            }
        }
        [Fact]
        public void ProductFactoryReturnsName()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Name);
            }
        }
        [Fact]
        public void ProductFactoryReturnsPrimaryColor()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.PrimaryColorCode);
            }
        }
        [Fact]
        public void ProductFactoryReturnsSecondaryColor()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.SecondaryColorCode);
            }
        }
        [Fact]
        public void ProductFactoryReturnsBrand()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Brand);
            }
        }
        [Fact]
        public void ProductFactoryReturnsMaterial()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.Material);
            }
        }

        [Fact]
        public void ProductFactoryReturnsImageSrc()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.NotNull(product.ImageSrc);
            }
        }

        /// <summary>
        /// Validates that the price field is between 19.99 and 199.99
        /// </summary>
        [Fact]
        public void ProductFactoryReturnsValidPrices()
        {
            //Arrange
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            //Act
            //Assert
            foreach (var product in products)
            {
                Assert.InRange(product.Price, 19.99M, 199.99M);
            }
        }

        /// <summary>
        /// Verifies that each product has an distinct ID
        /// </summary>
        [Fact]
        public void ProductFactoryReturnsDistinctId()
        {
            //Arrange
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            List<int> idList = new();
            foreach (var product in products)
            {
                idList.Add(product.Id);
            }
            var expected = 0;
            IEnumerable<int> distinctId = idList.Distinct();

            //Act
            var actual = idList.Count - distinctId.Count();

            //Assert
            Assert.Equal(expected, actual);
        }


        /// <summary>
        /// Validates that the release date is in a range starting from 1/1/2020 to the date of generation
        /// </summary>
        [Fact]
        public void ProductFactoryReturnsValidReleaseDate()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var min = new DateTime(2020, 1, 1);

            foreach (var product in products)
            {
                Assert.InRange(product.ReleaseDate, min, DateTime.Now);
            }
        }

        /// <summary>
        /// Validates that the quantity is a number between 0 and 10,000
        /// </summary>
        [Fact]
        public void ProductFactoryReturnsValidQuantity()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);

            foreach (var product in products)
            {
                Assert.InRange(product.Quantity, 0, 10000);
            }
        }

        /// <summary>
        /// The following tests check that all Items in the lists are represented
        /// </summary>
        [Fact]
        public void ProductCategoryListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "Golf",
            "Soccer",
            "Basketball",
            "Hockey",
            "Football",
            "Running",
            "Baseball",
            "Skateboarding",
            "Boxing",
            "Weightlifting" };
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Category))
                {
                    present.Add(product.Category);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }

        [Fact]
        public void ProductPrimaryColorListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "#000000",
            "#ffffff",
            "#39add1",
            "#3079ab",
            "#c25975",
            "#e15258",
            "#f9845b",
            "#838cc7",
            "#7d669e",
            "#53bbb4",
            "#51b46d",
            "#e0ab18",
            "#637a91",
            "#f092b0",
            "#b7c0c7"
                       };
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.PrimaryColorCode))
                {
                    present.Add(product.PrimaryColorCode);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }
        [Fact]
        public void ProductSecondaryColorListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "#000000",
            "#ffffff",
            "#39add1",
            "#3079ab",
            "#c25975",
            "#e15258",
            "#f9845b",
            "#838cc7",
            "#7d669e",
            "#53bbb4",
            "#51b46d",
            "#e0ab18",
            "#637a91",
            "#f092b0",
            "#b7c0c7"
                       };
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.PrimaryColorCode))
                {
                    present.Add(product.PrimaryColorCode);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }
        [Fact]
        public void ProductDemographicsListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "Men",
            "Women",
            "Kids"};
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Demographic))
                {
                    present.Add(product.Demographic);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }

        [Fact]
        public void ProductTypesListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){"Pant",
            "Short",
            "Shoe",
            "Glove",
            "Jacket",
            "Tank Top",
            "Sock",
            "Sunglasses",
            "Hat",
            "Helmet",
            "Belt",
            "Visor",
            "Shin Guard",
            "Elbow Pad",
            "Headband",
            "Wristband",
            "Hoodie",
            "Flip Flop",
            "Pool Noodle"};
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Type))
                {
                    present.Add(product.Type);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }
        [Fact]
        public void ProductBrandsListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "Nike",
            "Reebok",
            "Asics",
            "Brooks",
            "Skechers",
            "Puma",
            "Under Armor",
            "Adidas"};
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Brand))
                {
                    present.Add(product.Brand);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }
        [Fact]
        public void ProductMaterialsListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<string>(){ "Cotton",
            "Polyester",
            "Microfiber",
            "Nylon",
            "Synthetic",
            "Gore-Tex",
            "Spandex",
            "Calico",
            "Bamboo-Fiber"};
            var present = new List<string>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Material))
                {
                    present.Add(product.Material);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);

        }

        [Fact]
        public void ProductActiveListAllPresent()
        {
            ProductFactory productFactory = new();
            var products = productFactory.GenerateRandomProducts(250);
            var list = new List<bool>() { true, false };
            var present = new List<bool>();

            foreach (var product in products)
            {
                if (!present.Contains(product.Active))
                {
                    present.Add(product.Active);
                }
            }

            list.Sort();
            present.Sort();

            Assert.Equal(list, present);
        }


        }
    }
