using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HsmmErrorSources.Generation;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.GenerationApp.Utils;

namespace HsmmErrorSources.GenerationApp
{
    public class Program
    {
        private static readonly AutoResetEvent _closing = new AutoResetEvent(false);

        public static void Main(string[] args)
        {
            Console.WriteLine("Hsmm Error Sources Generation Application started");
            Console.WriteLine(
                "Please, specify Pseudo Random Generator mode as a number from the list:\r\n" +
                " 0 - Standart; \r\n" +
                " 1 - RC4; \r\n" +
                " 2 - Security");
            PseudoRandomGeneratorType prngMode = PromptParseUtils.ParsePseudoRandomGeneratorType(Console.ReadLine());

            Task.Factory.StartNew(() =>
            {
                bool ifExit = false;
                while (!ifExit)
                {
                    Console.WriteLine(
                        "Please, specify generation parameters");
                    string jsonModel = null;

                    while (jsonModel == null)
                    {
                        Console.WriteLine(
                            "Specify path to model file:");
                        string pathToFile = Console.ReadLine();
                        jsonModel = ParseModelFile(pathToFile);
                    }

                    Console.WriteLine(
                        "Specify desired sequence length:");
                    int sequenceLength = Convert.ToInt32(Console.ReadLine());

                    string outputPath = null;

                    while (outputPath == null)
                    {
                        Console.WriteLine("Specify output file path:");
                        outputPath = ParseOutputPath(Console.ReadLine());
                    }

                    Console.WriteLine("Starting generation");
                    GenerationManager manager = new GenerationManager(prngMode);
                    GenerationResult result = manager.Generate(jsonModel, sequenceLength);
                    if (result.HasErrors())
                    {
                        Console.WriteLine("Generation failed due to the following errors:" + result.Errors);
                    }
                    else
                    {
                        WriteOutputToFile(outputPath, result.Value);
                        Console.WriteLine("Generation has successfully completed. See result in " + outputPath);
                    }

                    Console.WriteLine("Do you want to continue? (y/n)");
                    ifExit = !PromptParseUtils.ParseBoolean(Console.ReadLine());
                }
                Console.WriteLine("Press Ctrl+C to exit...");
            });

            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnExit);
            _closing.WaitOne();
        }

        protected static void OnExit(object sender, ConsoleCancelEventArgs args)
        {
            Console.WriteLine("Exit");
            _closing.Set();
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

        private static string ParseOutputPath(string path)
        {
            if (path == null)
            {
                return null;
            }

            FileAttributes attr = File.GetAttributes(path);

            if (attr.HasFlag(FileAttributes.Directory))
            {
                return null;
            }

            return path;
        }

        private static void WriteOutputToFile(string path, IList<int> result)
        {
            if (path == null)
            {
                Console.WriteLine("Output file is not specified");
                return;
            }

            IList<string> outputList = result
                .AsEnumerable()
                .Select(x => x.ToString())
                .ToList();

            File.WriteAllText(path, string.Join("", outputList));
        }
    }
}