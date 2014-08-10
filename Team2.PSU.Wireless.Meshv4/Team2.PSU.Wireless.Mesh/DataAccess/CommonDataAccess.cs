using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Team2.PSU.Wireless.Mesh.Properties;

namespace Team2.PSU.Wireless.Mesh.DataAccess
{
    public class CommonDataAccess
    {
        #region Constants
        private Settings settings = Settings.Default;
            
        #endregion

        #region Execute Non Query

        ///----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to execute Store Procedure with input parameters  
        /// </summary>
        /// <param name="spName">Store Procedure Name</param>
        /// <param name="sqlParamList">Sql Parameter Collection List</param>
        /// <returns>Returns integer against Execution</returns>
        ///----------------------------------------------------------------------------------------------------------
        ///
        public int ExecuteNonQuery(string spName, List<SqlParameter> sqlParamList)
        {
            string connectionString = GetConnectionString();
            SqlDatabase dbConn = new SqlDatabase(connectionString);
            DbCommand dbCommand = dbConn.GetSqlStringCommand(spName);
            int returnValue = -1;
            try
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter sqlParam in sqlParamList)
                {
                    dbConn.AddInParameter(dbCommand, sqlParam.ParameterName, sqlParam.SqlDbType, sqlParam.Value);
                }
                returnValue = dbConn.ExecuteNonQuery(dbCommand);
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                dbConn = null;
                dbCommand = null;
            }
            return returnValue;
        }
        #endregion

        #region FillDataset
        ///----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Method To Fill Dataset with paramters
        /// </summary>
        /// <param name="spName">Stored Procedure Name</param>
        /// <param name="sqlParamList">List of parameter to be passd Stored Procedure</param>
        /// <returns>Returns a Dataset</returns> 
        ///----------------------------------------------------------------------------------------------------------
        public DataSet FillDataset(string spName, List<SqlParameter> sqlParamList)
        {
            DataSet dsData = new DataSet();
            string connectionString = GetConnectionString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(spName);
            SqlDataAdapter da = null;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                foreach (SqlParameter sqlParam in sqlParamList)
                {
                    cmd.Parameters.Add(sqlParam);
                }
                da = new SqlDataAdapter(cmd);
                da.Fill(dsData);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Dispose();
                conn = null;

                da.Dispose();
                da = null;

            }
            return dsData;
        }

        public DataSet FillDataset(string spName)
        {
            DataSet dsData = new DataSet();
            string connectionString = GetConnectionString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(spName);
            SqlDataAdapter da = null;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = conn;
                da = new SqlDataAdapter(cmd);
                da.Fill(dsData);
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Dispose();
                conn = null;

                da.Dispose();
                da = null;

            }
            return dsData;
        }
        #endregion

        #region GetConnectionString

        /// -----------------------------------------------------------------------------------------------------------
        /// <summary>
        ///Gets the connection string from the udtinventory site collection
        /// </summary>
        /// <param name="connectionValue">String Value</param>
        /// <returns>string</returns>
        ///  -----------------------------------------------------------------------------------------------------------
        public string GetConnectionString()
        {
            string connectionString= settings.ConnectionString;
            return connectionString;
        }

        #endregion

        #region AddSql Input Parameter
        ///----------------------------------------------------------------------------------------------------------
        /// <summary>
        ///  Add Parameter Name, Sql DB Type and Parameter Value to SqlParameter Object
        /// </summary>
        /// <param name="paramName">Parameter Name</param>
        /// <param name="dbType">Sql DB Type</param>
        /// <param name="paramValue">Parameter Value</param>
        /// <returns>Returns Sql Parameter</returns>
        ///----------------------------------------------------------------------------------------------------------
        ///
        public SqlParameter AddSqlParameter(string paramName, SqlDbType dbType, object paramValue)
        {
            SqlParameter sqlParam = new SqlParameter();

            sqlParam.ParameterName = paramName;
            sqlParam.SqlDbType = dbType;
            sqlParam.SqlValue = paramValue;

            return sqlParam;
        }
        #endregion



    }
}
