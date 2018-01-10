using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Utils;

namespace HsmmErrorSources.Generation.Validators
{
    public class HsmQPModelValidator : IValidator
    {
        private const double EPSILON = 0.00001D;

        private IList<string> errors;
        private HsmQPModel model;

        public HsmQPModelValidator(HsmQPModel model)
        {
            this.model = model;
            this.errors = new List<string>();
        }

        public void Validate()
        {
            if (model.A == null
                || model.B == null
                || model.Pi == null
                || model.Rho == null
                || model.Per == null
                || model.F == null)
            {
                errors.Add("Some of the model parameters are not set");
                return;
            }
            if (model.N != model.A.GetLength(1)
                || model.N != model.Pi.Length
                || model.N != model.B.GetLength(1)
                || model.N != model.Rho.Length
                || model.N != model.F.GetLength(1)
                || model.N != model.Per.Length)
            {
                errors.Add("Inconsistent matrices dimensions");
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
            if (!MatrixUtils.IsStochasticByRows(model.Rho))
            {
                errors.Add("Matrix F should be stochastic by rows");
            }

            if (!DoubleUtils.AreEqual(model.Pi.Sum(), 1))
            {
                errors.Add("Sum of Pi elements should be equal to 1");
            }

            if (!isRhoAdapted())
            {
                errors.Add("Rho is not adapted");
            }

            if (!isFAdapted())
            {
                errors.Add("Matrix F is not adapted");
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

        private int GetMaxPeriod(int stateNumber)
        {
            return MatrixUtils.GetRow(model.F, stateNumber)
                .Select((value, index) => new { value, index })
                .Where(item => !DoubleUtils.EqualsZero(item.value))
                .OrderByDescending(item => item.index)
                .First()
                .index;
        }

        private int GetMinPeriod(int stateNumber)
        {
            return MatrixUtils.GetRow(model.F, stateNumber)
                .Select((value, index) => new { value, index })
                .Where(item => !DoubleUtils.EqualsZero(item.value))
                .OrderBy(item => item.index)
                .First()
                .index;
        }

        private bool isRhoAdapted()
        {
            for (int i = 0; i < model.N; i++)
            {
                int modelSegmentLength = model.Rho[i].Length;
                double t = 1 / (modelSegmentLength * model.Per[i]);
                if (t >= 1)
                {
                    return false;
                }
                for (int j = 0; j < modelSegmentLength; j++)
                {
                    if (model.Rho[i][j] > t)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isFAdapted()
        {
            for (int i = 0; i < model.N; i++)
            {
                int minPeriodInState = GetMinPeriod(i);
                if (minPeriodInState * model.Per[i] <= 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
