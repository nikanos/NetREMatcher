using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace NetREMatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var parser = new CommandLine.Parser(opt =>
            {
                opt.MutuallyExclusive = true;
                opt.HelpWriter = Console.Error;
            });
            var options = new Options();
            if (parser.ParseArguments(args, options))
            {
                if (string.IsNullOrEmpty(options.Pattern) && string.IsNullOrEmpty(options.PatternFile))
                {
                    Console.Error.WriteLine(options.GetUsage());
                    Environment.Exit(-1);
                }
                string pattern = !string.IsNullOrEmpty(options.Pattern) ? options.Pattern : File.ReadAllLines(options.PatternFile).FirstOrDefault();
                Regex re = new Regex(pattern);
                using (TextReader tr = (!string.IsNullOrEmpty(options.InputFile) ? new StreamReader(options.InputFile) : Console.In))
                {
                    using (TextWriter tw = (!string.IsNullOrEmpty(options.OutputFile) ? new StreamWriter(options.OutputFile) : Console.Out))
                    {
                        string line;
                        while (null != (line = tr.ReadLine()))
                        {
                            bool matchResult = re.IsMatch(line);
                            matchResult = options.InvertResults ? !matchResult : matchResult;
                            if (matchResult)
                                tw.WriteLine(line);
                        }
                    }
                }
            }
        }
    }
}
