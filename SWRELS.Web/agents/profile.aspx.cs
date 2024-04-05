using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using SWRELS;
using SWRELS.Facade;
using SWRELS.Domain;

public partial class agents_profile : System.Web.UI.Page
{
    private int agentID;

    protected void Page_Load(object sender, EventArgs e)
    {
        // Get agent id from forms authentication ticket
        agentID = Global.GetAgentId();

        if (!IsPostBack)
        {
            PopulateStates();
            PopulateMonths();
            PopulateYears();
            PopulateProfileInfo();
        }

        // Set attributes for specific fields
        lfCreditCardExpirationMonth.List.Width = Unit.Pixel(135);
        lfCreditCardExpirationYear.List.Width = Unit.Pixel(115);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Validate();
        if (!IsValid)
            return;

        SaveProfileInfo();
        Response.Redirect("default.aspx");
    }

    protected void btnCancelAccount_Click(object sender, EventArgs e)
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Agent agent = facade.Get<Agent>(agentID);
            if (agent == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            agent.Active = false;
            facade.Save(agent);
        }

        FormsAuthentication.SignOut();
        Response.Redirect("../default.aspx");
    }

    private void PopulateStates()
    {
        for (int i = 0; i < Global.StateNames.Length; i++)
        {
            string stateName = Global.StateNames[i];
            string stateAbbr = Global.StateAbbreviations[i];
            lfState.Items.Add(new ListItem(stateName, stateAbbr));
        }
    }

    private void PopulateMonths()
    {
        for (int i = 0; i < Global.MonthNames.Length; i++)
        {
            string monthName = Global.MonthNames[i];
            int monthNumber = i + 1;
            string monthDisplayNumber = monthNumber < 10 ? String.Concat("0", monthNumber) : monthNumber.ToString();
            lfCreditCardExpirationMonth.Items.Add(new ListItem(String.Format("{0} - {1}", monthDisplayNumber, monthName), monthNumber.ToString()));
        }
    }

    private void PopulateYears()
    {
        int currentYear = DateTime.Today.Year;
        for (int i = currentYear; i <= currentYear + 10; i++)
            lfCreditCardExpirationYear.Items.Add(i.ToString());
    }

    private void PopulateProfileInfo()
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Agent agent = facade.Get<Agent>(agentID);
            if (agent == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            // Agent information
            lblUserName.Text = agent.LoginName.TrimNull();
            tfFirstName.Text = agent.FirstName.TrimNull();
            tfLastName.Text = agent.LastName.TrimNull();
            tfLicenseNumber.Text = agent.LicNumber.ToString();
            tfAgencyName.Text = agent.AgencyName.TrimNull();
            tfAddress.Text = agent.Address.TrimNull();
            tfCity.Text = agent.City.TrimNull();
            lfState.SelectedValue = agent.State.TrimNull();
            tfZipCode.Text = agent.ZipCode.TrimNull();
            tfPhoneNumber.Text = agent.PhoneNumber.TrimNull();
            tfFaxNumber.Text = agent.FaxNumber.TrimNull();
            tfEmailAddress.Text = agent.EmailAddress.TrimNull();

            // Billing information
            if (agent.Renewal != null)
                lfRenewal.SelectedValue = agent.Renewal.ToString();
            tfCreditCardFirstName.Text = agent.CcFirstName.TrimNull();
            tfCreditCardLastName.Text = agent.CcLastName.TrimNull();
            lfCreditCardType.SelectedValue = agent.LastName.TrimNull();
            if (!agent.CardNumber.IsNullOrEmpty() && agent.CardNumber.Trim().Length.Equals(16))
                tfCreditCardNumber.Text = agent.CardNumber.Trim().Substring(12).PadLeft(16, '*');
            if (agent.ExpireMonth != null)
                lfCreditCardExpirationMonth.SelectedValue = agent.ExpireMonth.ToString();
            if (agent.ExpireYear != null)
                lfCreditCardExpirationYear.SelectedValue = agent.ExpireYear.ToString();
            tfCreditCardSecurityCode.Text = agent.SecurityCode.TrimNull();
        }
    }

    private void SaveProfileInfo()
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Agent agent = facade.Get<Agent>(agentID);
            if (agent == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            agent.FirstName = Global.GetString(tfFirstName.Text);
            agent.LastName = Global.GetString(tfLastName.Text);
            agent.LicNumber = Convert.ToInt16(tfLicenseNumber.Text);
            agent.AgencyName = Global.GetString(tfAgencyName.Text);
            agent.Address = Global.GetString(tfAddress.Text);
            agent.City = Global.GetString(tfCity.Text);
            agent.State = Global.GetString(lfState.SelectedValue);
            agent.ZipCode = Global.GetString(tfZipCode.Text);
            agent.PhoneNumber = Global.GetString(tfPhoneNumber.Text);
            agent.FaxNumber = Global.GetString(tfFaxNumber.Text);
            agent.EmailAddress = Global.GetString(tfEmailAddress.Text);
            agent.Renewal = Convert.ToByte(lfRenewal.SelectedValue);
            agent.CcFirstName = Global.GetString(tfCreditCardFirstName.Text);
            agent.CcLastName = Global.GetString(tfCreditCardLastName.Text);
            agent.CardType = Global.GetString(lfCreditCardType.SelectedValue);
            agent.CardNumber = Global.GetString(tfCreditCardNumber.Text);
            agent.ExpireMonth = Convert.ToByte(lfCreditCardExpirationMonth.SelectedValue);
            agent.ExpireYear = Convert.ToInt16(lfCreditCardExpirationYear.SelectedValue);
            agent.SecurityCode = Global.GetString(tfCreditCardSecurityCode.Text);
            if (!String.IsNullOrEmpty(tfNewPassword.Text.Trim()) && !String.IsNullOrEmpty(tfConfirmPassword.Text.Trim()))
                agent.LoginPass = tfNewPassword.Text.Trim();

            facade.Save(agent);
        }
    }
}
