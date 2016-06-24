﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by CodeSmith.
//
//     Date:    10/7/2010
//     Time:    3:25 PM
//     Version: 5.0.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;

namespace Blumen
{
    #region usp_dashboard Wrapper
    /// <summary>
    /// This class is a wrapper for the usp_dashboard stored procedure.
    /// </summary>
    public class dashboard
    {
        #region Member Variables
        protected string _connectionString = String.Empty;
        protected SqlConnection _connection = null;
        protected SqlTransaction _transaction = null;
        protected bool _ownsConnection = true;
        protected int _recordsAffected = -1;
        protected int _returnValue = 0;
        protected SqlString _whereConditionID = SqlString.Null;
        protected bool _whereConditionIDSet = false;
        protected SqlString _company_id = SqlString.Null;
        protected bool _company_idSet = false;
        protected SqlDateTime _cOMP_VOUCHER_DATE = SqlDateTime.Null;
        protected bool _cOMP_VOUCHER_DATESet = false;
        #endregion

        #region Constructors
        public dashboard()
        {
        }

        public dashboard(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public dashboard(SqlConnection connection)
        {
            this.Connection = connection;
        }

        public dashboard(SqlConnection connection, SqlTransaction transaction)
        {
            this.Connection = connection;
            this.Transaction = transaction;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The connection string to use when executing the usp_dashboard stored procedure.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// The connection to use when executing the usp_dashboard stored procedure.
        /// If this is not null, it will be used instead of creating a new connection.
        /// </summary>
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        /// <summary>
        /// The transaction to use when executing the usp_dashboard stored procedure.
        /// If this is not null, the stored procedure will be executing within the transaction.
        /// </summary>
        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        /// <summary>
        /// Gets the return value from the usp_dashboard stored procedure.
        /// </summary>
        public int ReturnValue
        {
            get { return _returnValue; }
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the usp_dashboard stored procedure.
        /// </summary>
        public int RecordsAffected
        {
            get { return _recordsAffected; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString whereConditionID
        {
            get { return _whereConditionID; }
            set
            {
                _whereConditionID = value;
                _whereConditionIDSet = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString company_id
        {
            get { return _company_id; }
            set
            {
                _company_id = value;
                _company_idSet = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlDateTime COMP_VOUCHER_DATE
        {
            get { return _cOMP_VOUCHER_DATE; }
            set
            {
                _cOMP_VOUCHER_DATE = value;
                _cOMP_VOUCHER_DATESet = true;
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
            else
            {
                System.Diagnostics.Debug.Assert(this.ConnectionString.Length != 0, "You must first set the ConnectioString property before calling an Execute method.");
                return new SqlConnection(this.ConnectionString);
            }
        }
        #endregion

        #region Execute Methods
        /// <summary>
        /// This method calls the usp_dashboard stored procedure and returns a SqlDataReader with the results.
        /// </summary>
        /// <returns>SqlDataReader</returns>
        public virtual SqlDataReader Execute()
        {
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand();
            SqlConnection cn = this.GetConnection();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = this.Transaction;
                cmd.CommandText = "[dbo].[usp_dashboard]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region Populate Parameters
                SqlParameter prmReturnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                prmReturnValue.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmCOMP_VOUCHER_DATE = cmd.Parameters.Add("@COMP_VOUCHER_DATE", SqlDbType.DateTime);
                prmCOMP_VOUCHER_DATE.Direction = ParameterDirection.Input;
                if (_cOMP_VOUCHER_DATESet == true || this.COMP_VOUCHER_DATE.IsNull == false)
                {
                    prmCOMP_VOUCHER_DATE.Value = this.COMP_VOUCHER_DATE;
                }


                SqlParameter prmwhereConditionID = cmd.Parameters.Add("@whereConditionID", SqlDbType.VarChar);
                prmwhereConditionID.Direction = ParameterDirection.Input;
                prmwhereConditionID.Size = 300;
                if (_whereConditionIDSet == true || this.whereConditionID.IsNull == false)
                {
                    prmwhereConditionID.Value = this.whereConditionID;
                }

                SqlParameter prmcompany_id = cmd.Parameters.Add("@company_id", SqlDbType.Char);
                prmcompany_id.Direction = ParameterDirection.Input;
                prmcompany_id.Size = 4;
                if (_company_idSet == true || this.company_id.IsNull == false)
                {
                    prmcompany_id.Value = this.company_id;
                }
                #endregion

                #region Execute Command
                if (cn.State != ConnectionState.Open) cn.Open();
                if (_ownsConnection)
                {
                    reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    reader = cmd.ExecuteReader();
                }
                #endregion

                #region Get Output Parameters
                if (prmReturnValue.Value != null && prmReturnValue.Value != DBNull.Value)
                {
                    _returnValue = (int)prmReturnValue.Value;
                }

                #endregion
            }
            finally
            {
                cmd.Dispose();
            }

            return reader;
        }

        /// <summary>
        /// This method calls the usp_dashboard stored procedure and returns a DataSet with the results.
        /// </summary>
        /// <returns>DataSet</returns>
        public virtual DataSet ExecuteDataSet()
        {
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            SqlConnection cn = this.GetConnection();

            try
            {
                cmd.Connection = cn;
                cmd.Transaction = this.Transaction;
                cmd.CommandText = "[dbo].[usp_dashboard]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region Populate Parameters
                SqlParameter prmReturnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                prmReturnValue.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmwhereConditionID = cmd.Parameters.Add("@whereConditionID", SqlDbType.VarChar);
                prmwhereConditionID.Direction = ParameterDirection.Input;
                prmwhereConditionID.Size = 300;
                if (_whereConditionIDSet == true || this.whereConditionID.IsNull == false)
                {
                    prmwhereConditionID.Value = this.whereConditionID;
                }

                SqlParameter prmcompany_id = cmd.Parameters.Add("@company_id", SqlDbType.Char);
                prmcompany_id.Direction = ParameterDirection.Input;
                prmcompany_id.Size = 4;
                if (_company_idSet == true || this.company_id.IsNull == false)
                {
                    prmcompany_id.Value = this.company_id;
                }
                SqlParameter prmCOMP_VOUCHER_DATE = cmd.Parameters.Add("@COMP_VOUCHER_DATE", SqlDbType.DateTime);
                prmCOMP_VOUCHER_DATE.Direction = ParameterDirection.Input;
                if (_cOMP_VOUCHER_DATESet == true || this.COMP_VOUCHER_DATE.IsNull == false)
                {
                    prmCOMP_VOUCHER_DATE.Value = this.COMP_VOUCHER_DATE;
                }


                #endregion

                #region Execute Command
                if (cn.State != ConnectionState.Open) cn.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                _recordsAffected = ds.Tables[0].Rows.Count;
                #endregion

                #region Get Output Parameters
                if (prmReturnValue.Value != null && prmReturnValue.Value != DBNull.Value)
                {
                    _returnValue = (int)prmReturnValue.Value;
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

            return ds;
        }


        /// <summary>
        /// This method calls the usp_dashboard stored procedure and returns a SqlDataReader with the results.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="whereConditionID"></param>
        /// <param name="company_id"></param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader Execute(
        #region Parameters
string connectionString,
                SqlString whereConditionID,
                SqlString company_id,
                SqlDateTime COMP_VOUCHER_DATE
        #endregion
)
        {
            dashboard dashboard = new dashboard();

            #region Assign Property Values
            dashboard.ConnectionString = connectionString;
            dashboard.whereConditionID = whereConditionID;
            dashboard.company_id = company_id;
            dashboard.COMP_VOUCHER_DATE = COMP_VOUCHER_DATE;
            #endregion

            SqlDataReader reader = dashboard.ExecuteReader();

            #region Get Property Values

            #endregion

            return reader;
        }

        private static SqlDataReader ExecuteReader()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This method calls the usp_dashboard stored procedure and returns a DataSet with the results.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="whereConditionID"></param>
        /// <param name="company_id"></param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(
        #region Parameters
string connectionString,
                SqlString whereConditionID,
                SqlString company_id,
                SqlDateTime COMP_VOUCHER_DATE
        #endregion
)
        {
            dashboard dashboard = new dashboard();

            #region Assign Property Values
            dashboard.ConnectionString = connectionString;
            dashboard.whereConditionID = whereConditionID;
            dashboard.company_id = company_id;
            dashboard.COMP_VOUCHER_DATE = COMP_VOUCHER_DATE;
            #endregion

            DataSet ds = dashboard.ExecuteDataSet();

            #region Get Property Values

            #endregion

            return ds;
        }

        #endregion
    }
    #endregion
}