using System.Collections.Generic;

namespace HsmmErrorSources.Generation.Generators
{
    public interface IGenerator
    {
        IList<int> Generate(int length);
    }
}
