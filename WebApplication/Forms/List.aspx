<%@ Page Title="Submissions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication.Forms.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Submissions</h1>
    
    <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-striped">
        <Columns>
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />

            <asp:BoundField DataField="LastName" HeaderText="Last Name" />

            <asp:BoundField DataField="Email" HeaderText="Email" />

            <asp:BoundField DataField="LevelOfStudyDisplay" HeaderText="Level of Study" />

            <asp:TemplateField HeaderText="Disability Type">
                <ItemTemplate>
                    <asp:Label ID="lblDisabilityTypes" runat="server" Text='<%# Eval("DisabilityTypesDisplay") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="AdditionalAccessibilityRequirements" HeaderText="Additional Requirements" />

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
