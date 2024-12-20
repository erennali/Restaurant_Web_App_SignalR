using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }
    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetListAll();
        return Ok(values);
    }

    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBookingDto)
    {
        Booking booking = new Booking()
        {
            Mail = createBookingDto.Mail,
            Phone = createBookingDto.Phone,
            Date = createBookingDto.Date,
            Name = createBookingDto.Name,
            PersonCount = createBookingDto.PersonCount,
        };
        _bookingService.TAdd(booking);
        return Ok("Rezervasyon Yapıldı");
    }

    [HttpDelete]
    public IActionResult DeleteBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        _bookingService.TDelete(value);
        return Ok("Rezervasyon Silindi");
    }

    [HttpPut]
    public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        Booking booking = new Booking()
        {
            Mail = updateBookingDto.Mail,
            Phone = updateBookingDto.Phone,
            Date = updateBookingDto.Date,
            Name = updateBookingDto.Name,
            PersonCount = updateBookingDto.PersonCount,
            BookingId = updateBookingDto.BookingId,
        };
        _bookingService.TUpdate(booking);
        return Ok("Rezervasyon Güncellendi");
    }

    [HttpGet("GetBooking")]
    public IActionResult GetBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        return Ok(value);
    }
}