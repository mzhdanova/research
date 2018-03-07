using System;
using HsmmErrorSources.Generation.Generators;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Validators;

namespace HsmmErrorSources.Generation
{
    public class GenerationManager
    {
        private readonly JsonModelFactory _jsonModelFactory;
        private readonly HsmmValidatorFactory _validatorFactory;
        private readonly HsmmGeneratorFactory _generatorFactory;
        private readonly IPseudoRandomNumberGenerator _pseudoRandomNumberGenerator;

        public GenerationManager(PseudoRandomGeneratorType pseudoRandomGeneratorType)
        {
            _validatorFactory = new HsmmValidatorFactory();
            _jsonModelFactory = new JsonModelFactory();
            _generatorFactory = new HsmmGeneratorFactory();
            _pseudoRandomNumberGenerator =
                new PseudoRandomGeneratorFactory().CreatePseudoRandomNumberGenerator(pseudoRandomGeneratorType);
        }

        public GenerationResult Generate(String jsonModel, int length)
        {
            IHsmModel model = _jsonModelFactory.CreateModel(jsonModel);
            IValidator validator = _validatorFactory.CreateModelValidator(model);
            validator.Validate();

            if (validator.HasErrors())
            {
                GenerationResult.Failure(validator.GetErrors());
            }

            IGenerator generator = _generatorFactory.CreateModelGenerator(model, _pseudoRandomNumberGenerator);
            return GenerationResult.Success(generator.Generate(length));
        }
    }
}