[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IMathsOperations")]
public interface IMathsOperations
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
    int Add(int num1, int num2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Add", ReplyAction="http://tempuri.org/IMathsOperations/AddResponse")]
    System.Threading.Tasks.Task<int> AddAsync(int num1, int num2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
    int Multiply(int num1, int num2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMathsOperations/Multiply", ReplyAction="http://tempuri.org/IMathsOperations/MultiplyResponse")]
    System.Threading.Tasks.Task<int> MultiplyAsync(int num1, int num2);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IMathsOperationsChannel : IMathsOperations, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class MathsOperationsClient : System.ServiceModel.ClientBase<IMathsOperations>, IMathsOperations
{
    
    public MathsOperationsClient()
    {
    }
    
    public MathsOperationsClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public MathsOperationsClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MathsOperationsClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public MathsOperationsClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public int Add(int num1, int num2)
    {
        return base.Channel.Add(num1, num2);
    }
    
    public System.Threading.Tasks.Task<int> AddAsync(int num1, int num2)
    {
        return base.Channel.AddAsync(num1, num2);
    }
    
    public int Multiply(int num1, int num2)
    {
        return base.Channel.Multiply(num1, num2);
    }
    
    public System.Threading.Tasks.Task<int> MultiplyAsync(int num1, int num2)
    {
        return base.Channel.MultiplyAsync(num1, num2);
    }
}
