using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repository;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.EntityFramework;

public class EfBookingDal : GenericRepository<Booking>, IBookingDal
{
    public EfBookingDal(SignalRContext context) : base(context)
    {
    }
}