<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"
    MasterPageFile="~/MasterPage.master" %>

<%@ Register TagPrefix="ucontrol" TagName="UploadFile" Src="~/lib/Controls/UploadFile.ascx" %>
<asp:Content runat="server" ID="content1" ContentPlaceHolderID="mainBody">

    <%--<link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick-theme.min.css" rel="stylesheet" />--%>
     <link type="text/css" rel="stylesheet" href="~/lib/css/escWorksStyle.css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.5.8/slick.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.ad-items').slick({
                slidesToShow: 1,
                slidesToScroll: 1,
                autoplay: true,
                autoplaySpeed: 4000
            });
        });
    </script>

    <script language="javascript" type="text/javascript">
        if (typeof String.prototype.trim != 'function') { // detect native implementation
            String.prototype.trim = function () {
                return this.replace(/^\s+/, '').replace(/\s+$/, '');
            };
        }

        function FindSession() {
            var mSession = document.aspnetForm.findSession.value.trim();

            if (mSession.length < 1) {
                alert("Please type " + '<%# region4.escWeb.SiteVariables.ObjectProvider.SessionName %>' + " ID or Keyword");
                document.aspnetForm.findSession.focus();
                return;
            }
            if (isNaN(mSession))
                top.location.href = "search.aspx?SearchCriteria=" + mSession;
            else
                top.location.href = "./catalog/session.aspx?session_id=" + mSession;
        }
    </script>
    <div id="pageheader">
        <h1><span class="pageheadertxt">Welcome to Professional Development Online Registration</span></h1>
    </div>
    <div style="float: right; width: 784px; margin-bottom: 5px;">
        <div id="searchbox">
            <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
                <h2> <label for="Text1"> Search by Session ID or Keyword </label></h2><input type="text" name="findSession" id="Text1" />

                <asp:Button runat="server" ID="btnSearch" OnClientClick="FindSession();return false;"
                    Text="submit" />
                <br />
            </asp:Panel>
        </div>
    </div>
    <div style="float: right; width: 784px; border: 1px solid #000000; ">
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: #FAFAFA;">
            <tr>
                <td width="70%">
                    <table border="0" cellpadding="16" cellspacing="0" width="550px">
                        <tr>
                            <td colspan="2">
                              <%--  <iframe frameborder="0" width="450" height="300" id="iFrameBanner" src="swf_files/advertisement.html">
                                </iframe>--%>
                                <div class="ad-items" id="divAdItems" runat="server" style="width: 500px; height: 362px">
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" width="100%">
                                <table>
                                    <tr>
                                        <td valign="top" width="100%">
                                            <a href="about/contact.aspx" style="text-decoration: underline; color: #1611FF;"><font
                                                size="3" color="#1611FF"><b>Contact Us</b></font></a>
                                            <br />
                                            <span style="font-size: 9pt;">If you are experiencing errors, having difficulties finding an event, or have registered with more than one email address, please call (409) 951-1889 or send an email to <a href="mailto:accounts@esc5.net">accounts@esc5.net</a></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <ucontrol:UploadFile ID="UploadFile1" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td valign="top">
                    <br />
                    <h3><escWorks:UpcomingEvents runat="server" ID="UpcomingEvents1" ItemsToDisplay="10" /></h3>
                </td>
            </tr>
        </table>
        <br />
    </div>
    <script type="text/javascript" src="lib/js/swfobject.js"> 
    </script>
</asp:Content>
