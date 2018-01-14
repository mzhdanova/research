using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Utils;

namespace HsmmErrorSources.Generation.Validators
{
    public class AbstractHsmModelValidator<T> : IValidator where T : AbstractHsmModel
    {
        private IList<string> errors;
        protected T model;

        public AbstractHsmModelValidator(T model)
        {
            this.model = model;
            this.errors = new List<string>();
        }

        public virtual void Validate()
        {
            if (model.A == null
                || model.B == null
                || model.Pi == null
                || model.F == null)
            {
                errors.Add("Some of the general model parameters are not set");
                return;
            }
            if (model.N != model.A.GetLength(1)
                || model.N != model.Pi.Length
                || model.N != model.B.GetLength(1)
                || model.N != model.F.GetLength(1))
            {
                errors.Add("Inconsistent matrices and arrays dimensions");
                return;
            }

            if (!MatrixUtils.IsTwiceStochastic(model.A))
            {
                errors.Add("Matrix A should be twice stochastic");
            }

            if (!MatrixUtils.IsStochasticByRows(model.B))
            {
                errors.Add("Matrix B should be stochastic by rows");
            }

            if (!MatrixUtils.IsStochasticByRows(model.F))
            {
                errors.Add("Matrix F should be stochastic by rows");
            }
        }


        public bool HasErrors()
        {
            return errors != null && errors.Count != 0;
        }

        public IList<string> GetErrors()
        {
            return errors;
        }

        protected void AddError(String error)
        {
            errors.Add(error);
        }
    }
}
