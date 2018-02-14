using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HsmmErrorSources.Models.Models
{
    public interface IHsmModel
    {
        ModelType Type { get; }
    }
}
