using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Utilities.Validation;
using System.Collections.Generic;
using Xunit;

namespace Catalyte.Apparel.UnitTesting
{
    public class UnitTests
    {

        [Fact]
        public void CreditCardValidationTestNoneValid()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "Mary Jpnes";
            creditCard.CVV = 1234;
            creditCard.CardNumber = "";
            creditCard.Expiration = "11/20";

            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "The card number field must not be empty or whitespace. ",
                "This credit card is expired. ",
                "CVV must be 3 digits long. ",
            };
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void CreditCardValidationTestValid()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "Mary Jones";
            creditCard.CVV = 123;
            creditCard.CardNumber = "4123123412341234";
            creditCard.Expiration = "11/22";
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new();
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void CreditCardValidationTestEmpty()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "";
            creditCard.CVV = 123;
            creditCard.CardNumber = "";
            creditCard.Expiration = "";
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "The card number field must not be empty or whitespace. ",
                "The expiration field must not be empty or whitespace. ",
                "The card holder field must not be empty or whitespace. ",
            };
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void CreditCardValidationTestNull()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = null;
            creditCard.CVV = 0;
            creditCard.CardNumber = null;
            creditCard.Expiration = null;
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "The card number field must not be empty or whitespace. ",
                "The expiration field must not be empty or whitespace. ",
                "The card holder field must not be empty or whitespace. ",
                "The CVV field must not be empty or white space. "
            };
            Assert.Equal(Expected, Actual);
        }
    }
}

