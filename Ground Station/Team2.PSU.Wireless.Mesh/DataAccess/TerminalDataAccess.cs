using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team2.PSU.Wireless.Mesh.Model;
using System.Data.SqlClient;
using System.Data;

namespace Team2.PSU.Wireless.Mesh.DataAccess
{
    public class TerminalDataAccess
    {
        #region Variable Declaration
        private CommonDataAccess objCommonDataAccess = null;
        private List<SqlParameter> sqlParamList = null;
        const string ADD_AUDIT_SP_NAME = "WIRELESS_MESH_ADD_AUDIT";
        const string GET_AUDIT_RECORD_SP_NAME = "WIRELESS_MESH_GET_AUDIT";
        #endregion

        #region AddAuditEntry
        /// <summary>
        /// This method is used to add a record into Auditing table
        /// </summary>
        /// <param name="auditEntry"></param>
        /// <returns></returns>
        public int AddAuditEntry(AuditEntry auditEntry)
        {
            int result = -1;

            try
            {
                objCommonDataAccess = new CommonDataAccess();                
                sqlParamList = new List<SqlParameter>();                
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_BaudRate", SqlDbType.VarChar, auditEntry.BaudRate));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_ComPort", SqlDbType.VarChar, auditEntry.ComPort));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_DataBits", SqlDbType.VarChar, auditEntry.DataBits));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_DataDirection", SqlDbType.VarChar, auditEntry.DataDirection));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_Parity", SqlDbType.VarChar, auditEntry.Parity));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_StopBits", SqlDbType.VarChar, auditEntry.StopBits));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_TextMessage", SqlDbType.VarChar, auditEntry.TextMessage));
                sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_CommandDateTime", SqlDbType.DateTime, System.DateTime.Now));

                result = objCommonDataAccess.ExecuteNonQuery(ADD_AUDIT_SP_NAME, sqlParamList);
            }
            catch (Exception ex)
            {
                //Do not throw since return value will be -1;
            }
            return result;
        }
        #endregion


        public DataSet GetAuditRecords(AuditEntry auditEntry)
        {
            objCommonDataAccess = new CommonDataAccess();                        
            DataSet dsUDT = null;
            try
            {
                objCommonDataAccess = new CommonDataAccess();
                sqlParamList = new List<SqlParameter>();
                //sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_ComPort", SqlDbType.VarChar, auditEntry.ComPort));
                //sqlParamList.Add(objCommonDataAccess.AddSqlParameter("@pin_DataDirection", SqlDbType.VarChar, auditEntry.DataDirection));
                //dsUDT = objCommonDataAccess.FillDataset(GET_AUDIT_RECORD_SP_NAME,sqlParamList);
                dsUDT = objCommonDataAccess.FillDataset(GET_AUDIT_RECORD_SP_NAME);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
            finally
            {
                objCommonDataAccess = null;                
            }
            return dsUDT;
        }
    }
}

