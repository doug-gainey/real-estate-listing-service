using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;

[DefaultProperty("Text"), ValidationProperty("Text")]
public partial class TextField : UserControl
{
    public string CssClass { get; set; }

    public ValidationDataType DataType
    {
        get { return cmpCompare.Type; }
        set { cmpCompare.Type = value; }
    }

    private string _format;
    public string Format
    {
        get { return _format; }
        set
        {
            _format = value;
            tbxTextBox.ToolTip = String.Concat("Format: ", _format);
        }
    }

    public string Label
    {
        get { return lblLabel.Text; }
        set { lblLabel.Text = value; }
    }

    public int MaxLength
    {
        get { return tbxTextBox.MaxLength; }
        set { tbxTextBox.MaxLength = value; }
    }

    public ValidationCompareOperator Operator
    {
        get { return cmpCompare.Operator; }
        set
        {
            cmpCompare.Operator = value;
            cmpCompare.Visible = true;
        }
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

    public string Text
    {
        get { return tbxTextBox.Text; }
        set { tbxTextBox.Text = value; }
    }

    public TextBox TextBox
    {
        get { return tbxTextBox; }
    }

    public TextBoxMode TextMode
    {
        get { return tbxTextBox.TextMode; }
        set { tbxTextBox.TextMode = value; }
    }

    public string ValidationExpression
    {
        get { return regRegEx.ValidationExpression; }
        set
        {
            regRegEx.ValidationExpression = value;
            regRegEx.Visible = true;
        }
    }

    public string ValueToCompare
    {
        get { return cmpCompare.ValueToCompare; }
        set { cmpCompare.ValueToCompare = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set required field validator error message
            reqRequired.ErrorMessage = String.Concat(Label, " is a required field.");

            // Set regular expression validator error message
            if (!String.IsNullOrEmpty(Format))
                regRegEx.ErrorMessage = String.Concat(Label, " must be in the format: ", Format, ".");
            else
                regRegEx.ErrorMessage = String.Concat(Label, " is not in the correct format.");

            // Set compare validator error message
            cmpCompare.ErrorMessage = String.Concat(Label, " is not in the correct format.");
            if (Operator == ValidationCompareOperator.DataTypeCheck)
            {
                if (DataType == ValidationDataType.Currency)
                {
                    cmpCompare.ErrorMessage = String.Concat(Label, " must be a valid amount in the format: 100,000.");
                    Format = "100,000";
                }
                else if (DataType == ValidationDataType.Date)
                {
                    cmpCompare.ErrorMessage = String.Concat(Label, " must be a valid date in the format: mm/dd/yyyy.");
                    Format = "mm/dd/yyyy";
                }
                else if (DataType == ValidationDataType.Double)
                {
                    cmpCompare.ErrorMessage = String.Concat(Label, " must be a valid number.");
                    Format = "Number";
                }
                else if (DataType == ValidationDataType.Integer)
                {
                    cmpCompare.ErrorMessage = String.Concat(Label, " must be a valid integer.");
                    Format = "Integer";
                }
            }
            else if (Operator == ValidationCompareOperator.LessThanEqual && DataType == ValidationDataType.Integer)
            {
                cmpCompare.ErrorMessage = String.Concat(Label, " must be a valid integer in the range: 0 - ", ValueToCompare, ".");
                Format = String.Concat("0 - ", ValueToCompare);
            }
        }
    }
}
