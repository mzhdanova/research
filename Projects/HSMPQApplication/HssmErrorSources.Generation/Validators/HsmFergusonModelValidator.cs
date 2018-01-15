using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Generation.Validators
{
    public class HsmFergusonModelValidator: AbstractHsmModelValidator<HsmFergusonModel>
    {
        public HsmFergusonModelValidator(HsmFergusonModel model) : base(model) { }
    }
}
