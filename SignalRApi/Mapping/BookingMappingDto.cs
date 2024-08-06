using AutoMapper;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
    public class BookingMappingDto:Profile
    {
        public BookingMappingDto()
        {
            CreateMap<Booking,ResultBookingDto>().ReverseMap();
            CreateMap<Booking,CreateBookingDto>().ReverseMap();
            CreateMap<Booking,UpdateBookingDto>().ReverseMap();
            CreateMap<Booking, GetBookingDto>().ReverseMap();

        }
    }
}
