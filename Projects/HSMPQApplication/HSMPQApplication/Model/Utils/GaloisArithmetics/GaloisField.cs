using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace HSMPQApplication.Model.Utils.GaloisArithmetics
{
    class GaloisField
    {
        [DllImport("lib/GaloisFieldArithmetic.dll", EntryPoint = "GaloisField")]
        public extern GaloisField();

        [DllImport("lib/GaloisFieldArithmetic.dll", EntryPoint = "mul")]
        public extern int mul(int a, int b);

    }
}
