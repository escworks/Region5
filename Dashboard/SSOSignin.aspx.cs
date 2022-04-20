using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Dashboard_SSOSignin : region4.escWeb.BasePage
{
    protected override void OnPreInit(EventArgs e)
    {
        // base.OnPreInit(e);
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        ////TTTTTTTTTTTTTTTT Single Sign On for DashBoard TTTTTTTTTTTTTTTTTTTTTTTTTTTTTT
        string SSOPortalURL = System.Web.Configuration.WebConfigurationManager.AppSettings["SSOPortal"];
        if (!string.IsNullOrEmpty(SSOPortalURL) && CurrentUser.IsInRole("texasdashboard"))
        {
            //string redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, CurrentUser.PrimaryEmail, "Dashboard/TexasDashboard.aspx");
            string redirectUrl = EncodeSSOPortalUrl(SSOPortalURL, "texasdashboard5@esc5.net", "TexasDashboard2.aspx");
            HttpContext.Current.Response.Redirect(redirectUrl);
        }
        ////LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLL
    }

    private string EncodeSSOPortalUrl(string SSOPortalURL, string Email, string returnURL)
    {
        string SHARED_KEY = "70467023fcfcd40fe3b884b2b96f6c48";
        TimeSpan t = (DateTime.UtcNow - new DateTime(1970, 1, 1));
        int timestamp = (int)t.TotalSeconds;

        var payload = new System.Collections.Generic.Dictionary<string, object>() {
                   { "userId", "texasdashboard5" },
                 { "userDirectory", "EXCELUSER" },
                // { "url", region4.escWeb.SiteVariables.CustomerHostUrl + returnURL },
            };
        string token = JWT.JsonWebToken.Encode(payload, SHARED_KEY, JWT.JwtHashAlgorithm.HS256);
        //  string redirectUrl = SSOPortalURL + "login.aspx?" + "jwt=" + token;
        string redirectUrl = returnURL;
        return redirectUrl;
    }
}