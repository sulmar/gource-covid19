using System;

namespace converter.Models
{
    public class Observation
    {
        public string Province { get; set; }
        public string Country { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public DateTime Timestamp { get; set; }
        public int Confirmed { get; set; }
        public int Recovered { get; set; }
        public int Deaths { get; set; }
        public string Continent { get; set; }

        public override string ToString()
        {
            return $"{Province} {Country} {Timestamp} {Confirmed} {Recovered} {Deaths}";
        }
    }
}
