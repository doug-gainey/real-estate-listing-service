using System;
using System.Web.UI.WebControls;
using SWRELS.Domain;
using SWRELS.Facade;

public partial class defaultmaster : System.Web.UI.MasterPage
{
    public CustomValidator DefaultValidator
    {
        get { return (CustomValidator)ucValidationSummary.FindControl("cvDefaultValidator"); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Get header title information from database
            using (SwrelsFacade facade = new SwrelsFacade())
            {
                Reference reference = facade.GetReference("HEADER_TITLE");
                if (reference != null)
                {
                    string header = reference.IsWhatText;
                    string[] headerArray = header.Split('|');
                    litH1.Text = headerArray[0];
                    litH2.Text = headerArray[1];
                }
                else
                {
                    // Set default header
                    litH1.Text = "Welcome to SWRELS.com";
                    litH2.Text = "Where finding real estate is easy, and listing real estate is affordable";
                }
            }
        }
    }

    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        string userName = tfUserName.Text.Trim();
        string password = tfPassword.Text.Trim();
        Global.LogIn(userName, password);
    }
}
