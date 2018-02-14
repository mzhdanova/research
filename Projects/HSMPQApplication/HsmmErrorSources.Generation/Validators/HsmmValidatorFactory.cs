﻿using System;
using HsmmErrorSources.Models.Models;

namespace HsmmErrorSources.Generation.Validators
{
    public class HsmmValidatorFactory
    {
        public IValidator CreateModelValidator(IHsmModel model)
        {
            switch (model.Type)
            {
                case ModelType.HsmFergusonModel:
                {
                    return new HsmFergusonModelValidator((HsmFergusonModel) model);
                }
                case ModelType.HsmQpModel:
                {
                    return new HsmQPModelValidator((HsmQpModel) model);
                }
                default:
                {
                    throw new NotImplementedException("ModelType is not supported");
                }
            }
        }
    }
}