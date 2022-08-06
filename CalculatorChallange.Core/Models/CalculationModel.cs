using CalculatorChallenge.Core.Models.Enums;
using System.Linq;

namespace CalculatorChallenge.Core.Models
{
    public class CalculationModel
    {
        public List<decimal> Numbers { get; set; }
        public List<Functions> Functions { get; set; }

        public decimal Count()
        {
            var functions = Functions.OrderByDescending(x => x).ToList();
            var orderedFunctions = Functions.OrderByDescending(x => x).ToList();
            decimal Total = 0;
            for (int i = 0; i < orderedFunctions.Count; i++)
            {
                var functionIndex = Functions.IndexOf(orderedFunctions[i]);
                if (functionIndex != -1)
                {
                    var number1 = Numbers[functionIndex];
                    var number2 = Numbers[functionIndex + 1];
                    var basicCalculationModel = new BasicCalculationModel(number1, number2, orderedFunctions[i]);
                    Numbers.RemoveAt(functionIndex + 1);
                    Numbers[functionIndex] = basicCalculationModel.Count;
                    Functions.RemoveAt(functionIndex);
                    Total = Numbers[functionIndex];
                }
            }
            return Total;
        }
    }

}
