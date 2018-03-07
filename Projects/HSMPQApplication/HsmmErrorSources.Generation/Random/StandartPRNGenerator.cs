using System;

namespace HsmmErrorSources.Generation.Random
{
    public class StandartPrnGenerator: IPseudoRandomNumberGenerator
    {
        private static readonly System.Random Random = new System.Random(Convert.ToInt32(DateTime.Now.Millisecond));
        public double GetValue()
        {
            return Random.NextDouble(); 
        }
    }
}
