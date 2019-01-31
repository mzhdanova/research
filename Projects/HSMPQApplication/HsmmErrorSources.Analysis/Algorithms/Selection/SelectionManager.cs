using HsmmErrorSources.Analysis.Criteria;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Validators;
using System.Collections.Generic;

namespace HsmmErrorSources.Analysis.Algorithms.Selection
{
    public class SelectionManager
    {
        private readonly JsonModelFactory _jsonModelFactory;
        private readonly HsmmValidatorFactory _validatorFactory;
        private readonly HsmModelSelectorFactory _modelSelectorFactory;
        private readonly ModelSelectorType _modelSelectorType;
        private readonly SelectionCriterionType _selectionCriterionType;

        public SelectionManager(int segmentSize)
        {
            _validatorFactory = new HsmmValidatorFactory();
            _jsonModelFactory = new JsonModelFactory();
            _modelSelectorFactory = new HsmModelSelectorFactory(segmentSize);
        }

        public SelectionResult Select(Dictionary<string, string> jsonModelsToIds, List<int> sequence)
        {
            List<string> errors = new List<string>();
            List<IHsmModelHolder> models = new List<IHsmModelHolder>();
            foreach (KeyValuePair<string, string> entry in jsonModelsToIds)
            {
                IHsmModel model = _jsonModelFactory.CreateModel(entry.Value);
                IValidator validator = _validatorFactory.CreateModelValidator(model);
                validator.Validate();
                if (validator.HasErrors())
                {
                    errors.AddRange(validator.GetErrors());
                    continue;
                }
                else {
                    models.Add(new HsmModelHolder(entry.Key, model));
                }
            }

            if (errors.Count>0)
            {
                return SelectionResult.Failure(errors);
            }

            IModelSelector modelSelector = _modelSelectorFactory.CreateModelSelector(_modelSelectorType, _selectionCriterionType);
            IHsmModelHolder selectedModel = modelSelector.Select(sequence, models);
            return SelectionResult.Success(selectedModel.Name);
        }
    }
}
