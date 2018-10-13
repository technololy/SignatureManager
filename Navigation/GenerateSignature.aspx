<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="GenerateSignature.aspx.cs" Inherits="Navigation_GenerateSignature" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <asp:Label ID="lblFName" runat="server" Text="First Name"></asp:Label>
            </div>
            <div class="col-md-6">
               <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblLName" runat="server" Text="Last Name"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>                                
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblBranch" runat="server" Text="Branch"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlBranch" runat="server" DataTextField="Branch_name" DataValueField="branch_id"></asp:DropDownList>

            </div>
            <div class="col-md-6">
                <asp:Label ID="lblGroup" runat="server" Text="Group"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlGroup" runat="server" DataTextField="group_name" DataValueField="id"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblUnit" runat="server" Text="Unit"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:DropDownList ID="ddlUnit" runat="server" DataTextField="function_name" DataValueField="id"></asp:DropDownList>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblCugg" runat="server" Text="CUG"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtCug" runat="server"></asp:TextBox> 
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblPhone" runat="server" Text="Direct Line"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
             <asp:Label ID="LblExtn" runat="server" Text="Office Extension"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtExt" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <asp:Label ID="lblMob" runat="server" Text="Mobile Phone"></asp:Label>
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="txtMob" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-12">
                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-success" Text="Generate Signature" OnClick="btnGenerate_Click" />
            </div>
            <br />
            <br />
            <br />
            <br />


            <asp:Panel ID="Panel1" runat="server">
                <div class="container">
                    <div class="row">
                        <div>
                            <asp:Label ID="lblSetFirstName" runat="server" Text="lblFirstNameSet" Font-Size="16pt"></asp:Label>&nbsp;<asp:Label ID="lblSetLastName" runat="server" Text="lblLAstNameSet" Font-Size="16pt"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblUnitFunction" runat="server" Text="lblSetUnit" Font-Size="10pt"></asp:Label>,&nbsp;<asp:Label ID="lblGroupFunction" runat="server" Text="lblGroupSet" Font-Size="10pt"></asp:Label>
                
                        </div >                        
                            <hr style="color: #FF0000"/> 
                        <div>
                            <asp:Label ID="lblSterlingbank0" runat="server" Text="Sterling Bank PLC" Font-Size="10pt"></asp:Label>
                        </div>
                        <div>
                             <asp:Label ID="lblAddress" runat="server" Text="lblSetAddress" Font-Size="10pt"></asp:Label> 
                        </div>
                        <div>
                            CUG:<asp:Label ID="lblCug" runat="server" Text="lblSetCug" Font-Size="11pt"></asp:Label>|&nbsp; |Mobile:<asp:Label ID="lblSetMobile" runat="server" Text="lblSetMobile" Font-Size="10pt"></asp:Label>
                            <div>
                                DL:<asp:Label ID="lblTel" runat="server" Text="lblSetTel" Font-Size="10pt"></asp:Label>|Ext:<asp:Label ID="lblSetExt" runat="server" Text="lblSetExt" Font-Size="10pt"></asp:Label>|Web: www.sterlingbankng.com
                            </div>
                        </div>
                                           

                    </div>
                </div>
                <br />
                <br />
               

                <asp:Button ID="BtnDownload" runat="server" CssClass="btn btn-info" Text="Download Template" OnClick="BtnDownload_Click" />
                <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-danger" OnClick="btnEdit_Click" Text="Edit Signature" />

            </asp:Panel>


        </div>

    </div>
</asp:Content>

