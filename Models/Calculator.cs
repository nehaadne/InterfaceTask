namespace InterfaceTask.Models
{
    public class Calculator : ICalculate
    {
        public int multiply(int x, int y)
        {
            return x * y;
        }

        public int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
