using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EasyParking.Domain.Abstract;
using EasyParking.Domain.Entities;
using EasyParking.Dtos;
using EasyParking.Filters;
using EasyParking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyParking.Controllers
{
    [Route("Parking/[action]")]
    [ValidateModel]
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


        public IActionResult CreateNewParking()
        {
            return View("CreateParking");
        }


        [HttpGet("{moniker}")]
        public IActionResult Design(string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);
            if (!parking.Places.Any())
                return View(new DesignViewModel
                {
                    Columns = 0,
                    Rows = 0,
                    Places = new List<PlaceDto>()
                });
            return View(_mapper.Map<DesignViewModel>(parking));
        }

        [HttpPost("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ParkingAreaViewModel model)
        {
            _repo.Create(_mapper.Map<ParkingArea>(model));
            if (await _repo.SaveAsync())
                return RedirectToAction("Parkings", "Home");

            _logger.LogError($"Failed to add new parking {model.Moniker}");
            return BadRequest();
        }

        [HttpGet("{moniker}", Name = "WorkPage")]
        public IActionResult Work(string moniker)
        {
            var parking = _repo.GetParkingByMoniker(moniker);

            
            return View("WorkPage");
        }
    }


}