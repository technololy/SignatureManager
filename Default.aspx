<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>EMAIL SIGNATURE MANAGER</h1>
        <p class="lead">This application is used to generate Email Signature to attach to Microsoft Outlook, Mozilla Thunderbird and web mails.</p>
        <p><a href="#" class="btn btn-primary btn-large">First of all, Go down low &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Click Here to</h2>
            <p>
                Generate Email Signature via Active Directory
            </p>
            <p>
                <a class="btn btn-danger" href="Areas/AD/AD-Signature.aspx">Click Here To Begin &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Click Here to...</h2>
            <p>
                Generate Email Signature by inputting into fields</p>
            <p>
                <a class="btn btn-success" href="#">Click Here To Begin &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Click here to</h2>
            <p>
               Generate Office 365 Email signatures that auto attaches itself on the cloud
            </p>
            <p>
                <a class="btn btn-info" href="#">Click Here To Begin &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
