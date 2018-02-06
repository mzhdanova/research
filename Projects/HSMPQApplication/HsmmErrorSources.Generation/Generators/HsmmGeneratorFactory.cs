using System;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmmGeneratorFactory
    {
        public IGenerator CreateModelGenerator(IHsmModel model,
            IPseudoRandomNumberGenerator pRNGenerator)
        {
            switch (model.GetModelType())
            {
                case ModelType.HsmFergusonModel:
                {
                    return new HsmFergusonModelGenerator((HsmFergusonModel) model, pRNGenerator);
                }
                case ModelType.HsmQpModel:
                {
                    return new HsmQpModelGenerator((HsmQpModel) model, pRNGenerator);
                }
                default:
                {
                    throw new NotImplementedException("ModelType is not supported");
                }
            }
        }
    }
}