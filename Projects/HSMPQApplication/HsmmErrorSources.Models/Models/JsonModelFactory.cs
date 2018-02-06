using System;
using HsmmErrorSources.Models.Representations;

namespace HsmmErrorSources.Models.Models
{
    public class JsonModelFactory
    {
        public IHsmModel CreateModel(String json)
        {
            ModelType modelType = GetModelType(json);
            switch (modelType)
            {
                case ModelType.HsmFergusonModel:
                {
                    var jsonRepresentation = new JsonRepresentation<HsmFergusonModel>();
                    return jsonRepresentation.Deserialize(json);
                }
                case ModelType.HsmQpModel: {
                    var jsonRepresentation = new JsonRepresentation<HsmQpModel>();
                    return jsonRepresentation.Deserialize(json);
                }
                default:
                {
                    throw new NotImplementedException("Model Type is not supported");
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
