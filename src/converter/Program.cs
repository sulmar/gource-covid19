using converter.IServices;
using converter.Models;
using converter.Services;
using System;
using System.Runtime.InteropServices.ComTypes;

namespace converter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: converter {output}");
                return 1;
            }

            string output = args[0];

            Console.WriteLine("Converting to {output}...");

            string covidUrl = "https://raw.githubusercontent.com/datasets/covid-19/master/time-series-19-covid-combined.csv";
            string continentUrl = "https://raw.githubusercontent.com/dbouquin/IS_608/master/NanosatDB_munging/Countries-Continents.csv";

            IProgress<Observation> progress = new Progress<Observation>(p => Console.Write("."));

            ILocationService locationService = new UrlLocationService(continentUrl);

         

            IObservationService observationService = new UrlObservationService(covidUrl);
            ILogService logService = new GourceFileLogService(output);

            Converter converter = new Converter(observationService, logService, locationService, progress);
                
            converter.Convert();

            Console.WriteLine("Done.");

            return 0;

        }
    }
}
