using System;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack && Request.QueryString["error"] == "invalidlogin")
        {
            ((defaultmaster)Master).DefaultValidator.ErrorMessage = "Invalid login.  Please try again.";
            ((defaultmaster)Master).DefaultValidator.IsValid = false;
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string userName = tfUserName.Text.Trim();
        string password = tfPassword.Text.Trim();
        Global.LogIn(userName, password);
    }
}
