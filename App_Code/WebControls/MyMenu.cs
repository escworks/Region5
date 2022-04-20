



using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Configuration;

namespace region4.WebControls
{
    public class MenuV3 : WebControl
    {
        protected escWeb.SiteObjects.MenuClasses.MenuItemCollection _menuItems;
        protected string signInUrl, signOutUrl;
        protected string customerId;

        protected escWeb.BasePage currentPage
        {
            get
            {
                escWeb.BasePage result = Context.Handler as escWeb.BasePage;
                if (result == null)
                    throw new Exception("this control will only function on a page based on escWeb.BasePage");
                return result;
            }
        }

        protected bool _displayAllItems = false;
        public bool DisplayAllItems
        {
            get { return _displayAllItems; }
            set { _displayAllItems = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            string cacheKey = String.Format("menuCollection - {0} - {1}", currentPage.MenuId, Context.User.Identity.Name);
            _menuItems = Context.Cache[cacheKey] as escWeb.SiteObjects.MenuClasses.MenuItemCollection;
            if (_menuItems == null)
            {
                System.Web.Caching.CacheDependency dependency;
                _menuItems = escWeb.SiteObjects.MenuClasses.MenuItemCollection.GetMenu(currentPage.MenuId, out dependency);
                Context.Cache.Add(cacheKey, _menuItems, dependency, DateTime.Now.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
            }
            int temp = _menuItems.Count;

            //string appPath = HttpContext.Current.Request.ApplicationPath;
            //string[] customers = ConfigurationManager.AppSettings["nd_customer_id"].Split('|');


            //foreach (string cust in customers)
            //{

            //    if (appPath.Contains(cust))
            //    {
            //        customerId = cust;
            //        signInUrl = "~/lib/img/" + customerId + "/buttons/signin.gif";
            //        signOutUrl = "~/lib/img/" + customerId + "/buttons/signout.gif";
            //        break;
            //    }
            //}

            base.OnInit(e);
        }

        protected void OutputMenu(escWeb.SiteObjects.MenuClasses.MenuItem item, int level, HtmlTextWriter writer)
        {

            if (item.Display(Context)) //Passes permissions test here
            {
                bool selected = item.IsSelected(currentPage, Context);


                //Insert user sid if specified
                item.Href = item.Href.Replace("|sid|", Context.User.Identity.Name);
                //item.Href = item.Href.Replace("|custid|", customerId.Substring(3)); //Added by VM 11-21-2013
                //Determine anchor and item class definitions is any
                string anchorCss = "", itemCss = "";

                if (!String.IsNullOrEmpty(item.AnchorCssClass))
                    anchorCss = String.Format(" class=\"{0}{1}\"", item.AnchorCssClass, selected ? " menuItemSelected" : "");
                if (!String.IsNullOrEmpty(item.ItemCssClass))
                    itemCss = String.Format(" class=\"{0}\"", item.ItemCssClass);


                if (item.Href.StartsWith("http://") || item.Href.StartsWith("www") || item.Href.StartsWith("javascript"))
                    writer.Write(String.Format("<li{5}><a{6} href=\"{1}\" title=\"{2}\" target=\"{3}\">{4}</a>", currentPage.PathToRoot, item.Href, item.ToolTip, item.Target, item.Name, itemCss, anchorCss));
                else if (String.IsNullOrEmpty(item.Href))
                    writer.Write(String.Format("<li{5}><a{6}  title=\"{2}\" target=\"{3}\">{4}</a>", currentPage.PathToRoot, item.Href, item.ToolTip, item.Target, item.Name, itemCss, anchorCss));
                else
                    writer.Write(String.Format("<li{5}><a{6} href=\"{0}{1}\"  title=\"{2}\" target=\"{3}\">{4}</a>", currentPage.PathToRoot, item.Href, item.ToolTip, item.Target, item.Name, itemCss, anchorCss));



                if (selected || _displayAllItems)
                {
                    if (item.Items.Count > 0)
                        writer.Write(String.Format("<ul class=\"navLevel{0}\">", level));

                    foreach (escWeb.SiteObjects.MenuClasses.MenuItem l in item.Items)
                        OutputMenu(l, level + 1, writer);

                    if (item.Items.Count > 0)
                        writer.Write("</ul>");
                }


                writer.Write("</li>");

            }
        }

        public string SignInText { get; set; }
        public string SignOutText { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<div id=\"escWebMenu\">");
            writer.Write(String.Format("<ul class=\"navLevel{0}\">", 0));


            bool signinAdded = false;
            string anon, auth;
            //If sign in/out text is specified add the link as the last item in the list
            if (!String.IsNullOrEmpty(SignInText) || !String.IsNullOrEmpty(SignOutText))
            {
                anon = String.Format("<a id=\"ASignIn\" href=\"{0}security/signin.aspx?ReturnUrl={1}\" class=\"signInLink\">{2}</a>", currentPage.PathToRoot, HttpContext.Current.Request.Path + HttpContext.Current.Server.UrlEncode((HttpContext.Current.Request.QueryString.ToString().Length > 0) ? "?" + HttpContext.Current.Request.QueryString.ToString() : ""), SignInText);
                auth = String.Format("<a id=\"ASignOut\" href=\"{0}security/signout.aspx\" class=\"signInLink\">{1}</a></p>", currentPage.PathToRoot, SignOutText);
                writer.Write("<li>{0}</li>", HttpContext.Current.Request.IsAuthenticated ? auth : anon);
                signinAdded = true;


            }

            string welcome = "<span style=\"font: 16px Tahoma, Geneva, sans-serif; font-size: 14px;\" class=\"welcomeMessage\">Hello, <b>" + currentPage.CurrentUser.FullName + "</b></span>";
            anon =
                String.IsNullOrEmpty(SignInText) ?
                String.Format("<center><a id=\"ASignIn\" href=\"{0}security/signin.aspx?ReturnUrl={1}\"><img style=\"border: none;\" src=\"{2}\" alt=\"Click here to sign in.\" /></a><br>", currentPage.PathToRoot, HttpContext.Current.Request.Path + HttpContext.Current.Server.UrlEncode((HttpContext.Current.Request.QueryString.ToString().Length > 0) ? "?" + HttpContext.Current.Request.QueryString.ToString() : ""), currentPage.MapVirtualPath(signInUrl))
                :
                String.Format("<a id=\"ASignIn\" href=\"{0}security/signin.aspx?ReturnUrl={1}\" class=\"signInLink\">{2}</a>", currentPage.PathToRoot, HttpContext.Current.Request.Path + HttpContext.Current.Server.UrlEncode((HttpContext.Current.Request.QueryString.ToString().Length > 0) ? "?" + HttpContext.Current.Request.QueryString.ToString() : ""), SignInText);

            anon += String.Format("<a id=\"NewUser\" href=\"{0}\"><font size=\"2\"><i>{1}</i></font></a>", currentPage.PathToRoot + "shoebox/account/signup.aspx?ReturnUrl=%2f" + customerId + "%2fdefault.aspx", "Click here to create an account");



            auth = String.IsNullOrEmpty(SignOutText) ?
                String.Format("<center>{2} <br/><br/><a id=\"ASignOut\" href=\"{0}security/signout.aspx\"><img style=\"border: none;\" src=\"{1}\" alt=\"Click here to sign out.\" /></a></center>",
                    currentPage.PathToRoot,
                    currentPage.MapVirtualPath(signOutUrl),
                    welcome)
                :
                String.Format("<a id=\"ASignOut\" href=\"{0}security/signout.aspx\" class=\"signInLink\">{1}</a></p>", currentPage.PathToRoot, SignOutText);

            if (!signinAdded)
                writer.Write(HttpContext.Current.Request.IsAuthenticated ? auth : anon);

            writer.Write("<center><br /><br /></center>");

            foreach (escWeb.SiteObjects.MenuClasses.MenuItem item in _menuItems)
                OutputMenu(item, 1, writer);
            writer.Write("</ul>");

            writer.Write("</div>");
        }
    }
}
