using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyParking.Domain.Abstract;
using EasyParking.Domain.Entities;
using EasyParking.Dtos;
using EasyParking.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyParking.Controllers.Api
{

    [Route("api/parking/{moniker}/[action]")]
    [ValidateModel]
    public class ParkingController : Controller
    {
        private readonly ILogger<Controllers.ParkingController> _logger;
        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        public ParkingController(ILogger<Controllers.ParkingController> logger, IRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateLayout([FromQuery] int columns, int rows)
        {
            return ViewComponent("ParkingLayout", new { columns, rows });
        }

        [HttpPost]
        public async Task<IActionResult> SaveLayout([FromBody] IEnumerable<PlaceDto> places, string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);
            var listOfParkingPlaces = parking.Places;
            if (!listOfParkingPlaces.Any())
            {
                parking.Places = new List<Place>();
            }
            else
                try
                {
                   // parking.Places.Clear();
                    foreach (var pls in listOfParkingPlaces)
                    {
                        _repo.Delete(pls);

                    }
                    if (await _repo.SaveAsync())
                        _logger.LogInformation($"List of parking places for {moniker} cleared");
                }
                catch (Exception e)
                {
                    _logger.LogError($"Can't clear layout for {moniker}: {e.Message}");
                    return BadRequest();
                }

            _mapper.Map(places, parking.Places);
            _repo.Update(parking);
            if (await _repo.SaveAsync())
                return ViewComponent("ParkingLayout", new {moniker});
               
            _logger.LogError($"Failed to add new parking layout for {moniker}");
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> ParkVechicle([FromBody]PlaceDto place, [FromQuery]string number, string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);
            var lot = _repo.GetPlaceForParking(place.Row, place.Column, parking.Id);

            _repo.GetCreateVechicle(number).Wait(); 

            if (lot.Booked || lot.Occupied) return BadRequest("Place is busy or booked, choose another one!");

            lot.Occupied = true;
            _repo.Update(lot);

            if (await _repo.SaveAsync())
                _logger.LogInformation($"Parking lot {place.Row},{place.Column} for {moniker} occupied by vechicle {number}");
            return Ok();

        }
    }
}