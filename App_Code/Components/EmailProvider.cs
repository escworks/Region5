using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using region4;

/// <summary>
/// Summary description for EmailProvider
/// </summary>
public class EmailProvider : region4.Utilities.Email.baseEmailProvider
{
    protected override string CustomerLogoUrl
    {
        get
        {
            return "lib/img/region5LOGO.jpg";
        }
    }
    public override HtmlTable ReturnConfirmationReport(region4.ObjectModel.Attendee attendee, bool embedLogo)
    {
        string title = attendee.Session.Title.Replace(" ", "%20");
        string participantName = attendee.User.FullName.Replace(" ", "%20");

        //Render HtmlTable
        HtmlTable table = new HtmlTable();
        table.Width = "100%";
        table.Attributes.Add("border","0");

        HtmlTableRow row;

        if (CustomerLogo != null)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].Align = "left";
            row.Cells[0].Width = "50%";
            row.Cells[0].InnerHtml = String.Format("<img src=\"{0}\" alt=\"Customer Logo\"/>", embedLogo ? "cid:customerLogo" : pathToRoot + CustomerLogoUrl);
            
            row.Cells.Add(new HtmlTableCell());
            row.Cells[1].Align = "right";
            row.Cells[1].Width = "50%";
            row.Cells[1].InnerHtml = String.Format("<a href=\"{0}\">Manage Your Account</a>&nbsp;|&nbsp;<a href=\"{1}\">Courses</a>",
                region4.escWeb.SiteVariables.CustomerHostUrl + "shoebox/registration/default.aspx",
                region4.escWeb.SiteVariables.CustomerHostUrl + "search.aspx");
            table.Rows.Add(row);
        }

        //Date
        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        builder.AppendFormat("<br /><br />{0}, {1} {2}, {3} at {4:t}<br /><br />", System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedDayNames[(int)attendee.RegistrationTime.DayOfWeek], System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames[(int)attendee.RegistrationTime.Month - 1], attendee.RegistrationTime.Day, attendee.RegistrationTime.Year, attendee.RegistrationTime);
        builder.AppendFormat("{0} {1} <br />", attendee.User.FirstName, attendee.User.LastName);

        if (!String.IsNullOrEmpty(attendee.User.Address))
        {
            builder.AppendFormat("{0}<br />", attendee.User.Address);
            builder.AppendFormat("{0}, {1} {2} <br /> <br />", attendee.User.City, attendee.User.State, attendee.User.Zip);
        }
        else
            builder.Append("<br /><br />");

        builder.AppendFormat("<div style=\"font-size: 12pt; font-weight: bold\">Confirmation Number: <font color=\"green\">{0}-{1}-{2}</font></div>", attendee.Session.Event.EventID, attendee.Session.ID, attendee.ID);
        
        if(attendee.Creator != null)
            builder.AppendFormat("<br />Thank you for your registration. This confirms your registration for the following class by {0}. If payment was required, your receipt is included in the Payments Received section below.<br/><br/>", attendee.Creator.FullName);
        else
            builder.AppendFormat("<br />Thank you for your registration. This confirms your registration for the following class. If payment was required, your receipt is included in the Payments Received section below.<br/><br/>");

        if (!String.IsNullOrEmpty(attendee.Session.Subtitle))
            builder.AppendFormat("<span style=\"font-weight: bold;\">{0}</span><br />{1}<br />{2}<br /> <br />", attendee.Session.Event.Title, attendee.Session.Subtitle, attendee.Session.Event.Description);
        else
            builder.AppendFormat("<span style=\"font-weight: bold;\">{0}</span><br />{2}<br /> <br />", attendee.Session.Event.Title, attendee.Session.Subtitle, attendee.Session.Event.Description);

        builder.AppendFormat("<strong>Session ID: </strong>{0}<br /><br />", attendee.Session.ID);

        row.Cells[0].InnerHtml = builder.ToString();

        table.Rows.Add(row);

        //For online session
        if (attendee.Session.IsOnline)
        {
            row = new HtmlTableRow(); //Location
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].InnerHtml = "<b>Location:<b>";
            row.Cells[1].InnerHtml = "Online";
            table.Rows.Add(row);

            if (attendee.Session.IsSelfPacedOnline || attendee.Session.IsOnDemandOnline)
            {
                row = new HtmlTableRow(); //Subscription length
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Subscription Length:<b>";
                row.Cells[1].InnerHtml = attendee.Session.SubscriptionLength;
                table.Rows.Add(row);

                row = new HtmlTableRow(); //Expiration Date
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Expiration Date:<b>";
                row.Cells[1].InnerHtml = attendee.Session.OnlineExpirationDate.ToShortDateString();
                table.Rows.Add(row);
            }
            else
            {
                row = new HtmlTableRow(); //Dates
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].InnerHtml = "<b>Dates:<b>";
                row.Cells[1].InnerHtml = (attendee.Session.StartDate.ToString().Contains("12:00:00 AM") ? attendee.Session.StartDate.ToShortDateString() : attendee.Session.StartDate.ToString()) + " - " + (attendee.Session.EndDate.ToString().Contains("12:00:00 AM") ? attendee.Session.EndDate.ToShortDateString() : attendee.Session.EndDate.ToString());
                table.Rows.Add(row);
            }
        }
        else
        {
            //Date/Time Location
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            DateTime currentStart, currentEnd;
            currentStart = currentEnd = new DateTime(1919, 10, 9);

            row.Cells[0].InnerHtml = "<b>Dates/Times:<b>";
            row.Cells[1].InnerHtml = "<b>Location:</b>";
            table.Rows.Add(row);

            foreach (region4.ObjectModel.ScheduleItem schedule in attendee.Session.Schedule)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                if (schedule.StartDate == currentStart && schedule.EndDate == currentEnd)
                    continue;
                row.Cells[0].InnerHtml = String.Format("{0:d} {0:t} - {1:t}<br />", schedule.StartDate, schedule.EndDate);
                currentStart = schedule.StartDate;
                currentEnd = schedule.EndDate;
                region4.ObjectModel.Room room = schedule.Location;


                    if (ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(room.LocationID.ToString()))

                        row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, room.Name, room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1, room.Site.IsServiceCenter ? room.Site.City : room.City, room.Site.IsServiceCenter ? room.Site.State : room.State, room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);
              

                   else if (ConfigurationManager.AppSettings["location.rooms.6thfloo4"].Contains(room.LocationID.ToString()))
                

                   row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, room.Name + ',' + " on the 6th floor of the Edison Plaza building", room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1, room.Site.IsServiceCenter ? room.Site.City : room.City, room.Site.IsServiceCenter ? room.Site.State : room.State, room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);
            

                   else if (room.Site.SiteID == 38225)
                

                   row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, room.Name  + ',' + " on the 4th floor of the Edison Plaza building", room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1, room.Site.IsServiceCenter ? room.Site.City : room.City, room.Site.IsServiceCenter ? room.Site.State : room.State, room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);
            
                   else

                   row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, room.Name,  room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1, room.Site.IsServiceCenter ? room.Site.City : room.City, room.Site.IsServiceCenter ? room.Site.State : room.State, room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);

                //row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(room.LocationID.ToString()) ? room.Name : ConfigurationManager.AppSettings["location.rooms.6thfloo4"].Contains(room.LocationID.ToString()) ? room.Name + ',' + " on the 6th floor of the Edison Plaza building" : room.Site.SiteID == 38225 ? room.Name + ',' + " on the 4th floor of the Edison Plaza building" : room.Name,

                
                //row.Cells[1].InnerHtml += string.Format("{0}: {1} {2} {3}, {4} {5}<br />", room.Site.Name, ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(room.LocationID.ToString()) ? room.Name : room.Site.SiteID == 38225 ? room.Name + ',' + " on the 4th floor of the Edison Plaza building" : room.Name,
                   //room.Site.IsServiceCenter ? room.Site.Address1 : room.Address1,
                   // room.Site.IsServiceCenter ? room.Site.City : room.City,
                   // room.Site.IsServiceCenter ? room.Site.State : room.State,
                   // room.Site.IsServiceCenter ? room.Site.Zip : room.Zip);
                table.Rows.Add(row);
            }
        }

        if (!String.IsNullOrEmpty(attendee.Session.ConfirmationComments))
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;
            row.Cells[0].InnerHtml = String.Format("<b>Additional Information:</b><br />{0}", attendee.Session.ConfirmationComments);
            table.Rows.Add(row);
        }

        table.Rows.Add(row);

        if (attendee.Payments.Count > 0)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;

            row.Cells[0].InnerHtml = "<strong><br />Payments Received/Submitted:</strong><br />The following payments have been received for/submitted to your account:<br /><br />";

            table.Rows.Add(row);

            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].ColSpan = 2;

            HtmlTable detailTable = new HtmlTable();
            HtmlTableRow detailRow = new HtmlTableRow();

            detailTable.Style.Add("border", "solid #c0c0c0 1px");
            detailTable.Style.Add("border-collapse", "collapse");
            detailTable.Align = "center";
            detailTable.Width = "100%";

            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());

            detailRow.Style.Add("font-weight", "bold");

            detailRow.Cells[0].InnerText = "Date Submitted";
            detailRow.Cells[1].InnerText = "Payment Type";
            detailRow.Cells[2].InnerText = "Amount";
            detailRow.Cells[3].InnerText = "Status";
            detailRow.Cells[4].InnerText = "Reference/Receipt";

            detailTable.Rows.Add(detailRow);

            foreach (region4.ObjectModel.PaymentItem p in attendee.Payments)
            {
                detailRow = new HtmlTableRow();
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells.Add(new HtmlTableCell());

                detailRow.Cells[0].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[1].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[2].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[3].Style.Add("border", "1px solid #c0c0c0");
                detailRow.Cells[4].Style.Add("border", "1px solid #c0c0c0");

                detailRow.Cells[0].InnerText = String.Format("{0:d}", p.timestamp.Date);
                detailRow.Cells[1].InnerText = p.type.Display;
                detailRow.Cells[2].InnerText = String.Format("{0:c}", p.amount);
                detailRow.Cells[3].InnerText = p.status;
                detailRow.Cells[4].InnerHtml = "&nbsp;" + p.reference;

                detailTable.Rows.Add(detailRow);
            }

            row.Cells[0].Controls.Add(detailTable);
            table.Rows.Add(row);
        }

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;

        row.Cells[0].InnerHtml = "<strong><br />Cancellation Policy:</strong><br /> Cancellations must be completed online or sent to <a  href=\"mailto:cancellations@esc5.net?subject=escWorks%20Registration%20Cancellation:%20" + 
            participantName + ",%20" + "Session%20" + attendee.Session.ID.ToString() + ",%20" + title + "\">cancellations@esc5.net</a>. no later than 7 calendar days prior to event for a refund. Phone cancellations are  not accepted. Registrations are transferrable if there is another workshop at a later date. A cancellation fee of $10.00 will be charged if workshop is cancelled 1-6 days prior to event. No refunds for online courses, or nonattendance. Participants will receive a full refund for events cancelled by Region 5 Education Service Center.<br /><br />";

        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";
        row.Cells[0].InnerHtml = String.Format("<br/><b>Questions?</b></br>Manage your <a href=\"{0}\">registrations online</a><br/><br/>",
                            region4.escWeb.SiteVariables.CustomerHostUrl + "shoebox/registration/default.aspx");
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        ;
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "left";
        string docs = String.Format("<br/><b><a href=\"{0}\">4thfloorforguests</a>&nbsp;|&nbsp;",
            region4.escWeb.SiteVariables.CustomerHostUrl + "lib/docs/4thfloorforguests.pdf");

        docs += String.Format("<b><a href=\"{0}\">Directions to Region 5 ESC</a>&nbsp;|&nbsp;",
            region4.escWeb.SiteVariables.CustomerHostUrl + "lib/docs/Directions to Region 5 ESC.pdf");

        docs += String.Format("<b><a href=\"{0}\">Region 5 Parking</a><br/><br/>",
            region4.escWeb.SiteVariables.CustomerHostUrl + "lib/docs/Region 5 Parking.pdf");

        row.Cells[0].InnerHtml = docs;      

        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";
        row.Cells[0].InnerHtml = "&nbsp;";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].ColSpan = 2;
        row.Cells[0].Align = "center";

        row.Cells[0].InnerHtml = String.Format("<br /><br /><img src=\"{0}\" alt=\"Customer Logo\" />", embedLogo ? "cid:escWorksLogo" : pathToRoot + "lib/img/pwrdby_clear.gif");
        table.Rows.Add(row);

        return table;
    }

    public override HtmlTable ReturnConfirmationReport(SortedList<Item, region4.ObjectModel.Attendee> attendees, bool embedLogo)
    {
        //Render HtmlTable
        HtmlTable table = new HtmlTable();
        table.Width = "100%";

        HtmlTableRow row;

        //escWeb.BasePage page = System.Web.HttpContext.Current.CurrentHandler as escWeb.BasePage;
        if (CustomerLogo != null)
        {
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells[0].Align = CustomerLogoAlignment;
            row.Cells[0].InnerHtml = String.Format("<img src=\"{0}\" alt=\"Customer Logo\"/>", embedLogo ? "cid:customerLogo" : pathToRoot + CustomerLogoUrl);
            table.Rows.Add(row);
        }

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].InnerHtml = "<div style=\"font-size: 36pt; color: gray; font-family:Arial; font-style: bold;\">Thank you</div><div style=\"font-size: 32pt; color: black; font-family:Arial;\">&nbsp;&nbsp;for your registration</div>";
        row.Cells[0].Align = "center";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].InnerHtml = String.Format("<br />Thank you for your registration.  This page contains confirmation information that can be used to verify your enrollment in a conference", region4.escWeb.SiteVariables.ObjectProvider.SessionName);
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].InnerHtml = String.Format("<br /><div style=\"font-size: 14pt; font-weight: bold\">Confirmation Number: {0}-{1}-{2} </div>", attendees.Values[0].Session.Event.EventID, attendees.Values[0].Session.ID, attendees.Values[0].ID);
        row.Cells[0].Align = "center";
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());

        row.Cells[0].InnerHtml = String.Format("<br /> <br />This confirmation page verifies that <b>{0} {1}</b> was registered for the conference entitled <b>{2}</b> on <b>{3} {4}</b> ", attendees.Values[0].User.FirstName, attendees.Values[0].User.LastName, attendees.Values[0].Session.Event.Title, attendees.Values[0].RegistrationTime.ToLongDateString(), attendees.Values[0].RegistrationTime.ToShortTimeString());
        table.Rows.Add(row);

        //row = new HtmlTableRow();
        //row.Cells.Add(new HtmlTableCell());
        //row.Cells[0].InnerHtml = String.Format("<div style=\"font-size: 14pt; font-weight: bold\">{0}</div>", attendee.Session.Event.Title);
        //table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].InnerHtml = String.Format("{0}", attendees.Values[0].Session.Event.Description);
        table.Rows.Add(row);

        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());

        HtmlTable detailTable = new HtmlTable();

        foreach (KeyValuePair<Item, region4.ObjectModel.Attendee> pair in attendees)
        {

            HtmlTableRow detailRow = new HtmlTableRow();

            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells[0].ColSpan = 2;

            detailRow.Cells[0].InnerHtml = String.Format("<b>{0}</b>", pair.Value.Session.Subtitle);

            detailTable.Rows.Add(detailRow);

            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());

            detailRow.Cells[0].InnerHtml = String.Format("<b>{0} ID:</b>", region4.escWeb.SiteVariables.ObjectProvider.SessionNameCapitalized);
            detailRow.Cells[1].InnerText = String.Format("{0}", pair.Value.Session.ID);

            detailTable.Rows.Add(detailRow);

            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());

            detailRow.Cells[0].InnerHtml = String.Format("<b>Location:</b>");
           
            
            //detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(pair.Value.Session.Schedule[0].Location.LocationID.ToString()) ? pair.Value.Session.Schedule[0].Location.Name : pair.Value.Session.Schedule[0].Location.Site.SiteID == 38225 ? pair.Value.Session.Schedule[0].Location.Name + ',' + " on the 4th floor of the Edison Plaza building" : pair.Value.Session.Schedule[0].Location.Name);

            //detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(pair.Value.Session.Schedule[0].Location.LocationID.ToString()) ? pair.Value.Session.Schedule[0].Location.Name : pair.Value.Session.Schedule[0].Location.Site.Name, ConfigurationManager.AppSettings["location.rooms.6thfloo4"].Contains(pair.Value.Session.Schedule[0].Location.LocationID.ToString()) ? pair.Value.Session.Schedule[0].Location.Name + ',' + " on the 6th floor of the Edison Plaza building" : pair.Value.Session.Schedule[0].Location.Site.SiteID == 38225 ? pair.Value.Session.Schedule[0].Location.Name + ',' + " on the 4th floor of the Edison Plaza building" : pair.Value.Session.Schedule[0].Location.Name);

            if (ConfigurationManager.AppSettings["location.rooms.nochanged"].Contains(pair.Value.Session.Schedule[0].Location.LocationID.ToString()))

                detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, pair.Value.Session.Schedule[0].Location.Name);


            else if (ConfigurationManager.AppSettings["location.rooms.6thfloo4"].Contains(pair.Value.Session.Schedule[0].Location.LocationID.ToString()))


                detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, pair.Value.Session.Schedule[0].Location.Name + ',' + " on the 6th floor of the Edison Plaza building");


            else if (pair.Value.Session.Schedule[0].Location.Site.SiteID == 38225)


                detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, pair.Value.Session.Schedule[0].Location.Name + ',' + " on the 4th floor of the Edison Plaza building");

            else

                detailRow.Cells[1].InnerText = String.Format("{0}, {1}", pair.Value.Session.Schedule[0].Location.Site.Name, pair.Value.Session.Schedule[0].Location.Name);

            detailTable.Rows.Add(detailRow);

            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());

            detailRow.Cells[0].InnerHtml = String.Format("<b>First Date/Time:</b> ");
            detailRow.Cells[1].InnerText = String.Format("{0:d} from {0:t} to {1:t}", pair.Value.Session.Schedule[0].StartDate, pair.Value.Session.Schedule[0].EndDate);

            detailTable.Rows.Add(detailRow);

            detailRow = new HtmlTableRow();
            detailRow.Cells.Add(new HtmlTableCell());
            detailRow.Cells.Add(new HtmlTableCell());

            detailRow.Cells[0].InnerHtml = String.Format("<b>All Dates:</b> ");
            detailRow.Cells[1].InnerText = String.Format("{0}", pair.Value.Session.ScheduleSummary);

            detailTable.Rows.Add(detailRow);

            if (!String.IsNullOrEmpty(pair.Value.Session.ConfirmationComments))
            {
                detailRow = new HtmlTableRow();
                detailRow.Cells.Add(new HtmlTableCell());
                detailRow.Cells[0].ColSpan = 2;
                detailRow.Cells[0].InnerHtml = String.Format("<b>Confirmation Comments:</b><br />{0}", pair.Value.Session.ConfirmationComments);
                detailTable.Rows.Add(detailRow);
            }
        }
        row.Cells[0].Controls.Add(detailTable);

        table.Rows.Add(row);

        //if (attendee.Payments.Count > 0)
        //{
        //    row = new HtmlTableRow();
        //    row.Cells.Add(new HtmlTableCell());


        //    detailTable = new HtmlTable();
        //    detailTable.Style.Add("border", "dashed black 1px");
        //    detailTable.Align = "center";
        //    detailTable.Width = "75%";

        //    detailRow = new HtmlTableRow();
        //    detailRow.Cells.Add(new HtmlTableCell());
        //    detailRow.Cells[0].ColSpan = 4;
        //    detailRow.Cells[0].InnerHtml = String.Format("<b>Payments Received/Submitted</b><br /><br />The following payment have been received or submitted.");

        //    detailTable.Rows.Add(detailRow);

        //    detailRow = new HtmlTableRow();
        //    detailRow.Cells.Add(new HtmlTableCell());
        //    detailRow.Cells.Add(new HtmlTableCell());
        //    detailRow.Cells.Add(new HtmlTableCell());
        //    detailRow.Cells.Add(new HtmlTableCell());

        //    detailRow.Cells[0].BgColor = "gray";
        //    detailRow.Cells[1].BgColor = "gray";
        //    detailRow.Cells[2].BgColor = "gray";
        //    detailRow.Cells[3].BgColor = "gray";

        //    detailRow.Cells[0].InnerText = "Date Submitted";
        //    detailRow.Cells[1].InnerText = "Payment Type";
        //    detailRow.Cells[2].InnerText = "Amount";
        //    detailRow.Cells[3].InnerText = "Status";

        //    detailTable.Rows.Add(detailRow);

        //    foreach (ObjectModel.PaymentItem p in attendee.Payments)
        //    {
        //        detailRow = new HtmlTableRow();
        //        detailRow.Cells.Add(new HtmlTableCell());
        //        detailRow.Cells.Add(new HtmlTableCell());
        //        detailRow.Cells.Add(new HtmlTableCell());
        //        detailRow.Cells.Add(new HtmlTableCell());

        //        detailRow.Cells[0].InnerText = String.Format("{0}", p.timestamp);
        //        detailRow.Cells[1].InnerText = p.type.Display;
        //        detailRow.Cells[2].InnerText = String.Format("{0:c}", p.amount);
        //        detailRow.Cells[3].InnerText = p.status;


        //        detailTable.Rows.Add(detailRow);
        //    }

        //    row.Cells[0].Controls.Add(detailTable);
        //    table.Rows.Add(row);
        //}


        row = new HtmlTableRow();
        row.Cells.Add(new HtmlTableCell());
        row.Cells[0].Align = "right";

        row.Cells[0].InnerHtml = String.Format("<br /><br /><img src=\"{0}\" alt=\"Customer Logo\" />", embedLogo ? "cid:escWorksLogo" : pathToRoot + "lib/img/pwrdby_clear.gif");
        table.Rows.Add(row);

        return table;
    }

    protected override bool NeedVoucher(List<region4.ObjectModel.Attendee> attendees)
    {
        string[] nonElectronic = { "MO", "CK", "CS" };
        foreach (region4.ObjectModel.Attendee attendee in attendees)
            foreach (region4.ObjectModel.PaymentItem payment in attendee.Payments)
                for (int lcv = 0; lcv < nonElectronic.Length; lcv++)
                    if (nonElectronic[lcv] == payment.type.Code && attendee.Fee > 0)
                        return true;
        return false;
    }
 
}
