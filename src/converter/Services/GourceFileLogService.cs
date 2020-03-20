using converter.IServices;
using converter.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace converter.Services
{
    public class GourceFileLogService : ILogService
    {
        private readonly string filename;

        public GourceFileLogService(string filename)
        {
            this.filename = filename;
        }

        public void Add(Observation observation)
        {
            if (observation.Confirmed == 0 && observation.Deaths == 0)
                return;

            var unixtime = new DateTimeOffset(observation.Timestamp).ToUnixTimeSeconds();

            string path = observation.Country;

            string color = "FF0000";

            File.AppendAllText(filename, $"{unixtime}|Covid19|A|{path}|{color}\n");

            if (!string.IsNullOrEmpty(observation.Province))
                path += $"/{observation.Province}";
            
            File.AppendAllText(filename, $"{unixtime}|Covid19|A|{path}|{color}\n");
            
        }
    }
}
