using System;
using System.Web.UI;
using System.Web.UI.WebControls;

[ParseChildren(true, "Items")]
public partial class ListField : UserControl
{
    public string CssClass { get; set; }

    public string Label
    {
        get { return lblLabel.Text; }
        set { lblLabel.Text = value; }
    }

    public ListItemCollection Items
    {
        get { return ddlList.Items; }
    }

    public DropDownList List
    {
        get { return ddlList; }
    }

    public bool Required
    {
        get { return reqRequired.Visible; }
        set
        {
            lblRequired.Visible = value;
            reqRequired.Visible = value;
        }
    }

    public string SelectedValue
    {
        get { return ddlList.SelectedValue; }
        set { ddlList.SelectedValue = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Set required field validator error message
        if (!IsPostBack)
            reqRequired.ErrorMessage = String.Concat(Label, " is a required field.");
    }
}
