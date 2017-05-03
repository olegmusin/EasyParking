using System.Collections.Generic;
using EasyParking.Domain.Abstract;
using EasyParking.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EasyParking.ViewComponents
{
    public class ParkingLayout : ViewComponent
    {

        private readonly IRepository _repo;
        private readonly ILogger<ParkingLayout> _logger;

        public ParkingLayout(IRepository repo,
                                           ILogger<ParkingLayout> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public IViewComponentResult Invoke(string moniker = null, int ? columns = null, int? rows = null)
        {
            if (columns != null && rows != null)
            {
                return View("Generated",CreateLots(columns, rows));
            }
            else if (moniker != null)
            {
                return View("Saved",GetLots(moniker));
            }
            return View("Generated", CreateLots(0,0));
        }

        private  IEnumerable<PlaceViewModel> CreateLots(int? columns, int? rows)
        {
            var newLotsList = new List<PlaceViewModel>();
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    var lot = new PlaceViewModel
                    {
                        Column = i,
                        Row = j
                    };
                    newLotsList.Add(lot);
                }
            }
            return newLotsList;
        }

        private IEnumerable<PlaceViewModel> GetLots(string moniker)
        {
            return AutoMapper.Mapper.Map<IEnumerable<PlaceViewModel>>(_repo.GetParkingByMoniker(moniker).Places);
        }


    }
}
