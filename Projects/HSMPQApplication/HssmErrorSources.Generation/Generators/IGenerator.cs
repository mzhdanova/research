using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Generators
{
    public interface IGenerator
    {
        IList<int> Generate(int length);
    }
}
