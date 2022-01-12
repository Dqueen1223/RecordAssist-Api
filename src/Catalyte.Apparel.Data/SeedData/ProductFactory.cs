using System;
using System.Collections.Generic;
using System.Text;
using Catalyte.Apparel.Data.Model;

namespace Catalyte.Apparel.Data.SeedData
{
    /// <summary>
    /// This class provides tools for generating random products.
    /// </summary>
    public class ProductFactory
    {
        Random _rand = new();

        private List<string> _colors = new()
        {
            "#000000", // white
            "#ffffff", // black
            "#39add1", // light blue
            "#3079ab", // dark blue
            "#c25975", // mauve
            "#e15258", // red
            "#f9845b", // orange
            "#838cc7", // lavender
            "#7d669e", // purple
            "#53bbb4", // aqua
            "#51b46d", // green
            "#e0ab18", // mustard
            "#637a91", // dark gray
            "#f092b0", // pink
            "#b7c0c7"  // light gray
        };

        private readonly List<string> _demographics = new()
        {
            "Men",
            "Women",
            "Kids"
        };
        private readonly List<string> _categories = new()
        {
            "Golf",
            "Soccer",
            "Basketball",
            "Hockey",
            "Football",
            "Running",
            "Baseball",
            "Skateboarding",
            "Boxing",
            "Weightlifting"
        };

        private List<string> _adjectives = new()
        {
            "Lightweight",
            "Slim",
            "Shock Absorbing",
            "Exotic",
            "Elastic",
            "Fashionable",
            "Trendy",
            "Next Gen",
            "Colorful",
            "Comfortable",
            "Water Resistant",
            "Wicking",
            "Heavy Duty"
        };

        private List<string> _types = new()
        {
            "Pant",
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
            "Pool Noodle"
        };

        private List<string> _skuMods = new()
        {
            "Blue",
            "Red",
            "KJ",
            "SM",
            "RD",
            "LRG"
        };

        private List<string> _brands = new()
        {
            "Nike",
            "Reebok",
            "Asics",
            "Brooks",
            "Skechers",
            "Puma",
            "Under Armor",
            "Adidas"
        };

        private List<string> _materials = new()
        {
            "Cotton",
            "Polyester",
            "Microfiber",
            "Nylon",
            "Synthetic",
            "Gore-Tex",
            "Spandex",
            "Calico",
            "Bamboo-Fiber"
        };

        private List<bool> _active = new()
        {
            true,
            false
        };

        /// <summary>
        /// Generates a randomized product SKU.
        /// </summary>
        /// <returns>A SKU string.</returns>
        private string GetRandomSku()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(RandomString(3));
            builder.Append('-');
            builder.Append(_skuMods[_rand.Next(0, _skuMods.Count)]);

            return builder.ToString().ToUpper();
        }

        /// <summary>
        /// Returns a random demographic from the list of demographics.
        /// </summary>
        /// <returns>A demographic string.</returns>
        private string GetDemographic()
        {
            return _demographics[_rand.Next(0, _demographics.Count)];
        }

        /// <summary>
        /// Generates a random product offering id.
        /// </summary>
        /// <returns>A product offering string.</returns>
        private string GetRandomProductId()
        {
            return "po-" + RandomString(7);
        }

        /// <summary>
        /// Generates a random style code.
        /// </summary>
        /// <returns>A style code string.</returns>
        private string GetStyleCode()
        {
            return "sc" + RandomString(5);
        }

        /// <summary>
        /// Generates a random price between 19.99 and 199.99.
        /// </summary>
        /// <returns>A price double.</returns>
        private decimal GetPrice()
        {

            double minValue = 19.99;
            double maxValue = 200;
            double random = _rand.NextDouble();
            double price = minValue + (random * (maxValue - minValue));
            var priceString = String.Format("{0:0.00}", price);

            return Decimal.Parse(priceString);
        }
        /// <summary>
        /// Generates a random integer less than 10000 for the quantity field .
        /// </summary>
        /// <returns>A quantity integer</returns>
        private int GetQuantity()
        {
            return _rand.Next(0, 10000);
        }

        private DateTime GetReleaseDate()
        {
            //sets the minimum date to 1/1/2020
            var minDate = new DateTime(2020, 1, 1);
            //sets the maximum date to the current date
            var maxDate = DateTime.Now;
            //sets the range that release dates can be to any day between minDate and maxDate in daye
            var range = Convert.ToInt32(maxDate.Subtract(minDate).TotalDays);
            //returns a random day from the range of days starting at the minDate
            return minDate.AddDays(_rand.Next(range));


        }

