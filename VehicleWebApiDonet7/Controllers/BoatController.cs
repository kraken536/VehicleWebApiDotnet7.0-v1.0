using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VehicleWebApiDonet7.Models;
using VehicleWebApiDonet7.Services.BoatServices;

namespace VehicleWebApiDonet7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoatController : ControllerBase
    {
        private readonly IBoatService _boatService;

        public BoatController(IBoatService boatService)
        {
            _boatService = boatService;   
        }

        [HttpPost("add")]
        public ActionResult<List<Boat>> AddNewBoat(Boat boat)
        {
            var result = _boatService.AddNewBoat(boat);

            if(result == null)
            {
                return NotFound("The data are invalid please try agian...");
            }
            return result;
        }

        [HttpGet("{color}")]
        public ActionResult<List<Boat>> GetBoatByColor(string color)
        {
            var result = _boatService.GetBoatsByColor(color);
            
            if(result == null)
            {
                return NotFound("There is no car with the given color...");
            }

            return result;
        }


        [HttpGet]
        public ActionResult<List<Boat>> GetBoatList()
        {
            var result = _boatService.GetBoatList();

            if (result == null)
                return NotFound("There is no baot available for the moment...");

            return result;
        }
    }
}
