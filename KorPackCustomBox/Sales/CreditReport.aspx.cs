using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Blumensoft.Utility;
using Blumen;

public partial class Sales_CreditReport : System.Web.UI.Page
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
                string strSQL = @"SELECT        Id, CustomerName, Comment, BelegunNumber, KundenNumber, LieferDatum, Rechnungsdatum, Varkaufer, IhreUID, Address,
				isnull((
				SELECT        count(MasterId)
				FROM            Master_Credit_Grid1
				where MasterId=M.Id
				and Beschreibung<>''
				),0) ch1cnt,
				isnull((
				SELECT        count(MasterId)
				FROM            Master_Credit_Grid2
				where MasterId=M.Id
				and Beschreibung<>''
				),0) ch2cnt,
				isnull((
				SELECT        count(MasterId)
				FROM            Master_Credit_Grid3
				where MasterId=M.Id
				and Beschreibung<>''
				),0) ch3cnt

			    FROM            Master_Credit M where Id=" + strId + "";
                ExecuteSQL objExecute = new ExecuteSQL();
                DataTable dt = objExecute.SearchReportRecordFromSQLQuery(strSQL);
                objExecute.Dispose();

                RFQCreditReports.CreditReport _CreditReport = new RFQCreditReports.CreditReport();
                Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();

                //Create new CultureInfo
                var cultureInfo = new System.Globalization.CultureInfo("fr-FR");

                // Set the language for static text (i.e. column headings, titles)
                System.Threading.Thread.CurrentThread.CurrentUICulture = cultureInfo;

                // Set the language for dynamic text (i.e. date, time, money)
                System.Threading.Thread.CurrentThread.CurrentCulture = cultureInfo;

                _CreditReport.DataSource = dt;
                ReportViewer1.Report = _CreditReport;
                ReportViewer1.RefreshReport();
            }


        }
    }
}