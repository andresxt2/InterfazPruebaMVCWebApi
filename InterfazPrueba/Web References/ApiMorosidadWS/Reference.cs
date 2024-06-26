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

namespace InterfazPrueba.ApiMorosidadWS {
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
    [System.Web.Services.WebServiceBindingAttribute(Name="API_GestionMorosidadSoap", Namespace="http://tempuri.org/")]
    public partial class API_GestionMorosidad : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback ListarOperationCompleted;
        
        private System.Threading.SendOrPostCallback ListarPorEstudianteOperationCompleted;
        
        private System.Threading.SendOrPostCallback ListarPorDiasDeRetrasoOperationCompleted;
        
        private System.Threading.SendOrPostCallback leerPorIdOperationCompleted;
        
        private System.Threading.SendOrPostCallback InsertarOperationCompleted;
        
        private System.Threading.SendOrPostCallback ActualizarOperationCompleted;
        
        private System.Threading.SendOrPostCallback EliminarOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public API_GestionMorosidad() {
            this.Url = global::InterfazPrueba.Properties.Settings.Default.InterfazPrueba_ApiMorosidadWS_API_GestionMorosidad;
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
        public event ListarCompletedEventHandler ListarCompleted;
        
        /// <remarks/>
        public event ListarPorEstudianteCompletedEventHandler ListarPorEstudianteCompleted;
        
        /// <remarks/>
        public event ListarPorDiasDeRetrasoCompletedEventHandler ListarPorDiasDeRetrasoCompleted;
        
        /// <remarks/>
        public event leerPorIdCompletedEventHandler leerPorIdCompleted;
        
        /// <remarks/>
        public event InsertarCompletedEventHandler InsertarCompleted;
        
        /// <remarks/>
        public event ActualizarCompletedEventHandler ActualizarCompleted;
        
        /// <remarks/>
        public event EliminarCompletedEventHandler EliminarCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Listar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Morosidad[] Listar() {
            object[] results = this.Invoke("Listar", new object[0]);
            return ((Morosidad[])(results[0]));
        }
        
        /// <remarks/>
        public void ListarAsync() {
            this.ListarAsync(null);
        }
        
        /// <remarks/>
        public void ListarAsync(object userState) {
            if ((this.ListarOperationCompleted == null)) {
                this.ListarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarOperationCompleted);
            }
            this.InvokeAsync("Listar", new object[0], this.ListarOperationCompleted, userState);
        }
        
