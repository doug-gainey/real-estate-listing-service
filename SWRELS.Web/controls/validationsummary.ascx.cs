using System.Web.UI;

public partial class controls_validationsummary : UserControl
{
    public string ValidationGroup
    {
        get { return vsMain.ValidationGroup; }
        set
        {
            vsMain.ValidationGroup = value;
            cvDefaultValidator.ValidationGroup = value;
        }
    }
}