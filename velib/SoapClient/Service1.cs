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
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IService1")]
public interface IService1
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAvailableBikes", ReplyAction = "http://tempuri.org/IService1/GetAvailableBikesResponse")]
    string GetAvailableBikes(string station, string city);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAvailableBikes", ReplyAction = "http://tempuri.org/IService1/GetAvailableBikesResponse")]
    System.Threading.Tasks.Task<string> GetAvailableBikesAsync(string station, string city);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAllCities", ReplyAction = "http://tempuri.org/IService1/GetAllCitiesResponse")]
    string[] GetAllCities();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAllCities", ReplyAction = "http://tempuri.org/IService1/GetAllCitiesResponse")]
    System.Threading.Tasks.Task<string[]> GetAllCitiesAsync();

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAllStations", ReplyAction = "http://tempuri.org/IService1/GetAllStationsResponse")]
    string[] GetAllStations(string city);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IService1/GetAllStations", ReplyAction = "http://tempuri.org/IService1/GetAllStationsResponse")]
    System.Threading.Tasks.Task<string[]> GetAllStationsAsync(string city);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IService1Channel : IService1, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class Service1Client : System.ServiceModel.ClientBase<IService1>, IService1
{

    public Service1Client()
    {
    }

    public Service1Client(string endpointConfigurationName) :
            base(endpointConfigurationName)
    {
    }

    public Service1Client(string endpointConfigurationName, string remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(endpointConfigurationName, remoteAddress)
    {
    }

    public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(binding, remoteAddress)
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
}
