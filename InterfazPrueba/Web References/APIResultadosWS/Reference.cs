﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace InterfazPrueba.APIResultadosWS {
    using System.Diagnostics;
    using System;
    using System.Xml.Serialization;
    using System.ComponentModel;
    using System.Web.Services.Protocols;
    using System.Web.Services;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="API_GestionResultadosSoap", Namespace="http://tempuri.org/")]
    public partial class API_GestionResultados : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback SPReporteDistribucionBecasPorProgramaOperationCompleted;
        
        private System.Threading.SendOrPostCallback SPReporteEstadoPagosOperationCompleted;
        
        private System.Threading.SendOrPostCallback SPReporteMorosidadPorProgramaOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public API_GestionResultados() {
            this.Url = global::InterfazPrueba.Properties.Settings.Default.InterfazPrueba_APIResultadosWS_API_GestionResultados;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event SPReporteDistribucionBecasPorProgramaCompletedEventHandler SPReporteDistribucionBecasPorProgramaCompleted;
        
        /// <remarks/>
        public event SPReporteEstadoPagosCompletedEventHandler SPReporteEstadoPagosCompleted;
        
        /// <remarks/>
        public event SPReporteMorosidadPorProgramaCompletedEventHandler SPReporteMorosidadPorProgramaCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SPReporteDistribucionBecasPorPrograma", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ReporteDistribucionBecasPorPrograma_Result[] SPReporteDistribucionBecasPorPrograma() {
            object[] results = this.Invoke("SPReporteDistribucionBecasPorPrograma", new object[0]);
            return ((ReporteDistribucionBecasPorPrograma_Result[])(results[0]));
        }
        
        /// <remarks/>
        public void SPReporteDistribucionBecasPorProgramaAsync() {
            this.SPReporteDistribucionBecasPorProgramaAsync(null);
        }
        
        /// <remarks/>
        public void SPReporteDistribucionBecasPorProgramaAsync(object userState) {
            if ((this.SPReporteDistribucionBecasPorProgramaOperationCompleted == null)) {
                this.SPReporteDistribucionBecasPorProgramaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSPReporteDistribucionBecasPorProgramaOperationCompleted);
            }
            this.InvokeAsync("SPReporteDistribucionBecasPorPrograma", new object[0], this.SPReporteDistribucionBecasPorProgramaOperationCompleted, userState);
        }
        
        private void OnSPReporteDistribucionBecasPorProgramaOperationCompleted(object arg) {
            if ((this.SPReporteDistribucionBecasPorProgramaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SPReporteDistribucionBecasPorProgramaCompleted(this, new SPReporteDistribucionBecasPorProgramaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SPReporteEstadoPagos", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ReporteEstadoPagos_Result[] SPReporteEstadoPagos() {
            object[] results = this.Invoke("SPReporteEstadoPagos", new object[0]);
            return ((ReporteEstadoPagos_Result[])(results[0]));
        }
        
        /// <remarks/>
        public void SPReporteEstadoPagosAsync() {
            this.SPReporteEstadoPagosAsync(null);
        }
        
        /// <remarks/>
        public void SPReporteEstadoPagosAsync(object userState) {
            if ((this.SPReporteEstadoPagosOperationCompleted == null)) {
                this.SPReporteEstadoPagosOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSPReporteEstadoPagosOperationCompleted);
            }
            this.InvokeAsync("SPReporteEstadoPagos", new object[0], this.SPReporteEstadoPagosOperationCompleted, userState);
        }
        
        private void OnSPReporteEstadoPagosOperationCompleted(object arg) {
            if ((this.SPReporteEstadoPagosCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SPReporteEstadoPagosCompleted(this, new SPReporteEstadoPagosCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SPReporteMorosidadPorPrograma", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public ReporteMorosidadPorPrograma_Result[] SPReporteMorosidadPorPrograma() {
            object[] results = this.Invoke("SPReporteMorosidadPorPrograma", new object[0]);
            return ((ReporteMorosidadPorPrograma_Result[])(results[0]));
        }
        
        /// <remarks/>
        public void SPReporteMorosidadPorProgramaAsync() {
            this.SPReporteMorosidadPorProgramaAsync(null);
        }
        
        /// <remarks/>
        public void SPReporteMorosidadPorProgramaAsync(object userState) {
            if ((this.SPReporteMorosidadPorProgramaOperationCompleted == null)) {
                this.SPReporteMorosidadPorProgramaOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSPReporteMorosidadPorProgramaOperationCompleted);
            }
            this.InvokeAsync("SPReporteMorosidadPorPrograma", new object[0], this.SPReporteMorosidadPorProgramaOperationCompleted, userState);
        }
        
        private void OnSPReporteMorosidadPorProgramaOperationCompleted(object arg) {
            if ((this.SPReporteMorosidadPorProgramaCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SPReporteMorosidadPorProgramaCompleted(this, new SPReporteMorosidadPorProgramaCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ReporteDistribucionBecasPorPrograma_Result {
        
        private string programa_academicoField;
        
        private System.Nullable<int> total_BecasField;
        
        private System.Nullable<decimal> monto_Total_BecasField;
        
        /// <remarks/>
        public string programa_academico {
            get {
                return this.programa_academicoField;
            }
            set {
                this.programa_academicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Total_Becas {
            get {
                return this.total_BecasField;
            }
            set {
                this.total_BecasField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<decimal> Monto_Total_Becas {
            get {
                return this.monto_Total_BecasField;
            }
            set {
                this.monto_Total_BecasField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ReporteMorosidadPorPrograma_Result {
        
        private string programa_academicoField;
        
        private System.Nullable<int> total_Casos_MorosidadField;
        
        private System.Nullable<decimal> monto_Total_DeudaField;
        
        /// <remarks/>
        public string programa_academico {
            get {
                return this.programa_academicoField;
            }
            set {
                this.programa_academicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Total_Casos_Morosidad {
            get {
                return this.total_Casos_MorosidadField;
            }
            set {
                this.total_Casos_MorosidadField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<decimal> Monto_Total_Deuda {
            get {
                return this.monto_Total_DeudaField;
            }
            set {
                this.monto_Total_DeudaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class ReporteEstadoPagos_Result {
        
        private string estadoField;
        
        private System.Nullable<int> total_PagosField;
        
        private System.Nullable<decimal> monto_TotalField;
        
        /// <remarks/>
        public string estado {
            get {
                return this.estadoField;
            }
            set {
                this.estadoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<int> Total_Pagos {
            get {
                return this.total_PagosField;
            }
            set {
                this.total_PagosField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<decimal> Monto_Total {
            get {
                return this.monto_TotalField;
            }
            set {
                this.monto_TotalField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void SPReporteDistribucionBecasPorProgramaCompletedEventHandler(object sender, SPReporteDistribucionBecasPorProgramaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SPReporteDistribucionBecasPorProgramaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SPReporteDistribucionBecasPorProgramaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReporteDistribucionBecasPorPrograma_Result[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReporteDistribucionBecasPorPrograma_Result[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void SPReporteEstadoPagosCompletedEventHandler(object sender, SPReporteEstadoPagosCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SPReporteEstadoPagosCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SPReporteEstadoPagosCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReporteEstadoPagos_Result[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReporteEstadoPagos_Result[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void SPReporteMorosidadPorProgramaCompletedEventHandler(object sender, SPReporteMorosidadPorProgramaCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SPReporteMorosidadPorProgramaCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SPReporteMorosidadPorProgramaCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public ReporteMorosidadPorPrograma_Result[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((ReporteMorosidadPorPrograma_Result[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591