using BookingRoomDal.Abstract;
using System.Collections.Generic;
using BookingRoomModels;
using System;

namespace BookingRoomServices
{
    public class BookingServices : IBookingServices
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingServices(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking Add(Booking booking)
        {
            return _bookingRepository.Add(booking);
        }

        public void Delete(int id)
        {
            _bookingRepository.Delete(id);
        }

        public Booking Get(int id)
        {
            return _bookingRepository.Get(id);
        }


    }
}
