<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="row" aria-labelledby="defaultTitle">
            <h1 id="defaultTitle">Technical Test Web Application</h1>
            <p class="lead">Submit new registration applications and manage submitted applications.</p>
        </section>
        <div class="row">
            <div class="col-6">
                <div class="card" aria-labelledby="submitApplication">
                    <div class="card-body">
                        <h3 id="submitApplication" class="card-title">Submit an application</h3>
                        <p class="card-text">Fill out the form details and submit an application.</p>
                        <a href="/Forms/Registration" class="btn btn-primary">Go there</a>
                    </div>
                </div>
            </div>
            <div class="col-6">
                <div class="card" aria-labelledby="reviewApplication">
                    <div class="card-body">
                        <h3 id="reviewApplication" class="card-title">Review submissions</h3>
                        <p class="card-text">Review submitted applications and form details.</p>
                        <a href="/Forms/List" class="btn btn-primary">Go there</a>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
