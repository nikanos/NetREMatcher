using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using CommandLine.Text;

namespace NetREMatcher
{
    class Options
    {
        [Option('i', "input", Required = false, HelpText = "Input file name")]
        public string InputFile { get; set; }

        [Option('o', "output", Required = false, HelpText = "Output file Name")]
        public string OutputFile { get; set; }

        [Option('p', "pattern", Required = false, HelpText = "Pattern", MutuallyExclusiveSet = "pattern")]
        public string Pattern { get; set; }

        [Option('f', "pattern-file", Required = false, HelpText = "Pattern file name", MutuallyExclusiveSet = "pattern")]
        public string PatternFile { get; set; }

        [Option('v', "invert-results", Required = false, HelpText = "Invert Results")]
        public bool InvertResults { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            var help = new HelpText
            {
                Heading = new HeadingInfo("NetREMatcher"),
                AdditionalNewLineAfterOption = false,
                AddDashesToOption = true
            };
            help.AddPostOptionsLine("Pattern and Pattern file name are mutually exclusive.");
            help.AddPostOptionsLine("Either Pattern or Pattern file name must be set.");
            help.AddOptions(this);
            return help;

        }

    }
}
