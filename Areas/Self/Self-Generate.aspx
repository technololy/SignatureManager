<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Self-Generate.aspx.cs" Inherits="Areas_Self_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <script src="../../Scripts/jquery-1.10.2.js"></script>
        <script src="../../Content/chosen_v1.7.0/chosen.jquery.js"></script>
    <link href="../../Content/chosen_v1.7.0/chosen.css" rel="stylesheet" />
    <script type="text/javascript">
        $(document).ready(function () {           
            $(".chosen-select").chosen({ disable_search_threshold: 10 });
        });
    </script>
     
    <div class="#jumbotron">
        <div class="container">
            <br />
        <div id ="alertDivID" runat="server" visible="false" class="alert alert-dismissible alert-success">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <asp:Label ID="alertLabelID" runat="server" ></asp:Label>
            </div>    
                <div id ="alertDivError" runat="server" visible="false" class="alert alert-dismissible alert-danger">
                <button type="button" class="close" data-dismiss="alert">&times;</button>
                <asp:Label ID="Label1" runat="server" ></asp:Label>
            </div>  
    <fieldset>
        <legend>BEGIN BY FILLING THE TEXT BOX AND CLICK PREVIEW BUTTON</legend>
    </fieldset>
            <br />
            <asp:Panel ID="pnlEnterDetails" Visible="false" runat="server">
            <div class="form-horizontal">
            <div class="form-group">
                <div class="row">
                    <label for="lblFName" class="col-lg-2 control-label"> First Name</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtFName"  CssClass="form-control" runat="server"></asp:TextBox>

                </div>
                    <label for="lblLName" class="col-lg-2 control-label">Last Name</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtLName" CssClass="form-control"  runat="server"></asp:TextBox>
                    
                </div>
                </div>
                
            </div>
         
                        <div class="form-group">
                            <div class="row">
                                <label for="lblBranch" class="col-lg-2 control-label">branch</label>
                <div class="col-lg-4">

                    <div class="col-lg-4">
                                    <asp:DropDownList ID="ddlBranch" runat="server" NoResultsText="No results match." width="350px" DataTextField="BranchName" CssClass="form-control chosen-select" DataValueField="branchCode"       DataPlaceHolder="Type Here..." AllowSingleDeselect="true">          
        </asp:DropDownList>
                        </div>
                </div>
                                <label for="lblGroup" class="col-lg-2 control-label">Group</label>
                <div class="col-lg-4">
                    <%--<asp:TextBox ID="txtAgencyCode" CssClass="form-control" runat="server"></asp:TextBox>--%>
                        <asp:DropDownListChosen ID="ddlGroup" runat="server" NoResultsText="No results match." width="350px" DataTextField="groupname" DataValueField="id"       DataPlaceHolder="Type Here Now..." AllowSingleDeselect="true">          
        </asp:DropDownListChosen>

                </div>


                            </div>
                
            </div>
                       
                        <div class="form-group">
                            <div class="row">
                                <label for="lblUnit" class="col-lg-2 control-label">Unit</label>
                <div class="col-lg-4">

                   <asp:DropDownListChosen ID="ddlUnit" runat="server" NoResultsText="No results match." width="350px" DataTextField="function_name" DataValueField="id"  DataPlaceHolder="Type Here Searches Automatically..." AllowSingleDeselect="true">          
        </asp:DropDownListChosen>
                </div>


                                <label for="lblcug" class="col-lg-2 control-label">CUG</label>
                <div class="col-lg-4">
<asp:TextBox ID="txtCug" CssClass="form-control" runat="server"></asp:TextBox> 


                </div>
                            </div>
                
            </div>

               <div class="form-group">
<div class="row">
                <label for="Client ID" class="col-lg-2 control-label">Direct Line</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>

                </div>

    <label for="Client ID" class="col-lg-2 control-label">Mobile Number</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtMob" CssClass="form-control"  runat="server"></asp:TextBox>
                    
                </div>
