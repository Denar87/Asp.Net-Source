﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using ERPSSL.INV.DAL;

namespace HRMApp.HRM
{
    /// <summary>
    /// Summary description for CompanyLogo
    /// </summary>
    public class CompanyLogo : IHttpHandler
    {
        //private HRM_Entities _context = new HRM_Entities();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        public void ProcessRequest(HttpContext context)
        {
            string CID = Convert.ToString(context.Request.QueryString["pId"]);
            string OCODE = Convert.ToString(context.Request.QueryString["oCode"]);

            string ConnectionString = (_context.Connection as EntityConnection).StoreConnection.ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(ConnectionString);
            builder.ConnectTimeout = 2500;

            SqlConnection Conn = new SqlConnection(builder.ConnectionString);
            System.Data.Common.DbDataReader sqlReader;
            Conn.Open();

            SqlCommand cmd = new SqlCommand("INV_GET_Company_Logo", Conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@OCODE", SqlDbType.NVarChar).Value = OCODE;
            cmd.Parameters.Add("@CID", SqlDbType.NVarChar).Value = CID;
            cmd.CommandTimeout = 0;
            sqlReader = (System.Data.Common.DbDataReader)cmd.ExecuteReader();
            try
            {
                if (sqlReader.Read())
                {
                    byte[] imageByte = sqlReader["Logo"] as byte[] ?? null;

                    //byte[] imageByte = (byte[])sqlReader["EMP_PHOTO"];

                    System.Drawing.Image b;
                    Bitmap bitMap = null;

                    if (imageByte != null && imageByte.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            ms.Write(imageByte, 0, imageByte.Length);
                            b = System.Drawing.Image.FromStream(ms);
                            bitMap = new System.Drawing.Bitmap(b, b.Width, b.Height);

                            using (Graphics g = Graphics.FromImage(bitMap))
                            {
                                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                                g.SmoothingMode = SmoothingMode.AntiAlias;
                                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                                g.DrawImage(bitMap, 0, 0, b.Width, b.Height);
                                g.Dispose();
                                b.Dispose();
                                ms.Dispose();
                                context.Response.ContentType = "image/jpeg";
                                bitMap.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                bitMap.Dispose();
                            }
                        }
                    }
                    else
                    {
                        string imagePath = "../resources/no_image_found.png";
                        context.Response.ContentType = "image/jpeg";
                        context.Response.Write(imagePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conn.Close();
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}