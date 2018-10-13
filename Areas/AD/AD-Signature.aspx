<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AD-Signature.aspx.cs" Inherits="Areas_AD_AD_Signature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div id ="alertDivID" runat="server" visible="false" class="alert alert-dismissible alert-success">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <asp:Label ID="alertLabelID" runat="server"  Visible="false"></asp:Label>
            </div>
     <div id ="alertDivError" runat="server" visible="false" class="alert alert-dismissible alert-danger">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <asp:Label ID="alertlabelError" runat="server"  Visible="false"></asp:Label>
            </div>

       <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Use a local account to connect to pull AD Details</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="UserName" CssClass="col-md-2 control-label">User name</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="UserName" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="UserName"
                                CssClass="text-danger" ErrorMessage="The user name field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                            
                        </div>
                    </div>
               
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button ID="Button1" runat="server" OnClick="LogIn" Text="Generate From AD" CssClass="btn btn-info" />
                        </div>
                    </div>
                </div>
             
            </section>
        </div>

        <div class="col-md-4">
            <section id="socialLoginForm">
            </section>
        </div>
    </div>
</asp:Content>

