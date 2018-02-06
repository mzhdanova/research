using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HsmmErrorSources.Models.Representations;

namespace HsmmErrorSources.Models.Models
{
    public class JsonModelFactory
    {
        public IHsmModel CreateModel(String json)
        {
            ModelType modelType = GetModelType(json);
            JsonRepresentation<AbstractHsmModel> jsonRepresentation;
            switch (modelType)
            {
                case ModelType.HsmFergusonModel:
                {
                    jsonRepresentation = new JsonRepresentation<HsmFergusonModel>();
                }
                case ModelType.HsmQpModel: {
                    jsonRepresentation = new JsonRepresentation<HsmQpModel>();
                }
            }
        }

        private ModelType GetModelType(String json)
        {
            if (json == null)
            {
                throw new ArgumentException("Invalid input json");
            }

            if (json.Contains(ModelType.HsmQpModel.ToString()))
            {
                return ModelType.HsmQpModel;
            }

            if (json.Contains(ModelType.HsmFergusonModel.ToString()))
            {
                return ModelType.HsmFergusonModel;
            }

            throw new NotImplementedException("Model Type is not supported");
        }
    }
}
