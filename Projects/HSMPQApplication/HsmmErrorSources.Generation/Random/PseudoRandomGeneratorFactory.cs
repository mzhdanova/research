namespace HsmmErrorSources.Generation.Random
{
    public class PseudoRandomGeneratorFactory
    {
        public IPseudoRandomNumberGenerator CreatePseudoRandomNumberGenerator(PseudoRandomGeneratorType type)
        {
            switch (type)
            {
                case PseudoRandomGeneratorType.Rc4:
                {
                    return new Rc4PrnGenerator();
                }
                case PseudoRandomGeneratorType.Security:
                {
                    return new CryptoServiceRnGenerator();
                }
                default:
                {
                    return new StandartPrnGenerator();
                }
            }
        }
    }
}