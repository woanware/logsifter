using CommandLine;

namespace logsifter
{
    /// <summary>
    /// 
    /// </summary>
    [Verb("sift", HelpText = "Stores meta data regarding disabled applications")]
    class Options
    {
        [Option('i', "input", Required = true, HelpText = "Input file")]
        public string Input { get; set; }
         
        [Option('d', "distance", Default = 0.30f, Required = false, HelpText = "Levenshtein distance value")]
        public float Distance { get; set; }
    }
}
