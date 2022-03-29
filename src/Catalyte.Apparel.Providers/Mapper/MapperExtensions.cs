using AutoMapper;
using Catalyte.SuperHealth.Data.Model;
using Catalyte.SuperHealth.DTOs.Encounters;
using Catalyte.SuperHealth.DTOs.Patients;
using System;

namespace Catalyte.SuperHealth.API.DTOMappings
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Helper method to build model for a encounter DTO.
        /// </summary>
        /// <param name="encounter">The encounter to be persisted.</param>
        /// <returns>A encounter DTO.</returns>
        public static EncounterDTO MapEncounterToEncounterDto(this IMapper mapper, Encounter encounter)
        {
            return new EncounterDTO()
            {
                PatientId = encounter.PatientId,
                Notes = encounter.Notes,
                VisitCode = encounter.VisitCode,
                Provider = encounter.Provider,
                BillingCode = encounter.BillingCode,
                Icd10 = encounter.Icd10,
                TotalCost = encounter.TotalCost,
                Copay = encounter.Copay,
                ChiefComplaint = encounter.ChiefComplaint,
                Pulse = encounter.Pulse,
                Systolic = encounter.Systolic,
                Diastolic = encounter.Diastolic,
                Date = encounter.Date
            };
        }

        public static PatientDTO MapPatientToPatientDto(this IMapper mapper, Patient patient)
        {
            return new PatientDTO()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Ssn = patient.Ssn,
                Email = patient.Email,
                Street = patient.Street,
                City = patient.City,
                State = patient.State,
                Age = patient.Age,
                Height = patient.Height,
                Weight = patient.Weight,
                Insurance = patient.Insurance,
                Gender = patient.Gender,
                Postal = patient.Postal,
            };
        }
        public static Patient MapCreatePatientDtoToPatient(this IMapper mapper, PatientDTO patientDTO)
        {
            var patient = new Patient
            {
                DateCreated = DateTime.Now,
            };
            patient = mapper.Map(patientDTO, patient);

            return patient;
        }
    }
}
