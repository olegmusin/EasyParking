using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EasyParking.Domain.Abstract;
using EasyParking.Domain.Entities;
using EasyParking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyParking.Dtos;

namespace EasyParking.Controllers
{
    [Route("parking")]
    public class ParkingController : Controller
    {
        private readonly ILogger<ParkingController> _logger;
        private readonly IRepository _repo;
        private IMapper _mapper;


        public ParkingController(ILogger<ParkingController> logger, IRepository repo, IMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{moniker}")]
        public IActionResult Design(string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);
            return View(_mapper.Map<DesignViewModel>(parking));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ParkingAreaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repo.Create(_mapper.Map<ParkingArea>(model));
                if (await _repo.SaveAsync())
                    return RedirectToAction("Parkings", "Home");
            }
            _logger.LogError($"Failed to add new parking {model.Moniker}");
            return BadRequest();
        }
        [HttpPost("{moniker}/layout/save")]
        public async Task<IActionResult> SaveLayout([FromBody] IEnumerable<PlaceViewModel> places, string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);
            foreach (var pls in places)
            {
                parking.Places.Add(_mapper.Map<Place>(pls));
            }
           
            if (ModelState.IsValid)
            {
                _repo.Update(parking);
                if (await _repo.SaveAsync())
                    return RedirectToAction("Parkings", "Home");
            }
            _logger.LogError($"Failed to add new parking layout for {moniker}");
            return BadRequest();
        }

        [HttpGet("{moniker}/layout")]
        public IActionResult CreateLayout([FromQuery] int columns, int rows)
        {
            return ViewComponent("ParkingLayout", new { columns, rows });
        }
    }


}