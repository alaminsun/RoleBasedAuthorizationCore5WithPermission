using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RoleBasedAuthorizationCore5.Services.Helpers;
using System.Data;

namespace RoleBasedAuthorizationCore5.Services.Helpers
{
    public class DBHelper
    {
        private readonly IConfiguration configuration;
        private readonly IDGenerated _iDGenerated;
        private readonly string _connectionString;
        public DBHelper(IConfiguration configuration, IDGenerated iDGenerated)
        {
            _iDGenerated = iDGenerated;
            this.configuration = configuration;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
            //DBConnection dbConnection = new DBConnection();
            //public DataTable GetDataTable(string Qry)
            //{
            //  DataTable dt = new DataTable();
            //  using (OracleConnection objConn = new OracleConnection(dbConnection.StringRead()))
            //  {
            //    OracleCommand objCmd = new OracleCommand();
            //    objCmd.CommandText = Qry;
            //    objCmd.Connection = objConn;       
            //    objConn.Open();
            //    objCmd.ExecuteNonQuery();

            //  using(OracleDataReader rdr = objCmd.ExecuteReader())
            //   { 
            //    if (rdr.HasRows)
            //    {
            //        dt.Load(rdr);               
            //    }
            //    }
            //  }          
            //   return dt;  
            //}

            //public Int64 CmdExecute(string Qry)
            //{
            //    Int64 noOfRows = 0;
            //    using (OracleConnection con = new OracleConnection(dbConnection.StringRead()))
            //    {
            //        OracleCommand cmd = new OracleCommand(Qry, con);
            //        con.Open();
            //        noOfRows= cmd.ExecuteNonQuery();
            //        con.Close();
            //    }
            //    return noOfRows;
            //}

            //public string GetValue(string QueryString)
            //{

            //    string conn = dbConnection.StringRead();
            //    string ID = "";         
            //    using (OracleConnection oracleConnection = new OracleConnection(dbConnection.StringRead()))
            //    {
            //        oracleConnection.Open();
            //        OracleCommand oracleCommand = new OracleCommand(QueryString, oracleConnection);
            //        using (OracleDataReader rdr = oracleCommand.ExecuteReader())
            //        {
            //            if (rdr.Read())
            //            {
            //                ID = rdr[0].ToString();
            //            }
            //        }
            //    }
            //    return ID;
            //}

            //public Tuple<Boolean, string> IsExistsWithGetValue(string Qry)
            //{
            //    string GetSL = ""; bool isTrue = false;

            //    DataTable dt = GetDataTable(Qry);
            //    if (dt.Rows.Count > 0)
            //    {
            //        isTrue = true;
            //        GetSL = dt.Rows[0][0].ToString();
            //    }
            //    return Tuple.Create(isTrue, GetSL);
            //}



        public DataTable GetDataTable(string Qry)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {

                SqlCommand objCmd = new SqlCommand();
                objCmd.CommandText = Qry;
                objCmd.Connection = connection;
                connection.Open();
                objCmd.ExecuteNonQuery();
                using (SqlDataReader rdr = objCmd.ExecuteReader())
                {
                    if (rdr.HasRows)
                    {
                        dt.Load(rdr);
                    }
                }

            }

            return dt;
        }

        //public DataTable GetDataTable(string Conn,string Qry)
        //{
        //    DataTable dt = new DataTable();
        //    using (OracleConnection objConn = new OracleConnection(Conn))
        //    {
        //        OracleCommand objCmd = new OracleCommand();
        //        objCmd.CommandText = Qry;
        //        objCmd.Connection = objConn;
        //        objConn.Open();
        //        objCmd.ExecuteNonQuery();

        //        using (OracleDataReader rdr = objCmd.ExecuteReader())
        //        {
        //            if (rdr.HasRows)
        //            {
        //                dt.Load(rdr);
        //            }
        //        }
        //    }
        //    return dt;
        //}
    }
}