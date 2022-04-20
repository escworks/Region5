<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="shoebox_account_signup"
    MasterPageFile="~/MasterPage.master" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content runat="server" ContentPlaceHolderID="mainBody">
    <asp:Panel runat="server" ID="pFirst">
    <asp:Label ID="lbErrorMessage" CssClass="error" runat="server"></asp:Label>
        <table width="75%" class="mainBody">
            <tr>
                <td colspan="3">
                    <strong><asp:Label ID="PrimaryEmaildLabel"
            text="Primary Email:"
            AssociatedControlID="txtPrimaryEmail"
            runat="server"></asp:Label></strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtPrimaryEmail" runat="server" Width="278px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPrimaryEmail"
                        CssClass="error" Display="Dynamic" ErrorMessage="RequiredFieldValidator" SetFocusOnError="True">Primary Email is required</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SecondaryEmaildLabel"
            text="Secondary Email:"
            AssociatedControlID="txtSecondaryEmail"
            runat="server"></asp:Label></strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtSecondaryEmail" runat="server" Width="276px" CssClass="formInput" /></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SalutationLabel"
            text="Salutation:"
            AssociatedControlID="ddlSalutation"
            runat="server"></asp:Label></strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="formInput">
                    </asp:DropDownList><br />
                </td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="LastNameLabel"
            text="Last Name:"
            AssociatedControlID="txtLastName"
            runat="server"></asp:Label></strong></td>
                <td valign="top">
                    <strong><asp:Label ID="FirstNameLabel"
            text="First Name:"
            AssociatedControlID="txtFirstName"
            runat="server"></asp:Label></strong>
                </td>
                <td valign="top">
                    <strong><asp:Label ID="MiddleNameLabel"
            text="Middle Name:"
            AssociatedControlID="txtMiddleName"
            runat="server"></asp:Label>
</strong></td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <asp:TextBox ID="txtLastName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                        CssClass="error" ErrorMessage="Last Name is required"></asp:RequiredFieldValidator></td>
                <td valign="top">
                    <asp:TextBox ID="txtFirstName" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFirstName"
                        CssClass="error" ErrorMessage="First Name is required"></asp:RequiredFieldValidator></td>
                <td style="height: 45px" valign="top">
                    <asp:TextBox ID="txtMiddleName" runat="server" CssClass="formInput" /></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="HomeAddressLabel"
            text="Home Address:"
            AssociatedControlID="txtHomeAddress"
            runat="server"></asp:Label></strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:TextBox ID="txtHomeAddress" runat="server" Width="250px" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtHomeAddress"
                        CssClass="error" ErrorMessage="Home Address is required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="CityLabel"
            text="City:"
            AssociatedControlID="txtCity"
            runat="server"></asp:Label></strong></td>

                <td colspan="1" valign="top">
                    <strong><asp:Label ID="StateLabel"
            text="State:(2 letter Abbrev)"
            AssociatedControlID="ddState"
            runat="server"></asp:Label></strong></td>

                <td colspan="1" valign="top">
                    <strong><asp:Label ID="ZipLabel"
            text="ZIP:"
            AssociatedControlID="txtZip"
            runat="server"></asp:Label></strong></td>

            </tr>
            <tr>
                <td style="width: 158px; height: 45px;" valign="top">
                    <asp:TextBox ID="txtCity" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity"
                        CssClass="error" ErrorMessage="City is required"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:DropDownList ID="ddState" runat="server" CssClass="formInput">
                    </asp:DropDownList><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddState"
                        CssClass="error" ErrorMessage="State is required"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtZip" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip"
                        CssClass="error" ErrorMessage="Zip is required"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 158px" valign="top">
                    <strong><asp:Label ID="HomePhoneLabel"
            text="Home Phone:"
            AssociatedControlID="txtHomePhone"
            runat="server"></asp:Label></strong></td>

                <td colspan="1" valign="top">
                    <strong><asp:Label ID="WorkPhoneLabel"
            text="Work Phone:"
            AssociatedControlID="txtworkPhone"
            runat="server"></asp:Label></strong></td>

                <td colspan="1" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 158px; height: 45px" valign="top">
                    <asp:TextBox ID="txtHomePhone" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtHomePhone"
                        CssClass="error" ErrorMessage="Home Phone is required"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtWorkPhone" runat="server" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtWorkPhone"
                        CssClass="error" ErrorMessage="Work Phone is required"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong>
                        <asp:Label ID="OrganizationLabel"
                         text=<%# region4.escWeb.SiteVariables.ObjectProvider.OrganizationNameCapitalized %>
                         AssociatedControlID="ddlRegion"
                        runat="server"></asp:Label>   
                        :</strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlRegion" runat="server" CssClass="formInput" />
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegion"
                        CssClass="error" ErrorMessage="Region is a required field"></asp:RequiredFieldValidator>
                    <cc1:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="ddlRegion" Category="Org" PromptText="Please select a region..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetRegions" />
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="DistrictLabel"
            text=<%# region4.escWeb.SiteVariables.ObjectProvider.SiteNameCapitalized %>
                        AssociatedControlID="ddlDistrict"
            runat="server"></asp:Label>
                        :</strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="formInput" />
                    <br />
                    <cc1:CascadingDropDown ID="CascadingDropDown2" runat="server" TargetControlID="ddlDistrict" ParentControlID="ddlRegion" PromptText="Please select a district..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetDistrictsForRegion" Category="Site" />
                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="SchoolLabel"
            text=<%# region4.escWeb.SiteVariables.ObjectProvider.SchoolNameCapitalized %>
                        AssociatedControlID="ddlSchool"
            runat="server"></asp:Label>

                        :</strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlSchool" runat="server" CssClass="formInput" /><br />
                    <cc1:CascadingDropDown ID="CascadingDropDown3" runat="server" TargetControlID="ddlSchool" ParentControlID="ddlDistrict" PromptText="Please select a school..." ServicePath="~/services/locationservice.asmx" ServiceMethod="GetSchoolsFromDistricts" Category="Room" />
                    <%--<asp:RangeValidator ID="RangeValidator3" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%></td>
            </tr>
               <tr>
                <td  colspan="3" valign="top">
                    <strong><asp:Label ID="AccommodationsLabel"
            text="Required Accommodations:"
            AssociatedControlID="txtSpecialNeeds"
            runat="server"></asp:Label></strong>
                </td>
            </tr>
             <tr>
                <td style="height: 45px" valign="top" colspan="3">
                    <asp:TextBox ID="txtSpecialNeeds" runat="server" CssClass="formInput" Width="510px"/><br />
                </td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <strong><asp:Label ID="PositionLabel"
            text="Position:"
            AssociatedControlID="ddlPosition"
            runat="server"></asp:Label>
