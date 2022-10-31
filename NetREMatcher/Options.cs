using CommandLine;
using CommandLine.Text;
using System.Collections.Generic;

namespace NetREMatcher
{
    class Options
    {
        [Option('i', "input", Required = false, HelpText = "Input file name")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file Name")]
        public string OutputFile { get; set; }

        [Option('p', "pattern", Required = false, HelpText = "Pattern", Group = "pattern")]
        public string Pattern { get; set; }

        [Option('f', "pattern-file", Required = false, HelpText = "Pattern file name", Group = "pattern")]
        public string PatternFile { get; set; }

        [Option('v', "invert-results", Required = false, HelpText = "Invert Results")]
        public bool InvertResults { get; set; }

        [Option('l', "logging-enabled", Required = false, HelpText = "Enable logging")]
        public bool LoggingEnabled { get; set; }

        [Usage(ApplicationAlias = "NetREMatcher.exe")]
        public static IEnumerable<Example> Examples
        {
            get
            {
                yield return new Example("Match 3-digit numbers (Reading/writing from/to standard IO)", new Options { Pattern = "^[0-9]$" });
                yield return new Example("Match anything that is NOT a 3-digit number (Reading/writing from/to standard IO)", new Options { Pattern = "^[0-9]$", InvertResults = true });
                yield return new Example("Match pattern read from file named <pattern.re> and enable logging (Reading/writing from/to standard IO)", new Options { PatternFile = "pattern.re", LoggingEnabled = true });
                yield return new Example("Match pattern read from file named <pattern.re> and enable logging (Reading/writing from/to given files)", new Options { PatternFile = "pattern.re", LoggingEnabled = true, InputFile = "input.txt", OutputFile = "output.txt" });
            }
        }

    }
}
