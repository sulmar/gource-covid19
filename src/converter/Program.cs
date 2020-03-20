using converter.IServices;
using converter.Models;
using converter.Services;
using System;

namespace converter
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args.Length!=2)
            {
                Console.WriteLine("Usage: converter {input} {output}");
                return 1;
            }

            string input = args[0];
            string output = args[1];

            Console.WriteLine("Converting {input} to {output}...");

            IProgress<Observation> progress = new Progress<Observation>(p => Console.Write("."));

            IObservationService observationService = new FileObservationService(input);
            ILogService logService = new GourceFileLogService(output);

            Converter converter = new Converter(observationService, logService, progress);
                
            converter.Convert();

            Console.WriteLine("Done.");

            return 0;

        }
    }
}
