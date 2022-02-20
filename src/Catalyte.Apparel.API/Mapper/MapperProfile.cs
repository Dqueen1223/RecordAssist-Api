using AutoMapper;
using Catalyte.Apparel.Data.Model;
using Catalyte.Apparel.DTOs;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.DTOs.Promos;
using Catalyte.Apparel.DTOs.Purchases;
<<<<<<< HEAD
using Catalyte.Apparel.DTOs.Reviews;
=======
using Catalyte.Apparel.DTOs.ShippingRate;
>>>>>>> e714bf42316e5767c876d0b94a74b7bc7cd846a9

namespace Catalyte.Apparel.API
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<CreatePurchaseDTO, Purchase>();

            CreateMap<Purchase, PurchaseDTO>();
            CreateMap<Purchase, DeliveryAddressDTO>().ReverseMap();
            CreateMap<Purchase, CreditCardDTO>().ReverseMap();
            CreateMap<Purchase, BillingAddressDTO>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.BillingEmail))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.BillingPhone))
                .ReverseMap();

            CreateMap<LineItem, LineItemDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Review, ReviewsDTO>().ReverseMap();

            CreateMap<Promo, PromoDTO>();

            CreateMap<CreatePromoDTO, Promo>();

            CreateMap<ShippingRate, ShippingRateDTO>();

            CreateMap<ShippingRateDTO, ShippingRate>();
        }

    }
}
