using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Blumensoft.Utility;
using Blumen;
public partial class Sales_Reports : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("~/Login.aspx");

        }
        
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                string strId = Request.QueryString["Id"].ToString();
                string strSQL = @"SELECT        Id, CustomerName, BelegunNumber, KundenNumber, LieferDatum, Rechnungsdatum, Varkaufer, IhreUID, Address
                FROM            Master_Credit where Id=" + strId + "";
                ExecuteSQL objExecute = new ExecuteSQL();
                DataTable dt = objExecute.SearchReportRecordFromSQLQuery(strSQL);
                objExecute.Dispose();

                RFQCreditReports.CreditReport _CreditReport = new RFQCreditReports.CreditReport();
                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                _CreditReport.DataSource = dt;
                ReportViewer1.Report = _CreditReport;
                ReportViewer1.RefreshReport();
            }


        }

    }
   
}