        /// <summary>
        /// Assigns the image source based on the {type} of product.
        /// </summary>
        /// <param name="type">type of product</param>
        /// <returns>a string that is a URL to an image source</returns>
        private string GetImageSrc(string type)
        {
            string source;
            switch (type)
            {
                case "Pant": source = "https://m.media-amazon.com/images/I/51cxynn5yIL._AC_UX569_.jpg";
                    break;
                case "Short": source = "https://m.media-amazon.com/images/I/71c0K11eDeS._AC_UX569_.jpg";
                    break;
                case "Shoe": source = "https://m.media-amazon.com/images/I/41huVYB16VL._AC_.jpg";
                    break;
                case "Glove": source = "https://m.media-amazon.com/images/I/81blOUiYdaL._AC_SX679_.jpg";
                    break;
                case "Jacket": source = "https://m.media-amazon.com/images/I/61ZNBEQpQ0L._AC_UX679_.jpg";
                    break;
                case "Tank Top": source = "https://m.media-amazon.com/images/I/81WMOaI0zbL._AC_UX466_.jpg";
                    break;
                case "Sock": source = "https://m.media-amazon.com/images/I/81+Yg21pxJL._AC_UX679_.jpg";
                    break;
                case "Sunglasses": source = "https://m.media-amazon.com/images/I/61tta3M0geS._AC_SX522_.jpg";
                    break;
                case "Hat": source = "https://m.media-amazon.com/images/I/71LPDt9QbAL._AC_SX466._SX._UX._SY._UY_.jpg";
                    break;
                case "Helmet": source = "https://m.media-amazon.com/images/I/711+u8SbLnL._AC_SX679_.jpg";
                    break;
                case "Belt": source = "https://m.media-amazon.com/images/I/81tjDxwjErS._AC_UX466_.jpg";
                    break;
                case "Visor": source = "https://m.media-amazon.com/images/I/81kQfSNbNAL._AC_UY445_.jpg";
                    break;
                case "Shin Guard": source = "https://m.media-amazon.com/images/I/41tDyH7SZPL._AC_.jpg";
                    break;
                case "Elbow Pad": source = "https://m.media-amazon.com/images/I/81wiqyEka0S._AC_SL1500_.jpg";
                    break;
                case "Headband": source = "https://m.media-amazon.com/images/I/61az40d6MGL._AC_SX679_.jpg";
                    break;
                case "Wristband": source = "https://m.media-amazon.com/images/I/91j6AUptoLL._AC_UX466_.jpg";
                    break;
                case "Hoodie": source = "https://m.media-amazon.com/images/I/81rc97tuOhL._AC_UX569_.jpg";
                    break;
                case "Flip Flop": source = "https://m.media-amazon.com/images/I/61Sh6GpKroL._AC_UY500_.jpg";
                    break;
                case "Pool Noodle": source = "https://m.media-amazon.com/images/I/81t6UzFSWQL._AC_SY679_.jpg";
                    break;
                default: source = "https://www.signfix.com.au/wp-content/uploads/2017/09/placeholder-600x400.png";
                    break;
            }

            return source;
        }
        /// <summary>
        /// Generates a number of random products based on input.
        /// </summary>
        /// <param name="numberOfProducts">The number of random products to generate.</param>
        /// <returns>A list of random products.</returns>
        public List<Product> GenerateRandomProducts(int numberOfProducts)
        {

            var productList = new List<Product>();

            for (var i = 0; i < numberOfProducts; i++)
            {
                productList.Add(CreateRandomProduct(i + 1));
            }

            return productList;
        }

        /// <summary>
        /// Uses random generators to build a products.
        /// </summary>
        /// <param name="id">ID to assign to the product.</param>
        /// <returns>A randomly generated product.</returns>
        private Product CreateRandomProduct(int id)
        {
            var cat = _categories[_rand.Next(0, _categories.Count)];
            var adj = _adjectives[_rand.Next(0, _adjectives.Count)];
            var demo = GetDemographic();
            var type = _types[_rand.Next(0, _types.Count)];


            return new Product
            {
                Id = id,
                Category = cat,
                Type = type,
                Sku = GetRandomSku(),
                Demographic = demo,
                GlobalProductCode = GetRandomProductId(),
                StyleNumber = GetStyleCode(),
                ReleaseDate = GetReleaseDate(),
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Active = _active[_rand.Next(0, _active.Count)],
                Description = cat + " " + demo + " " + adj,
                Name = adj + " " + cat + " " + type,
                PrimaryColorCode = _colors[_rand.Next(0, _colors.Count)],
                SecondaryColorCode = _colors[_rand.Next(0, _colors.Count)],
                Brand = _brands[_rand.Next(0, _brands.Count)],
                Material = _materials[_rand.Next(0, _materials.Count)],
                Price = GetPrice(),
                Quantity = GetQuantity(),
                ImageSrc = GetImageSrc(type)
            };
        }

        /// <summary>
        /// Generates a random string of characters.
        /// </summary>
        /// <param name="size">Number of characters in the string.</param>
        /// <param name="lowerCase">Boolean if the character string should be lowercase only; defaults to false.</param>
        /// <returns>A random string of characters.</returns>
        private string RandomString(int size, bool lowerCase = false)
        {

            // ** Learning moment **
            // Code From
            // https://www.c-sharpcorner.com/article/generating-random-number-and-string-in-C-Sharp/

            // ** Learning moment **
            // Always use a string builder when concatenating more than a couple of strings.
            // Why? https://www.geeksforgeeks.org/c-sharp-string-vs-stringbuilder/
            var builder = new StringBuilder(size);

            // Unicode/ASCII Letters are divided into two blocks
            // (Letters 65–90 / 97–122):
            // The first group containing the uppercase letters and
            // the second group containing the lowercase.  

            // char is a single Unicode character  
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26; // A...Z or a..z: length=26  

            for (var i = 0; i < size; i++)
            {
                // ** Learning moment **
                // Because 'char' is a reserved word you can put '@' at the beginning to allow
                // its use as a variable name.  You could do the same thing with 'class'
                var @char = (char)_rand.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }
    }
}

