using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public class EvaluationResult
    {
        public IList<string> Errors { get; private set; }
        public double? Value { get; private set; }

        private EvaluationResult(IList<string> errors, double? value)
        {
            Errors = errors;
            Value = value;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Count != 0;
        }

        public static EvaluationResult Success(double value)
        {
            return new EvaluationResult(new List<string>(), value);
        }

        public static EvaluationResult Failure(IList<string> errors)
        {
            return new EvaluationResult(new List<string>(errors), null);
        }
    }
}
