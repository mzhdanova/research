using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Random;

namespace HsmmErrorSources.GenerationApp.Utils
{
    public class PromptParseUtils
    {
        public static bool ParseBoolean(string input)
        {
            return input.ToLower() == "yes";
        }

        public static PseudoRandomGeneratorType ParsePseudoRandomGeneratorType(string input)
        {
            int typeCode = 0;
            try
            {
                typeCode = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to parse Pseudo Random Generator mode, the Standart one is used by default");
            }
            switch (typeCode)
            {
                case 1:
                {
                    return PseudoRandomGeneratorType.Rc4;
                }
                case 2:
                {
                    return PseudoRandomGeneratorType.Security;
                }
                default:
                {
                    return PseudoRandomGeneratorType.Standart;
                }
            }
        }
    }
}
