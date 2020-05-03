namespace ExpressoApi.Controllers
{
    using ExpressoApi.Data;
    using ExpressoApi.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly ExpressoDbContext expressoDbContext;

        public ReservationsController(ExpressoDbContext expressoDbContext)
        {
            this.expressoDbContext = expressoDbContext;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            return this.Ok(this.expressoDbContext.Reservations);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Reservation reservation)
        {
            this.expressoDbContext.Reservations.Add(reservation);
            this.expressoDbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
