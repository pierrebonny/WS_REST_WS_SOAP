using System.ServiceModel;

namespace MathsLibrary
{
    public class MathsOperations :IMathsOperations
    {
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        public int Multiply(int num1, int num2)
        {
            return (num1 * num2);
        }
        public double Divide(int num1, int num2)
        {
            if(num2 == 0)
            {
                CustomFaultDetails fault = new CustomFaultDetails();
                fault.Message = "Exception occurred at service level : Divide by zero";
                throw new FaultException<CustomFaultDetails>(fault);
            }
            else
            {
                return ((double)num1 / (double)num2);
            }
            
        }
    }
}
