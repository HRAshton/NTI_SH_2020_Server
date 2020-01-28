using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebApplication4.Models.ResponseModels
{
    public abstract class ModelBase
    {
        public Statuses Status { get; set; }

        public string Message { get; set; }

        public string DateTime => System.DateTime.Now.ToLongTimeString();

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum Statuses
    {
        Error,

        Success
    }
}