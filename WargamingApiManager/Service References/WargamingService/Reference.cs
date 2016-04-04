﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WargamingApiManager.WargamingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WargamingService.IWargamingService")]
    public interface IWargamingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWargamingService/SearchPlayers", ReplyAction="http://tempuri.org/IWargamingService/SearchPlayersResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WargamingTypesLibrary.Enums.SearchType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(WargamingTypesLibrary.Enums.Language))]
        object SearchPlayers(string searchTerm, WargamingTypesLibrary.Enums.SearchType searchType, int limit, WargamingTypesLibrary.Enums.Language language, string responseFields);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWargamingService/SearchPlayers", ReplyAction="http://tempuri.org/IWargamingService/SearchPlayersResponse")]
        System.Threading.Tasks.Task<object> SearchPlayersAsync(string searchTerm, WargamingTypesLibrary.Enums.SearchType searchType, int limit, WargamingTypesLibrary.Enums.Language language, string responseFields);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWargamingServiceChannel : WargamingApiManager.WargamingService.IWargamingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WargamingServiceClient : System.ServiceModel.ClientBase<WargamingApiManager.WargamingService.IWargamingService>, WargamingApiManager.WargamingService.IWargamingService {
        
        public WargamingServiceClient() {
        }
        
        public WargamingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WargamingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WargamingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WargamingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public object SearchPlayers(string searchTerm, WargamingTypesLibrary.Enums.SearchType searchType, int limit, WargamingTypesLibrary.Enums.Language language, string responseFields) {
            return base.Channel.SearchPlayers(searchTerm, searchType, limit, language, responseFields);
        }
        
        public System.Threading.Tasks.Task<object> SearchPlayersAsync(string searchTerm, WargamingTypesLibrary.Enums.SearchType searchType, int limit, WargamingTypesLibrary.Enums.Language language, string responseFields) {
            return base.Channel.SearchPlayersAsync(searchTerm, searchType, limit, language, responseFields);
        }
    }
}