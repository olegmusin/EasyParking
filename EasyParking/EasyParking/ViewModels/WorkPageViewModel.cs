using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EasyParking.ViewModels
{
    public class WorkPageViewModel
    {
        public enum ParkingTypes
        {
            Booking = 3,    
            PerHour = 1,
            PerNight = 2
        }

        public string VechicleNumber { get; set; }
        public ParkingTypes ParkingType { get; set; }

      
    }
}