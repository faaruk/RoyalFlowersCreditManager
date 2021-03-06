﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by CodeSmith.
//
//     Date:    5/30/2012
//     Time:    11:06 PM
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
    #region usp_Select_AllUsers Wrapper
    /// <summary>
    /// This class is a wrapper for the usp_Select_AllUsers stored procedure.
    /// </summary>
    public class SelectAllUsers
    {
        #region Member Variables
        protected string _connectionString = String.Empty;
        protected SqlConnection _connection = null;
        protected SqlTransaction _transaction = null;
        protected bool _ownsConnection = true;
        protected int _recordsAffected = -1;
        protected int _returnValue = 0;
        protected SqlString _companyID = SqlString.Null;
        protected bool _companyIDSet = false;
        protected SqlString _wherecondition = SqlString.Null;
        protected bool _whereconditionSet = false;
        protected SqlString _orderByExpression = SqlString.Null;
        protected bool _orderByExpressionSet = false;
        #endregion

        #region Constructors
        public SelectAllUsers()
        {
        }

        public SelectAllUsers(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SelectAllUsers(SqlConnection connection)
        {
            this.Connection = connection;
        }

        public SelectAllUsers(SqlConnection connection, SqlTransaction transaction)
        {
            this.Connection = connection;
            this.Transaction = transaction;
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// The connection string to use when executing the usp_Select_AllUsers stored procedure.
        /// </summary>
        public string ConnectionString
        {
            get { return _connectionString; }
            set { _connectionString = value; }
        }

        /// <summary>
        /// The connection to use when executing the usp_Select_AllUsers stored procedure.
        /// If this is not null, it will be used instead of creating a new connection.
        /// </summary>
        public SqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        /// <summary>
        /// The transaction to use when executing the usp_Select_AllUsers stored procedure.
        /// If this is not null, the stored procedure will be executing within the transaction.
        /// </summary>
        public SqlTransaction Transaction
        {
            get { return _transaction; }
            set { _transaction = value; }
        }

        /// <summary>
        /// Gets the return value from the usp_Select_AllUsers stored procedure.
        /// </summary>
        public int ReturnValue
        {
            get { return _returnValue; }
        }

        /// <summary>
        /// Gets the number of rows changed, inserted, or deleted by execution of the usp_Select_AllUsers stored procedure.
        /// </summary>
        public int RecordsAffected
        {
            get { return _recordsAffected; }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString CompanyID
        {
            get { return _companyID; }
            set
            {
                _companyID = value;
                _companyIDSet = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString wherecondition
        {
            get { return _wherecondition; }
            set
            {
                _wherecondition = value;
                _whereconditionSet = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public SqlString OrderByExpression
        {
            get { return _orderByExpression; }
            set
            {
                _orderByExpression = value;
                _orderByExpressionSet = true;
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
        /// This method calls the usp_Select_AllUsers stored procedure and returns a SqlDataReader with the results.
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
                cmd.CommandText = "[dbo].[usp_Select_AllUsers]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region Populate Parameters
                SqlParameter prmReturnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                prmReturnValue.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmCompanyID = cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar);
                prmCompanyID.Direction = ParameterDirection.Input;
                prmCompanyID.Size = 10;
                if (_companyIDSet == true || this.CompanyID.IsNull == false)
                {
                    prmCompanyID.Value = this.CompanyID;
                }

                SqlParameter prmwherecondition = cmd.Parameters.Add("@wherecondition", SqlDbType.NVarChar);
                prmwherecondition.Direction = ParameterDirection.Input;
                prmwherecondition.Size = 500;
                if (_whereconditionSet == true || this.wherecondition.IsNull == false)
                {
                    prmwherecondition.Value = this.wherecondition;
                }

                SqlParameter prmOrderByExpression = cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar);
                prmOrderByExpression.Direction = ParameterDirection.Input;
                prmOrderByExpression.Size = 250;
                if (_orderByExpressionSet == true || this.OrderByExpression.IsNull == false)
                {
                    prmOrderByExpression.Value = this.OrderByExpression;
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
        /// This method calls the usp_Select_AllUsers stored procedure and returns a DataSet with the results.
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
                cmd.CommandText = "[dbo].[usp_Select_AllUsers]";
                cmd.CommandType = CommandType.StoredProcedure;

                #region Populate Parameters
                SqlParameter prmReturnValue = cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
                prmReturnValue.Direction = ParameterDirection.ReturnValue;

                SqlParameter prmCompanyID = cmd.Parameters.Add("@CompanyID", SqlDbType.VarChar);
                prmCompanyID.Direction = ParameterDirection.Input;
                prmCompanyID.Size = 10;
                if (_companyIDSet == true || this.CompanyID.IsNull == false)
                {
                    prmCompanyID.Value = this.CompanyID;
                }

                SqlParameter prmwherecondition = cmd.Parameters.Add("@wherecondition", SqlDbType.NVarChar);
                prmwherecondition.Direction = ParameterDirection.Input;
                prmwherecondition.Size = 500;
                if (_whereconditionSet == true || this.wherecondition.IsNull == false)
                {
                    prmwherecondition.Value = this.wherecondition;
                }

                SqlParameter prmOrderByExpression = cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar);
                prmOrderByExpression.Direction = ParameterDirection.Input;
                prmOrderByExpression.Size = 250;
                if (_orderByExpressionSet == true || this.OrderByExpression.IsNull == false)
                {
                    prmOrderByExpression.Value = this.OrderByExpression;
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
        /// This method calls the usp_Select_AllUsers stored procedure and returns a SqlDataReader with the results.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="companyID"></param>
        /// <param name="wherecondition"></param>
        /// <param name="orderByExpression"></param>
        /// <returns>SqlDataReader</returns>
        

        /// <summary>
        /// This method calls the usp_Select_AllUsers stored procedure and returns a DataSet with the results.
        /// </summary>
        /// <param name="connectionString">The connection string to use</param>
        /// <param name="companyID"></param>
        /// <param name="wherecondition"></param>
        /// <param name="orderByExpression"></param>
        /// <returns>DataSet</returns>
        public static DataSet ExecuteDataSet(
        #region Parameters
string connectionString,
                SqlString companyID,
                SqlString wherecondition,
                SqlString orderByExpression
        #endregion
)
        {
            SelectAllUsers selectAllUsers = new SelectAllUsers();

            #region Assign Property Values
            selectAllUsers.ConnectionString = connectionString;
            selectAllUsers.CompanyID = companyID;
            selectAllUsers.wherecondition = wherecondition;
            selectAllUsers.OrderByExpression = orderByExpression;
            #endregion

            DataSet ds = selectAllUsers.ExecuteDataSet();

            #region Get Property Values

            #endregion

            return ds;
        }

        #endregion
    }
    #endregion
}
