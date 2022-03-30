using Catalyte.SuperHealth.Data.Model;
using Catalyte.SuperHealth.DTOs.Patients;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Catalyte.SuperHealth.Test.Integration
{
    public class PatientIntegrationTests : IntegrationTests
    {

        [Fact]
        public async Task CreatePatient_Returns201()
        {
            //HttpContent patient 
            var patient = new Patient
            {
                FirstName = "TESTName",
                LastName = "Last",
                Email = "somethine2g@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "Insured",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CA",
                Postal = "12345",
            };
            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/patients", requestContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
        [Fact]
        public async Task CreatePatient_Returns409()
        {
            var patient = new Patient
            {
                FirstName = "TestName",
                LastName = "Last",
                Email = "something@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "Insured",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CA",
                Postal = "12345",
            };

            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/patients", requestContent);
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }
        [Fact]
        public async Task CreatePatient_Returns400()
        {
            var patient = new Patient
            {
                FirstName = "TESTName",
                LastName = "Edeef",
                Email = "somethine2g@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CeA",
                Postal = "12345",
            };

            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/patients", requestContent);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        [Fact]
        public async Task GetPatients_Returns200()
        {
            var response = await _client.GetAsync("/patients");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task GetPatientById_GivenByExistingId_Returns200()
        {
            var response = await _client.GetAsync("/patients/1");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsAsync<PatientDTO>();
            Assert.Equal(1, content.Id);
        }
        [Fact]
        public async Task GetPatientById_GivenByExistingId_Returns404()
        {
            var response = await _client.GetAsync("/patients/111111");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task DeletePatientsByIdAsync_Returns204()
        {
            var response = await _client.DeleteAsync("/patients/2");
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        [Fact]
        public async Task DeletePatientsByIdAsync_Returns409IfEncounters()
        {
            var response = await _client.DeleteAsync("/patients/1");
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }
        [Fact]
        public async Task DeletePatientsByIdAsync_Returns404IfNoPatientFound()
        {
            var response = await _client.DeleteAsync("/patients/9999");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task UpdatePatientById_Returns200()
        {
            var patient = new Patient
            {
                Id = 1,
                FirstName = "testupdate",
                LastName = "Edeef",
                Email = "somethinqweqweqee2g@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "Insured",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CA",
                Postal = "12345",
            };
            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("patients/1", requestContent);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task UpdatePatientById_Returns404()
        {
            var patient = new Patient
            {
                Id = 333333,
                FirstName = "testupdate",
                LastName = "Edeef",
                Email = "somethine2g@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "Insured",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CA",
                Postal = "12345",
            };
            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("patients/33333", requestContent);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public async Task UpdatePatientById_Returns409()
        {
            var patient = new Patient
            {
                Id = 1,
                FirstName = "testupdate",
                LastName = "Edeef",
                Email = "somethine2g@gmail.com",
                Ssn = "123-45-6789",
                Age = 67,
                Height = 80,
                Weight = 300,
                Insurance = "Insured",
                Gender = "Male",
                Street = "Street",
                City = "city",
                State = "CA",
                Postal = "12345",
            };
            string serializedPatient = JsonSerializer.Serialize(patient);
            var requestContent = new StringContent(serializedPatient, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync("patients/1", requestContent);
            Assert.Equal(HttpStatusCode.Conflict, response.StatusCode);
        }

    }
}