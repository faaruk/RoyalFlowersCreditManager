
//******************************************
// Author : Faruk Ahmed
// Development Date : 30th of May 2012
// Module : User Authentication
//******************************************

using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Web;


namespace StringEncodeDecode
{
    public partial class UserAuthentication_PrmUserInfo : System.Web.UI.Page
    {
        string cnnString = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
        String path = HttpContext.Current.Request.PhysicalApplicationPath;
        private string strLoginUserID = null;
        private string myScript = "";
        private string strcompanyID = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Logout.aspx");
            }
            else
            {
                strcompanyID ="01";
                strLoginUserID = Session["UserID"].ToString();
              
             
            }
        }
       

        protected void FillRecords()
        {
            try
            {
                DataSet ds = getData();
                if ((ds.Tables[0].Rows.Count > 0))
                {
                    exportData(ds.Tables[0]);
                    //string validationfile = ExportToExcel(ds.Tables[0], "CreditData");
                }
                else
                {
                   
                }
            }
            catch (SqlException exp)
            {
                Response.Write(exp.Message);
            }
            finally
            {
                
            }
        }
        private DataSet getData()
        {
            DataSet ds = new DataSet("CreditData");
            using (SqlConnection conn = new SqlConnection(cnnString))
            {
                SqlCommand sqlComm = new SqlCommand("usp_getCreditData", conn);
                string _insertDate = System.DateTime.Now.ToString();

                sqlComm.Parameters.AddWithValue("@FromDate", txtFromDate.Text);
                sqlComm.Parameters.AddWithValue("@ToDate", txtToDate.Text);
                sqlComm.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;

                da.Fill(ds);

            }
            return ds;

        }
        private void exportData(DataTable dt) {
            
            // This actually makes your HTML output to be downloaded as .xls file
            Response.Clear();
            Response.ClearContent();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=CreditData.xls");

            // Create a dynamic control, populate and render it
            GridView excel = new GridView();
            excel.DataSource = dt;
            excel.DataBind();
            excel.RenderControl(new HtmlTextWriter(Response.Output));

            Response.Flush();
            Response.End();
        }
        private string ExportToExcel(DataTable dt, string filename)
        {
            DateTime dte = DateTime.Now;
            int Year = dte.Year;
            int Month = dte.Month;
            int Date = dte.Day;
            int Hour = dte.Hour;
            int Minute = dte.Minute;
            int Second = dte.Second;
            string FileDate = Year.ToString() + "-" + Month.ToString() + "-" + Date.ToString() + " " + Hour.ToString() + " " + Minute.ToString() + " " + Second.ToString();
            filename = filename + "-" + FileDate;
            filename = filename.Replace(" ", "_");

            if (dt.Rows.Count > 0)
            {

                // create the DataGrid and perform the databinding
                System.Web.UI.WebControls.DataGrid grid =
                            new System.Web.UI.WebControls.DataGrid();
                grid.HeaderStyle.Font.Bold = true;
                grid.DataSource = dt;
                //grid.DataMember = dt.Stats.TableName;

                grid.DataBind();
                string strFilePath = path+ "logs/" + filename + ".xls";
                string strFilePath2 = path+"logs/" + filename + ".txt";
                //render the DataGrid control to a file
                using (StreamWriter sw = new StreamWriter(strFilePath))
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        grid.RenderControl(hw);
                    }
                }


                //To Write to text
                Write(dt, strFilePath2);
            }

            return filename + ".xls";
        }
        static void Write(DataTable dt, string outputFilePath)
        {
            int[] maxLengths = new int[dt.Columns.Count];

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                maxLengths[i] = dt.Columns[i].ColumnName.Length;

                foreach (DataRow row in dt.Rows)
                {
                    if (!row.IsNull(i))
                    {
                        int length = row[i].ToString().Length;
                        if (length > maxLengths[i])
                        {
                            maxLengths[i] = length;
                        }
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(outputFilePath, false))
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i].ColumnName.PadRight(maxLengths[i] + 2));
                }

                sw.WriteLine();

                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (!row.IsNull(i))
                        {
                            sw.Write(row[i].ToString().PadRight(maxLengths[i] + 2));
                        }
                        else
                        {
                            sw.Write(new string(' ', maxLengths[i] + 2));
                        }
                    }

                    sw.WriteLine();
                }

                sw.Close();
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            FillRecords();
        }
        
        public void Page_LoadComplete()
        {
            //if (Request.Browser.Browser == "Firefox") Response.Cache.SetNoStore();
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            string myScript = "$('#loading').hide();";
            ScriptManager.RegisterStartupScript(Page, this.GetType(), "ClientScript", myScript, true);
            myScript = "";

        }
        

    }
}