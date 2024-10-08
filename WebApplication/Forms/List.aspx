<%@ Page Title="Submissions" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="WebApplication.Forms.List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Submissions</h1>
    <div class="table-responsive">
        <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" CssClass="table table-striped" OnRowCommand="gvSubmissions_RowCommand">
            <Columns>

                <asp:TemplateField HeaderText="First Name">
                    <ItemTemplate>
                        <span aria-label='<%# "First Name: " + Eval("FirstName") %>'>
                            <%# Eval("FirstName") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Last Name">
                    <ItemTemplate>
                        <span aria-label='<%# "Last Name: " + Eval("LastName") %>'>
                            <%# Eval("LastName") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <span aria-label='<%# "Email: " + Eval("Email") %>'>
                            <%# Eval("Email") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Level of Study">
                    <ItemTemplate>
                        <span aria-label='<%# "Level of Study: " + Eval("LevelOfStudyDisplay") %>'>
                            <%# Eval("LevelOfStudyDisplay") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Disability Type">
                    <ItemTemplate>
                        <span aria-label='<%# "Disability type: " + Eval("DisabilityTypesDisplay") %>'>
                            <%# Eval("DisabilityTypesDisplay") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Additional Requirements">
                    <ItemTemplate>
                        <span aria-label='<%# "Additional Accessibility Requirements: " + Eval("AdditionalAccessibilityRequirements") %>'>
                            <%# Eval("AdditionalAccessibilityRequirements") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnView" runat="server" Text="View" CommandName="View" 
                                    CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary"
                                    aria-label='<%# "View details for " + Eval("FirstName") + " " + Eval("LastName") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>



</asp:Content>
