using System;

namespace SIM.Jobs.API.Models.Locations
{
    public class LocationsUpdateRequestDto
    {

        public string title { get; set; }
         public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
    }
}