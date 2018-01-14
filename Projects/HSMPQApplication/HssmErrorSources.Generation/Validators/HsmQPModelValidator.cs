using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Generation.Models;
using HsmmErrorSources.Generation.Utils;

namespace HsmmErrorSources.Generation.Validators
{
    public class HsmQPModelValidator : AbstractHsmModelValidator<HsmQPModel>
    {
        public HsmQPModelValidator(HsmQPModel model) : base(model) { }

        public override void Validate()
        {
            base.Validate();
            if (HasErrors())
            {
                return;
            }
            if (model.Rho == null
                || model.Per == null)
            {
                AddError("Some of the QP-model parameters are not set");
                return;
            }
            if (model.N != model.Rho.Length
                || model.N != model.Per.Length)
            {
                AddError("Inconsistent matrices and arrays dimensions");
                return;
            }

            if (!MatrixUtils.IsStochasticByRows(model.Rho))
            {
                AddError("Rho vectors should be stochastic");
            }

            if (!DoubleUtils.AreEqual(model.Pi.Sum(), 1))
            {
                AddError("Sum of Pi elements should be equal to 1");
            }

            if (!isRhoAdapted())
            {
                AddError("Rho is not adapted");
            }

            if (!isFAdapted())
            {
                AddError("Matrix F is not adapted");
            }
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
