
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
using Blumen;

namespace StringEncodeDecode
{
    public partial class UserAuthentication_PrmUserInfo : System.Web.UI.Page
    {
        string cnnString = ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString;
        private string strLoginUserID = null;
        private string myScript = "";
        private string strcompanyID = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("../Logout.aspx");
            }
            else
            {
                this.hidMenuID.Value = "70";
                strcompanyID ="01";
                strLoginUserID = Session["UserID"].ToString();
                if (!IsPostBack)
                {   
                    FillRecords();
                }
             
            }
        }
       

        protected void FillRecords()
        {
            try
            {
                string strSQL = @"SELECT      Id, CustomerName, BelegunNumber, KundenNumber, convert(varchar(10),LieferDatum,104) LieferDatum, convert(varchar(10),Rechnungsdatum,104) Rechnungsdatum, Varkaufer, IhreUID, Address
                                FROM Master_Credit";
                ExecuteSQL objExecute = new ExecuteSQL();
                DataTable dt = objExecute.SearchReportRecordFromSQLQuery(strSQL);
                objExecute.Dispose();
                if ((dt.Rows.Count > 0))
                {
                    
                    grdEmpInfo.DataSource = dt;
                    grdEmpInfo.DataBind();
                    if (this.grdEmpInfo.Rows.Count > 0)
                    {
                        grdEmpInfo.UseAccessibleHeader = true;
                        grdEmpInfo.HeaderRow.TableSection = TableRowSection.TableHeader;

                    }
                }
                else
                {
                    grdEmpInfo.DataSource = null;
                    grdEmpInfo.DataBind();
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
        protected void DeleteRecord(string strId)
        {
            try
            {
                string strSQL = @"
                Delete FROM Master_Credit_Grid1 where MasterId=" + strId + @"
                Delete FROM Master_Credit_Grid2 where MasterId=" + strId + @"
                Delete FROM Master_Credit_Grid3 where MasterId=" + strId + @"
                Delete FROM Master_Credit where Id="+ strId +@"
                ";
                ExecuteSQL objExecute = new ExecuteSQL();
                objExecute.ExecuteQuery(strSQL);
                objExecute.Dispose();
            }
            catch (SqlException exp)
            {
                Response.Write(exp.Message);
            }
            finally
            {

            }
        }
        protected void GridView1_RowDataBound(object sender,
                         GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton l = (LinkButton)e.Row.FindControl("LinkButton1");
                l.Attributes.Add("onclick", "javascript:return " +
                "confirm('Are you sure you want to delete this record BelegunNumber " +
                DataBinder.Eval(e.Row.DataItem, "BelegunNumber") + "')");
            }
        }
        protected void GridView1_RowCommand(object sender,
                         GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int RecId = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(RecId.ToString());   
                Response.Redirect("CreditList.aspx");

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