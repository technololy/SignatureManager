using CentralBilling;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICSharpCode.SharpZipLib.Zip;
using System.Xml;
using System.Runtime.InteropServices;
using System.Security.Principal;

public partial class Areas_Self_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //lblSetFirstName.Text = "firstname";
        //lblSetLastName.Text = "lastname";
        //lblAddress.Text = "address1";
        //lblUnitFunction.Text = "unit";
        //lblGroupFunction.Text = "Technology Group";
        //lblTel.Text = "01-22044998";
        //lblSetMobile.Text = "12333";
        //lblSetExt.Text = "1234";
        //GenerateEmailTemplate();
        //pnlEnterDetails.Visible = false;

        if (!IsPostBack)
        {

            if (Request.QueryString["firstname"] == null)
            {
                Panel1.Visible = false;
                ddlBranch.DataSource = GetData("spGetBranches", null);
                ddlBranch.DataBind();
                ddlGroup.DataSource = GetData("spGetGroup", null);
                ddlGroup.DataBind();
                ddlUnit.DataSource = GetData("spGetFunction", null);
                ddlUnit.DataBind();
            }
            else
            {

                lblSetFirstName.Text = Request.QueryString["firstname"].ToString();
                lblSetLastName.Text = Request.QueryString["lastname"].ToString();
                lblAddress.Text = Request.QueryString["address1"].ToString();
                lblBranchx.Text = Request.QueryString["address5"].ToString();
                lblUnitFunction.Text = Request.QueryString["unit"].ToString();
                lblSetMobile.Text = Request.QueryString["mobile"].ToString();
                lblSetExt.Text = Session["officeExtension"].ToString();
                lblTel.Text = Session["officeDirectLine"].ToString();
                lblGroupFunction.Text = Request.QueryString["group"].ToString();

                //lblSetFirstName.Text = "firstname";
                //lblSetLastName.Text = "lastname";
                //lblAddress.Text = "address1";
                //lblUnitFunction.Text = "unit";
                //lblGroupFunction.Text = "Technology Group";
                //lblTel.Text = "01-22044998";
                //lblSetMobile.Text = "12333";
                //lblSetExt.Text = "1234";
                GenerateEmailTemplate();
                //pnlEnterDetails.Visible = false;



            }





        }

    }


    private DataSet GetData(string StoredProcedName, SqlParameter StoProCed_Para)
    {
        string cs = ConfigurationManager.ConnectionStrings["EmailSig"].ConnectionString;
        SqlConnection SqlCon = new SqlConnection(cs);
        SqlDataAdapter da = new SqlDataAdapter(StoredProcedName, SqlCon);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        if (StoProCed_Para != null)
        {
            da.SelectCommand.Parameters.Add(StoProCed_Para);
        }

        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        pnlEnterDetails.Visible = false;
        //txtFName.Text = txtFName.Text.ToUpper();
        //txtLName.Text = txtLName.Text.ToUpper();
        //lblSetFirstName.Text = txtFName.Text;
        //lblSetLastName.Text = txtLName.Text;
        string capitalizedFName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtFName.Text);
        string capitalizedLName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(txtLName.Text);
        lblSetFirstName.Text = capitalizedFName;
        lblSetLastName.Text = capitalizedLName;
        lblUnitFunction.Text = ddlUnit.SelectedItem.Text;
        lblGroupFunction.Text = ddlGroup.SelectedItem.Text;
        lblAddress.Text = ddlBranch.SelectedItem.Text;
        lblTel.Text = txtPhone.Text;
        lblCug.Text = txtCug.Text;
        lblSetExt.Text = txtExt.Text;
        lblSetMobile.Text = txtMob.Text;

        GenerateEmailTemplate();



        //lblSetFirstName.Text = "ololade";
        //lblSetLastName.Text = "oye";
        //lblUnitFunction.Text = "developer";
        //lblGroupFunction.Text = "technology";
        //lblAddress.Text = "marina";
        //lblTel.Text = "1234";
        //lblCug.Text = "1234";
        //lblSetExt.Text = "123456";
        //lblSetMobile.Text = "89876";



    }

    private void GenerateEmailTemplate()
    {
        var fileContents = System.IO.File.ReadAllText(Server.MapPath(@"~/App_Data/ApprovedSignature2.html"));
        fileContents = fileContents.Replace("%fullname%", lblSetFirstName.Text + " " + lblSetLastName.Text);
        fileContents = fileContents.Replace("%address1%", lblAddress.Text);
        fileContents = fileContents.Replace("%address2%", lblBranchx.Text);
        fileContents = fileContents.Replace("%unit%", lblUnitFunction.Text);
        fileContents = fileContents.Replace("%group%", lblGroupFunction.Text);
        fileContents = fileContents.Replace("%phone%", lblTel.Text);
        fileContents = fileContents.Replace("%mobile%", lblSetMobile.Text);
        fileContents = fileContents.Replace("%extension%", lblSetExt.Text);
        fileContents = fileContents.Replace("%group%", lblGroupFunction.Text);
        fileContents = fileContents.Replace("%title%", Session["title"].ToString());
        fileContents = fileContents.Replace("%email%", lblSetFirstName.Text + "." + lblSetLastName.Text + "@sterlingbankng.com");
        Literal1.Text = fileContents;
        Session["HTMLPath"] = fileContents;
        Guid a = Guid.NewGuid();
        //new CentralBilling.JobLog(a.ToString(), fileContents);
        //Log4net.log.Info(fileContents);
    }

    protected void BtnDownload_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["HTMLPath"] == null)
        {
            //Log4net.log.Info("empty session");

            new CentralBilling.ErrorLog("emoty session");

            alertDivID.Visible = true;
            alertLabelID.Text = "empty html session";
            return;
        }

        string username = Context.User.Identity.GetUserName();
        //string username = "oyebanjieo";
        string sourceFile = HttpContext.Current.Session["HTMLPath"].ToString();
        string userDirectory = @"~\\GeneratedTempSignatureHTML\\" + username;
        new ErrorLog("this is the user's directory i just formed where i will save (and retrieve later) his email sig file on the app server. " + userDirectory);
        if (!Directory.Exists(Server.MapPath(userDirectory)))
        {
            try
            {
                Directory.CreateDirectory(Server.MapPath(userDirectory));
                new ErrorLog("the directory " + userDirectory + " did not exist before so i just created it");
            }
            catch (Exception ex)
            {
               
                new ErrorLog("oh Damn. seems theres an error in creating the users directory " + userDirectory + ". The actual error is " + ex.ToString());
                alertDivID.Visible = true;

                alertLabelID.Text = "Unexpected Error occured. Please check the logs" ;
                return;
            }
        }
        try
        {
            string fullUserFilepathOnServer = Server.MapPath(userDirectory + "\\" + "sterling_sig" + ".htm");
            string directoryOnserverSavingUsersSigtemplate = Server.MapPath(userDirectory);
            //string signatureFileName = "ApprovedSignature.htm";
            string signatureFileName = "sterling_sig.htm";
            // do something here with the string, like save to disk

            string MachineNameOfUser2 = HttpContext.Current.Server.MachineName;
            string MachineNameOfUser = HttpContext.Current.Request.UserHostName;
            string MachineNameOfUser33 = HttpContext.Current.Request.UserHostAddress;

            try
            {
                File.WriteAllText((fullUserFilepathOnServer), sourceFile);
            }
            catch (Exception ex)
            {
                new ErrorLog("Seems i cant write from source " + fullUserFilepathOnServer + " to destination " + sourceFile + ". the actual error is " + ex.ToString());
                alertDivError.Visible = true;

                alertLabelID.Text = "Unexpected Error occured during content copy. Please check the logs";
                return;
            }
           
            string pathOnUsersPC3 = string.Format((@"\\{0}\c$\Users\{1}\AppData\Roaming\Microsoft\Signatures\ApprovedSignature.htm"), MachineNameOfUser, username);
            string directoryOnUsersPC = string.Format((@"\\{0}\c$\Users\{1}\AppData\Roaming\Microsoft\Signatures"), MachineNameOfUser, username);

            new ErrorLog(" this is the user's directory i am preparing to copy files to " + directoryOnUsersPC);
            //if (File.Exists(pathOnUsersPC3))
            //{
            //    File.Delete(pathOnUsersPC3);
            //}


            string aduser = ConfigurationManager.AppSettings["AdUser"].ToString();
             string adpass = ConfigurationManager.AppSettings["AdPass"].ToString();

            //string aduser = Session["username"].ToString();
            //string adpass = Session["password"].ToString();
            new ErrorLog("using the credential of " + aduser+" to append signature");
            IntPtr admin_token = default(IntPtr);
            WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
            WindowsIdentity wid_admin = null;
            WindowsImpersonationContext wic = null;
            try
            {
              
                if (Impersonationn.LogonUser(aduser, "Sterlingbank.com", adpass, 9, 0, ref admin_token) != 0)
                {
                    new ErrorLog("i have entered ninja mode for user " + username+" via "+aduser);
                    new ErrorLog("this is the copy-as-path file name of the file on the server " + fullUserFilepathOnServer);
                    new ErrorLog("this is the directory on the server where the signature is first saved " + directoryOnserverSavingUsersSigtemplate);
                    new ErrorLog("this is the copy-as-path (user's pc and the file name) " + pathOnUsersPC3);
                    //directoryOnUsersPC = @"\\10.0.11.173\c$\Users\deji-akintolao\AppData\Roaming\Microsoft\Signatures";
                    new ErrorLog("this is the test path " + directoryOnUsersPC);
                    new ErrorLog("this is the file to copy " + signatureFileName);
                    new ErrorLog("this is the directory i am copying the signature files to on to the users pc " + directoryOnUsersPC);

                    
                     wid_admin = new WindowsIdentity(admin_token);
                    wic = wid_admin.Impersonate();
                    try
                    {
                        //File.Copy(fullUserFilepathOnServer, pathOnUsersPC3, true);
                       // File.SetAttributes(Path.Combine(directoryOnUsersPC, signatureFileName), FileAttributes.Normal);
                        File.Copy(Path.Combine(directoryOnserverSavingUsersSigtemplate,signatureFileName),Path.Combine(directoryOnUsersPC,signatureFileName),true);
                    
                        new ErrorLog("file copied to " + directoryOnUsersPC);
                    }
                    catch (Exception ex)
                    {

                        new ErrorLog("Seems i cant copy the needed files to this users PC. the directory i tried to copy the files to is \n" +directoryOnUsersPC+" and the actual error is \n "+ex.ToString());
                alertDivError.Visible = true;


                        Label1.Text = "Challenges experienced!!!" ;
                        return;
                    }
                    //if (Directory.Exists(directoryOnUsersPC))
                    //{
                        //if (File.Exists(pathOnUsersPC3))
                        //{
                        //    File.Delete(pathOnUsersPC3);
                        //}
                      

                    //}
                    //else
                    //{
                       
                    //}
                 
                }
                else
                {
                    alertDivID.Visible = true;
                    alertLabelID.Text = "error setting signature on "+username +"'s PC";
                    return;
                    
                }
            }
            catch (System.Exception se)
            {
                new ErrorLog("this is an unhandled error when they clicked on download signature to my pc. the actual error is " + se.ToString());
                int ret = Marshal.GetLastWin32Error();
              
                alertDivError.Visible = true;

                alertLabelID.Text = "error setting signature";
                return;
                // MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString());
                //MessageBox.Show(se.Message);
            }
            finally
            {
                if (wic != null)
                {
                    wic.Undo();
                }
            }




            //File.Copy(fullUserFilepathOnServer, pathOnUsersPC3);

            #region MyRegion
            //// Code to Zip a Folder.
            //string sPath = Server.MapPath(userDirectory);
            ////string sPath = Server.MapPath("~") + "/GeneratedTempSignatureHTML";



            //string pathOfBatFile = Server.MapPath("~/Temp/html sig batch_sterling.bat");
            //string pathOfFile = Server.MapPath("~/GeneratedTempSignatureHTML/" + username+"/sig.bat");
            //if (File.Exists(pathOfFile))
            //{
            //    File.Delete(pathOfFile);
            //}
            ////=====================error here
            //File.Copy(pathOfBatFile, pathOfFile);
            //string zipFullPath = Server.MapPath(string.Format("{0}" + "_" + Context.User.Identity.GetUserName() + "_signature.zip", "Sterling"));
            //ZipOutputStream zipOut = new ZipOutputStream(File.Create(zipFullPath));
            //foreach (string fName in Directory.GetFiles(sPath))
            //{
            //    FileInfo fi = new FileInfo(fName);
            //    ZipEntry entry = new ZipEntry(fi.Name);
            //    FileStream sReader = File.OpenRead(fName);
            //    byte[] buff = new byte[Convert.ToInt32(sReader.Length)];
            //    sReader.Read(buff, 0, (int)sReader.Length);
            //    entry.DateTime = fi.LastWriteTime;
            //    entry.Size = sReader.Length;
            //    sReader.Close();
            //    zipOut.PutNextEntry(entry);
            //    zipOut.Write(buff, 0, buff.Length);
            //}

            //zipOut.Finish();
            //zipOut.Close();
            //Response.Clear();
            //Response.ContentType = "application/octet-stream";
            //string fnames = string.Format("{0}" + "_" + lblSetFirstName.Text + "_signature.zip", DateTime.Now.Ticks.ToString());
            //Response.AddHeader("Content-Disposition", "Attachment; filename=" + fnames);
            //Response.TransmitFile(zipFullPath);
            //Response.End(); 
            #endregion



        }
        catch (Exception ex)
        {
            new ErrorLog(ex);
            alertDivError.Visible = true;

            alertLabelID.Text = "unknown error "+ex.ToString();
            return;

        }
        alertDivID.Visible = true;
        alertLabelID.Text = "Successfully set signature. Please select the signature on your mail client (Outlook)";
        //return;

        return;

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        pnlEnterDetails.Visible = true;
        Panel1.Visible = false;
        Response.Redirect("~/Areas/Self/self-generate.aspx");


    }
}