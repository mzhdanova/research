using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HssmErrorSources.Generation.Validators
{
    interface IValidator
    {
        public void Validate();

        public bool HasErrors();

        public IList<String> GetErrors();
    }
}
