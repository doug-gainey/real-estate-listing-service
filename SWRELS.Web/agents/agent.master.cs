using System;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class agentmaster : System.Web.UI.MasterPage
{
    public CustomValidator DefaultValidator
    {
        get { return (CustomValidator)ucValidationSummary.FindControl("cvDefaultValidator"); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btnSignOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("../default.aspx");
    }
}