        private void OnListarOperationCompleted(object arg) {
            if ((this.ListarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarCompleted(this, new ListarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ListarPorEstudiante", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Morosidad[] ListarPorEstudiante(string id) {
            object[] results = this.Invoke("ListarPorEstudiante", new object[] {
                        id});
            return ((Morosidad[])(results[0]));
        }
        
        /// <remarks/>
        public void ListarPorEstudianteAsync(string id) {
            this.ListarPorEstudianteAsync(id, null);
        }
        
        /// <remarks/>
        public void ListarPorEstudianteAsync(string id, object userState) {
            if ((this.ListarPorEstudianteOperationCompleted == null)) {
                this.ListarPorEstudianteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarPorEstudianteOperationCompleted);
            }
            this.InvokeAsync("ListarPorEstudiante", new object[] {
                        id}, this.ListarPorEstudianteOperationCompleted, userState);
        }
        
        private void OnListarPorEstudianteOperationCompleted(object arg) {
            if ((this.ListarPorEstudianteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarPorEstudianteCompleted(this, new ListarPorEstudianteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/ListarPorDiasDeRetraso", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Morosidad[] ListarPorDiasDeRetraso(int dias) {
            object[] results = this.Invoke("ListarPorDiasDeRetraso", new object[] {
                        dias});
            return ((Morosidad[])(results[0]));
        }
        
        /// <remarks/>
        public void ListarPorDiasDeRetrasoAsync(int dias) {
            this.ListarPorDiasDeRetrasoAsync(dias, null);
        }
        
        /// <remarks/>
        public void ListarPorDiasDeRetrasoAsync(int dias, object userState) {
            if ((this.ListarPorDiasDeRetrasoOperationCompleted == null)) {
                this.ListarPorDiasDeRetrasoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnListarPorDiasDeRetrasoOperationCompleted);
            }
            this.InvokeAsync("ListarPorDiasDeRetraso", new object[] {
                        dias}, this.ListarPorDiasDeRetrasoOperationCompleted, userState);
        }
        
        private void OnListarPorDiasDeRetrasoOperationCompleted(object arg) {
            if ((this.ListarPorDiasDeRetrasoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ListarPorDiasDeRetrasoCompleted(this, new ListarPorDiasDeRetrasoCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/leerPorId", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Morosidad leerPorId(int id) {
            object[] results = this.Invoke("leerPorId", new object[] {
                        id});
            return ((Morosidad)(results[0]));
        }
        
        /// <remarks/>
        public void leerPorIdAsync(int id) {
            this.leerPorIdAsync(id, null);
        }
        
        /// <remarks/>
        public void leerPorIdAsync(int id, object userState) {
            if ((this.leerPorIdOperationCompleted == null)) {
                this.leerPorIdOperationCompleted = new System.Threading.SendOrPostCallback(this.OnleerPorIdOperationCompleted);
            }
            this.InvokeAsync("leerPorId", new object[] {
                        id}, this.leerPorIdOperationCompleted, userState);
        }
        
        private void OnleerPorIdOperationCompleted(object arg) {
            if ((this.leerPorIdCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.leerPorIdCompleted(this, new leerPorIdCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Insertar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void Insertar(Morosidad morosidad) {
            this.Invoke("Insertar", new object[] {
                        morosidad});
        }
        
        /// <remarks/>
        public void InsertarAsync(Morosidad morosidad) {
            this.InsertarAsync(morosidad, null);
        }
        
        /// <remarks/>
        public void InsertarAsync(Morosidad morosidad, object userState) {
            if ((this.InsertarOperationCompleted == null)) {
                this.InsertarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnInsertarOperationCompleted);
            }
            this.InvokeAsync("Insertar", new object[] {
                        morosidad}, this.InsertarOperationCompleted, userState);
        }
        
        private void OnInsertarOperationCompleted(object arg) {
            if ((this.InsertarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.InsertarCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Actualizar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Actualizar(Morosidad morosidad) {
            object[] results = this.Invoke("Actualizar", new object[] {
                        morosidad});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void ActualizarAsync(Morosidad morosidad) {
            this.ActualizarAsync(morosidad, null);
        }
        
        /// <remarks/>
        public void ActualizarAsync(Morosidad morosidad, object userState) {
            if ((this.ActualizarOperationCompleted == null)) {
                this.ActualizarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnActualizarOperationCompleted);
            }
            this.InvokeAsync("Actualizar", new object[] {
                        morosidad}, this.ActualizarOperationCompleted, userState);
        }
        
        private void OnActualizarOperationCompleted(object arg) {
            if ((this.ActualizarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.ActualizarCompleted(this, new ActualizarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Eliminar", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public bool Eliminar(int id) {
            object[] results = this.Invoke("Eliminar", new object[] {
                        id});
            return ((bool)(results[0]));
        }
        
        /// <remarks/>
        public void EliminarAsync(int id) {
            this.EliminarAsync(id, null);
        }
        
        /// <remarks/>
        public void EliminarAsync(int id, object userState) {
            if ((this.EliminarOperationCompleted == null)) {
                this.EliminarOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEliminarOperationCompleted);
            }
            this.InvokeAsync("Eliminar", new object[] {
                        id}, this.EliminarOperationCompleted, userState);
        }
        
        private void OnEliminarOperationCompleted(object arg) {
            if ((this.EliminarCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EliminarCompleted(this, new EliminarCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    public partial class Morosidad {
        
        private int id_morosidadField;
        
        private string id_estudianteField;
        
        private string semestreField;
        
        private int dias_retrasoField;
        
        private decimal monto_debidoField;
        
        private System.Nullable<bool> borrado_logicoField;
        
        private System.Nullable<System.DateTime> fecha_borrado_logicoField;
        
        private Estudiantes estudiantesField;
        
        /// <remarks/>
        public int id_morosidad {
            get {
                return this.id_morosidadField;
            }
            set {
                this.id_morosidadField = value;
            }
        }
        
        /// <remarks/>
        public string id_estudiante {
            get {
                return this.id_estudianteField;
            }
            set {
                this.id_estudianteField = value;
            }
        }
        
        /// <remarks/>
        public string semestre {
            get {
                return this.semestreField;
            }
            set {
                this.semestreField = value;
            }
        }
        
        /// <remarks/>
        public int dias_retraso {
            get {
                return this.dias_retrasoField;
            }
            set {
                this.dias_retrasoField = value;
            }
        }
        
        /// <remarks/>
        public decimal monto_debido {
            get {
                return this.monto_debidoField;
            }
            set {
                this.monto_debidoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> borrado_logico {
            get {
                return this.borrado_logicoField;
            }
            set {
                this.borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> fecha_borrado_logico {
            get {
                return this.fecha_borrado_logicoField;
            }
            set {
                this.fecha_borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        public Estudiantes Estudiantes {
            get {
                return this.estudiantesField;
            }
            set {
                this.estudiantesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Estudiantes {
        
        private string id_estudianteField;
        
        private string nombresField;
        
        private string apellidosField;
        
        private string correo_electronicoField;
        
        private string programa_academicoField;
        
        private string estado_matriculaField;
        
        private System.Nullable<bool> borrado_logicoField;
        
        private System.Nullable<System.DateTime> fecha_borrado_logicoField;
        
        private Becas_Ayudas_Financieras[] becas_Ayudas_FinancierasField;
        
        private Morosidad[] morosidadField;
        
        private Pagos[] pagosField;
        
        /// <remarks/>
        public string id_estudiante {
            get {
                return this.id_estudianteField;
            }
            set {
                this.id_estudianteField = value;
            }
        }
        
        /// <remarks/>
        public string nombres {
            get {
                return this.nombresField;
            }
            set {
                this.nombresField = value;
            }
        }
        
        /// <remarks/>
        public string apellidos {
            get {
                return this.apellidosField;
            }
            set {
                this.apellidosField = value;
            }
        }
        
        /// <remarks/>
        public string correo_electronico {
            get {
                return this.correo_electronicoField;
            }
            set {
                this.correo_electronicoField = value;
            }
        }
        
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
        public string estado_matricula {
            get {
                return this.estado_matriculaField;
            }
            set {
                this.estado_matriculaField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> borrado_logico {
            get {
                return this.borrado_logicoField;
            }
            set {
                this.borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> fecha_borrado_logico {
            get {
                return this.fecha_borrado_logicoField;
            }
            set {
                this.fecha_borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        public Becas_Ayudas_Financieras[] Becas_Ayudas_Financieras {
            get {
                return this.becas_Ayudas_FinancierasField;
            }
            set {
                this.becas_Ayudas_FinancierasField = value;
            }
        }
        
        /// <remarks/>
        public Morosidad[] Morosidad {
            get {
                return this.morosidadField;
            }
            set {
                this.morosidadField = value;
            }
        }
        
        /// <remarks/>
        public Pagos[] Pagos {
            get {
                return this.pagosField;
            }
            set {
                this.pagosField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Becas_Ayudas_Financieras {
        
        private int id_becaField;
        
        private string id_estudianteField;
        
        private string tipo_becaField;
        
        private decimal montoField;
        
        private string semestreField;
        
        private System.Nullable<bool> borrado_logicoField;
        
        private System.Nullable<System.DateTime> fecha_borrado_logicoField;
        
        private Estudiantes estudiantesField;
        
        /// <remarks/>
        public int id_beca {
            get {
                return this.id_becaField;
            }
            set {
                this.id_becaField = value;
            }
        }
        
        /// <remarks/>
        public string id_estudiante {
            get {
                return this.id_estudianteField;
            }
            set {
                this.id_estudianteField = value;
            }
        }
        
        /// <remarks/>
        public string tipo_beca {
            get {
                return this.tipo_becaField;
            }
            set {
                this.tipo_becaField = value;
            }
        }
        
        /// <remarks/>
        public decimal monto {
            get {
                return this.montoField;
            }
            set {
                this.montoField = value;
            }
        }
        
        /// <remarks/>
        public string semestre {
            get {
                return this.semestreField;
            }
            set {
                this.semestreField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> borrado_logico {
            get {
                return this.borrado_logicoField;
            }
            set {
                this.borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> fecha_borrado_logico {
            get {
                return this.fecha_borrado_logicoField;
            }
            set {
                this.fecha_borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        public Estudiantes Estudiantes {
            get {
                return this.estudiantesField;
            }
            set {
                this.estudiantesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.9032.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Pagos {
        
        private int id_pagoField;
        
        private string cod_pagoField;
        
        private string id_estudianteField;
        
        private System.DateTime fecha_pagoField;
        
        private decimal saldoField;
        
        private string semestreField;
        
        private string estadoField;
        
        private System.Nullable<bool> borrado_logicoField;
        
        private System.Nullable<System.DateTime> fecha_borrado_logicoField;
        
        private Estudiantes estudiantesField;
        
        /// <remarks/>
        public int id_pago {
            get {
                return this.id_pagoField;
            }
            set {
                this.id_pagoField = value;
            }
        }
        
        /// <remarks/>
        public string cod_pago {
            get {
                return this.cod_pagoField;
            }
            set {
                this.cod_pagoField = value;
            }
        }
        
        /// <remarks/>
        public string id_estudiante {
            get {
                return this.id_estudianteField;
            }
            set {
                this.id_estudianteField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime fecha_pago {
            get {
                return this.fecha_pagoField;
            }
            set {
                this.fecha_pagoField = value;
            }
        }
        
        /// <remarks/>
        public decimal saldo {
            get {
                return this.saldoField;
            }
            set {
                this.saldoField = value;
            }
        }
        
        /// <remarks/>
        public string semestre {
            get {
                return this.semestreField;
            }
            set {
                this.semestreField = value;
            }
        }
        
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
        public System.Nullable<bool> borrado_logico {
            get {
                return this.borrado_logicoField;
            }
            set {
                this.borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<System.DateTime> fecha_borrado_logico {
            get {
                return this.fecha_borrado_logicoField;
            }
            set {
                this.fecha_borrado_logicoField = value;
            }
        }
        
        /// <remarks/>
        public Estudiantes Estudiantes {
            get {
                return this.estudiantesField;
            }
            set {
                this.estudiantesField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void ListarCompletedEventHandler(object sender, ListarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Morosidad[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Morosidad[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void ListarPorEstudianteCompletedEventHandler(object sender, ListarPorEstudianteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarPorEstudianteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarPorEstudianteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Morosidad[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Morosidad[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void ListarPorDiasDeRetrasoCompletedEventHandler(object sender, ListarPorDiasDeRetrasoCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ListarPorDiasDeRetrasoCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ListarPorDiasDeRetrasoCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Morosidad[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Morosidad[])(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void leerPorIdCompletedEventHandler(object sender, leerPorIdCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class leerPorIdCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal leerPorIdCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Morosidad Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Morosidad)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void InsertarCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void ActualizarCompletedEventHandler(object sender, ActualizarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ActualizarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal ActualizarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    public delegate void EliminarCompletedEventHandler(object sender, EliminarCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.9032.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EliminarCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal EliminarCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public bool Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((bool)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591