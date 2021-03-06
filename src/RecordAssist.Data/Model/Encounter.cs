using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecordAssist.Health.Data.Model
{
    /// <summary>
    /// Describes an Encounter of a patient.
    /// </summary>
    public class Encounter : BaseEntity
    {

        [Column("PatientId")]
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

        private sealed class EncounterEqualityComparer : IEqualityComparer<Encounter>
        {
            public bool Equals(Encounter x, Encounter y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.PatientId == y.PatientId && x.Notes == y.Notes && x.VisitCode == y.VisitCode && x.Provider == y.Provider && x.BillingCode == y.BillingCode && x.Icd10 == y.Icd10 && x.TotalCost == y.TotalCost && x.Copay == y.Copay && x.ChiefComplaint == y.ChiefComplaint && x.Pulse == y.Pulse && x.Systolic == y.Systolic && x.Diastolic == y.Diastolic && x.Date == y.Date;
            }

            public int GetHashCode(Encounter obj)
            {
                return HashCode.Combine(obj.PatientId, obj.Notes, obj.VisitCode, obj.Provider, obj.BillingCode, obj.Icd10, obj.TotalCost, obj.Copay);
            }
        }

        public static IEqualityComparer<Encounter> EncounterComparer { get; } = new EncounterEqualityComparer();
    }
}
