using Catalyte.SuperHealth.Data.Model;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Catalyte.Apparel.Utilities.Validation
{
    public static class Validation
    {

        /// <summary>
        /// This function validates that Encounters are valid based on multiple criteria.
        /// </summary>
        /// <param name="encounter"></param>
        /// <returns>if invalid, it returns a list of error strings. otherwise it returns an empty list.</returns>
        public static List<string> EncounterValidation(Encounter encounter)
        {
            List<string> errors = new();
            if (encounter.VisitCode.Trim() == "" || encounter.VisitCode == null)
                errors.Add("VisitCode is required.");
            else if (!Regex.IsMatch(encounter.VisitCode, @"[a-zA-Z]{1}\d{1}[a-zA-Z]{1}\s\d{1}[a-zA-Z]{1}\d{1}"))
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
        /// <summary>
        /// This function validates that patients are valid based on multiple criteria.
        /// </summary>
        /// <param name="patient"></param>
        /// <returns>if invalid, it returns a list of error strings. otherwise it returns an empty list.</returns>
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
