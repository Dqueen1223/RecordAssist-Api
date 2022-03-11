using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalyte.Apparel.Data.Model
{
    /// <summary>
    /// This class is a representation of Super Health Inc. patients.
    /// </summary>
    public class Patient : BaseEntity
    {
        public int PatientId { get; set; }

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
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
        public static IEqualityComparer<Patient> ProductComparer { get; } = new ProductEqualityComparer();

        private sealed class ProductEqualityComparer : IEqualityComparer<Patient>
        {
            public bool Equals(Patient x, Patient y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.FirstName == y.FirstName && x.LastName == y.LastName && x.Ssn == y.Ssn && x.Email == y.Email && x.Street == y.Street && x.City == y.City && x.State == y.State && x.ZipCode == y.ZipCode && x.Age == y.Age && x.Height == y.Height && x.Weight == y.Weight && x.Insurance == y.Insurance && x.Gender == y.Gender;
            }

            public int GetHashCode(Patient obj)
            {
                var hashCode = new HashCode();
                hashCode.Add(obj.FirstName);
                hashCode.Add(obj.LastName);
                hashCode.Add(obj.Ssn);
                hashCode.Add(obj.Email);
                hashCode.Add(obj.Street);
                hashCode.Add(obj.City);
                hashCode.Add(obj.State);
                hashCode.Add(obj.ZipCode);
                hashCode.Add(obj.Age);
                hashCode.Add(obj.Height);
                hashCode.Add(obj.Weight);
                hashCode.Add(obj.Insurance);
                hashCode.Add(obj.Gender);

                return hashCode.ToHashCode();
            }
        }

    }

}

