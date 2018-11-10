using HsmmErrorSources.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public interface IModelSelector
    {
        IHsmModel Select(List<int> sequence, List<IHsmModel> models);
    }
}
