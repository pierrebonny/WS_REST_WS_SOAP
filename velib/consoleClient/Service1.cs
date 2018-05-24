﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IService1", CallbackContract=typeof(IService1Callback))]
public interface IService1
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAvailableBikes", ReplyAction="http://tempuri.org/IService1/GetAvailableBikesResponse")]
    string GetAvailableBikes(string station, string city);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAvailableBikes", ReplyAction="http://tempuri.org/IService1/GetAvailableBikesResponse")]
    System.Threading.Tasks.Task<string> GetAvailableBikesAsync(string station, string city);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCities", ReplyAction="http://tempuri.org/IService1/GetAllCitiesResponse")]
    string[] GetAllCities();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllCities", ReplyAction="http://tempuri.org/IService1/GetAllCitiesResponse")]
    System.Threading.Tasks.Task<string[]> GetAllCitiesAsync();
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStations", ReplyAction="http://tempuri.org/IService1/GetAllStationsResponse")]
    string[] GetAllStations(string city);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetAllStations", ReplyAction="http://tempuri.org/IService1/GetAllStationsResponse")]
    System.Threading.Tasks.Task<string[]> GetAllStationsAsync(string city);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SuscribeStationEvent", ReplyAction="http://tempuri.org/IService1/SuscribeStationEventResponse")]
    void SuscribeStationEvent(string station, string city);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SuscribeStationEvent", ReplyAction="http://tempuri.org/IService1/SuscribeStationEventResponse")]
    System.Threading.Tasks.Task SuscribeStationEventAsync(string station, string city);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IService1Callback
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IService1/GetStation")]
    void GetStation(string city, string station, int value);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IService1Channel : IService1, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class Service1Client : System.ServiceModel.DuplexClientBase<IService1>, IService1
{
    
    public Service1Client(System.ServiceModel.InstanceContext callbackInstance) : 
            base(callbackInstance)
    {
    }
    
    public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
            base(callbackInstance, endpointConfigurationName)
    {
    }
    
    public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public Service1Client(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public Service1Client(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, binding, remoteAddress)
    {
    }
    
    public string GetAvailableBikes(string station, string city)
    {
        return base.Channel.GetAvailableBikes(station, city);
    }
    
    public System.Threading.Tasks.Task<string> GetAvailableBikesAsync(string station, string city)
    {
        return base.Channel.GetAvailableBikesAsync(station, city);
    }
    
    public string[] GetAllCities()
    {
        return base.Channel.GetAllCities();
    }
    
    public System.Threading.Tasks.Task<string[]> GetAllCitiesAsync()
    {
        return base.Channel.GetAllCitiesAsync();
    }
    
    public string[] GetAllStations(string city)
    {
        return base.Channel.GetAllStations(city);
    }
    
    public System.Threading.Tasks.Task<string[]> GetAllStationsAsync(string city)
    {
        return base.Channel.GetAllStationsAsync(city);
    }
    
    public void SuscribeStationEvent(string station, string city)
    {
        base.Channel.SuscribeStationEvent(station, city);
    }
    
    public System.Threading.Tasks.Task SuscribeStationEventAsync(string station, string city)
    {
        return base.Channel.SuscribeStationEventAsync(station, city);
    }
}
