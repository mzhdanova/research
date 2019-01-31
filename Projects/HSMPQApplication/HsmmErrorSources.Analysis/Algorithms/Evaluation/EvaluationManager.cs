using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Validators;
using System;
using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Algorithms.Evaluation
{
    public class EvaluationManager
    {
        private readonly JsonModelFactory _jsonModelFactory;
        private readonly HsmmValidatorFactory _validatorFactory;
        private readonly HsmProbabilityCalculatorFactory _probabilityCalculatorFactory;

        public EvaluationManager()
        {
            _validatorFactory = new HsmmValidatorFactory();
            _jsonModelFactory = new JsonModelFactory();
            _probabilityCalculatorFactory = new HsmProbabilityCalculatorFactory();
        }

        public EvaluationResult Evaluate(string jsonModel, List<int> sequence)
        {
            IHsmModel model = _jsonModelFactory.CreateModel(jsonModel);
            IValidator validator = _validatorFactory.CreateModelValidator(model);
            validator.Validate();

            if (validator.HasErrors())
            {
                return EvaluationResult.Failure(validator.GetErrors());
            }

            IProbabilityCalculator probabilityCalculator = _probabilityCalculatorFactory.CreateProbabilityCalculator(model, sequence);
            return EvaluationResult.Success(probabilityCalculator.Calculate());
        }
    }
}
