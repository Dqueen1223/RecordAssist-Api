using RecordAssist.Health.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace RecordAssist.Health.Data.Context
{
    public static class Extensions
    {
        /// <summary>
        /// Produces a set of seed data to insert into the database on startup.
        /// </summary>
        /// <param name="modelBuilder">Used to build model base DbContext.</param>
        public static void SeedData(this ModelBuilder modelBuilder)
        {

            var patient1 = new Patient()
            {
                Id = 1,
                FirstName = "Hulk",
                LastName = "Hogan",
                Ssn = "123-45-6789",
                Email = "hulksnewemailaddress@wwf.com",
                Age = 66,
                Height = 79,
                Weight = 299,
                Insurance = "Self-Insured",
                Gender = "Male",
                Street = "8430 W Sunset Blvd",
                City = "Los Angeles",
                State = "CA",
                Postal = "90049"
            };

            var patient2 = new Patient()
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Ssn = "123-45-6789",
                Email = "something@gmail.com",
                Age = 24,
                Height = 77,
                Weight = 111,
                Insurance = "Insured",
                Gender = "Female",
                Street = "9933 Sandshrew bld.",
                City = "Elkridge",
                State = "MD",
                Postal = "90049"
            };
            var patient3 = new Patient()
            {
                Id = 3,
                FirstName = "Mary",
                LastName = "Doe",
                Ssn = "333-44-6559",
                Email = "NewEmail@gmail.com",
                Age = 33,
                Height = 68,
                Weight = 111,
                Insurance = "Insured",
                Gender = "Female",
                Street = "9933 Sandshrew bld.",
                City = "Elkridge",
                State = "MD",
                Postal = "90049"
            };
            var encounter = new Encounter()
            {
                Id = 1,
                PatientId = 1,
                Notes = "new encounter",
                VisitCode = "N3W 3C3",
                Provider = "New Hospital",
                BillingCode = "123.456.789-00",
                Icd10 = "Z99",
                TotalCost = 0.11M,
                Copay = 0,
                ChiefComplaint = "new complaint",
                Pulse = null,
                Systolic = null,
                Diastolic = null,
                Date = DateTime.Parse("2020-08-04")
            };
            modelBuilder.Entity<Patient>().HasData(patient1);
            modelBuilder.Entity<Patient>().HasData(patient2);
            modelBuilder.Entity<Patient>().HasData(patient3);
            modelBuilder.Entity<Encounter>().HasData(encounter);

        }
    }
}
