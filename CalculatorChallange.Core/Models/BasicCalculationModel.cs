using CalculatorChallenge.Core.Models.Enums;

namespace CalculatorChallenge.Core.Models
{
    public class BasicCalculationModel
    {
        public BasicCalculationModel(decimal number1, decimal number2, Functions function)
        {
            Number1 = number1;
            Number2 = number2;
            Function = function;
        }

        public decimal Number1 { get; set; }
        public decimal Number2 { get; set; }
        public Functions Function { get; set; }

        public decimal Count
        {
            get
            {
                switch (Function)
                {
                    case Functions.Sum:
                        return Number1 + Number2;
                    case Functions.Subtract:
                        return Number1 - Number2;
                    case Functions.Multiply:
                        return Number1 * Number2;
                    case Functions.Divide:
                        return Number1 / Number2;
                    default:
                        throw new NotImplementedException("Calculation for this operator is not implemented!");
                }
            }
        }
    }
}