</div>
    
            </div>
         <div class="form-group">
             <div class="row">
                 <label for="Client ID" class="col-lg-2 control-label">Extension</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtExt"  CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>
                 <%-- <label for="Client ID" class="col-lg-2 control-label">Response Generating WebGUID</label>
                <div class="col-lg-4">
                    <asp:TextBox ID="txtWebGuidResponse" CssClass="form-control" runat="server"></asp:TextBox>
                    
                </div>--%>
             </div>

         </div>
                <div class="form-group">
                    <div class="row">
                        <label for="Client ID" class="col-lg-2 control-label"></label>
                        <div class="col-lg-8">
                    <asp:Button ID="btnGenerate" CssClass="btn btn-danger" runat="server" Text="Click Here to Preview  Signature" OnClick="btnGenerate_Click" />
                            </div>
                        </div>
                </div>
       </div>
      </asp:Panel>
    <asp:Panel ID="Panel1" runat="server">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <br />
        <table>
            <tr>
                <td style="text-align: center">
                    <asp:Button ID="BtnDownload" runat="server" CssClass="btn btn-success" Text="Download And Append to Outlook" OnClick="BtnDownload_Click" />
                </td>
                <td>

                    <asp:Button ID="btnEdit" Enabled="false" CssClass="btn btn-danger" runat="server" OnClick="btnEdit_Click" Text="Edit Signature" />

                </td>
            </tr>
            
        </table>

            </asp:Panel>
       </div>
      <asp:Panel ID="Panel2" Visible="false" runat="server">
      <div class="nothing">
         <table>
                    <tr>
                        <td style="font-size: 21px; font-weight: bold; text-transform: capitalize; font-family: Arial, Helvetica, sans-serif;">
                            <asp:Label ID="lblSetFirstName" CssClass="form-control" runat="server" Text="lblFirstNameSet" Font-Size="16pt"></asp:Label>&nbsp;<asp:Label ID="lblSetLastName" runat="server" Text="lblLAstNameSet" Font-Size="16pt"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td style=" font-size: 15px; text-transform: capitalize; font-family: Arial, Helvetica, sans-serif;">
                            <asp:Label ID="lblUnitFunction" CssClass="form-control" runat="server" Text="lblSetUnit" Font-Size="10pt"></asp:Label>,&nbsp;<asp:Label ID="lblGroupFunction" runat="server" Text="lblGroupSet" Font-Size="10pt"></asp:Label>
                
                        </td>
                    </tr>
                </table>
              <%--  <div style="font-size: medium; font-weight: bold; text-transform: capitalize">
                    
                <br />
                
                    
                </div>--%>
                <div>
                <table>
                    <tr>
                        <td style="width: 700px; color: #FF0000;">
                            <hr style="color: #FF0000"/>
                        </td>
                    </tr>
                </table>
                    </div>
                <div>
                  
                    <table class="auto-style1" style="width: 700px; font-family: Arial, Helvetica, sans-serif;">
                        <tr>
                            <td style="font-size: medium; font-weight: bold" class="auto-style6" >
                                  <asp:Label ID="lblSterlingbank0" runat="server" Text="Sterling Bank PLC" Font-Size="10pt"></asp:Label></td>
                            <td rowspan="4" class="auto-style4" style="text-align: right"><img src="http://10.0.41.183/emailsignature/temp/sterlinglogo3.png" /></td>
                        </tr>
                        <tr>
                            <td class="auto-style6">
                               <asp:Label ID="lblAddress" runat="server" Text="lblSetAddress" Font-Size="10pt"></asp:Label> 
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6" style="font-size: 10pt">
                               CUG:<asp:Label ID="lblCug" runat="server" Text="lblSetCug" Font-Size="11pt"></asp:Label>|&nbsp; |Mobile:<asp:Label ID="lblSetMobile" runat="server" Text="lblSetMobile" Font-Size="10pt"></asp:Label>
                            </td>
                            
                        </tr>
                        <tr>
                            <td class="auto-style6" style="font-size: 10pt">
                                DL:<asp:Label ID="lblTel" runat="server" Text="lblSetTel" Font-Size="10pt"></asp:Label>|Ext:<asp:Label ID="lblSetExt" runat="server" Text="lblSetExt" Font-Size="10pt"></asp:Label>|Web: www.sterlingbankng.com</td>
                            
                        </tr>
                    </table>
                    <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                </div>
    </div>
           <table>
            <asp:Panel ID="Panel3" Visible="false" runat="server">
             <tr>
                <td><asp:Label ID="dd" CssClass="form-control"  runat="server" Text="First Name"></asp:Label></td>
                <td><asp:TextBox ID="ddddd" CssClass="form-control"  runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="ddd" CssClass="form-control"  runat="server" Text="Last Name"></asp:Label></td>
                
            </tr>
            <tr>
                <td><asp:Label ID="lblBranchx" CssClass="form-control"  runat="server" Text="Branch"></asp:Label></td>
                <td><asp:DropDownList ID="ddlBranchx" CssClass="form-control"  runat="server" DataTextField="BranchName" DataValueField="branchCode"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblGroup" CssClass="form-control"  runat="server" Text="Group"></asp:Label></td>
                <td><asp:DropDownList ID="hght" CssClass="form-control"  runat="server" DataTextField="groupname" DataValueField="id"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblUnit" CssClass="form-control"  runat="server" Text="Unit"></asp:Label></td>
                <td><asp:DropDownList ID="ddlUnitx" CssClass="form-control"  runat="server" DataTextField="function_name" DataValueField="id"></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblCugg" CssClass="form-control" runat="server" Text="CUG"></asp:Label></td>
                <td><asp:TextBox ID="txtCug1" CssClass="form-control" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPhone" CssClass="form-control"  runat="server" Text="Direct Line"></asp:Label></td>
                <td><asp:TextBox ID="txtPhonex" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td><asp:Label ID="LblExtn" CssClass="form-control" runat="server" Text="Office Extension"></asp:Label></td>
                <td><asp:TextBox ID="txtExtx" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
             <tr>
                <td><asp:Label ID="lblMob" CssClass="form-control" runat="server" Text="Mobile Phone"></asp:Label></td>
                <td><asp:TextBox ID="txtMobx" CssClass="form-control" runat="server"></asp:TextBox></td>
            </tr>
            </asp:Panel>
            <tr>
                <td style="text-align: center"></td>
                <td></td>
            </tr>
        </table>
          </asp:Panel>
        </div>
</asp:Content>

