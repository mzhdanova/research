using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Generators
{
    interface IGenerator
    {
        public int[] Generate(int length);
    }
}
