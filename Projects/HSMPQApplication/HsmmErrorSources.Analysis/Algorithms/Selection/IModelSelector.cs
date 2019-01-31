using HsmmErrorSources.Models.Models;
using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public interface IModelSelector
    {
        IHsmModelHolder Select(List<int> sequence, List<IHsmModelHolder> models);
    }
}
