using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace NetREMatcher
{
    class Program
    {
        static int Main(string[] args)
        {
            int result = Parser.Default.ParseArguments<Options>(args).MapResult(
                            (options) => RunOptions(options),
                            (errors) => HandleParseError(errors));
            return result;
        }

        static int RunOptions(Options options)
        {
            int result;
            try
            {
                string pattern = !string.IsNullOrEmpty(options.Pattern) ? options.Pattern : File.ReadAllLines(options.PatternFile).FirstOrDefault();
                if (options.LoggingEnabled)
                {
                    Console.Error.WriteLine($"Pattern is: {pattern}");
                }
                Regex re = new Regex(pattern);
                using (TextReader tr = (!string.IsNullOrEmpty(options.InputFile) ? new StreamReader(options.InputFile) : Console.In))
                {
                    using (TextWriter tw = (!string.IsNullOrEmpty(options.OutputFile) ? new StreamWriter(options.OutputFile) : Console.Out))
                    {
                        string line;
                        int currentLineNumber = 1;
                        while (null != (line = tr.ReadLine()))
                        {
                            bool matchResult = re.IsMatch(line);
                            if (options.LoggingEnabled)
                            {
                                Console.Error.WriteLine($"Line #{currentLineNumber} ({line}) {(matchResult ? "matches" : "does NOT match")} pattern {pattern}");
                            }
                            bool includeResult = options.InvertResults ? !matchResult : matchResult;
                            if (includeResult)
                            {
                                tw.WriteLine(line);
                            }
                            currentLineNumber++;
                        }
                    }
                }
                result = 0;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.ToString());
                result = -1;
            }

            if (options.LoggingEnabled)
            {
                Console.Error.WriteLine($"Result Code: {result}");
            }
            return result;
        }
        static int HandleParseError(IEnumerable<Error> errors)
        {
            int result = -1;
            if (errors.Any(x => x is HelpRequestedError || x is VersionRequestedError))
                result = 0;
            return result;
        }
    }
}
