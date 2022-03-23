using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// Describes an Encounter of a patient.
    /// </summary>
    public class Encounter : BaseEntity
    {
        //[Column("EncounterId")]
        //public int PurchaseId { get; set; }

        [Column("PatientId")]
        public int PatientId { get; set; }

        public string Notes { get; set; }

        public string VisitCode { get; set; }

        public string Provider { get; set; }

        public string BillingCode { get; set; }

        public string Icd10 { get; set; }

        public decimal TotalCost { get; set; }

        public int Copay { get; set; }

        public string ChiefComplaint { get; set; }

        public int Pulse { get; set; }

        public int Systolic { get; set; }

        public int Diastolic { get; set; }

        public DateTime Date { get; set; }

        //public Patient Patient { get; set; }

        //    private sealed class EncounterIdPatientIdEqualityComparer : IEqualityComparer<Encounter>
        //    {
        //        public bool Equals(Encounter x, Encounter y)
        //        {
        //            if (ReferenceEquals(x, y)) return true;
        //            if (ReferenceEquals(x, null)) return false;
        //            if (ReferenceEquals(y, null)) return false;
        //            if (x.GetType() != y.GetType()) return false;
        //            return x.Id == y.Id && x.PatientId == y.PatientId;
        //        }

        //        public int GetHashCode(Encounter obj)
        //        {
        //            return HashCode.Combine(obj.Id, obj.PatientId);
        //        }
        //    }
        //    public static IEqualityComparer<Encounter> EncounterIdPatientIdComparer { get; } = new EncounterIdPatientIdEqualityComparer();
        //}
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
