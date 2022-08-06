using System.Text.Json.Serialization;

namespace CalculatorChallenge.Core.Models
{
    public class ResultModel
    {
        [JsonConstructor]
        public ResultModel(bool success)
        {
            Success = success;
        }

        public bool Success { get; set; }
    }

    public class DataResultModel<T> : ResultModel
    {
        [JsonConstructor]
        public DataResultModel(bool success, T data): base(success)
        {
            Data = data;
        }

        public T? Data { get; set; }
    }
}
