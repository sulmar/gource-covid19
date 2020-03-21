using converter.IServices;
using converter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Tokenizer.RFC4180;

namespace converter.Services
{
    public class UrlLocationService : ILocationService
    {
        private readonly string url;

        public UrlLocationService(string url)
        {
            this.url = url;
        }

        public IEnumerable<Location> Get()
        {
            return Get(url);
        }

        private IEnumerable<Location> Get(string url)
        {
            var tokenizer = new RFC4180Tokenizer(new Options('"', '\\', ','));

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, tokenizer);
            LocationCsvMapping csvMapper = new LocationCsvMapping();
            CsvParser<Location> csvParser = new CsvParser<Location>(csvParserOptions, csvMapper);
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions("\n");

            var result = csvParser
                .ReadFromUrl(csvReaderOptions, url)
                .ToList()
                .Where(d => d.IsValid)
                .Select(d => d.Result);

            return result;
        }
    }

   
}
