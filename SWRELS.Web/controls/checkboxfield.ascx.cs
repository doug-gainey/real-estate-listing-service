using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckBoxField : UserControl
{
    public CheckBox CheckBox
    {
        get { return cbxCheckBox; }
    }

    public bool Checked
    {
        get { return cbxCheckBox.Checked; }
        set { cbxCheckBox.Checked = value; }
    }

    public string CssClass { get; set; }

    public string Label
    {
        get { return cbxCheckBox.Text; }
        set { cbxCheckBox.Text = value; }
    }
}
