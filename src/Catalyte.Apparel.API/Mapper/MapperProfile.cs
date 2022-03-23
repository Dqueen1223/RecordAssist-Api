using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.DTOs.Patients;
using Catalyte.Apparel.DTOs.Promos;
using Catalyte.Apparel.DTOs.Purchases;
using Catalyte.Apparel.DTOs.Reviews;
using Catalyte.Apparel.DTOs.Encounters;
using Catalyte.Apparel.DTOs.ShippingRate;

namespace Catalyte.Apparel.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Patient, PatientDTO>().ReverseMap();
            CreateMap<Encounter, EncounterDTO>();

            //CreateMap<Purchase, PurchaseDTO>();
            //CreateMap<Purchase, DeliveryAddressDTO>().ReverseMap();
            //CreateMap<Purchase, CreditCardDTO>().ReverseMap();
            //CreateMap<Purchase, BillingAddressDTO>()
            //    .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.BillingEmail))
            //    .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.BillingPhone))
            //    .ReverseMap();
            //CreateMap<LineItem, LineItemDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Review, ReviewsDTO>().ReverseMap();

            CreateMap<Promo, PromoDTO>();

            CreateMap<CreatePromoDTO, Promo>();

            CreateMap<ShippingRate, ShippingRateDTO>();

            CreateMap<ShippingRateDTO, ShippingRate>();
        }

    }
}
