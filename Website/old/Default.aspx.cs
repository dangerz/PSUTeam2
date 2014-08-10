﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Team2.PSU.Wireless.Mesh.Util.MapUtils;
using Team2.PSU.Wireless.Mesh.Commands;
public partial class _Default : System.Web.UI.Page
{

    public double planeLongitude;
    public double planeLatitude;
    public double planeAltitude;
    public double quadLongitude;
    public double quadLatitude;
    public double quadAltitude;
    
    private static string locationSP = "WIRELESS_MESH_GET_LATEST_GPS_AUDIT";
    private static string connectionString = "Data Source=L117\\SQLEXPRESS;Initial Catalog=Team2PSU;Trusted_Connection=True;";    

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.Print("Loading Page");
        planeLatitude = -38.397;
        planeLongitude = 140.644;
        quadLatitude = -31.442;
        quadLongitude = 133.999;       
       
    }

    [System.Web.Services.WebMethod]
    public static double GetPlaneLatitude()
    {
        return -40.364;
    }
    [System.Web.Services.WebMethod]
    
    public static string GetUpdatedLocationData()
    {
        DataSet ds = FillDataset(locationSP, getParams());
        UpdateLocationCmd lc = new UpdateLocationCmd(ds.Tables[0].Rows[0]["TextMessage"].ToString());
        return lc.GetGeoLocation().GetLatitude().ToString() + "," + lc.GetGeoLocation().GetLongitude().ToString() + "," + "0";
    }
    
    public static DataSet FillDataset(string spName, List<SqlParameter> sqlParamList)
    {
        DataSet dsData = new DataSet();
        
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

    private static List<SqlParameter> getParams()
    {
        List<SqlParameter> sqlParams = new List<SqlParameter>();
        sqlParams.Add(new SqlParameter("@pin_Node", "pl1"));
        return sqlParams;
    }


}