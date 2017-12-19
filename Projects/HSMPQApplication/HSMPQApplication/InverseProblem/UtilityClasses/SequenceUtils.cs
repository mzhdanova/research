using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSMPQApplication.InverseProblem
{
    class SequenceUtils<T>
    {
        /// <summary>
        /// startIndex is included, endIndex is not included
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public static T[] getSubsequence(T[] sequence, int startIndex, int endIndex)
        {
            if (startIndex<0||endIndex<0||startIndex > sequence.Length || endIndex > sequence.Length || startIndex > endIndex)
                throw new IndexOutOfRangeException();
            T[] result = new T[endIndex-startIndex];
            for (int i = startIndex; i < endIndex; i++)
            {
                result[i-startIndex] = sequence[i];
            }
            return result;
        }
    }
}
