using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using System.Configuration;

namespace ERPSSL.INV.DAL
{
    public class DataAccessEX
    {
        private SqlTransaction tran;
        private static SqlConnection con;
        private static SqlCommand cmd;
        private static string ConnectionString = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;

        //public DataAccessEX()
        //{
        //}

        public long InsertData(Hashtable htable, string procedureName, string ConnectionString)
        {
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();

            long retID = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = procedureName;
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (object OBJ in htable.Keys)
                {
                    string COLUMN_NAME = Convert.ToString(OBJ);
                    SqlParameter param = new SqlParameter("@" + COLUMN_NAME, htable[OBJ]);
                    cmd.Parameters.Add(param);
                }

                cmd.ExecuteNonQuery();
                retID = 1;
                cmd.Parameters.Clear();
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                con.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    con.Close();
                    throw ex;
                }
            }
            finally
            {
                con.Close();
            }
            return retID;
        }

        public DataTable GetDataByProc(Hashtable ht, string SProc, string ConnectionString)
        {

            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();


            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = SProc;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (object obj in ht.Keys)
                {
                    string ColumnName = Convert.ToString(obj);
                    SqlParameter param = new SqlParameter(ColumnName, ht[obj]);
                    cmd.Parameters.Add(param);
                }
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Table1");
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        public DataSet GetDataSetByProc(Hashtable ht, string SProc, string ConnectionString)
        {

            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();


            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = SProc;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (object obj in ht.Keys)
                {
                    string ColumnName = Convert.ToString(obj);
                    SqlParameter param = new SqlParameter(ColumnName, ht[obj]);
                    cmd.Parameters.Add(param);
                }
                adp.SelectCommand = cmd;
                adp.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds;
        }
        public DataTable GetDataByProc(string SProc, string ConnectionString)
        {


            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();


            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = SProc;
                cmd.CommandType = CommandType.StoredProcedure;
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Table1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

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

        public static DataTable GetDataBySQLString(Hashtable htable, string QueryString)
        {
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();
            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = QueryString;
                cmd.CommandType = CommandType.Text;
                foreach (object obj in htable.Keys)
                {
                    string ColumnName = Convert.ToString(obj);
                    SqlParameter param = new SqlParameter(ColumnName, htable[obj]);
                    cmd.Parameters.Add(param);
                }
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Table1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }

        public DataTable GetDataBySQLString(string SQLString, string ConnectionString)
        {

            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();

            DataSet ds = new DataSet();
            SqlDataAdapter adp = new SqlDataAdapter();
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = SQLString;
                cmd.CommandType = CommandType.Text;
                adp.SelectCommand = cmd;
                adp.Fill(ds, "Table1");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return ds.Tables[0];
        }
        public long ExecuteCommand(Hashtable htable, string procedureName, string ConnectionString)
        {



            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();


            long retID = 0;
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con = new SqlConnection(ConnectionString);
                    con.Open();
                }
                cmd.Connection = con;
                cmd.CommandText = procedureName;
                // cmd.Transaction = tran;   
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (object OBJ in htable.Keys)
                {
                    string COLUMN_NAME = Convert.ToString(OBJ);
                    SqlParameter param = new SqlParameter("@" + COLUMN_NAME, htable[OBJ]);
                    cmd.Parameters.Add(param);
                }
                cmd.ExecuteNonQuery();
                retID = 1;
                cmd.Parameters.Clear();
                if (tran == null)
                {
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                }
                con.Close();
                throw ex;

            }
            catch (Exception ex)
            {
                if (tran != null)
                {
                    tran.Rollback();
                    tran = null;
                    con.Close();
                    throw ex;
                }

            }
            finally
            {
                con.Close();
            }

            return retID;
        }
        public void beginTransaction(string ConnectionString)
        {
            con = new SqlConnection(ConnectionString);
            cmd = new SqlCommand();


            if (con.State != ConnectionState.Open)
            {
                con = new SqlConnection(ConnectionString);
                con.Open();
            }
            if (tran == null)
            {
                cmd = con.CreateCommand();
                tran = con.BeginTransaction(ConnectionString);
                cmd.Transaction = tran;
            }
        }
        public void commitTransaction()
        {
            if (tran != null)
            {
                tran.Commit();
                tran = null;
            }
            else
            {
                tran.Rollback();


            }
        }



    }
}
