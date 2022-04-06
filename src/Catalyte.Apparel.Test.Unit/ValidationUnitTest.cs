using RecordAssist.Health.Data.Model;
using RecordAssist.Health.Utilities.Validation;
using System.Collections.Generic;
using Xunit;


namespace RecordAssist.Health.Test.Unit
{
    public class UnitTests
    {
        [Fact]
        public void CreditCardValidationTestNoneValid()
        {
            Patient patient = new();
            patient.FirstName = "Mary";
            patient.LastName = "Jones";
            patient.Ssn = "123-45-1234";
            patient.Email = "somethingnew@gmail.com";
            patient.Age = 34;
            patient.Height = 88;
            patient.Weight = 233;
            patient.Insurance = "Insured";
            patient.Gender = "Male";
            patient.Street = "Street";
            patient.City = "LA";
            patient.State = "CA";
            patient.Postal = "03930";

            var Actual = Validation.PatientValidation(patient);
            List<string> Expected = new()
            {
            };
            Assert.Equal(Expected, Actual);
        }
    }
}
//        [Fact]
//        public void CreditCardValidationTestValid()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Mary Jones";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "4123123412341234";
//            creditCard.Expiration = "11/22";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new();
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void CreditCardValidationTestEmpty()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "";
//            creditCard.Expiration = "";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "The card number field must not be empty or whitespace. ",
//                "The expiration field must not be empty or whitespace. ",
//                "Correct format for date is MM/YY ",
//                "The card holder field must not be empty or whitespace. "
//            };
//            Assert.Equal(Expected, Actual);
//        }

//        [Fact]
//        public void CreditCardExpirationAboveYear72ReturnsError()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "4132402120390213";
//            creditCard.Expiration = "02/73";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "This credit card is expired. "
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void CreditCardExpirationBelowYear72DoesntReturnError()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "4132402120390213";
//            creditCard.Expiration = "02/72";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void NullCVVReturnserror()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "";
//            creditCard.CardNumber = "4132402120390213";
//            creditCard.Expiration = "02/72";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "The CVV field must not be empty or white space. "
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void UnsupportedCreditCardReturnsError()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "1111222233334444";
//            creditCard.Expiration = "02/72";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "This credit card provider is not supported. "
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void shortCardLengthreturnserror()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "411122223333444";
//            creditCard.Expiration = "02/72";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "Card number length must be between 16 and 19 characters. "
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void longCardLengthreturnserror()
//        {
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "41112222333344445555";
//            creditCard.Expiration = "02/72";
//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "Card number length must be between 16 and 19 characters. "
//            };
//            Assert.Equal(Expected, Actual);
//        }

//        [Fact]
//        public void ThisMonthAndThisYearReturnsTrue()
//        {
//            var CurrentMonth = DateTime.Now.Month;

//            var CurrentYear = DateTime.Now.Year.ToString().Substring(2, 2);
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "4132402120390213";
//            if (CurrentMonth < 10)
//            {
//                creditCard.Expiration = $"0{CurrentMonth}/{CurrentYear}";
//            }
//            else
//                creditCard.Expiration = $"{CurrentMonth}/{CurrentYear}";

//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//            };
//            Assert.Equal(Expected, Actual);
//        }
//        [Fact]
//        public void ThisYearLastMonthReturnError()
//        {
//            var CurrentMonth = DateTime.Now.Month - 1;

//            var CurrentYear = DateTime.Now.Year.ToString().Substring(2, 2);
//            Purchase creditCard = new();
//            creditCard.CardHolder = "Json";
//            creditCard.CVV = "123";
//            creditCard.CardNumber = "4132402120390213";
//            if (CurrentMonth < 10)
//            {
//                creditCard.Expiration = $"0{CurrentMonth}/{CurrentYear}";
//            }
//            else
//                creditCard.Expiration = $"{CurrentMonth}/{CurrentYear}";

//            var Actual = Validation.CreditCardValidation(creditCard);
//            List<string> Expected = new()
//            {
//                "This credit card is expired. "
//            };
//            Assert.Equal(Expected, Actual);
//        }
//    }
//}

