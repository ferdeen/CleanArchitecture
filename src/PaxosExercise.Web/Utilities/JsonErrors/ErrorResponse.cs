using Newtonsoft.Json;
using System.Collections.Generic;

namespace PaxosExercise.Web.Utilities.JsonErrors
{
    public class ErrorResponse
    {
        [JsonProperty(PropertyName = "errors")]
        public List<ErrorModel> Errors { get; set; }
    }

    public class ErrorModel
    {
        [JsonProperty(PropertyName = "status")]
        public int Status { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
