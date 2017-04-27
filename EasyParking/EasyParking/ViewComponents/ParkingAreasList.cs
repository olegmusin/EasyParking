using System.Collections.Generic;
using AutoMapper;
using EasyParking.Domain.Abstract;
using EasyParking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EasyParking.Domain;
using EasyParking.Domain.Entities;

namespace EasyParking.ViewComponents
{
    public class ParkingAreasList : ViewComponent
    {
        private readonly IRepository _repo;
        private readonly ILogger<ParkingAreasList> _logger;

        public ParkingAreasList(IRepository repo,
                                ILogger<ParkingAreasList> logger)
        {
            _repo = repo;
            _logger = logger;
        }
        public IViewComponentResult Invoke()
        {
            var items = GetItems();
            return View(items);
        }

        private IEnumerable<ParkingAreaViewModel> GetItems()
        {
            if (_repo == null)//DEBUG
                _logger.LogError("Repository instance is null!");
            return Mapper
                  .Map<IEnumerable<ParkingAreaViewModel>>(_repo?.GetAllParkingsWithPlaces());
        }
    }
}
