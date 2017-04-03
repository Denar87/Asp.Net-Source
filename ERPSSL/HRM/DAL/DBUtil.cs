using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL
{
    public class DBUtil
    {
        #region DBUtil.Constants

        public static readonly string gsrSaveInFile = "FILE";
        public static readonly string gsrSaveInMDB = "MDB";


        //the Name of the DataBase Setting MDB File Access 2000 version
        public static readonly string gsrDBSettingsFileName = "SysInfoNet.mdb";

        //name of the File Persisted for Database Settings.
        public static readonly string gsrDBPersitDBSettingFileName = "DBSettings.sys";


        public static readonly string gsrtblSERVERDETAIL = "SERVERDETAIL";

        public static readonly string gsrfldCONCODE = "CONCODE";
        public static readonly string gsrfldCONNAME = "CONNAME";
        public static readonly string gsrfldSERVERTYPE = "SERVERTYPE";
        public static readonly string gsrfldSERVER_NAME = "SERVER_NAME";
        public static readonly string gsrfldDATABASE_NAME = "DATABASE_NAME";


        public static readonly string gsrtblAppDetails = "AppDetails";

        public static readonly string gsrfldCOMPANY_ID = "COMPANY_ID";
        public static readonly string gsrfldCOMPANY_NAME = "COMPANY_NAME";
        public static readonly string gsrfldVALID_UPTO = "VALID_UPTO";

        #endregion

        # region ConnectionLib variables

        public enum eConnectionLib : short { SQlClient, Oledb, ODBC, OracleClient, OledbMSSQL, OledbOracle, OledbMSAcess2000 };

        public static readonly string[] aryConnectionLib = { "SQlClient", "Oledb", "ODBC", "OracleClient", "OledbMSSQL", "OledbOracle", "OledbMSAcess2000" };

        public static readonly Hashtable htConnectionLib;

        #endregion


        // constructor
        static DBUtil()
        {
            //
            // TODO: Add constructor logic here
            //
            htConnectionLib = new Hashtable(CaseInsensitiveHashCodeProvider.Default, CaseInsensitiveComparer.Default);
            htConnectionLib.Add("SQlClient", 0);
            htConnectionLib.Add("Oledb", 1);
            htConnectionLib.Add("ODBC", 2);
            htConnectionLib.Add("OracleClient", 3);
            htConnectionLib.Add("OledbMSSQL", 4);
            htConnectionLib.Add("OledbOracle", 5);
            htConnectionLib.Add("OledbMSAcess2000", 6);
        } // End of function

        #region DBUtil functions
        public static bool IsNumeric(string strNumber)
        {
            Double d;

            NumberFormatInfo n = new NumberFormatInfo();

            if (strNumber.Length == 0)
            {
                return false;
            }
            return Double.TryParse(strNumber, System.Globalization.NumberStyles.Float, n, out d);
        }
        public string TextWithSingleCode(string FullText)
        {
            try
            {
                string TotalText = string.Empty;
                string fullItem = string.Empty;

                FullText = FullText.Trim();
                if (FullText.Contains(","))
                {
                    string[] TextArray = FullText.Split(',');

                    foreach (string item in TextArray)
                    {
                        fullItem = fullItem + "'" + item + "',";
                    }
                    TotalText = fullItem.TrimEnd(',');

                }
                else
                {
                    TotalText = "'" + FullText + "'";
                }

                return TotalText;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }


        }
        #endregion
    }
}