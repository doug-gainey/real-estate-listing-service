using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UploadField : UserControl
{
    public string CssClass { get; set; }

    public FileUpload FileUpload
    {
        get { return fileUpload; }
    }

    public bool HasFile
    {
        get { return fileUpload.HasFile; }
    }

    public string Label
    {
        get { return lblLabel.Text; }
        set { lblLabel.Text = value; }
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

    public Button UploadButton
    {
        get { return btnUpload; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Set required field validator error message
        if (!IsPostBack)
            reqRequired.ErrorMessage = String.Concat(Label, " is a required field.");

        // Register script to enable upload button after file has been selected
        string enableScript = @"
        function enableUpload(uploadId, btnId) {{
            if($('#' + uploadId).val() != '') {{
                $('.buttons input[type=""submit""]').attr('disabled', 'disabled');
                $('#' + btnId).removeAttr('disabled');
            }}
        }}";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "enableUploadButton", enableScript, true);
        fileUpload.Attributes.Add("onchange", String.Format("enableUpload('{0}', '{1}')", fileUpload.ClientID, btnUpload.ClientID));
    }

    public void ShowPreview(string imageUrl)
    {
        // After image has been uploaded, a preview is displayed
        lblRequired.Visible = false;
        reqRequired.Visible = false;
        fileUpload.Visible = false;
        btnUpload.Visible = false;
        imgPreview.ImageUrl = imageUrl;
        imgPreview.Visible = true;
    }
}
