using System.Runtime.Serialization;
using System.ServiceModel;

namespace MathsLibrary
{
    [DataContract]
    internal class CustomFaultDetails
    {
        [DataMember]
        public string Message { get; set; }
    }

    [ServiceContract]
    public interface IMathsOperations
    {
        [OperationContract]
        int Add(int num1, int num2);

        [OperationContract]
        int Multiply(int num1, int num2);

        [OperationContract]
        [FaultContract(typeof(CustomFaultDetails))]
        double Divide(int num1, int num2);
    }
}
