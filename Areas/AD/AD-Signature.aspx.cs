using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.Owin.Security;
using OneDirectory;
using SignatureManager;
using System.Web.Script.Serialization;
using CentralBilling;

public partial class Areas_AD_AD_Signature : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LogIn(object sender, EventArgs e)
    {
        bool logged = OneDirectory.Profile.Authenticate(UserName.Text, Password.Text);
        Session["username"] = UserName.Text;
        Session["password"] = Password.Text;
        //logged = true;
        if (!logged)
        {
            PopUpAlert("Invalid credentials");
           
            return;
        }
        var userFullDetails = AD.AuthenticateUser("STERLINGBANK.COM", UserName.Text, Password.Text);
        if (userFullDetails.officeExtension == "")
        {
            PopUpAlert("Blank Office Extension on AD. Please go to AD Self Service on HQ-Portal and Fill Extension Field");
            return;
        }
        if (userFullDetails.officeLandLine == "")
        {
            PopUpAlert("Blank Office Extension on AD. Please go to AD Self Service on HQ-Portal and Fill CUG Field");
            return;
        }
        Session["title"] = userFullDetails.title;
        Session["officeExtension"] = userFullDetails.officeExtension;
        Session["officeDirectLine"] = userFullDetails.officeLandLine;
        Session["usersDepartment"] = userFullDetails.department;
        //ClaimsHelper.ClaimsSignIn(userFullDetails, UserName.Text);
        CheckIfADDetailsIsEmpty(userFullDetails);
        var users_full_object = OneDirectory.Profile.GetInfo(UserName.Text, UserName.Text, Password.Text);
        try
        {
            var dd = OneDirectory.Profile.GetInfo(UserName.Text, "", "");
        }
        catch (Exception)
        {


        }
        try
        {
            ClaimsHelper.SignIn2(users_full_object, UserName.Text);
        }
        catch (Exception ex)
        {

            new ErrorLog(ex);
            //Utility.ErrorLog.LogElmahError(ex, "");
        }
        //string url = string.Format("~/Areas/self/self-generate.aspx?firstname={0}&lastname={1}&unit={2}&group={3}&address1={4}&address5={5}&email={6}&mobile={7}",users_full_object.FirstName,users_full_object.LastName,users_full_object.Unit.Trim(), users_full_object.Department,users_full_object.OfficeLocation,users_full_object.Region,users_full_object.Email,users_full_object.Mobile);
        string url = string.Format("~/Areas/self/self-generate.aspx?firstname={0}&lastname={1}&unit={2}&group={3}&address1={4}&address5={5}&email={6}&mobile={7}", users_full_object.FirstName, users_full_object.LastName, userFullDetails.department.Trim(), userFullDetails.groupname, userFullDetails.branchnamereal, userFullDetails.streetaddress+", "+userFullDetails.state, users_full_object.Email, users_full_object.Mobile);
        Response.Redirect(url);
    }

    private void PopUpAlert(string v)
    {
        alertDivError.Visible = true;
        alertlabelError.Visible = true;
        alertlabelError.Text = v;
       
    }

    private void CheckIfADDetailsIsEmpty(AD.ADDetails userFullDetails)
    {
       
    }

    private void CheckIfADDetailsIsEmpty()
    {
        
    }

    private void UseClaimsHere(User users_full_object, string text)
    {
       
    }

    public class ClaimsHelper
    {
        private static IAuthenticationManager AuthManager { get { return HttpContext.Current.GetOwinContext().Authentication; } }
        //  IAuthenticationManager siginManager = HttpContext.Current.GetOwinContext().Authentication;


        internal static void SignIn2(OneDirectory.User user, string username)
        {
            // IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var claims = new List<Claim>();

            //required claims
            claims.Add(new Claim(ClaimTypes.Name, username));
            claims.Add(new Claim(ClaimTypes.Email, user.Email == null ? "" : user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.JobTitle == null ? "" : user.JobTitle));
            claims.Add(new Claim(ClaimTypes.GivenName, user.FullName == null ? "" : user.FullName));
            claims.Add(new Claim(ClaimTypes.SerialNumber, user.StaffID == null ? "" : user.StaffID));

            //custom claims
            claims.Add(new Claim("deptName", user.Department == null ? "" : user.Department));
            claims.Add(new Claim("tellerid", user.TellerID == null ? "" : user.TellerID));
            claims.Add(new Claim("group", user.Department == null ? "" : user.Department));
            claims.Add(new Claim("branch", user.OfficeLocation == null ? "" : user.OfficeLocation));
            claims.Add(new Claim("branchcode", user.Region == null ? "" : user.Region));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var userdetailsJsonObj = serializer.Serialize(user);
            //var userdetailsJsonObj = JsonConvert.SerializeObject(user);
            //  claims.Add(new Claim("userdetails", userdetailsJsonObj));

            var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignIn(new AuthenticationProperties() { AllowRefresh = true }, claimsIdentity);
            //   HttpContext.Current.Response.Redirect("Main.aspx");

        }



        internal static void ClaimsSignIn(AD.ADDetails user, string username)
        {
            // IAuthenticationManager authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            var claims = new List<Claim>();

            //required claims
            claims.Add(new Claim(ClaimTypes.Name, username));
            claims.Add(new Claim(ClaimTypes.Email, user.mail == null ? "" : user.mail));
            claims.Add(new Claim(ClaimTypes.Role, user.role == null ? "" : user.role));
            claims.Add(new Claim(ClaimTypes.GivenName, user.staffName == null ? "" : user.staffName));
            claims.Add(new Claim(ClaimTypes.SerialNumber, user.staffid == null ? "" : user.staffid));

            //custom claims
            claims.Add(new Claim("deptName", user.department == null ? "" : user.department));
            claims.Add(new Claim("tellerid", user.staffid == null ? "" : user.staffid));
            claims.Add(new Claim("group", user.department == null ? "" : user.department));
            claims.Add(new Claim("branch", user.branch_name == null ? "" : user.branch_name));
            claims.Add(new Claim("branchcode", user.branch_code == null ? "" : user.branch_code));
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var userdetailsJsonObj = serializer.Serialize(user);
            //var userdetailsJsonObj = JsonConvert.SerializeObject(user);
            //  claims.Add(new Claim("userdetails", userdetailsJsonObj));

            var claimsIdentity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            AuthManager.SignIn(new AuthenticationProperties() { AllowRefresh = true }, claimsIdentity);
            //   HttpContext.Current.Response.Redirect("Main.aspx");

        }

       
    }
}