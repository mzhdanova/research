using System;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Generation.Generators
{
    public class HsmmGeneratorFactory
    {
        public IGenerator CreateModelGenerator(IHsmModel model,
            IPseudoRandomNumberGenerator pRnGenerator)
        {
            switch (model.Type)
            {
                case ModelType.HsmFergusonModel:
                {
                    return new HsmFergusonModelGenerator((HsmFergusonModel) model, pRnGenerator);
                }
                case ModelType.HsmQpModel:
                {
                    return new HsmQpModelGenerator((HsmQpModel) model, pRnGenerator);
                }
                default:
                {
                    throw new NotImplementedException("ModelType is not supported");
                }
            }
        }
    }
}