using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class Navigation_GenerateSignature : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated)
	{
		 
	}
        else
        {
            Response.Redirect("~/Account/Login.aspx", true);
            
        }
    }
    protected void btnGenerate_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
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
    }
    protected void BtnDownload_Click(object sender, EventArgs e)
    {

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {

    }
}