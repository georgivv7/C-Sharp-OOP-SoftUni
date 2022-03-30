namespace DependencyInversion.Strategies
{
    using Contracts;
    public class DivisionStartegy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
