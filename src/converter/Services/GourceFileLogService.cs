using converter.IServices;
using converter.Models;
using System;
using System.IO;

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

            string path = observation.Continent;

            string color = "FF0000";

            string author = observation.Continent;

            string content = $"{unixtime}|{author}|A|{path}|{color}\n";

            File.AppendAllText(filename, content);

            path += $"/{observation.Country}";

            content = $"{unixtime}|{author}|A|{path}|{color}\n";

            File.AppendAllText(filename, content);

            if (!string.IsNullOrEmpty(observation.Province))
                path += $"/{observation.Province}";

            content = $"{unixtime}|{author}|A|{path}|{color}\n";

            File.AppendAllText(filename, content);
            
        }
    }
}
