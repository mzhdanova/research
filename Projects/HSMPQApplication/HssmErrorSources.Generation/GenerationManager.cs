using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Generators;
using HsmmErrorSources.Generation.Random;
using HsmmErrorSources.Generation.Validators;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Representations;

namespace HsmmErrorSources.Generation
{
    public class GenerationManager
    {
        private AbstractHsmModel model;
        private IPseudoRandomNumberGenerator pseudoRandomNumberGenerator;
        private IGenerator generator;
        private IValidator validator;
        private int length;

        public void Initialize(String jsonModel, PseudoRandomGeneratorType pseudoRandomGeneratorType)
        {
        }

        public void Validate()
        {
        }

        public void Generate()
        {
        }


    }
}