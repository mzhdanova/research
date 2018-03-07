using System;
using System.Collections.Generic;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Utils;

namespace HsmmErrorSources.Models.Validators
{
    public class AbstractHsmModelValidator<T> : IValidator where T : AbstractHsmModel
    {
        private readonly IList<string> _errors;
        protected T Model;

        public AbstractHsmModelValidator(T model)
        {
            Model = model;
            _errors = new List<string>();
        }

        public virtual void Validate()
        {
            if (Model.A == null
                || Model.B == null
                || Model.Pi == null
                || Model.F == null)
            {
                _errors.Add("Some of the general model parameters are not set");
                return;
            }
            if (Model.N != Model.A.GetLength(1)
                || Model.N != Model.Pi.Length
                || Model.N != Model.B.GetLength(1)
                || Model.N != Model.F.GetLength(1))
            {
                _errors.Add("Inconsistent matrices and arrays dimensions");
                return;
            }

            if (!MatrixUtils.IsTwiceStochastic(Model.A))
            {
                _errors.Add("Matrix A should be twice stochastic");
            }

            if (!MatrixUtils.IsStochasticByRows(Model.B))
            {
                _errors.Add("Matrix B should be stochastic by rows");
            }

            if (!MatrixUtils.IsStochasticByRows(Model.F))
            {
                _errors.Add("Matrix F should be stochastic by rows");
            }
        }


        public bool HasErrors()
        {
            return _errors != null && _errors.Count != 0;
        }

        public IList<string> GetErrors()
        {
            return _errors;
        }

        protected void AddError(String error)
        {
            _errors.Add(error);
        }
    }
}
