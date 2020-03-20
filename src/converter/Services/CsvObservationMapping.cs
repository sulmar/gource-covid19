using converter.Models;
using TinyCsvParser.Mapping;

namespace converter
{
    partial class CsvObservationMapping : CsvMapping<Observation>
    {
        public CsvObservationMapping()
            : base()
        {
            MapProperty(0, x => x.Province);
            MapProperty(1, x => x.Country);
            MapProperty(2, x => x.Lat);
            MapProperty(3, x => x.Lon);
            MapProperty(4, x => x.Timestamp);
            MapProperty(5, x => x.Confirmed);
            MapProperty(6, x => x.Recovered);
            MapProperty(7, x => x.Deaths);
        }
    }
}
