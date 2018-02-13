using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.GenerationApp.Utils;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.GenerationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hsmm Error Sources Generation Application");
            Console.WriteLine(
                "Please, specify Pseudo Random Generator mode as a number from the list: 0 - Standart; 1 - RC4; 2 - Security");
            PseudoRandomGeneratorType prngMode = PromptParseUtils.ParsePseudoRandomGeneratorType(Console.ReadLine());

            string jsonModel = null;

            while (jsonModel == null)
            {
                Console.WriteLine(
                    "Please, specify path to model file");
                string pathToFile = Console.ReadLine();
                jsonModel = ParseModelFile(pathToFile);
            }

            Console.WriteLine(
                "Please, specify desired sequence length");
            int sequenceLength = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Do you prefer to record generated sequence to file? (yes/no)");
            bool isSaveToFile = PromptParseUtils.ParseBoolean(Console.ReadLine());
            string outputPath = null;
            if (isSaveToFile)
            {
                Console.WriteLine("Please, specify output file path");
                outputPath = Console.ReadLine();
            }

            GenerationManager manager = new GenerationManager(prngMode);
            GenerationResult result = manager.Generate(jsonModel, sequenceLength);
            if (result.HasErrors())
            {
                Console.WriteLine("Errors:" + result.Errors);
            }
            else {
                Console.WriteLine("Result:" + result.Value);
            }

        }

        private static string ParseModelFile(string path)
        {
            if (path == null || !File.Exists(path))
            {
                Console.WriteLine("Specified file is not found");
                return null;
            }

            return File.ReadAllText(path);
        }
    }
}