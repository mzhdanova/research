﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Analysis.Criteria
{
    public interface ISelectionCriterion
    {
        IHsmModelHolder Apply(IDictionary<IHsmModelHolder, double> probabilitiesByModels);
    }
}
