using System;
using System.Collections.Generic;

namespace DTOs
{
    [Serializable]
    public class Planet
    {
        public string name { get; set; }
        public string pic { get; set; }
        public string description { get; set; }
    }

    [Serializable]
    public class PlanetResponse
    {
        public List<Planet> Planets { get; set; }
    }

}
