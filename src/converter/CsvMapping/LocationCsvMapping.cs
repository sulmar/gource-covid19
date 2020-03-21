using converter.Models;
using TinyCsvParser.Mapping;

namespace converter
{
    public class LocationCsvMapping : CsvMapping<Location>
    {
        public LocationCsvMapping()
              : base()
        {
            MapProperty(0, x => x.Continent);
            MapProperty(1, x => x.Country);
        }
    }

}
