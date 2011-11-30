using AutoMapper;
using DiscountMe.BL;
using DiscountMe.BL.DTO;

namespace DiscountMe.WebServicesLayer {
    public static class AutoMapperConfiguration {
        public static void Initialize() {
            Mapper.CreateMap<Discount, DiscountDTO>()
                .ForMember(dd => dd.Latitude, d => d.MapFrom(dis => dis.Advertiser.Latitude))
                .ForMember(dd => dd.Longitude, dis => dis.MapFrom(d => d.Advertiser.Longitude));
        }
    }
}