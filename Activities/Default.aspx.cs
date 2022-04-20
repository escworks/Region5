using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Data.SqlClient;
using tx_r5.BusinessObect.Accountability;

public partial class Activities_Default : System.Web.UI.Page
{
    protected string strDate = string.Empty;
    Assistances myList;
    escWeb.tx_r5.ObjectModel.User user;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = region4.Common.DataConnection.DbConnection;
        LocationList.ConnectionString = conn.ConnectionString;

        if (!Page.IsPostBack)
        {
            strDate = LegacyCode.Strings.GetSafeString("date", LegacyCode.Strings.StringType.QueryString);
            txtDate.Value = strDate;
            libDate.Text = Convert.ToDateTime(strDate).ToShortDateString();

            user = (escWeb.tx_r5.ObjectModel.User)Session["profile"];
            litEmployeeName.Text = "<b>" + user.FirstName + " " + user.LastName + "</b>";
            litHours.Text = ((AssistancesDisplay)Session["myListDisplay"]).GetHours(Convert.ToDateTime(strDate), Convert.ToDateTime(strDate)).ToString();
            myList = Assistances.GetAssistances(Convert.ToDateTime(strDate), Convert.ToDateTime(strDate), user.Sid);

            grdActivity.DataSource = myList;
            grdActivity.DataBind();

            Session["myList"] = myList;
        }

    }

    protected void grdActivity_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {

        if (e.CommandName == "Select")
        {
            txtObjId.Value = e.Item.Cells[2].Text;
            UpdateParentPageScript.Visible = true;
            CloseDialogScript.Visible = true;
        }

    }

    protected void grdActivity_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if (e.Item is GridCommandItem)
        {
            e.Item.FindControl("InitInsertButton").Parent.Visible = false;
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {

        UpdateParentPageScript.Visible = true;
        CloseDialogScript.Visible = true;
    }
}

