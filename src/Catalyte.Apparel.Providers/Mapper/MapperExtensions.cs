using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs.Patients;
using Catalyte.Apparel.DTOs.Promos;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.Utilities.HttpResponseExceptions;
using Catalyte.Apparel.DTOs.Encounters;

namespace Catalyte.Apparel.API.DTOMappings
{
    public static class MapperExtensions
    {

        //public static IEnumerable<PurchaseDTO> MapPurchasesToPurchaseDtos(this IMapper mapper, IEnumerable<Purchase> purchases)
        //{
        //    return purchases
        //        .Select(x => mapper.MapPurchaseToPurchaseDto(x))
        //        .ToList();
        //}
        public static IEnumerable<PromoDTO> MapPromosToPromoDtos(this IMapper mapper, IEnumerable<Promo> promos)
        {
            return promos
                .Select(x => mapper.MapPromoToPromoDto(x))
                .ToList();
        }
        public static PromoDTO MapPromoToPromoDto(this IMapper mapper, Promo promo)
        {
            return new PromoDTO()
            {
                Id = promo.ID,
                Code = promo.Code,
                Type = promo.Type,
                Discount = promo.Discount,
                StartDate = promo.StartDate,
                EndDate = promo.EndDate
            };
        }
        public static Promo MapCreatePromoDtoToPromo(this IMapper mapper, CreatePromoDTO promoDTO)
        {
            var promo = new Promo() { };
            promo = mapper.Map(promoDTO, promo);
            return promo;
        }
        /// <summary>
        /// Helper method to build model for a purchase DTO.
        /// </summary>
        /// <param name="purchase">The purchase to be persisted.</param>
        /// <returns>A purchase DTO.</returns>
        public static EncounterDTO MapEncounterToEncounterDto(this IMapper mapper, Encounter encounter)
        {
            return new EncounterDTO()
            {
                PatientId = encounter.PatientId,
                //Id = encounter.Id,
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

                //LineItems = mapper.Map<List<EncounterDTO>>(encounter.LineItems),
                //DeliveryAddress = mapper.Map<DeliveryAddressDTO>(encounter),
                //BillingAddress = mapper.Map<BillingAddressDTO>(encounter),
                //CreditCard = mapper.Map<CreditCardDTO>(encounter)

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
        //public static Purchase MapCreatePurchaseDtoToPurchase(this IMapper mapper, CreatePurchaseDTO purchaseDTO)
        //{
        //    var purchase = new Purchase
        //    {
        //        OrderDate = DateTime.UtcNow,
        //    };
        //    if (purchaseDTO.CreditCard == null)
        //    {
        //        throw new BadRequestException("No credit card associated with this purchase");
        //    }
        //    purchase.TotalCost = purchaseDTO.TotalCost;
        //    purchase = mapper.Map(purchaseDTO.DeliveryAddress, purchase);
        //    purchase = mapper.Map(purchaseDTO.BillingAddress, purchase);
        //    purchase = mapper.Map(purchaseDTO.CreditCard, purchase);
        //    purchase.LineItems = mapper.Map(purchaseDTO.LineItems, purchase.LineItems);

        //    return purchase;
        //}

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
