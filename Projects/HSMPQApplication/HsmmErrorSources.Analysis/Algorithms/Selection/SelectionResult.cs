using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class SelectionResult
    {
        public IList<string> Errors { get; private set; }
        public string Value { get; private set; }

        private SelectionResult(IList<string> errors, string value)
        {
            Errors = errors;
            Value = value;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Count != 0;
        }

        public static SelectionResult Success(string value)
        {
            return new SelectionResult(new List<string>(), value);
        }

        public static SelectionResult Failure(IList<string> errors)
        {
            return new SelectionResult(new List<string>(errors), null);
        }
    }
}
