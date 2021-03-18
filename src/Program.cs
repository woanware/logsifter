using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;

namespace logsifter
{
    class Program
    {
        /// <summary>
        /// Application entry point
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static int Main(string[] args)
        {
            return Parser.Default.ParseArguments<Options>(args)
                .MapResult(
                    (Options opts) => DoLogSift(opts),
                    errs => 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opts"></param>
        static int DoLogSift(Options opts)
        {
            if (File.Exists(opts.Input) == false)
            {
                Console.WriteLine();
                return 1;
            }

            using (StreamReader file = new StreamReader(opts.Input))
            {
                HashSet<string> data = new HashSet<string>();
                string current;
                bool display;
                int length;
                int distance;
                float normalisedLev;

                string previous = string.Empty;

                while ((current = file.ReadLine()) != null)
                {
                    display = true;

                    if (previous.Length > 0)
                    {
                        distance = Fastenshtein.Levenshtein.Distance(previous, current);
                        length = Math.Max(previous.Length, current.Length);
                        normalisedLev = (float)distance/ (float)length;

                        if (normalisedLev <= opts.Distance)
                        {
                            display = false;
                        }
                    }

                    if (display == true)
                    {
                        Console.WriteLine(current);
                    }

                    previous = current;
                }
            }               

            return 0;
        }
    }
}
