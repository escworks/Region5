using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class security_signin : region4.escWeb.BasePages.Security.signin_aspx
{

    protected override void AssignControlsToBase()
    {
        base._errorMessage = this.lblMessage;
        base._txtPassword = this.txtPassword;
        base._txtUserName = this.txtUserName;
    }

    protected override string NoEmailGiven { get { return Resources.security.noUserName; } }

    protected override string NoPasswordGiven { get { return Resources.security.noPassword; } }

    protected override string InvalidCredentials { get { return Resources.security.invalidCredentials; } }

    protected override string AccountDisabled { get { return Resources.security.accountDisabled; } }

    protected override string DatabaseError { get { return Resources.security.databaseError; } }
}
