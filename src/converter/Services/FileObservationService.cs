using converter.IServices;
using converter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Tokenizer.RFC4180;

namespace converter.Services
{
    // dotnet add package TinyCsvParser
    public class FileObservationService : IObservationService
    {
        private readonly string filename;

        public FileObservationService(string filename)
        {
            this.filename = filename;
        }

        public IEnumerable<Observation> Get()
        {
            return Get(filename);
        }

        private IEnumerable<Observation> Get(string input)
        {
            var tokenizer = new RFC4180Tokenizer(new Options('"', '\\', ','));

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, tokenizer);
            CsvObservationMapping csvMapper = new CsvObservationMapping();
            CsvParser<Observation> csvParser = new CsvParser<Observation>(csvParserOptions, csvMapper);

            var result = csvParser
                .ReadFromFile(input, Encoding.ASCII)
                .ToList()
                .Where(d => d.IsValid)
                .Select(d => d.Result)
                .OrderBy(p => p.Timestamp);

            return result;
        }
    }
}
