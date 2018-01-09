using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Models;

namespace HsmmErrorSources.Generation.Validators
{
    public class HsmQPModelValidator: IValidator
    {
        private const double EPSILON = 0.00001D;

        private IList<string> errors;
        private HsmQPModel model;

        public HsmQPModelValidator(HsmQPModel model) {
            this.model = model;
            this.errors = new List<string>();
        }

        public void Validate()
        {
            if (model.A == null || model.B == null || model.Pi == null || model.Rho == null || model.Per == null || model.F == null) {
                errors.Add("Some of the model parameters are not set");
                return;
            }
            if (model.N != model.B.GetLength(1)||model.N != model.Pi.GetLength(0)) {
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
    }
}
