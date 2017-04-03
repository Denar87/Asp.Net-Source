﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[assembly: EdmSchemaAttribute()]
namespace ERPSSL.HRM.DAL.AttendanceDataModel
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class BackUpHRMEntities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new BackUpHRMEntities object using the connection string found in the 'BackUpHRMEntities' section of the application configuration file.
        /// </summary>
        public BackUpHRMEntities() : base("name=BackUpHRMEntities", "BackUpHRMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BackUpHRMEntities object.
        /// </summary>
        public BackUpHRMEntities(string connectionString) : base(connectionString, "BackUpHRMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new BackUpHRMEntities object.
        /// </summary>
        public BackUpHRMEntities(EntityConnection connection) : base(connection, "BackUpHRMEntities")
        {
            this.ContextOptions.LazyLoadingEnabled = true;
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<tblprocessedData> tblprocessedDatas
        {
            get
            {
                if ((_tblprocessedDatas == null))
                {
                    _tblprocessedDatas = base.CreateObjectSet<tblprocessedData>("tblprocessedDatas");
                }
                return _tblprocessedDatas;
            }
        }
        private ObjectSet<tblprocessedData> _tblprocessedDatas;

        #endregion

        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the tblprocessedDatas EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddTotblprocessedDatas(tblprocessedData tblprocessedData)
        {
            base.AddObject("tblprocessedDatas", tblprocessedData);
        }

        #endregion

    }

    #endregion

    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="BackUpHRMModel", Name="tblprocessedData")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class tblprocessedData : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new tblprocessedData object.
        /// </summary>
        /// <param name="empId">Initial value of the EmpId property.</param>
        /// <param name="punchDate">Initial value of the PunchDate property.</param>
        public static tblprocessedData CreatetblprocessedData(global::System.String empId, global::System.DateTime punchDate)
        {
            tblprocessedData tblprocessedData = new tblprocessedData();
            tblprocessedData.EmpId = empId;
            tblprocessedData.PunchDate = punchDate;
            return tblprocessedData;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String EmpId
        {
            get
            {
                return _EmpId;
            }
            set
            {
                if (_EmpId != value)
                {
                    OnEmpIdChanging(value);
                    ReportPropertyChanging("EmpId");
                    _EmpId = StructuralObject.SetValidValue(value, false);
                    ReportPropertyChanged("EmpId");
                    OnEmpIdChanged();
                }
            }
        }
        private global::System.String _EmpId;
        partial void OnEmpIdChanging(global::System.String value);
        partial void OnEmpIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> TimeIn
        {
            get
            {
                return _TimeIn;
            }
            set
            {
                OnTimeInChanging(value);
                ReportPropertyChanging("TimeIn");
                _TimeIn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TimeIn");
                OnTimeInChanged();
            }
        }
        private Nullable<global::System.DateTime> _TimeIn;
        partial void OnTimeInChanging(Nullable<global::System.DateTime> value);
        partial void OnTimeInChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> TimeOut
        {
            get
            {
                return _TimeOut;
            }
            set
            {
                OnTimeOutChanging(value);
                ReportPropertyChanging("TimeOut");
                _TimeOut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("TimeOut");
                OnTimeOutChanged();
            }
        }
        private Nullable<global::System.DateTime> _TimeOut;
        partial void OnTimeOutChanging(Nullable<global::System.DateTime> value);
        partial void OnTimeOutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Lin
        {
            get
            {
                return _Lin;
            }
            set
            {
                OnLinChanging(value);
                ReportPropertyChanging("Lin");
                _Lin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Lin");
                OnLinChanged();
            }
        }
        private Nullable<global::System.DateTime> _Lin;
        partial void OnLinChanging(Nullable<global::System.DateTime> value);
        partial void OnLinChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Lout
        {
            get
            {
                return _Lout;
            }
            set
            {
                OnLoutChanging(value);
                ReportPropertyChanging("Lout");
                _Lout = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Lout");
                OnLoutChanged();
            }
        }
        private Nullable<global::System.DateTime> _Lout;
        partial void OnLoutChanging(Nullable<global::System.DateTime> value);
        partial void OnLoutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Llate
        {
            get
            {
                return _Llate;
            }
            set
            {
                OnLlateChanging(value);
                ReportPropertyChanging("Llate");
                _Llate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Llate");
                OnLlateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Llate;
        partial void OnLlateChanging(Nullable<global::System.DateTime> value);
        partial void OnLlateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Late
        {
            get
            {
                return _Late;
            }
            set
            {
                OnLateChanging(value);
                ReportPropertyChanging("Late");
                _Late = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Late");
                OnLateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Late;
        partial void OnLateChanging(Nullable<global::System.DateTime> value);
        partial void OnLateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime PunchDate
        {
            get
            {
                return _PunchDate;
            }
            set
            {
                if (_PunchDate != value)
                {
                    OnPunchDateChanging(value);
                    ReportPropertyChanging("PunchDate");
                    _PunchDate = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("PunchDate");
                    OnPunchDateChanged();
                }
            }
        }
        private global::System.DateTime _PunchDate;
        partial void OnPunchDateChanging(global::System.DateTime value);
        partial void OnPunchDateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String PunchShiftCode
        {
            get
            {
                return _PunchShiftCode;
            }
            set
            {
                OnPunchShiftCodeChanging(value);
                ReportPropertyChanging("PunchShiftCode");
                _PunchShiftCode = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("PunchShiftCode");
                OnPunchShiftCodeChanged();
            }
        }
        private global::System.String _PunchShiftCode;
        partial void OnPunchShiftCodeChanging(global::System.String value);
        partial void OnPunchShiftCodeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> RegHour
        {
            get
            {
                return _RegHour;
            }
            set
            {
                OnRegHourChanging(value);
                ReportPropertyChanging("RegHour");
                _RegHour = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("RegHour");
                OnRegHourChanged();
            }
        }
        private Nullable<global::System.DateTime> _RegHour;
        partial void OnRegHourChanging(Nullable<global::System.DateTime> value);
        partial void OnRegHourChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Sin
        {
            get
            {
                return _Sin;
            }
            set
            {
                OnSinChanging(value);
                ReportPropertyChanging("Sin");
                _Sin = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Sin");
                OnSinChanged();
            }
        }
        private Nullable<global::System.DateTime> _Sin;
        partial void OnSinChanging(Nullable<global::System.DateTime> value);
        partial void OnSinChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Sout
        {
            get
            {
                return _Sout;
            }
            set
            {
                OnSoutChanging(value);
                ReportPropertyChanging("Sout");
                _Sout = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Sout");
                OnSoutChanged();
            }
        }
        private Nullable<global::System.DateTime> _Sout;
        partial void OnSoutChanging(Nullable<global::System.DateTime> value);
        partial void OnSoutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> SReg
        {
            get
            {
                return _SReg;
            }
            set
            {
                OnSRegChanging(value);
                ReportPropertyChanging("SReg");
                _SReg = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SReg");
                OnSRegChanged();
            }
        }
        private Nullable<global::System.DateTime> _SReg;
        partial void OnSRegChanging(Nullable<global::System.DateTime> value);
        partial void OnSRegChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> Slate
        {
            get
            {
                return _Slate;
            }
            set
            {
                OnSlateChanging(value);
                ReportPropertyChanging("Slate");
                _Slate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Slate");
                OnSlateChanged();
            }
        }
        private Nullable<global::System.DateTime> _Slate;
        partial void OnSlateChanging(Nullable<global::System.DateTime> value);
        partial void OnSlateChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> OTHour
        {
            get
            {
                return _OTHour;
            }
            set
            {
                OnOTHourChanging(value);
                ReportPropertyChanging("OTHour");
                _OTHour = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("OTHour");
                OnOTHourChanged();
            }
        }
        private Nullable<global::System.DateTime> _OTHour;
        partial void OnOTHourChanging(Nullable<global::System.DateTime> value);
        partial void OnOTHourChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Sts
        {
            get
            {
                return _Sts;
            }
            set
            {
                OnStsChanging(value);
                ReportPropertyChanging("Sts");
                _Sts = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Sts");
                OnStsChanged();
            }
        }
        private global::System.String _Sts;
        partial void OnStsChanging(global::System.String value);
        partial void OnStsChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Byte> NoPunch
        {
            get
            {
                return _NoPunch;
            }
            set
            {
                OnNoPunchChanging(value);
                ReportPropertyChanging("NoPunch");
                _NoPunch = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("NoPunch");
                OnNoPunchChanged();
            }
        }
        private Nullable<global::System.Byte> _NoPunch;
        partial void OnNoPunchChanging(Nullable<global::System.Byte> value);
        partial void OnNoPunchChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String NShiftDesc
        {
            get
            {
                return _NShiftDesc;
            }
            set
            {
                OnNShiftDescChanging(value);
                ReportPropertyChanging("NShiftDesc");
                _NShiftDesc = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("NShiftDesc");
                OnNShiftDescChanged();
            }
        }
        private global::System.String _NShiftDesc;
        partial void OnNShiftDescChanging(global::System.String value);
        partial void OnNShiftDescChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String OTShiftDesc
        {
            get
            {
                return _OTShiftDesc;
            }
            set
            {
                OnOTShiftDescChanging(value);
                ReportPropertyChanging("OTShiftDesc");
                _OTShiftDesc = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("OTShiftDesc");
                OnOTShiftDescChanged();
            }
        }
        private global::System.String _OTShiftDesc;
        partial void OnOTShiftDescChanging(global::System.String value);
        partial void OnOTShiftDescChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> SectIn
        {
            get
            {
                return _SectIn;
            }
            set
            {
                OnSectInChanging(value);
                ReportPropertyChanging("SectIn");
                _SectIn = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SectIn");
                OnSectInChanged();
            }
        }
        private Nullable<global::System.DateTime> _SectIn;
        partial void OnSectInChanging(Nullable<global::System.DateTime> value);
        partial void OnSectInChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> SectOut
        {
            get
            {
                return _SectOut;
            }
            set
            {
                OnSectOutChanging(value);
                ReportPropertyChanging("SectOut");
                _SectOut = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("SectOut");
                OnSectOutChanged();
            }
        }
        private Nullable<global::System.DateTime> _SectOut;
        partial void OnSectOutChanging(Nullable<global::System.DateTime> value);
        partial void OnSectOutChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.DateTime> BTime
        {
            get
            {
                return _BTime;
            }
            set
            {
                OnBTimeChanging(value);
                ReportPropertyChanging("BTime");
                _BTime = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("BTime");
                OnBTimeChanged();
            }
        }
        private Nullable<global::System.DateTime> _BTime;
        partial void OnBTimeChanging(Nullable<global::System.DateTime> value);
        partial void OnBTimeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Ramadan
        {
            get
            {
                return _Ramadan;
            }
            set
            {
                OnRamadanChanging(value);
                ReportPropertyChanging("Ramadan");
                _Ramadan = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Ramadan");
                OnRamadanChanged();
            }
        }
        private global::System.String _Ramadan;
        partial void OnRamadanChanging(global::System.String value);
        partial void OnRamadanChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<global::System.Int32> Status
        {
            get
            {
                return _Status;
            }
            set
            {
                OnStatusChanging(value);
                ReportPropertyChanging("Status");
                _Status = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("Status");
                OnStatusChanged();
            }
        }
        private Nullable<global::System.Int32> _Status;
        partial void OnStatusChanging(Nullable<global::System.Int32> value);
        partial void OnStatusChanged();

        #endregion

    
    }

    #endregion

    
}