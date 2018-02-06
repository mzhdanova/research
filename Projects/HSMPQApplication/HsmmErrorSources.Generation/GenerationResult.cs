using System.Collections.Generic;

namespace HsmmErrorSources.Generation
{
    public class GenerationResult
    {
        public IList<string> Errors { get; private set; }
        public IList<int> Value { get; private set; }

        private GenerationResult(IList<string> errors, IList<int> value)
        {
            Errors = errors;
            Value = value;
        }

        public bool HasErrors()
        {
            return Errors != null && Errors.Count != 0;
        }

        public static GenerationResult Success(IList<int> value)
        {
            return new GenerationResult(new List<string>(), new List<int>(value));
        }

        public static GenerationResult Failure(IList<string> errors)
        {
            return new GenerationResult(new List<string>(errors), new List<int>());
        }
    }
}