using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Utilities.Validation;
using System.Collections.Generic;
using Xunit;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.Serialization;
using System;



namespace Catalyte.Apparel.UnitTesting
{
    public class UnitTests
    {
        [Fact]
        public void CreditCardValidationTestNoneValid()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "Mary Jpnes";
            creditCard.CVV = "1234";
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
            creditCard.CVV = "123";
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
            creditCard.CVV = "123";
            creditCard.CardNumber = "";
            creditCard.Expiration = "";
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "The card number field must not be empty or whitespace. ",
                "The expiration field must not be empty or whitespace. ",
                "Correct format for date is MM/YY ",
                "The card holder field must not be empty or whitespace. "
            };
            Assert.Equal(Expected, Actual);
        }
            
        [Fact]
        public void CreditCardExpirationAboveYear72ReturnsError()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "Json";
            creditCard.CVV = "123";
            creditCard.CardNumber = "4132402120390213";
            creditCard.Expiration = "02/73";
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "This credit card is expired. "
            };
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void CreditCardExpirationBelowYear72DoesntReturnError()
        {
            Purchase creditCard = new();
            creditCard.CardHolder = "Json";
            creditCard.CVV = "123";
            creditCard.CardNumber = "4132402120390213";
            creditCard.Expiration = "02/72";
            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
            };
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void ThisMonthAndThisYearReturnsTrue()
        {
            var CurrentMonth = DateTime.Now.Month;
            
            var CurrentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            Purchase creditCard = new();
            creditCard.CardHolder = "Json";
            creditCard.CVV = "123";
            creditCard.CardNumber = "4132402120390213";
            if (CurrentMonth < 10)
            {
                creditCard.Expiration = $"0{CurrentMonth}/{CurrentYear}";
            }
            else
                creditCard.Expiration = $"{CurrentMonth}/{CurrentYear}";

              var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
            };
            Assert.Equal(Expected, Actual);
        }
        [Fact]
        public void ThisYearLastMonthReturnError()
        {
            var CurrentMonth = DateTime.Now.Month -1;

            var CurrentYear = DateTime.Now.Year.ToString().Substring(2, 2);
            Purchase creditCard = new();
            creditCard.CardHolder = "Json";
            creditCard.CVV = "123";
            creditCard.CardNumber = "4132402120390213";
            if (CurrentMonth < 10)
            {
                creditCard.Expiration = $"0{CurrentMonth}/{CurrentYear}";
            }
            else
                creditCard.Expiration = $"{CurrentMonth}/{CurrentYear}";

            var Actual = Validation.CreditCardValidation(creditCard);
            List<string> Expected = new()
            {
                "This credit card is expired. "
            };
            Assert.Equal(Expected, Actual);
        }
    }
}

