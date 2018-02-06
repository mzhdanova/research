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
                    return new RC4PRNGenerator();
                }
                case PseudoRandomGeneratorType.Security:
                {
                    return new CryptoServiceRNGenerator();
                }
                default:
                {
                    return new StandartPRNGenerator();
                }
            }
        }
    }
}