using System.Linq;
using HsmmErrorSources.Models.Models;
using HsmmErrorSources.Models.Utils;

namespace HsmmErrorSources.Models.Validators
{
    public class HsmQpModelValidator : AbstractHsmModelValidator<HsmQpModel>
    {
        public HsmQpModelValidator(HsmQpModel model) : base(model) { }

        public override void Validate()
        {
            base.Validate();
            if (HasErrors())
            {
                return;
            }
            if (Model.Rho == null
                || Model.Per == null)
            {
                AddError("Some of the QP-model parameters are not set");
                return;
            }
            if (Model.N != Model.Rho.Length
                || Model.N != Model.Per.Length)
            {
                AddError("Inconsistent matrices and arrays dimensions");
                return;
            }

            if (!MatrixUtils.IsStochasticByRows(Model.Rho))
            {
                AddError("Rho vectors should be stochastic");
            }

            if (!DoubleUtils.AreEqual(Model.Pi.Sum(), 1))
            {
                AddError("Sum of Pi elements should be equal to 1");
            }

            if (!IsRhoAdapted())
            {
                AddError("Rho is not adapted");
            }

            if (!IsFAdapted())
            {
                AddError("Matrix F is not adapted");
            }
        }

        private int GetMaxPeriod(int stateNumber)
        {
            return MatrixUtils.GetRow(Model.F, stateNumber)
                .Select((value, index) => new { value, index })
                .Where(item => !DoubleUtils.EqualsZero(item.value))
                .OrderByDescending(item => item.index)
                .First()
                .index;
        }

        private int GetMinPeriod(int stateNumber)
        {
            return MatrixUtils.GetRow(Model.F, stateNumber)
                .Select((value, index) => new { value, index })
                .Where(item => !DoubleUtils.EqualsZero(item.value))
                .OrderBy(item => item.index)
                .First()
                .index;
        }

        private bool IsRhoAdapted()
        {
            for (int i = 0; i < Model.N; i++)
            {
                int modelSegmentLength = Model.Rho[i].Length;
                double t = 1 / (modelSegmentLength * Model.Per[i]);
                if (t >= 1)
                {
                    return false;
                }
                for (int j = 0; j < modelSegmentLength; j++)
                {
                    if (Model.Rho[i][j] > t)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool IsFAdapted()
        {
            for (int i = 0; i < Model.N; i++)
            {
                int minPeriodInState = GetMinPeriod(i);
                if (minPeriodInState * Model.Per[i] <= 1)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
