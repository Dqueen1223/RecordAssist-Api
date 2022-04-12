using System;
namespace RecordAssist.Health.DTOs.Encounters
{
    /// <summary>
    /// Describes a data transfer object for any associated encounters.
    /// </summary>
    public class EncounterDTO
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public string Notes { get; set; }

        public string VisitCode { get; set; }

        public string Provider { get; set; }

        public string BillingCode { get; set; }

        public string Icd10 { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Copay { get; set; }

        public string ChiefComplaint { get; set; }

        public Nullable<int> Pulse { get; set; }

        public Nullable<int> Systolic { get; set; }

        public Nullable<int> Diastolic { get; set; }

        public DateTime Date { get; set; }
    }
}
