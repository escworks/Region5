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

public partial class instructor_default : region4.escWeb.BasePages.Instructor.default_aspx
{

    protected override void AssignControlsToBase()
    {
        this._radTabStrip = radTabStrip;
        this._pPlaceHolder = pPlaceHolder;
        this._hiddenFieldTabValue = hiddenFieldTabValue;
    }


    public override  HtmlTableRow ReturnSessionRow(region4.ObjectModel.SessionInfo sessionInfo, bool altRow)
    {
        HtmlTableRow row = new HtmlTableRow();
        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());
        row.Cells.Add(new HtmlTableCell());

        if (altRow)
        {
            row.Cells[0].Attributes.Add("class", "tableAltRow");
            row.Cells[1].Attributes.Add("class", "tableAltRow");
            row.Cells[2].Attributes.Add("class", "tableAltRow");
        }

        ImageButton button = new ImageButton();
        button.ImageUrl = "~/lib/img/signinrpt.gif";
        button.AlternateText = "Please click the sign in sheet";
        button.Click += new System.Web.UI.ImageClickEventHandler(signIn_Click);
        button.CommandArgument = sessionInfo.SessionID.ToString();
        row.Cells[0].Controls.Add(button);

        System.Web.UI.LiteralControl l = new System.Web.UI.LiteralControl(String.Format("<a href=\"email.aspx?session_id={0}\"><img src=\"{1}lib/img/email.gif\" alt=\"Click here for email link\" style=\"border: 0px;\" /></a>", sessionInfo.SessionID, this.PathToRoot)); //new System.Web.UI.LiteralControl(String.Format("<a href=\"email.aspx?session_id={0}\"><img src=\"{1}lib/img/email.gif\" /></a>", session.ID, this.PathToRoot));
        row.Cells[0].Controls.Add(l);

        //l = new System.Web.UI.LiteralControl(String.Format("<a href=\"javascript:getAttendee({0});\"><img src=\"../lib/img/attendee.gif\" border=\"0\" alt=\"Attendence Record \"></a>", sessionInfo.SessionID));
        //row.Cells[0].Controls.Add(l); // added attendance icon

        row.Cells[1].InnerHtml = String.Format("<em>{0} - {1}</em> <br />{2:d} {2:t}", sessionInfo.SessionID, sessionInfo.IsConference ? sessionInfo.Title + " (" + sessionInfo.Subtitle + ")" : sessionInfo.Title, sessionInfo.StartDate);
        row.Cells[2].InnerText = String.Format("{0} / {1}", sessionInfo.NumberOfAttendeesRegistered, sessionInfo.Limit);

        return row;
    }

}
