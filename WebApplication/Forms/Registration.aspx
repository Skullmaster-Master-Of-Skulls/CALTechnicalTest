<%@ Page Title="Registration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication.Forms.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Register with CAL</h1>
    <p>Please complete the form below and click the 'Submit' button when you are done. The 'Submit' button is located at the very bottom of this page.</p>

    <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Please correct the following errors:" CssClass="text-danger" />

    <fieldset>
        <legend>Personal Information</legend>
        
        <!-- First Name (Required; Text input) -->
        <asp:Label AssociatedControlID="txtFirstName" Text="First Name (Required): " runat="server" />
        <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name is required" CssClass="text-danger" />

        <br />

        <!-- Last Name (Required; Text input) -->
        <asp:Label AssociatedControlID="txtLastName" Text="Last Name (Required): " runat="server" />
        <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name is required" CssClass="text-danger" />

        <br />

        <!-- Email (Required; Text email input) -->
        <asp:Label AssociatedControlID="txtEmail" Text="Email (Required): " runat="server" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" />
        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email is required" CssClass="text-danger" />
        <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationExpression="^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$" ErrorMessage="Invalid email format" CssClass="text-danger" />

        <br />

        <!-- Preferred Pronouns (Dropdown list or radio buttons) -->
        <asp:Label AssociatedControlID="ddlPreferredPronoun" Text="Preferred Pronouns: " runat="server" />
        <asp:DropDownList ID="ddlPreferredPronoun" runat="server" CssClass="small-dropdown">
            <asp:ListItem Text="He/Him" Value="He/Him"></asp:ListItem>
            <asp:ListItem Text="She/Her" Value="She/Her"></asp:ListItem>
            <asp:ListItem Text="They/Them" Value="They/Them"></asp:ListItem>
            <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
        </asp:DropDownList>

        <br /><br />

        <!-- Level of Study (Required; Radio buttons) -->
        <fieldset aria-labelledby="lblLevelOfStudy">
            <legend id="lblLevelOfStudy">Level of Study (Required):</legend>
            <asp:RadioButtonList ID="rblLevelOfStudy" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                <asp:ListItem Text="High school graduate" Value="HighSchoolGraduate" />
                <asp:ListItem Text="Undergraduate" Value="Undergraduate" />
                <asp:ListItem Text="Graduate" Value="Graduate" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rfvLevelOfStudy" runat="server" ControlToValidate="rblLevelOfStudy" InitialValue="" ErrorMessage="Please select a level of study" CssClass="text-danger" />
        </fieldset>
      </fieldset>
        <br />
      <fieldset>
        <!-- International Student Status (Required; Radio buttons) -->
        <fieldset aria-labelledby="lblInternationalStatus">
            <legend id="lblInternationalStatus">International Student Status (Required):</legend>
            <asp:RadioButtonList ID="rblInternationalStatus" runat="server" RepeatDirection="Vertical" RepeatLayout="Flow">
                <asp:ListItem Text="International Student" Value="true" />
                <asp:ListItem Text="Domestic Student" Value="false" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rfvInternationalStatus" runat="server" ControlToValidate="rblInternationalStatus" InitialValue="" ErrorMessage="Please select your international status." CssClass="text-danger" />
        </fieldset>

        <br />

        <!-- Disability Information (Required; Checkboxes) -->
        <fieldset aria-labelledby="lblDisabilityInfo">
            <legend id="lblDisabilityInfo">Disability Information (Required):</legend>
            <asp:CheckBoxList ID="cblDisabilityType" runat="server" RepeatLayout="Flow">
                <asp:ListItem Text="ADHD" Value="1" />
                <asp:ListItem Text="Autism" Value="2" />
                <asp:ListItem Text="Chronic illness" Value="3" />
                <asp:ListItem Text="Deaf or hard of hearing" Value="4" />
                <asp:ListItem Text="Learning disability" Value="5" />
                <asp:ListItem Text="Mental health" Value="6" />
                <asp:ListItem Text="Neurological" Value="7" />
                <asp:ListItem Text="Physical or mobility" Value="8" />
                <asp:ListItem Text="Vision" Value="9" />
                <asp:ListItem Text="Other" Value="10" />
            </asp:CheckBoxList>
        </fieldset>


        <asp:CustomValidator ID="cvDisabilityType" runat="server" 
            ErrorMessage="Please select at least one disability type" 
            OnServerValidate="cvDisabilityType_ServerValidate" 
            CssClass="text-danger" />
        <br /><br />



        <!-- Additional Accessibility Requirements (Multiline Text Area) -->
        <asp:Label AssociatedControlID="txtAccessibilityReq" Text="Additional Accessibility Requirements:" runat="server" />
        <asp:TextBox ID="txtAccessibilityReq" runat="server" TextMode="MultiLine" Rows="5" CssClass="form-control" />

    </fieldset>
    <br />

    <fieldset>
        <legend>Consent</legend>

        <!-- Consent Information (Text paragraph) -->
        <p>By submitting this form, you consent to the collection and processing of the provided information in accordance with our privacy policy.</p>

        <!-- Full Name (Text input) -->
        <asp:Label AssociatedControlID="txtConsentFullName" Text="Full Name (Required):" runat="server" />
        <asp:TextBox ID="txtConsentFullName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvConsentFullName" runat="server" ControlToValidate="txtConsentFullName" ErrorMessage="Full name is required" CssClass="text-danger" />

        <br />

        <!-- Confirm Full Name (Text input) -->
        <asp:Label AssociatedControlID="txtConfirmConsentFullName" Text="Confirm Full Name (Required):" runat="server" />
        <asp:TextBox ID="txtConfirmConsentFullName" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator ID="rfvConfirmConsentFullName" runat="server" ControlToValidate="txtConfirmConsentFullName" ErrorMessage="Please confirm your full name" CssClass="text-danger" />
        <asp:CompareValidator ID="cvConfirmFullName" runat="server" ControlToValidate="txtConfirmConsentFullName" ControlToCompare="txtConsentFullName" ErrorMessage="Full names do not match" CssClass="text-danger" />
        
        <asp:CustomValidator ID="cvCheckFullName" runat="server" ControlToValidate="txtConsentFullName" 
            OnServerValidate="ValidateFullNameMatch" ErrorMessage="The entered full name must match your first and last name." CssClass="text-danger" />
    </fieldset>

    <!-- Submit Button -->
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-primary" />
    
</asp:Content>
