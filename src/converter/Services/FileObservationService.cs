﻿using converter.IServices;
using converter.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Tokenizer.RFC4180;

namespace converter.Services
{
    // dotnet add package TinyCsvParser
    public class UrlObservationService : IObservationService
    {
        private readonly string filename;

        public UrlObservationService(string filename)
        {
            this.filename = filename;
        }

        public IEnumerable<Observation> Get()
        {
            return Get(filename);
        }

        private IEnumerable<Observation> Get(string url)
        {
            var tokenizer = new RFC4180Tokenizer(new Options('"', '\\', ','));

            CsvParserOptions csvParserOptions = new CsvParserOptions(true, tokenizer);
            ObservationCsvMapping csvMapper = new ObservationCsvMapping();
            CsvParser<Observation> csvParser = new CsvParser<Observation>(csvParserOptions, csvMapper);
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions("\n");

            var result = csvParser
                .ReadFromUrl(csvReaderOptions, url)
                .ToList()
                .Where(d => d.IsValid)
                .Select(d => d.Result)
                .OrderBy(p => p.Timestamp);

            return result;
        }
    }
}
