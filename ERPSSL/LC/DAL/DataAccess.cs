using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL
{
    public class DataAccess
    {

        private static SqlTransaction tran;
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;


        public object AggRetrive(string Command, string ConnectionString)
        {
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();

            object obj = new object();
            try
            {
                con.Open();
                cmd = new SqlCommand(Command.Trim(), con);
                obj = cmd.ExecuteScalar();

                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return obj;
        }


        //public static long InsertData(Hashtable htable, string procedureName)
        //{
        //    con = new SqlConnection(ConnectionString);
        //    cmd = new SqlCommand();

        //    long retID = 0;
        //    try
        //    {
        //        if (con.State != ConnectionState.Open)
        //        {
        //            con = new SqlConnection(ConnectionString);
        //            con.Open();
        //        }
        //        cmd.Connection = con;
        //        cmd.CommandText = procedureName;
        //        cmd.CommandType = CommandType.StoredProcedure;

        //        foreach (object OBJ in htable.Keys)
        //        {
        //            string COLUMN_NAME = Convert.ToString(OBJ);
        //            SqlParameter param = new SqlParameter("@" + COLUMN_NAME, htable[OBJ]);
        //            cmd.Parameters.Add(param);
        //        }

        //        cmd.ExecuteNonQuery();
        //        retID = 1;
        //        cmd.Parameters.Clear();
        //    }
        //    catch (SqlException ex)
        //    {
        //        if (tran != null)
        //        {
        //            tran.Rollback();
        //            tran = null;
        //        }
        //        con.Close();
        //        throw ex;

        //    }
        //    catch (Exception ex)
        //    {
        //        if (tran != null)
        //        {
        //            tran.Rollback();
        //            tran = null;
        //            con.Close();
        //            throw ex;
        //        }
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return retID;
        //}

    }
}