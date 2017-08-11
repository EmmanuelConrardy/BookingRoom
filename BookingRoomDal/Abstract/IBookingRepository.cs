using BookingRoomModels;
using System.Collections.Generic;

namespace BookingRoomDal.Abstract
{
    public interface IBookingRepository
    {
        Booking Add(Booking booking);
        void Delete(int id);
        Booking Get(int id);
    }
}