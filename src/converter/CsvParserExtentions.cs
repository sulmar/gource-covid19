using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TinyCsvParser.Mapping;

namespace TinyCsvParser
{
    public static class CsvParserExtensions
    {
        public static CsvMappingEnumerable<TEntity> ReadFromUrl<TEntity>(this CsvParser<TEntity> csvParser, CsvReaderOptions csvReaderOptions, string url) where TEntity : new()
        {
            using WebClient client = new WebClient();
            string content = client.DownloadString(url);
            return csvParser.ReadFromString(csvReaderOptions, content);
        }
    }
}
