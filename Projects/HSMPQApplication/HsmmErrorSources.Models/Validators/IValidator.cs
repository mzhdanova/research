using System;
using System.Collections.Generic;

namespace HsmmErrorSources.Models.Validators
{
    public interface IValidator
    {
        void Validate();

        bool HasErrors();

        IList<String> GetErrors();
    }
}
