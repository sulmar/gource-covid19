using converter.IServices;
using converter.Models;
using System;
using System.Linq;

namespace converter
{
    public class Converter
    {
        private readonly IObservationService observationService;
        private readonly ILogService logService;
        private readonly ILocationService locationService;
        private readonly IProgress<Observation> progress;

        public Converter(IObservationService observationService, ILogService logService, ILocationService locationService, IProgress<Observation> progress = null)
        {
            this.observationService = observationService;
            this.logService = logService;
            this.locationService = locationService;
            this.progress = progress;
        }

        public void Convert()
        {
            var observations = observationService.Get();

            var continents = locationService.Get();

            foreach (var observation in observations)
            {
                observation.Continent = continents.SingleOrDefault(c => c.Country == observation.Country)?.Continent;

                logService.Add(observation);

                progress?.Report(observation);
            }

        }

    }
}
