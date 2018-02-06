using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Generation.Validators
{
    public interface IValidator
    {
        void Validate();

        bool HasErrors();

        IList<String> GetErrors();
    }
}
