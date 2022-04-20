using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace escWeb.tx_r5.ObjectModel
{
    /// <summary>
    /// Summary description for AttendeeInfo
    /// </summary>
    [Serializable]
    public class AttendeeInfo : region4.ObjectModel.AttendeeInfo
    {
        private bool _ondemandAllowReview = false; // Added by VM 4-26-2017
        public bool OndemandAllowReview { get { return _ondemandAllowReview; } } // Added by VM 4-26-2017

        public AttendeeInfo(DataRow reader) : base(reader)
        {
            //
            // TODO: Add constructor logic here
            //
        }

        // Added by VM 4-26-2017
        protected override void LoadCustomerData(DataRow reader)
        {
            _ondemandAllowReview = (bool)reader["ondemandAllowReview"];
            this._PrevSessionID = (int)(reader["PrerequisiteSessionID"] == DBNull.Value ? -1 : reader["PrerequisiteSessionID"]);
            this._PrevSessionIDAttended = (bool)(reader["PrevSessionIDAttended"] == DBNull.Value ? false : reader["PrevSessionIDAttended"]);
        }

        public override void AddOnlineCompleteTile(HtmlTableRowCollection htmlTableRowCollection)
        {
            //Session ID
            HtmlTableRow row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].Attributes.Add("class", "onlineHeading");
            row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Session ID:")));

            row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", SessionID)));
            row.Cells[1].Attributes.Add("class", "onlineContent");

            htmlTableRowCollection.Add(row);
            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            htmlTableRowCollection.Add(row);

            //Title
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].Attributes.Add("class", "onlineHeading");
            row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Session Title:")));

            row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0} - {1}", Title, Subtitle)));
            row.Cells[1].Attributes.Add("class", "onlineContent");

            htmlTableRowCollection.Add(row);
            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            htmlTableRowCollection.Add(row);

            //Credit
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.Cells.Add(new HtmlTableCell());

            row.Cells[0].Attributes.Add("class", "onlineHeading");
            row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Credit:")));
            row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0} {1}", _CreditDisplay, _CreditAmount.ToString())));
            row.Cells[1].Attributes.Add("class", "onlineContent");

            htmlTableRowCollection.Add(row);
            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            htmlTableRowCollection.Add(row);

            if (IsInstructorLedOnline)
            {
                //start date
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Start Date:")));

                row.Cells[1].Attributes.Add("class", "onlineContent");
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", StartDate.ToLongDateString())));

                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);

                //end date
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "End Date:")));

                row.Cells[1].Attributes.Add("class", "onlineContent");
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", EndDate.ToLongDateString())));

                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }
            else if (IsOnDemandOnline)
            {
                //score
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Score:")));

                row.Cells[1].Attributes.Add("class", "onlineContent");
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", _onDemandTotalPoints.ToString())));

                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);

                //complete date
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Completed Date:")));

                row.Cells[1].Attributes.Add("class", "onlineContent");
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", _onDemandcompletedDate.ToString())));

                htmlTableRowCollection.Add(row);

                //OndemandAllowReview
                if (OndemandAllowReview)
                {
                    row.Cells.Add(new HtmlTableCell());

                    Button link = new Button();
                    link.Text = "Review";
                    link.ID = "OpenTraining" + ID.ToString();
                    link.CommandArgument = ID.ToString();
                    link.OnClientClick = String.Format("javascript:OpenTraining('{0}', this); return false;", OnDemandOrgOrAtt);
                    row.Cells[2].Controls.Add(link);
                }


                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }

            else
            {
                //expiration date
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Completed Date:")));

                row.Cells[1].Attributes.Add("class", "onlineContent");
                row.Cells[1].Controls.Add(new LiteralControl(string.Format("{0}", AttendedTimeStamp.ToString())));

                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }


            //BING Comment out Rating
            //this.AddRating(htmlTableRowCollection);

            //Add link
            if (ShowEvaluationLink)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Link:")));

                PlaceHolder pLinks = new PlaceHolder();
                row.Cells[1].Attributes.Add("class", "onlineContent");
                LinkButton link = new LinkButton();
                link.Text = "Evaluation";
                link.CssClass = "link";
                link.ID = "OnlineEvaluation" + ID.ToString();
                link.CommandArgument = ID.ToString();
                //                link.OnClientClick = String.Format(@"javascript:window.open('../evaluation/?registrationId={0}&sessionId={1}', 'Evaluation', 'width=575, height=550, resizable=no, scrollbars=no, status=no, menubar=no'); return false;", ID, SessionID);
                link.OnClientClick = String.Format(@"javascript:window.open('../evaluation/?registrationId={0}&sessionId={1}&certificateId={2}', 'Evaluation', 'width=700, height=650, resizable=no, scrollbars=no, status=no, menubar=no');return false;", ID, SessionID, this.CertificateID);
                AddLink(pLinks, link);
                AddOnlineCustomerLinks(pLinks);
                row.Cells[1].Controls.Add(pLinks);
                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }
            else if (ShowCertificateLink)
            {
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                row.Cells.Add(new HtmlTableCell());

                row.Cells[0].Attributes.Add("class", "onlineHeading");
                row.Cells[0].Controls.Add(new LiteralControl(string.Format("<b>{0}</b>", "Link:")));

                PlaceHolder pLinks = new PlaceHolder();
                row.Cells[1].Attributes.Add("class", "onlineContent");
                LinkButton link = new LinkButton();
                link = new LinkButton();
                link.Text = "Certificate";
                link.CssClass = "link";
                link.ID = "OnlineCertificate" + ID.ToString();
                //                link.CommandArgument = ID.ToString();
                link.CommandArgument = ID.ToString() + "|" + this.CertificateID.ToString();
                link.Click += new EventHandler(certificateLink_Click);
                AddLink(pLinks, link);
                AddOnlineCustomerLinks(pLinks);
                row.Cells[1].Controls.Add(pLinks);

                htmlTableRowCollection.Add(row);
                //space
                row = new HtmlTableRow();
                row.Cells.Add(new HtmlTableCell());
                htmlTableRowCollection.Add(row);
            }

            //space
            row = new HtmlTableRow();
            row.Cells.Add(new HtmlTableCell());
            row.BgColor = "#909090";
            row.Cells[0].ColSpan = 2;
            htmlTableRowCollection.Add(row);

        }
    }
}