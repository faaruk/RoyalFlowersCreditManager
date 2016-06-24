﻿
using System;
using System.Data;
using System.Data.SqlClient;

namespace KPCustomBox
{
    #region usp_UpdateCBSalesPerson Wrapper
    /// <summary>
    /// This class is a wrapper for the usp_UpdateCBSalesPerson stored procedure.
    /// </summary>
    public class UpdateCBSalesPerson
    {
        #region Member Variables

        protected string _connectionString = String.Empty;
        protected SqlConnection _connection;
        protected SqlTransaction _transaction;
        protected bool _ownsConnection = true;
        protected int _recordsAffected = -1;
        protected System.Int32 _returnValue;
        protected int? _sPAutoId;
        protected string _sPName;
        protected string _sPAddress;
        protected string _sPPosition;
        protected string _sPEmail;
        protected string _sPFaxNo;
        protected string _sPPhoneNo;
        protected string _comments;

        #endregion

        #region Constructors

        public UpdateCBSalesPerson()
        {
        }

        public UpdateCBSalesPerson(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public UpdateCBSalesPerson(SqlConnection connection)
        {
            this.Connection = connection;
        }

        public UpdateCBSalesPerson(SqlConnection connection, SqlTransaction transaction)
        {
            this.Connection = connection;
            this.Transaction = transaction;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The connection string to use when executing the usp_UpdateCBSalesPerson stored procedure.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// The connection to use when executing the usp_UpdateCBSalesPerson stored procedure.
        /// If this is not null, it will be used instead of creating a new connection.
        /// </summary>
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        /// <summary>
        /// The transaction to use when executing the usp_UpdateCBSalesPerson stored procedure.
        /// If this is not null, the stored procedure will be executing within the transaction.
        /// </summary>
        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        /// <summary>
        /// Gets the return value from the usp_UpdateCBSalesPerson stored procedure.
        /// </summary>
        public System.Int32 ReturnValue
        {
            get { return _returnValue; }
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the usp_UpdateCBSalesPerson stored procedure.
        /// </summary>
        public int RecordsAffected
        {
            get { return _recordsAffected; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? SPAutoId
        {
            get { return _sPAutoId; }
            set
            {
                _sPAutoId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPName
        {
            get { return _sPName; }
            set
            {
                _sPName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPAddress
        {
            get { return _sPAddress; }
            set
            {
                _sPAddress = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPPosition
        {
            get { return _sPPosition; }
            set
            {
                _sPPosition = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPEmail
        {
            get { return _sPEmail; }
            set
            {
                _sPEmail = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPFaxNo
        {
            get { return _sPFaxNo; }
            set
            {
                _sPFaxNo = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SPPhoneNo
        {
            get { return _sPPhoneNo; }
            set
            {
                _sPPhoneNo = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Comments
        {
            get { return _comments; }
            set
            {
                _comments = value;
            }
        }

        #endregion

        #region Helper Methods

        private SqlConnection GetConnection()
        {
            if (this.Connection != null)
            {
                _ownsConnection = false;
                return this.Connection;
            }

            System.Diagnostics.Debug.Assert(this.ConnectionString.Length != 0, "You must first set the ConnectioString property before calling an Execute method.");
            return new SqlConnection(this.ConnectionString);
        }

        #endregion

        #region Execute Methods

        /// <summary>
        /// This method calls the usp_UpdateCBSalesPerson stored procedure.
        /// </summary>
        public virtual void Execute()
        {
            SqlCommand cmd = new SqlCommand();

            SqlConnection cn = this.GetConnection();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = this.Transaction;
                cmd.CommandText = "[dbo].[usp_UpdateCBSalesPerson]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region Populate Parameters
                SqlParameter prmReturnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                prmReturnValue.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmSPAutoId = cmd.Parameters.Add("@SPAutoId", SqlDbType.Int);
                prmSPAutoId.Direction = ParameterDirection.Input;
                if (SPAutoId.HasValue)
                    prmSPAutoId.Value = SPAutoId.Value;
                else
                    prmSPAutoId.Value = DBNull.Value;


                SqlParameter prmSPName = cmd.Parameters.Add("@SPName", SqlDbType.NVarChar);
                prmSPName.Direction = ParameterDirection.Input;
                prmSPName.Size = 200;
                if (!string.IsNullOrEmpty(SPName))
                    prmSPName.Value = SPName;
                else
                    prmSPName.Value = DBNull.Value;


                SqlParameter prmSPAddress = cmd.Parameters.Add("@SPAddress", SqlDbType.NVarChar);
                prmSPAddress.Direction = ParameterDirection.Input;
                prmSPAddress.Size = 500;
                if (!string.IsNullOrEmpty(SPAddress))
                    prmSPAddress.Value = SPAddress;
                else
                    prmSPAddress.Value = DBNull.Value;


                SqlParameter prmSPPosition = cmd.Parameters.Add("@SPPosition", SqlDbType.NVarChar);
                prmSPPosition.Direction = ParameterDirection.Input;
                prmSPPosition.Size = 200;
                if (!string.IsNullOrEmpty(SPPosition))
                    prmSPPosition.Value = SPPosition;
                else
                    prmSPPosition.Value = DBNull.Value;


                SqlParameter prmSPEmail = cmd.Parameters.Add("@SPEmail", SqlDbType.NVarChar);
                prmSPEmail.Direction = ParameterDirection.Input;
                prmSPEmail.Size = 200;
                if (!string.IsNullOrEmpty(SPEmail))
                    prmSPEmail.Value = SPEmail;
                else
                    prmSPEmail.Value = DBNull.Value;


                SqlParameter prmSPFaxNo = cmd.Parameters.Add("@SPFaxNo", SqlDbType.NVarChar);
                prmSPFaxNo.Direction = ParameterDirection.Input;
                prmSPFaxNo.Size = 200;
                if (!string.IsNullOrEmpty(SPFaxNo))
                    prmSPFaxNo.Value = SPFaxNo;
                else
                    prmSPFaxNo.Value = DBNull.Value;


                SqlParameter prmSPPhoneNo = cmd.Parameters.Add("@SPPhoneNo", SqlDbType.NVarChar);
                prmSPPhoneNo.Direction = ParameterDirection.Input;
                prmSPPhoneNo.Size = 200;
                if (!string.IsNullOrEmpty(SPPhoneNo))
                    prmSPPhoneNo.Value = SPPhoneNo;
                else
                    prmSPPhoneNo.Value = DBNull.Value;


                SqlParameter prmComments = cmd.Parameters.Add("@Comments", SqlDbType.NVarChar);
                prmComments.Direction = ParameterDirection.Input;
                prmComments.Size = 200;
                if (!string.IsNullOrEmpty(Comments))
                    prmComments.Value = Comments;
                else
                    prmComments.Value = DBNull.Value;

                #endregion

                #region Execute Command
                if (cn.State != ConnectionState.Open) cn.Open();
                _recordsAffected = cmd.ExecuteNonQuery();
                #endregion

                #region Get Output Parameters
                if (prmReturnValue.Value != null && prmReturnValue.Value != DBNull.Value)
                {
                    _returnValue = (System.Int32)prmReturnValue.Value;
                }

                #endregion
            }
            finally
            {
                if (_ownsConnection)
                {
                    if (cn.State == ConnectionState.Open)
                    {
                        cn.Close();
                    }

                    cn.Dispose();
                }
                cmd.Dispose();
            }
        }

        /// <summary>
        /// This method calls the usp_UpdateCBSalesPerson stored procedure.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="sPAutoId"></param>
        /// <param name="sPName"></param>
        /// <param name="sPAddress"></param>
        /// <param name="sPPosition"></param>
        /// <param name="sPEmail"></param>
        /// <param name="sPFaxNo"></param>
        /// <param name="sPPhoneNo"></param>
        /// <param name="comments"></param>
        public static void Execute(
        #region Parameters
                string connectionString,
                int? sPAutoId,
                string sPName,
                string sPAddress,
                string sPPosition,
                string sPEmail,
                string sPFaxNo,
                string sPPhoneNo,
                string comments
        #endregion
            )
        {
            UpdateCBSalesPerson updateCBSalesPerson = new UpdateCBSalesPerson();

            #region Assign Property Values
            updateCBSalesPerson.ConnectionString = connectionString;
            updateCBSalesPerson.SPAutoId = sPAutoId;
            updateCBSalesPerson.SPName = sPName;
            updateCBSalesPerson.SPAddress = sPAddress;
            updateCBSalesPerson.SPPosition = sPPosition;
            updateCBSalesPerson.SPEmail = sPEmail;
            updateCBSalesPerson.SPFaxNo = sPFaxNo;
            updateCBSalesPerson.SPPhoneNo = sPPhoneNo;
            updateCBSalesPerson.Comments = comments;
            #endregion

            updateCBSalesPerson.Execute();

            #region Get Property Values

            #endregion
        }
        #endregion
    }
    #endregion
}

