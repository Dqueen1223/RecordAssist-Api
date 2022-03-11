namespace Catalyte.Apparel.DTOs.Patients
{
    /// <summary>
    /// Describes a data transfer object for patients.
    /// </summary>
    public class PatientDTO
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string Email { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string Age { get; set; }

        public string Height { get; set; }

        public bool Weight { get; set; }

        public string Insurance { get; set; }

        public string Gender { get; set; }

    }
}
