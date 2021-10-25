using System;

namespace SIM.Jobs.Core.Models.Locations
{

    public class LocationsCreateRequest
    {
        public string title { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int zip { get; set; }
    }
}