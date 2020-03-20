using converter.IServices;
using converter.Models;
using System;

namespace converter
{
    public class Converter
    {
        private readonly IObservationService observationService;
        private readonly ILogService logService;
        private readonly IProgress<Observation> progress;

        public Converter(IObservationService observationService, ILogService logService, IProgress<Observation> progress = null)
        {
            this.observationService = observationService;
            this.logService = logService;
            this.progress = progress;
        }

        public void Convert()
        {
            var observations = observationService.Get();

            foreach (var observation in observations)
            {
                logService.Add(observation);

                progress?.Report(observation);
            }

        }

    }
}
