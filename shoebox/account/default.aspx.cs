using System;
using System.Web.UI;

public partial class shoebox_account_default : region4.escWeb.BasePages.ShoeBox.Account.default_aspx
{
    protected override void AssignControlsToBase()
    {
        base._primaryEmail = txtPrimaryEmail;
        base._secondaryEmail = txtSecondaryEmail;
        base._saluation = ddlSalutation;
        base._lastName = txtLastName;
        base._firstName = txtFirstName;
        base._middleName = txtMiddleName;
        base._homeAddress = txtHomeAddress;
        base._city = txtCity;
        base._state = ddState;
        base._zip = txtZip;
        base._homePhone = txtHomePhone;
        base._workPhone = txtWorkPhone;
        base._region = ddlRegion;
        base._district = ddlDistrict;
        base._school = ddlSchool;
        base._position = ddlPosition;
        base._errorMessage = lbErrorMessage;

        base._btnSubmit = btnSubmit;

        base._pSuccess = pSuccess;
        base._pFirst = pFirst;

        //base._gradeLevel = ddlGradeLevel;

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CascadingDropDown1.SelectedValue = CurrentUser.Location.Site.Organization.LocationID.ToString();
            CascadingDropDown2.SelectedValue = CurrentUser.Location.Site.LocationID.ToString();
            CascadingDropDown3.SelectedValue = CurrentUser.Location.LocationID.ToString();

            if (CurrentUser.Sid != Guid.Empty)
            {
                txtSpecialNeeds.Text = ((escWeb.tx_r5.ObjectModel.User)CurrentUser).SpecialNeeds;
                
            }
        }
    }


    protected override void SetCustomerParameters(region4.ObjectModel.User user)
    {
        escWeb.tx_r5.ObjectModel.User u = user as escWeb.tx_r5.ObjectModel.User;

        u.SpecialNeeds = txtSpecialNeeds.Text == null ? null : txtSpecialNeeds.Text;

    }

    protected void OnChangePassword(object sender, EventArgs e)
    {
        string Email = this.txtPrimaryEmail.Text;

        string url = "password.aspx?mode=change&code=0" + "&email=" + Email;
        Response.Redirect(url);
    }
}
