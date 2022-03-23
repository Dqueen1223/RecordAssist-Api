using System;
namespace Catalyte.Apparel.DTOs.Encounters
{
    /// <summary>
    /// Describes a data transfer objecct for a single line item of a purchase transaction.
    /// </summary>
    public class EncounterDTO
    {
        public int PatientId { get; set; }

        public string Notes { get; set; }

        public string VisitCode { get; set; }

        public string Provider { get; set; }

        public string BillingCode { get; set; }

        public string Icd10 { get; set; }

        public decimal TotalCost { get; set; }

        public int Copay { get; set; }

        public string ChiefComplaint { get; set; }

        public Nullable<int> Pulse { get; set; }

        public Nullable<int> Systolic { get; set; }

        public Nullable<int> Diastolic { get; set; }

        public DateTime Date { get; set; }
    }
}
