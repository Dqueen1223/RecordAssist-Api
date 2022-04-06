using RecordAssist.Health.Data.Model;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace RecordAssist.Test.Integration
{
    public class EncounterIntegrationTests : IntegrationTests
    {
        [Fact]
        public async Task CreateEncounter_Returns201()
        {
            var encounter = new Encounter
            {
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
            string serializedEncounter = JsonSerializer.Serialize(encounter);
            var requestContent = new StringContent(serializedEncounter, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/patients/1/encounters", requestContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task CreateEncounter_Returns400()
        {
            var encounter = new Encounter
            {
                PatientId = 1,
                Notes = "new encounter",
                VisitCode = "N3Ww 3E3",
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
            string serializedEncounter = JsonSerializer.Serialize(encounter);
            var requestContent = new StringContent(serializedEncounter, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/patients/1/encounters", requestContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task UpdateEncounter_Returns200()
        {
            var encounter = new Encounter
            {
                Id = 1,
                PatientId = 1,
                Notes = "new encounter",
                VisitCode = "N3W 3E3",
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
            string serializedEncounter = JsonSerializer.Serialize(encounter);
            var requestContent = new StringContent(serializedEncounter, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/patients/1/encounters/1", requestContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdateEncounter_Returns404()
        {
            var encounter = new Encounter
            {
                Id = 13333,
                PatientId = 1,
                Notes = "new encounter",
                VisitCode = "N3W 3E3",
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
            string serializedEncounter = JsonSerializer.Serialize(encounter);
            var requestContent = new StringContent(serializedEncounter, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/patients/1/encounters/13333", requestContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task UpdateEncounter_Returns400()
        {
            var encounter = new Encounter
            {
                Id = 1,
                PatientId = 1,
                Notes = "new encounter",
                VisitCode = "N3W ee3",
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
            string serializedEncounter = JsonSerializer.Serialize(encounter);
            var requestContent = new StringContent(serializedEncounter, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("/patients/1/encounters/13333", requestContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