</strong></td>
            </tr>
            <tr>
                <td colspan="3" valign="top">
                    <asp:DropDownList ID="ddlPosition" runat="server" CssClass="formInput">
                    </asp:DropDownList><br />
                    <%--<asp:RangeValidator ID="RangeValidator4" runat="server" ErrorMessage="RangeValidator"></asp:RangeValidator>--%></td>
            </tr>
            <%--<tr>
            <td colspan="3" valign="top">
            <strong><label for="ddlGradeLevel">Grade Level:</label></strong>
            </td>
            </tr>
            <tr>
            <td colspan="3" valign="top">
            <asp:DropDownList runat="server" ID="ddlGradeLevel" CssClass="formInput" />
            </td>
            </tr>--%>
            <tr>
                <td colspan="3" valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 158px" valign="top">
                    <strong><asp:Label ID="PasswordLabel"
            text="Password:"
            AssociatedControlID="txtPassword"
            runat="server"></asp:Label></strong></td>
                <td colspan="1" valign="top">
                    <strong><asp:Label ID="PassConfirmLabel"
            text="Confirm Password:"
            AssociatedControlID="txtConfirmPassword"
            runat="server"></asp:Label></strong></td>
                <td colspan="1" valign="top">
                </td>
            </tr>
            <tr>
                <td colspan="1" style="width: 158px; height: 45px;" valign="top">
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="formInput" /><br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Password is required" ControlToValidate="txtPassword" CssClass="error"></asp:RequiredFieldValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="formInput" /><br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" CssClass="error"
                        ErrorMessage="Password must match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword"></asp:CompareValidator></td>
                <td colspan="1" style="height: 45px" valign="top">
                </td>
            </tr>
        </table>
        
        <br />
        <br />
        <asp:Button runat="server" ID="btnSubmit" Text="Save Record" />
    </asp:Panel>
    <asp:Panel runat="server" ID="pSuccess" Visible="false">
        Your account has been created. <a href="~/default.aspx" runat="server" class="link">
            Please click here to continue</a>
    </asp:Panel>
</asp:Content>
