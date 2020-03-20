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

        //private IEnumerable<Observation> Get(string input)
        //{
        //    var tokenizer = new RFC4180Tokenizer(new Options('"', '\\', ','));

        //    CsvParserOptions csvParserOptions = new CsvParserOptions(true, tokenizer);
        //    CsvObservationMapping csvMapper = new CsvObservationMapping();
        //    CsvParser<Observation> csvParser = new CsvParser<Observation>(csvParserOptions, csvMapper);

        //    var result = csvParser
        //        .ReadFromFile(input, Encoding.ASCII)
        //        .ToList()
        //        .Where(d => d.IsValid)
        //        .Select(d => d.Result)
        //        .OrderBy(p => p.Timestamp);


        //    return result;
        //}



    }
}
