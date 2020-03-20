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
            var unixtime = new DateTimeOffset(observation.Timestamp).ToUnixTimeSeconds();

            string path = observation.Country;

            if (!string.IsNullOrEmpty(observation.Province))
                path += $"/{observation.Province}";

            File.AppendAllText(filename, $"{unixtime}|Covid19|A|{path}|FF0000\n");
        }
    }
}
