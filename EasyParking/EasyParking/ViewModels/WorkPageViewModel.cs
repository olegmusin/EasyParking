using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
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
        [Required(ErrorMessage = "Number of hours must be in range from 1 to 24")]
        public int Hours { get; set; }
       
        [MinLength(8)]
        [MaxLength(20)]
        [Required(ErrorMessage = "Vechicle number string is a mininmum of 8 symbols length")]
        public string VehicleNumber { get; set; }
        [Required(ErrorMessage = "Parking type must be selected")]
        public ParkingTypes ParkingType { get; set; }


    }
}