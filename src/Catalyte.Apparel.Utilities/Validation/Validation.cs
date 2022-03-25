﻿using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Catalyte.Apparel.Utilities.Validation
{
    public static class Validation
    {
        /// <summary>
        /// This function validates that credit cards are valid based on multiple criteria.
        /// if invalid, it returns a list of strings. otherwise it returns an empty list.
        /// </summary>
        //public static List<string> CreditCardValidation(Purchase Purchase)
        //{

        //    List<string> errors = new();
        //    //Card number validation
        //    try
        //    {
        //        if (Purchase.CardNumber.Trim() == "" || Purchase.CardNumber == null)
        //            errors.Add("The card number field must not be empty or whitespace. ");

        //        if (Purchase.CardNumber.Trim() != "" && Purchase.CardNumber.Trim().Length < 16 || Purchase.CardNumber.Trim().Length > 19)
        //            errors.Add("Card number length must be between 16 and 19 characters. ");

        //        if (Purchase.CardNumber.Trim() != "" && !Purchase.CardNumber.Trim().All(char.IsDigit))
        //            errors.Add("Card number must be only numbers. ");

        //        if (Purchase.CardNumber.Trim() != "" && Purchase.CardNumber.Trim().First() != '4' && Purchase.CardNumber.Trim().First() != '5')
        //            errors.Add("This credit card provider is not supported. ");
        //    }
        //    catch (Exception)
        //    {
        //        errors.Add("The card number field must not be empty or whitespace. ");
        //    }
        //    //Expiration Validation
        //    try
        //    {
        //        if (Purchase.Expiration.Trim() == "" || Purchase.Expiration == null)
        //            errors.Add("The expiration field must not be empty or whitespace. ");
        //        if (Purchase.Expiration.Trim().Length == 5 && Purchase.Expiration.Trim().Substring(2, 1) == "/")
        //        {
        //            var CardYear = Purchase.Expiration.Trim().Substring(3, 2);
        //            var CardMonth = Purchase.Expiration.Trim().Substring(0, 2);
        //            var CurrentMonth = DateTime.Now.Month;
        //            var CurrentYear = DateTime.Now.Year.ToString().Substring(2, 2);
        //            if (int.Parse(CardYear) > int.Parse(CurrentYear) + 50)
        //                CardYear = $"/19{CardYear}";
        //            else
        //                CardYear = $"/20{CardYear}";

        //            if (Purchase.Expiration.Trim() != "" && DateTime.Parse($"{CurrentMonth}/20{CurrentYear}") > DateTime.Parse($"{CardMonth}{CardYear}"))
        //                errors.Add("This credit card is expired. ");
        //        }
        //        else
        //            errors.Add("Correct format for date is MM/YY ");
        //    }
        //    catch (Exception)
        //    {
        //        errors.Add("This card must be a valid date in MM/YY format. ");
        //    }

        //    if (Purchase.CardHolder == null || Purchase.CardHolder.Trim() == "")
        //        errors.Add("The card holder field must not be empty or whitespace. ");

        //    try
        //    {
        //        if (Purchase.CVV.Length == 0 || Purchase.CVV == null)
        //            errors.Add("The CVV field must not be empty or white space. ");

        //        if (Purchase.CVV.Length != 0 && Purchase.CVV.Trim().Length != 3)
        //            errors.Add("CVV must be 3 digits long. ");

        //        if (Purchase.CVV.Trim() != "" && !Purchase.CVV.Trim().All(char.IsDigit))
        //            errors.Add("CVV must be only numbers. ");
        //    }
        //    catch (Exception)
        //    {
        //        errors.Add("The CVV field must not be empty or white space. ");
        //    }
        //    if (Purchase.CVV == null && Purchase.CardNumber == null && Purchase.Expiration == null && Purchase.CardHolder == null)
        //        throw new BadRequestException("No credit card provided. ");

        //    return errors;
        //}
        /// <summary>
        /// This function validates that promos are valid based on multiple criteria.
        /// if invalid, it returns a list of strings. otherwise it returns an empty list.
        /// </summary>
        public static List<string> PromoValidation(Promo promo)
        {
            List<string> errors = new();
            var count = 0;
            //check for null or default values
            if (promo.Type == null || promo.Type.Trim() == "")
            {
                errors.Add("The type field can't be empty or whitspace.");
                count++;
            }
            else if (promo.Type != "%" && promo.Type != "$")
            {
                errors.Add("The type field expects either % or $.");
                count++;
            }
            if (promo.Code == null || promo.Code.Trim() == "")
            {
                errors.Add("The code field can't be empty or whitspace.");
            }
            else if (!Regex.IsMatch(promo.Code, "^[a-zA-Z0-9]*$"))
            {
                errors.Add("A promotional code may only consist of alphanumeric characters.");
            }
            if (promo.Discount == null)
            {
                errors.Add("The discount field is required.");
                count++;
            }
            else
            {
                if (promo.Discount <= 0 && promo.Type == "$")
                {
                    errors.Add("A flat discount must be greater than 0.");
                }
                else if (promo.Type == "$" && Regex.IsMatch(promo.Discount.ToString(), @"\."))
                {
                    if (!Regex.IsMatch(promo.Discount.ToString(), @"^\d+\.\d{2}?$"))
                    {
                        errors.Add("If the desired discount has a decimal, it must specify to exactly 2 decimal places.");
                    }
                }
            }
            if (count == 0)
            {
                if (promo.Type == "%" && (promo.Discount < 1 || promo.Discount > 100))
                {
                    errors.Add("If Discount type is %, the discount must be between 1 and 100.");
                }
            }
            if (promo.StartDate == null)
            {
                errors.Add("The start date field is required.");
            }
            else if (promo.StartDate >= DateTime.UtcNow)
            {
                errors.Add("The start date must be in the past or today.");
            }
            if (promo.EndDate == null)
            {
                errors.Add("The end date field is required.");
            }
            else if (promo.EndDate < DateTime.UtcNow)
            {
                errors.Add("The end date must be in the future");
            }
            return errors;
        }
        /// <summary>
        /// This function validates that Encounters are valid based on multiple criteria.
        /// if invalid, it returns a list of strings. otherwise it returns an empty list.
        /// </summary>
        public static List<string> EncounterValidation(Encounter encounter)
        {
            List<string> errors = new();
            if (encounter.VisitCode.Trim() == "" || encounter.VisitCode == null)
                errors.Add("VisitCode is required.");
            else if(!Regex.IsMatch(encounter.VisitCode, @"[a-zA-Z]{1}\d{1}[a-zA-Z]{1}\s\d{1}[a-zA-Z]{1}\d{1}"))
                {
                errors.Add("Visit Code Format must match LDL DLD (ex. A1S 2D3)");
            }
            if (encounter.Provider.Trim() == "" || encounter.Provider == null)
                errors.Add("Provider is required.");
            if (encounter.BillingCode.Trim() == "" || encounter.BillingCode == null)
                errors.Add("BillingCode is required.");
            else if (!Regex.IsMatch(encounter.BillingCode, @"\d{3}\.\d{3}\.\d{3}-\d{2}$"))
            {
                errors.Add("BillingCode must match format of xxx.xxx.xxx-xx (ex. 123.456.789-12)");
            }
            if (encounter.Icd10.Trim() == "" || encounter.Icd10 == null)
                errors.Add("icd10 is required.");
            else if (!Regex.IsMatch(encounter.Icd10, @"[a-zA-Z]{1}\d{2}$"))
            {
                errors.Add("idc10 must match format of LDD (ex. A12)");
            }
            if (encounter.TotalCost.ToString() == null)
                    errors.Add("Total cost is required.");
            if (encounter.Copay.ToString() == null)
                errors.Add("Copay is required.");
            if (encounter.ChiefComplaint.Trim() == "" || encounter.ChiefComplaint == null)
                errors.Add("Chief Complaint is required.");
            if (encounter.Date == default)
                errors.Add("Date is required.");
            return errors;
        }
        public static List<string> PatientValidation(Patient patient)
        {
            List<string> errors = new();
            if (patient.FirstName.Trim() == "" || patient.FirstName == null)
                errors.Add("FirstName is required.");
            if (patient.LastName.Trim() == "" || patient.LastName == null)
                errors.Add("LastName is required.");
            if (patient.Ssn.Trim() == "" || patient.Ssn == null)
                errors.Add("Ssn is required.");
            else if (!Regex.IsMatch(patient.Ssn, @"\d{3}-\d{2}-\d{4}$"))
            {
                errors.Add("Must be a valid ssn (ex. 123-45-6798)");
            }
            if (patient.Email.Trim() == "" || patient.Email == null)
                errors.Add("Email is required.");
            else if (!Regex.IsMatch(patient.Email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                errors.Add("Must be a valid email (ex.test@test.com)");
            }
            if (patient.Street.Trim() == "" || patient.Street == null)
                errors.Add("Street is required.");
            if (patient.City.Trim() == "" || patient.City == null)
                errors.Add("City is required.");
            if (patient.State.Trim() == "" || patient.State == null)
                errors.Add("State is required.");
            else if (patient.State.Length != 2)
            {
                errors.Add("State must have a valid two letter state code (ex. MD)");
            }
            if (patient.Postal.Trim() == "" || patient.Postal == null)
                errors.Add("Postal code is required.");
            else if (!Regex.IsMatch(patient.Postal, @"\d{5}$") && !Regex.IsMatch(patient.Postal, @"\d{5}-\d{4}$"))
            {
                errors.Add("Must be a valid zip (ex. 12345 or 12345-6789)");
            }
            if (patient.Age.ToString() == null)
                errors.Add("Age is required.");
            if (patient.Height.ToString() == null)
                errors.Add("Height is required.");
            if (patient.Weight.ToString() == null)
                errors.Add("Weight is required.");
            if (patient.Insurance.Trim() == "" || patient.Insurance == null)
                errors.Add("Insurance is required.");
            if (patient.Gender.Trim() == "" || patient.Gender == null)
                errors.Add("Gender is required.");
            else if (patient.Gender != "Male" && patient.Gender != "Female" && patient.Gender != "Other")
            {
                errors.Add("Gender must be 'Male', 'Female' or 'Other'");
            }
            return errors;
        }
    }
}
