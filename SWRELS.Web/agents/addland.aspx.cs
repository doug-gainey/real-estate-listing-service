using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using SWRELS;
using SWRELS.Domain;
using SWRELS.Facade;

public partial class agents_addland : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateStates();
            PopulatePropertyTypes();
            SetDefaultValues();
        }

        PopulateFeatures();
        InitializePhotoUploads();

        // Set attributes for specific fields
        cbfForSale.CheckBox.Attributes.Add("onchange", String.Format("toggleField('{0}')", tfPricePerAcre.ClientID));
        cbfForLease.CheckBox.Attributes.Add("onchange", String.Format("toggleField('{0}'); toggleField('{1}')", tfLeasePrice.ClientID, tfLeaseMode.ClientID));
        tfExtraAmenities.TextBox.Width = Unit.Percentage(100);
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        Validate();
        if (!IsValid)
            return;

        if (phGeneral.Visible)
        {
            phGeneral.Visible = false;
            phLocation.Visible = true;
            btnGoBack.Visible = true;
        }
        else if (phLocation.Visible)
        {
            phLocation.Visible = false;
            phDetails.Visible = true;
        }
        else if (phDetails.Visible)
        {
            phDetails.Visible = false;
            phFeatures.Visible = true;
        }
        else if (phFeatures.Visible)
        {
            phFeatures.Visible = false;
            phPhotos.Visible = true;
            btnContinue.Visible = false;
            btnSave.Visible = true;
        }
    }

    protected void btnGoBack_Click(object sender, EventArgs e)
    {
        if (phLocation.Visible)
        {
            phLocation.Visible = false;
            phGeneral.Visible = true;
            btnGoBack.Visible = false;
        }
        else if (phDetails.Visible)
        {
            phDetails.Visible = false;
            phLocation.Visible = true;
        }
        else if (phFeatures.Visible)
        {
            phFeatures.Visible = false;
            phDetails.Visible = true;
        }
        else if (phPhotos.Visible)
        {
            phPhotos.Visible = false;
            phFeatures.Visible = true;
            btnSave.Visible = false;
            btnContinue.Visible = true;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Validate();
        if (!IsValid)
            return;

        using (SwrelsFacade facade = new SwrelsFacade())
        {
            int agentId = Global.GetAgentId();
            Agent agent = facade.Get<Agent>(agentId);

            // Listing information
            string title = Global.GetString(tfTitle.Text);
            DateTime? listDate = Global.GetDate(tfListDate.Text);
            DateTime? expirationDate = Global.GetDate(tfExpirationDate.Text);
            decimal? listPrice = Global.GetDecimal(tfListPrice.Text);
            string description = Global.GetString(tfDescription.Text);
            bool isForSale = cbfForSale.Checked;
            int? pricePerAcre = Global.GetInt32(tfPricePerAcre.Text);
            bool isForExchange = cbfForExchange.Checked;
            bool isForLease = cbfForLease.Checked;
            int? leasePrice = Global.GetInt32(tfLeasePrice.Text);
            string leaseMode = Global.GetString(tfLeaseMode.Text);
            int? mortgageBalance = Global.GetInt32(tfMortgageBalance.Text);

            // Location information
            string address = Global.GetString(tfAddress.Text);
            string city = Global.GetString(tfCity.Text);
            string state = Global.GetString(lfState.SelectedValue);
            string zipCode = Global.GetString(tfZipCode.Text);
            string county = Global.GetString(tfCounty.Text);
            short? area = Global.GetInt16(tfArea.Text);
            string suiteNumber = Global.GetString(tfSuiteNumber.Text);
            string subComplexComm = Global.GetString(tfSubComplexComm.Text);
            string parcelNumber = Global.GetString(tfParcelNumber.Text);
            string taxMapNumber = Global.GetString(tfTaxMapNumber.Text);
            string schoolDistrict = Global.GetString(tfSchoolDistrict.Text);
            string directions = Global.GetString(tfDirections.Text);

            // Property details
            PropertyType propertyType = null;
            int? propertyTypeId = Global.GetInt32(lfPropertyType.SelectedValue);
            if (propertyTypeId != null)
                propertyType = facade.Get<PropertyType>(propertyTypeId);
            string lotSize = Global.GetString(tfLotSize.Text);
            decimal? acreage = Global.GetDecimal(tfAcreage.Text);
            decimal? tillableAcres = Global.GetDecimal(tfTillableAcres.Text);
            decimal? usableAcres = Global.GetDecimal(tfUsableAcres.Text);
            byte? numBuildings = Global.GetByte(tfNumBuildings.Text);
            int? buildingSqFt = Global.GetInt32(tfBuildingSqFt.Text);
            int? yearlyTaxes = Global.GetInt32(tfYearlyTaxes.Text);
            bool isWaterfront = cbfWaterfront.Checked;
            string previousUse = Global.GetString(tfPreviousUse.Text);
            string zoning = Global.GetString(tfZoning.Text);
            decimal? distanceToInterchange = Global.GetDecimal(tfDistanceToInterchange.Text);
            int? trafficCount = Global.GetInt32(tfTrafficCount.Text);
            int? roadFront = Global.GetInt32(tfRoadFront.Text);
            string extraAmenities = Global.GetString(tfExtraAmenities.Text);

            // Save to the listing table
            Listing listing = new Listing
            {
                Acreage = acreage,
                Address = address,
                Agent = agent,
                Area = area,
                City = city,
                Closed = false,
                County = county,
                Description = description,
                Directions = directions,
                ExpireDate = expirationDate,
                Featured = false,
                ListDate = listDate,
                ListingPrice = listPrice,
                ListingType = ListingType.Residential,
                LotSize = lotSize,
                ParcelNumber = parcelNumber,
                Pending = false,
                PropertyType = propertyType,
                State = state,
                SubComplxComm = subComplexComm,
                SuiteUnit = suiteNumber,
                TaxMpNum = taxMapNumber,
                Title = title,
                WaterFront = isWaterfront,
                XtraAmment = extraAmenities,
                ZipCode = zipCode
            };
            facade.Save(listing);

            // Save to the land/farm table
            LandFarmListing landFarmListing = new LandFarmListing
                                                  {
                                                      BldgSqFt = buildingSqFt,
                                                      DistToInterc = distanceToInterchange,
                                                      ForExchange = isForExchange,
                                                      ForLease = isForLease,
                                                      ForSale = isForSale,
                                                      LeaseMode = leaseMode,
                                                      LeasePrice = leasePrice,
                                                      Listing = listing,
                                                      MortBalance = mortgageBalance,
                                                      NumBldgs = numBuildings,
                                                      PreviousUse = previousUse,
                                                      PricePerAcre = pricePerAcre,
                                                      UsableAcres = usableAcres,
                                                      RoadFront = roadFront,
                                                      SchoolDistrict = schoolDistrict,
                                                      TillableAcres = tillableAcres,
                                                      TrafCntPDay = trafficCount,
                                                      YearlyTaxes = yearlyTaxes,
                                                      Zoning = zoning
                                                  };
            facade.Save(landFarmListing);

            // Features
            string featureName = null;
            foreach (Control control in phFeatureSections.Controls)
            {
                if (control is LiteralControl)
                {
                    string html = ((LiteralControl)control).Text.Trim();
                    int headerBegin = html.IndexOf("<h2");
                    if (headerBegin != -1)
                    {
                        int featureNameBegin = html.IndexOf(">", headerBegin) + 1;
                        int featureNameEnd = html.IndexOf("</h2>");
                        if (featureNameBegin > 0 && featureNameEnd > -1)
                            featureName = html.Substring(featureNameBegin, featureNameEnd - featureNameBegin);
                    }
                }
                else if (control is CheckBoxList)
                {
                    CheckBoxList cblFeatures = (CheckBoxList)control;
                    foreach (ListItem feature in cblFeatures.Items)
                    {
                        if (feature.Selected)
                        {
                            // Save to the features table
                            Feature selectedFeature = new Feature
                                                          {
                                                              FeatureNum = Convert.ToInt16(feature.Value),
                                                              FeatureName = featureName,
                                                              FeatureOption = feature.Text,
                                                              Listing = listing
                                                          };
                            facade.Save(selectedFeature);
                            listing.Features.Add(selectedFeature);
                        }
                    }
                }
            }

            // Photos
            for (int i = 1; i <= Global.PhotoLimit; i++)
            {
                // Rename file
                string oldFileName = (string)ViewState[String.Concat("Photo ", i)];
                if (String.IsNullOrEmpty(oldFileName))
                    break;
                string oldFilePath = String.Concat(Global.PhotosDirectory, oldFileName);
                string newFilePath = String.Format(@"{0}{1}_{2}.jpg", Global.PhotosDirectory, listing.Id, i);
                File.Move(oldFilePath, newFilePath);

                // Save photo
                ListingPhoto photo = new ListingPhoto
                                         {
                                             Listing = listing,
                                             ListOrder = Convert.ToByte(i),
                                             PhotoFileName = Path.GetFileName(newFilePath)
                                         };
                facade.Save(photo);
                listing.Photos.Add(photo);
            }
        }

        Response.Redirect("default.aspx");
    }

    protected void UploadButton_Command(object sender, CommandEventArgs e)
    {
        Validate();
        if (!IsValid)
            return;

        UploadField ufPhoto = (UploadField)phPhotos.FindControl(e.CommandArgument.ToString());
        if (ufPhoto.HasFile && UploadFile(ufPhoto))
        {
            int photoIndex = Convert.ToInt32(ufPhoto.ID.Replace("ufPhoto", String.Empty));
            if (photoIndex < Global.PhotoLimit)
            {
                string nextPhotoId = String.Concat("ufPhoto", photoIndex + 1);
                UploadField ufNextPhoto = (UploadField)phPhotos.FindControl(nextPhotoId);
                ufNextPhoto.Visible = true;
            }

            ufPhoto.ShowPreview(String.Concat("../photos/", ViewState[String.Concat("Photo ", photoIndex)].ToString()));
        }
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

    private void PopulatePropertyTypes()
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            IList<PropertyType> propertyTypes = facade.GetPropertyTypes(ListingType.LandFarm);
            foreach (var propertyType in propertyTypes)
                lfPropertyType.Items.Add(new ListItem(propertyType.PTypeName.Trim(), propertyType.Id.ToString()));
        }
    }

    private void SetDefaultValues()
    {
        // Set default state
        int agentId = Global.GetAgentId();
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Agent agent = facade.Get<Agent>(agentId);
            if (agent == null)
            {
                FormsAuthentication.RedirectToLoginPage();
                return;
            }

            lfState.SelectedValue = agent.State.TrimNull();
        }
    }

    private void PopulateFeatures()
    {
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            string featureName = null;
            string cleanFeatureName = null;
            CheckBoxList cblFeatures = null;
            bool isFirst = true;

            IList<LandFarmFeature> features = facade.GetList<LandFarmFeature>();
            foreach (var feature in features)
            {
                if (featureName != feature.FeatureName.Trim())
                {
                    if (cblFeatures != null)
                    {
                        phFeatureSections.Controls.Add(new LiteralControl(String.Format("<h2 class=\"collapsible\" onclick=\"showFeatures('{0}')\">{1}</h2>", cleanFeatureName, featureName)));
                        phFeatureSections.Controls.Add(new LiteralControl(String.Format("<div class=\"datafield features {0}\" id=\"div{1}\">", !isFirst ? " hidden" : String.Empty, cleanFeatureName)));
                        phFeatureSections.Controls.Add(cblFeatures);
                        phFeatureSections.Controls.Add(new LiteralControl("</div>"));
                        isFirst = false;
                    }
                    featureName = feature.FeatureName.Trim();
                    cleanFeatureName = featureName.Replace(" ", "_");
                    cblFeatures = new CheckBoxList
                    {
                        ID = String.Concat("cbl", cleanFeatureName),
                        Width = Unit.Percentage(100),
                        RepeatColumns = 5,
                        RepeatDirection = RepeatDirection.Horizontal
                    };
                }
                if (cblFeatures != null)
                    cblFeatures.Items.Add(new ListItem(feature.FeatureOption.Trim(), feature.Id.ToString()));
            }
        }
    }

    private void InitializePhotoUploads()
    {
        foreach (Control control in phPhotos.Controls)
        {
            if (control is UploadField)
            {
                ((UploadField)control).UploadButton.CommandArgument = control.ID;
                ((UploadField)control).UploadButton.Command += UploadButton_Command;
            }
        }
    }

    private bool UploadFile(UploadField ufPhoto)
    {
        HttpPostedFile file = ufPhoto.FileUpload.PostedFile;

        // Check that a file was uploaded
        if (file == null || file.InputStream.Length == 0)
        {
            ((agentmaster)Master).DefaultValidator.ErrorMessage = String.Format("Invalid file for {0}. Please provide a valid photo (.jpg, .gif, or .png).", ufPhoto.Label);
            ((agentmaster)Master).DefaultValidator.IsValid = false;
            return false;
        }

        // Check file extension
        string fileExt = Path.GetExtension(file.FileName).ToLower();
        if (fileExt == ".jpeg") fileExt = ".jpg";
        if (!fileExt.Equals(".jpg") && !fileExt.Equals(".gif") && !fileExt.Equals(".png"))
        {
            ((agentmaster)Master).DefaultValidator.ErrorMessage = String.Format("Invalid file for {0}. Please provide a valid photo (.jpg, .gif, or .png).", ufPhoto.Label);
            ((agentmaster)Master).DefaultValidator.IsValid = false;
            return false;
        }

        // Create image
        System.Drawing.Image image = null;
        try
        {
            // Get image from input stream
            image = System.Drawing.Image.FromStream(file.InputStream);

            // Create temporary file name
            int agentId = Global.GetAgentId();
            string fileName = String.Format("tmp_{0}_{1}.jpg", agentId, DateTime.UtcNow.ToFileTimeUtc());
            string filePath = String.Concat(Global.PhotosDirectory, fileName);

            // Create a pointer to the temporary name so we can rename it after the listing is saved
            ViewState[ufPhoto.Label] = fileName;

            // Create photo
            Global.CreatePhoto(image, filePath);
        }
        catch (Exception ex)
        {
            // Write error to database
            Global.LogError(ex, "Error uploading photo");
            return false;
        }
        finally
        {
            if (image != null)
                image.Dispose();
        }

        return true;
    }
}
