using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales_InputFields : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Cnn"].ConnectionString);

    public string MasterId
    {
        get
        {
            return (string)ViewState["MasterId"];
        }

        set
        {
            ViewState["MasterId"] = value;
        }
    }
    public DataSet DSGrid1
    {
        get
        {
            return (DataSet)ViewState["DSGrid1"];
        }

        set
        {
            ViewState["DSGrid1"] = value;
        }
    }
    public DataSet DSGrid2
    {
        get
        {
            return (DataSet)ViewState["DSGrid2"];
        }

        set
        {
            ViewState["DSGrid2"] = value;
        }
    }
    public DataSet DSGrid3
    {
        get
        {
            return (DataSet)ViewState["DSGrid3"];
        }

        set
        {
            ViewState["DSGrid3"] = value;
        }
    }
    public DataSet DSGridSum
    {
        get
        {
            return (DataSet)ViewState["DSGridSum"];
        }

        set
        {
            ViewState["DSGridSum"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("../Logout.aspx");
        }
        if (!IsPostBack)
        {
            if (Request.QueryString["Id"] != null)
            {
                MasterId = Request.QueryString["Id"].ToString();
            }
            else
            {
                MasterId = "0";
                DataClassesDataContext dc = new DataClassesDataContext();
                string maxid = (dc.Master_Credits.Max(x => x.Id) + 1).ToString();
                string strFormattedId = maxid.PadLeft(6, '0');
                txtBelegunNumber.Text ="K" + strFormattedId;
                Session["BelegunNumber"] = strFormattedId;
            }

            DSGrid1 = new DataSet();
            DSGrid2 = new DataSet();
            DSGrid3 = new DataSet();

            LoadCredit();
        }
    }

    private void LoadCredit()
    {
        LoadMasterData();
        BindEmployeeDetails();
        BindEmployeeDetails2();
        BindEmployeeDetails3();
    }

    void LoadMasterData()
    {
        DataClassesDataContext dc = new DataClassesDataContext();
        Master_Credit objMaster = dc.Master_Credits.Where(x => x.Id == Convert.ToInt32(MasterId)).SingleOrDefault();
        if (objMaster != null)
        {
            txtCustomerName.Text = objMaster.CustomerName;
            txtAddress.Value = objMaster.Address;
            txtComment.Value = objMaster.Comment;
            txtBelegunNumber.Text = objMaster.BelegunNumber;
            txtKundenNumber.Text = objMaster.KundenNumber;
            txtLieferDatum.Text = objMaster.LieferDatum.ToString();
            txtRechnungsdatum.Text = objMaster.Rechnungsdatum.ToString();
            txtVarkaufer.Text = objMaster.Varkaufer;
            txtIhreUID.Text = objMaster.IhreUID;
            if (objMaster.LockStatus == true)
            {
                ddlLockStatus.SelectedValue = "1";
                hidLockStatus.Value = "1";
                btnSave.Enabled = false;
            }
            else {
                ddlLockStatus.SelectedValue = "0";
                hidLockStatus.Value = "0";
                btnSave.Enabled = true;
            }

        }
    }

    #region Grid1
    protected void BindEmployeeDetails()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [Id], [Beschreibung], [Lange], [Züchter], [VP], [Menge], [Einheit], [Preis], [Steuer], [Betrag] FROM [Master_Credit_Grid1] where MasterId =" + MasterId, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(DSGrid1);

        con.Close();
        if (DSGrid1.Tables[0].Rows.Count > 0)
        {
            gvDetails.DataSource = DSGrid1;
            gvDetails.DataBind();
        }
        else
        {
            DSGrid1.Tables[0].Rows.Add(DSGrid1.Tables[0].NewRow());
            gvDetails.DataSource = DSGrid1;
            gvDetails.DataBind();

        }


    }

    protected void BindEmployeeDetailsList()
    {

        gvDetails.DataSource = DSGrid1;
        gvDetails.DataBind();

    }

    protected void gvDetails_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails.EditIndex = e.NewEditIndex;
        BindEmployeeDetailsList();
    }
    protected void gvDetails_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string username = gvDetails.DataKeys[e.RowIndex].Values["Beschreibung"].ToString();

        DataRow dr = (from DataRow myRow in DSGrid1.Tables[0].Rows
                      where (string)myRow["Beschreibung"] == username
                      select myRow).SingleOrDefault();

        if (dr != null)
        {
            TextBox txtBeschreibung = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtBeschreibung");
            TextBox txtLange = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtLange");
            TextBox txtZüchter = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtZüchter");
            TextBox txtVP = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtVP");
            TextBox txtMenge = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtMenge");
            TextBox txtEinheit = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtEinheit");
            TextBox txtPreis = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtPreis");
            TextBox txtSteuer = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtSteuer");
            TextBox txtBetrag = (TextBox)gvDetails.Rows[e.RowIndex].FindControl("txtBetrag");

            dr["Beschreibung"] = txtBeschreibung.Text;
            dr["Lange"] = txtLange.Text;
            dr["Züchter"] = txtZüchter.Text;
            dr["VP"] = txtVP.Text;
            dr["Menge"] = txtMenge.Text;
            dr["Einheit"] = txtEinheit.Text;
            dr["Preis"] = txtPreis.Text;
            dr["Steuer"] = txtSteuer.Text;
            dr["Betrag"] = txtBetrag.Text;

            gvDetails.EditIndex = -1;
            BindEmployeeDetailsList();
        }
    }
    protected void gvDetails_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails.EditIndex = -1;
        BindEmployeeDetailsList();
    }
    protected void gvDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string username = string.Empty;

        try
        {
            username = ((Label)gvDetails.Rows[e.RowIndex].FindControl("lblBeschreibung")).Text;

            int rowIndex = e.RowIndex;
            DSGrid1.Tables[0].Rows.RemoveAt(rowIndex);

            if (DSGrid1.Tables[0].Rows.Count < 1)
            {
                DSGrid1.Tables[0].Rows.Add(DSGrid1.Tables[0].NewRow());
            }

            BindEmployeeDetailsList();
            lblMessage1.ForeColor = Color.Green;
            lblMessage1.Text = username + " details deleted successfully";

        }
        catch (Exception)
        {
            lblMessage1.ForeColor = Color.Red;
            lblMessage1.Text = username + " cannot be deleted";
        }
    }

    protected void gvDetails_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtBeschreibung = null;
        DataRow dr = null;
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                txtBeschreibung = (TextBox)gvDetails.FooterRow.FindControl("txtftrBeschreibung");
                TextBox txtLange = (TextBox)gvDetails.FooterRow.FindControl("txtftrLange");
                TextBox txtZüchter = (TextBox)gvDetails.FooterRow.FindControl("txtftrZüchter");
                TextBox txtVP = (TextBox)gvDetails.FooterRow.FindControl("txtftrVP");
                TextBox txtMenge = (TextBox)gvDetails.FooterRow.FindControl("txtftrMenge");
                TextBox txtEinheit = (TextBox)gvDetails.FooterRow.FindControl("txtftrEinheit");
                TextBox txtPreis = (TextBox)gvDetails.FooterRow.FindControl("txtftrPreis");
                TextBox txtSteuer = (TextBox)gvDetails.FooterRow.FindControl("txtftrSteuer");
                TextBox txtBetrag = (TextBox)gvDetails.FooterRow.FindControl("txtftrBetrag");

                if (DSGrid1.Tables[0].Rows.Count == 1 && DSGrid1.Tables[0].Rows[0][1].ToString() == "")
                {
                    dr = DSGrid1.Tables[0].Rows[0];

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;
                }
                else
                {
                    dr = DSGrid1.Tables[0].NewRow();

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;

                    DSGrid1.Tables[0].Rows.Add(dr);
                }

                BindEmployeeDetailsList();
                lblMessage1.ForeColor = Color.Green;
                lblMessage1.Text = txtBeschreibung.Text + " inserted successfully";

            }
        }
        catch (Exception)
        {

            lblMessage1.ForeColor = Color.Red;
            lblMessage1.Text = txtBeschreibung.Text + " not inserted to the grid";
        }
    }

    #endregion

    #region Grid2
    protected void BindEmployeeDetails2()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [Id], [Beschreibung], [Lange], [Züchter], [VP], [Menge], [Einheit], [Preis], [Steuer], [Betrag] FROM [Master_Credit_Grid2] where MasterId =" + MasterId, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(DSGrid2);
        con.Close();
        if (DSGrid2.Tables[0].Rows.Count > 0)
        {
            gvDetails2.DataSource = DSGrid2;
            gvDetails2.DataBind();
        }
        else
        {
            DSGrid2.Tables[0].Rows.Add(DSGrid2.Tables[0].NewRow());
            gvDetails2.DataSource = DSGrid2;
            gvDetails2.DataBind();
        }


    }

    protected void BindEmployeeDetailsList2()
    {
        gvDetails2.DataSource = DSGrid2;
        gvDetails2.DataBind();

    }

    protected void gvDetails2_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails2.EditIndex = e.NewEditIndex;
        BindEmployeeDetailsList2();

    }
    protected void gvDetails2_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string username = gvDetails2.DataKeys[e.RowIndex].Values["Beschreibung"].ToString();

        DataRow dr = (from DataRow myRow in DSGrid2.Tables[0].Rows
                      where (string)myRow["Beschreibung"] == username
                      select myRow).SingleOrDefault();

        if (dr != null)
        {
            TextBox txtBeschreibung = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtBeschreibung");
            TextBox txtLange = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtLange");
            TextBox txtZüchter = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtZüchter");
            TextBox txtVP = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtVP");
            TextBox txtMenge = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtMenge");
            TextBox txtEinheit = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtEinheit");
            TextBox txtPreis = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtPreis");
            TextBox txtSteuer = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtSteuer");
            TextBox txtBetrag = (TextBox)gvDetails2.Rows[e.RowIndex].FindControl("txtBetrag");

            dr["Beschreibung"] = txtBeschreibung.Text;
            dr["Lange"] = txtLange.Text;
            dr["Züchter"] = txtZüchter.Text;
            dr["VP"] = txtVP.Text;
            dr["Menge"] = txtMenge.Text;
            dr["Einheit"] = txtEinheit.Text;
            dr["Preis"] = txtPreis.Text;
            dr["Steuer"] = txtSteuer.Text;
            dr["Betrag"] = txtBetrag.Text;

            gvDetails2.EditIndex = -1;
            BindEmployeeDetailsList2();
        }
    }
    protected void gvDetails2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails.EditIndex = -1;
        BindEmployeeDetailsList();
    }
    protected void gvDetails2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string username = string.Empty;
        try
        {
            username = ((Label)gvDetails2.Rows[e.RowIndex].FindControl("lblBeschreibung")).Text;

            int rowIndex = e.RowIndex;
            DSGrid2.Tables[0].Rows.RemoveAt(rowIndex);

            if (DSGrid2.Tables[0].Rows.Count < 1)
            {
                DSGrid2.Tables[0].Rows.Add(DSGrid2.Tables[0].NewRow());
            }

            BindEmployeeDetailsList2();
            lblMessage2.ForeColor = Color.Green;
            lblMessage2.Text = username + " details deleted successfully";

        }
        catch (Exception)
        {
            lblMessage2.ForeColor = Color.Red;
            lblMessage2.Text = username + " cannot be deleted";
        }
    }
    protected void gvDetails2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtBeschreibung = null;
        DataRow dr = null;
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                txtBeschreibung = (TextBox)gvDetails2.FooterRow.FindControl("txtftrBeschreibung");
                TextBox txtLange = (TextBox)gvDetails2.FooterRow.FindControl("txtftrLange");
                TextBox txtZüchter = (TextBox)gvDetails2.FooterRow.FindControl("txtftrZüchter");
                TextBox txtVP = (TextBox)gvDetails2.FooterRow.FindControl("txtftrVP");
                TextBox txtMenge = (TextBox)gvDetails2.FooterRow.FindControl("txtftrMenge");
                TextBox txtEinheit = (TextBox)gvDetails2.FooterRow.FindControl("txtftrEinheit");
                TextBox txtPreis = (TextBox)gvDetails2.FooterRow.FindControl("txtftrPreis");
                TextBox txtSteuer = (TextBox)gvDetails2.FooterRow.FindControl("txtftrSteuer");
                TextBox txtBetrag = (TextBox)gvDetails2.FooterRow.FindControl("txtftrBetrag");

                if (DSGrid2.Tables[0].Rows.Count == 1 && DSGrid2.Tables[0].Rows[0][1].ToString() == "")
                {
                    dr = DSGrid2.Tables[0].Rows[0];

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;
                }
                else
                {
                    dr = DSGrid2.Tables[0].NewRow();

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;

                    DSGrid2.Tables[0].Rows.Add(dr);
                }

                BindEmployeeDetailsList2();

                lblMessage2.ForeColor = Color.Green;
                lblMessage2.Text = txtBeschreibung.Text + " inserted successfully";

            }
        }
        catch (Exception ex)
        {

            lblMessage2.ForeColor = Color.Red;
            lblMessage2.Text = txtBeschreibung.Text + " not inserted to the grid";
        }
    }

    #endregion

    #region Grid3
    protected void BindEmployeeDetails3()
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("SELECT [Id], [Beschreibung], [Lange], [Züchter], [VP], [Menge], [Einheit], [Preis], [Steuer], [Betrag] FROM [Master_Credit_Grid3] where MasterId =" + MasterId, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(DSGrid3);
        con.Close();

        if (DSGrid3.Tables[0].Rows.Count == 0)
        {
            DSGrid3.Tables[0].Rows.Add(DSGrid3.Tables[0].NewRow());
        }
        gvDetails3.DataSource = DSGrid3;
        gvDetails3.DataBind();

    }

    protected void BindEmployeeDetailsList3()
    {
        gvDetails3.DataSource = DSGrid3;
        gvDetails3.DataBind();

    }

    protected void gvDetails3_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvDetails3.EditIndex = e.NewEditIndex;
        BindEmployeeDetailsList3();
    }
    protected void gvDetails3_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string username = gvDetails3.DataKeys[e.RowIndex].Values["Beschreibung"].ToString();

        DataRow dr = (from DataRow myRow in DSGrid3.Tables[0].Rows
                      where (string)myRow["Beschreibung"] == username
                      select myRow).SingleOrDefault();

        if (dr != null)
        {
            TextBox txtBeschreibung = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtBeschreibung");
            TextBox txtLange = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtLange");
            TextBox txtZüchter = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtZüchter");
            TextBox txtVP = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtVP");
            TextBox txtMenge = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtMenge");
            TextBox txtEinheit = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtEinheit");
            TextBox txtPreis = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtPreis");
            TextBox txtSteuer = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtSteuer");
            TextBox txtBetrag = (TextBox)gvDetails3.Rows[e.RowIndex].FindControl("txtBetrag");

            dr["Beschreibung"] = txtBeschreibung.Text;
            dr["Lange"] = txtLange.Text;
            dr["Züchter"] = txtZüchter.Text;
            dr["VP"] = txtVP.Text;
            dr["Menge"] = txtMenge.Text;
            dr["Einheit"] = txtEinheit.Text;
            dr["Preis"] = txtPreis.Text;
            dr["Steuer"] = txtSteuer.Text;
            dr["Betrag"] = txtBetrag.Text;

            gvDetails3.EditIndex = -1;
            BindEmployeeDetailsList3();
        }
    }
    protected void gvDetails3_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvDetails3.EditIndex = -1;
        BindEmployeeDetailsList3();
    }
    protected void gvDetails3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string username = string.Empty;
        try
        {
            username = ((Label)gvDetails3.Rows[e.RowIndex].FindControl("lblBeschreibung")).Text;

            int rowIndex = e.RowIndex;
            DSGrid3.Tables[0].Rows.RemoveAt(rowIndex);

            if (DSGrid3.Tables[0].Rows.Count < 1)
            {
                DSGrid3.Tables[0].Rows.Add(DSGrid3.Tables[0].NewRow());
            }

            BindEmployeeDetailsList3();
            lblMessage3.ForeColor = Color.Green;
            lblMessage3.Text = username + " details deleted successfully";

        }
        catch (Exception)
        {
            lblMessage3.ForeColor = Color.Red;
            lblMessage3.Text = username + " cannot be deleted";
        }
    }
    protected void gvDetails3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        TextBox txtBeschreibung = null;
        DataRow dr = null;
        try
        {
            if (e.CommandName.Equals("AddNew"))
            {
                txtBeschreibung = (TextBox)gvDetails3.FooterRow.FindControl("txtftrBeschreibung");
                TextBox txtLange = (TextBox)gvDetails3.FooterRow.FindControl("txtftrLange");
                TextBox txtZüchter = (TextBox)gvDetails3.FooterRow.FindControl("txtftrZüchter");
                TextBox txtVP = (TextBox)gvDetails3.FooterRow.FindControl("txtftrVP");
                TextBox txtMenge = (TextBox)gvDetails3.FooterRow.FindControl("txtftrMenge");
                TextBox txtEinheit = (TextBox)gvDetails3.FooterRow.FindControl("txtftrEinheit");
                TextBox txtPreis = (TextBox)gvDetails3.FooterRow.FindControl("txtftrPreis");
                TextBox txtSteuer = (TextBox)gvDetails3.FooterRow.FindControl("txtftrSteuer");
                TextBox txtBetrag = (TextBox)gvDetails3.FooterRow.FindControl("txtftrBetrag");

                if (DSGrid3.Tables[0].Rows.Count == 1 && DSGrid3.Tables[0].Rows[0][1].ToString() == "")
                {
                    dr = DSGrid3.Tables[0].Rows[0];

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;
                }
                else
                {
                    dr = DSGrid3.Tables[0].NewRow();

                    dr["Beschreibung"] = txtBeschreibung.Text;
                    dr["Lange"] = txtLange.Text;
                    dr["Züchter"] = txtZüchter.Text;
                    dr["VP"] = txtVP.Text;
                    dr["Menge"] = txtMenge.Text;
                    dr["Einheit"] = txtEinheit.Text;
                    dr["Preis"] = txtPreis.Text;
                    dr["Steuer"] = txtSteuer.Text;
                    dr["Betrag"] = txtBetrag.Text;

                    DSGrid3.Tables[0].Rows.Add(dr);
                }

                BindEmployeeDetailsList3();

                lblMessage3.ForeColor = Color.Green;
                lblMessage3.Text = txtBeschreibung.Text + " inserted successfully";

            }
        }
        catch (Exception)
        {

            lblMessage3.ForeColor = Color.Red;
            lblMessage3.Text = txtBeschreibung.Text + " not inserted to the grid";
        }
    }

    protected void imgbtnAdd3_Click(object sender, EventArgs e)
    {

    }
    #endregion
    protected void btnSave_Click(object sender, EventArgs e)
    {

        if (MasterId == "0")
        {
            AddCredit();
        }
        else
        {
            UpdateCredit();

        }

        Response.Redirect("creditlist.aspx");
    }

    public EntitySet<Master_Credit_Grid1> ConvertToList(DataTable dt)
    {
        EntitySet<Master_Credit_Grid1> retList = new EntitySet<Master_Credit_Grid1>();

        foreach (DataRow dr in dt.Rows)
        {
            Master_Credit_Grid1 obj = new Master_Credit_Grid1();

            obj.Beschreibung = dr["Beschreibung"].ToString();
            obj.Lange = string.IsNullOrEmpty(dr["Lange"].ToString()) ? (int?)null : int.Parse(dr["Lange"].ToString());
            obj.Züchter = dr["Züchter"].ToString();
            obj.VP = dr["VP"].ToString();
            obj.Menge = string.IsNullOrEmpty(dr["Menge"].ToString()) ? (int?)null : int.Parse(dr["Menge"].ToString());
            obj.Einheit = string.IsNullOrEmpty(dr["Einheit"].ToString()) ? (int?)null : int.Parse(dr["Einheit"].ToString());
            obj.Preis = string.IsNullOrEmpty(dr["Preis"].ToString()) ? (decimal?)null : decimal.Parse(dr["Preis"].ToString());
            obj.Steuer = dr["Steuer"].ToString();
            obj.Betrag = string.IsNullOrEmpty(dr["Betrag"].ToString()) ? (decimal?)null : decimal.Parse(dr["Betrag"].ToString());

            retList.Add(obj);
        }

        return retList;
    }

    public EntitySet<Master_Credit_Grid2> ConvertToList2(DataTable dt)
    {
        EntitySet<Master_Credit_Grid2> retList = new EntitySet<Master_Credit_Grid2>();

        foreach (DataRow dr in dt.Rows)
        {
            Master_Credit_Grid2 obj = new Master_Credit_Grid2();

            obj.Beschreibung = dr["Beschreibung"].ToString();
            obj.Lange = string.IsNullOrEmpty(dr["Lange"].ToString()) ? (int?)null : int.Parse(dr["Lange"].ToString());
            obj.Züchter = dr["Züchter"].ToString();
            obj.VP = dr["VP"].ToString();
            obj.Menge = string.IsNullOrEmpty(dr["Menge"].ToString()) ? (int?)null : int.Parse(dr["Menge"].ToString());
            obj.Einheit = string.IsNullOrEmpty(dr["Einheit"].ToString()) ? (int?)null : int.Parse(dr["Einheit"].ToString());
            obj.Preis = string.IsNullOrEmpty(dr["Preis"].ToString()) ? (decimal?)null : decimal.Parse(dr["Preis"].ToString());
            obj.Steuer = dr["Steuer"].ToString();
            obj.Betrag = string.IsNullOrEmpty(dr["Betrag"].ToString()) ? (decimal?)null : decimal.Parse(dr["Betrag"].ToString());

            retList.Add(obj);
        }

        return retList;
    }
    public EntitySet<Master_Credit_Grid3> ConvertToList3(DataTable dt)
    {
        EntitySet<Master_Credit_Grid3> retList = new EntitySet<Master_Credit_Grid3>();

        foreach (DataRow dr in dt.Rows)
        {
            Master_Credit_Grid3 obj = new Master_Credit_Grid3();

            obj.Beschreibung = dr["Beschreibung"].ToString();
            obj.Lange = string.IsNullOrEmpty(dr["Lange"].ToString()) ? (int?)null : int.Parse(dr["Lange"].ToString());
            obj.Züchter = dr["Züchter"].ToString();
            obj.VP = dr["VP"].ToString();
            obj.Menge = string.IsNullOrEmpty(dr["Menge"].ToString()) ? (int?)null : int.Parse(dr["Menge"].ToString());
            obj.Einheit = string.IsNullOrEmpty(dr["Einheit"].ToString()) ? (int?)null : int.Parse(dr["Einheit"].ToString());
            obj.Preis = string.IsNullOrEmpty(dr["Preis"].ToString()) ? (decimal?)null : decimal.Parse(dr["Preis"].ToString());
            obj.Steuer = dr["Steuer"].ToString();
            obj.Betrag = string.IsNullOrEmpty(dr["Betrag"].ToString()) ? (decimal?)null : decimal.Parse(dr["Betrag"].ToString());

            retList.Add(obj);
        }

        return retList;
    }

    public bool AddCredit()
    {
        DbTransaction trans = null;
        DataClassesDataContext dc = new DataClassesDataContext();

        try
        {
            Master_Credit objMaster = new Master_Credit();

            objMaster.CustomerName = txtCustomerName.Text;
            objMaster.Address = txtAddress.Value;
            objMaster.Comment = txtComment.Value;
            objMaster.BelegunNumber = txtBelegunNumber.Text;
            objMaster.KundenNumber = txtKundenNumber.Text;
            objMaster.LieferDatum = string.IsNullOrEmpty(txtLieferDatum.Text) ? (DateTime?)null : DateTime.Parse(txtLieferDatum.Text);
            objMaster.Rechnungsdatum = string.IsNullOrEmpty(txtRechnungsdatum.Text) ? (DateTime?)null : DateTime.Parse(txtRechnungsdatum.Text);
            objMaster.Varkaufer = txtVarkaufer.Text;
            objMaster.IhreUID = txtIhreUID.Text;
            int i = int.Parse(ddlLockStatus.SelectedItem.Value);
            objMaster.LockStatus = Convert.ToBoolean(i);
            
            if (DSGrid1.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid1s = ConvertToList(DSGrid1.Tables[0]);
            }

            if (DSGrid2.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid2s = ConvertToList2(DSGrid2.Tables[0]);
            }
            if (DSGrid3.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid3s = ConvertToList3(DSGrid3.Tables[0]);
            }

            dc.Connection.Open();
            trans = dc.Connection.BeginTransaction();
            dc.Transaction = trans;
            dc.Master_Credits.InsertOnSubmit(objMaster);
            dc.SubmitChanges();
            trans.Commit();
        }
        catch (ChangeConflictException CCEX)
        {
            dc.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
        }
        catch (Exception ex)
        {
            if (trans != null)
            {
                trans.Rollback();
            }
        }
        finally
        {
            if (dc.Connection.State == ConnectionState.Open)
            {
                dc.Connection.Close();
            }
        }

        return true;
    }

    public bool UpdateCredit()
    {
        
        DbTransaction trans = null;
        Master_Credit objMaster = null;
        DataClassesDataContext dc = new DataClassesDataContext();

        try
        {
            objMaster = dc.Master_Credits.Where(x => x.Id == Convert.ToInt32(MasterId)).Single();

            objMaster.CustomerName = txtCustomerName.Text;
            objMaster.Address = txtAddress.Value;
            objMaster.Comment = txtComment.Value;
            objMaster.BelegunNumber = txtBelegunNumber.Text;
            objMaster.KundenNumber = txtKundenNumber.Text;
            objMaster.LieferDatum = string.IsNullOrEmpty(txtLieferDatum.Text) ? (DateTime?)null : DateTime.Parse(txtLieferDatum.Text);
            objMaster.Rechnungsdatum = string.IsNullOrEmpty(txtRechnungsdatum.Text) ? (DateTime?)null : DateTime.Parse(txtRechnungsdatum.Text);
            objMaster.Varkaufer = txtVarkaufer.Text;
            objMaster.IhreUID = txtIhreUID.Text;
            int i = int.Parse(ddlLockStatus.SelectedItem.Value);
            objMaster.LockStatus = Convert.ToBoolean(i);

            if (DSGrid1.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid1s.Clear();
                objMaster.Master_Credit_Grid1s = ConvertToList(DSGrid1.Tables[0]);
            }

            if (DSGrid2.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid2s.Clear();
                objMaster.Master_Credit_Grid2s = ConvertToList2(DSGrid2.Tables[0]);
            }
            if (DSGrid3.Tables[0].Rows.Count > 0)
            {
                objMaster.Master_Credit_Grid3s.Clear();
                objMaster.Master_Credit_Grid3s = ConvertToList3(DSGrid3.Tables[0]);
            }

            dc.Connection.Open();
            trans = dc.Connection.BeginTransaction();
            dc.Transaction = trans;

            dc.SubmitChanges();
            trans.Commit();
        }
        catch (ChangeConflictException CCEX)
        {
            dc.ChangeConflicts.ResolveAll(RefreshMode.KeepChanges);
        }
        catch (Exception ex)
        {
            if (trans != null)
            {
                trans.Rollback();
            }
        }
        finally
        {
            if (dc.Connection.State == ConnectionState.Open)
            {
                dc.Connection.Close();
            }
        }

        return true;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("creditlist.aspx");
    }
}