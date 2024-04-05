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

public partial class agents_addcommercial : Page
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
        cbfForLease.CheckBox.Attributes.Add("onchange", String.Format("toggleField('{0}')", tfLeasePrice.ClientID));
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
            bool isForExchange = cbfForExchange.Checked;
            bool isForLease = cbfForLease.Checked;
            int? leasePrice = Global.GetInt32(tfLeasePrice.Text);
            int? mortgageBalance = Global.GetInt32(tfMortgageBalance.Text);
            decimal? finishAllowSqFt = Global.GetDecimal(tfFinishAllowPerSqFt.Text);
            byte? percentRent = Global.GetByte(tfPercentRent.Text);
            bool willRemodel = cbfWillRemodel.Checked;

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
            string directions = Global.GetString(tfDirections.Text);

            // Property details
            PropertyType propertyType = null;
            int? propertyTypeId = Global.GetInt32(lfPropertyType.SelectedValue);
            if (propertyTypeId != null)
                propertyType = facade.Get<PropertyType>(propertyTypeId);
            string lotSize = Global.GetString(tfLotSize.Text);
            decimal? acreage = Global.GetDecimal(tfAcreage.Text);
            int? totalBuildingSqFt = Global.GetInt32(tfTotalBuildingSqFt.Text);
            int? totalAvailableSqFt = Global.GetInt32(tfTotalAvailableSqFt.Text);
            int? minSqFt = Global.GetInt32(tfMinSqFt.Text);
            int? maxContiguousSqFt = Global.GetInt32(tfMaxContiguousSqFt.Text);
            byte? numDocks = Global.GetByte(tfNumDocks.Text);
            string dockSize = Global.GetString(tfDockSize.Text);
            string baySize = Global.GetString(tfBaySize.Text);
            byte? numDriveInDoors = Global.GetByte(tfNumDriveInDoors.Text);
            string driveInDoorSize = Global.GetString(tfDriveInDoorSize.Text);
            short? numUnits = Global.GetInt16(tfNumUnits.Text);
            byte? numFloorsAboveGround = Global.GetByte(tfNumFloorsAboveGround.Text);
            short? totalParking = Global.GetInt16(tfTotalParking.Text);
            decimal? parkRate = Global.GetDecimal(tfParkRate.Text);
            int? trafficCount = Global.GetInt32(tfTrafficCount.Text);
            string ceilingHeight = Global.GetString(tfCeilingHeight.Text);
            short? yearBuilt = Global.GetInt16(tfYearBuilt.Text);
            short? yearRemodeled = Global.GetInt16(tfYearRemodeled.Text);
            bool isWaterfront = cbfWaterfront.Checked;
            string previousUse = Global.GetString(tfPreviousUse.Text);
            string useCode = Global.GetString(tfUseCode.Text);
            string zoning = Global.GetString(tfZoning.Text);
            short? occupancyRate = Global.GetInt16(tfOccupancyRate.Text);
            string nearInterchange = Global.GetString(tfNearInterchange.Text);
            decimal? distanceToInterchange = Global.GetDecimal(tfDistanceToInterchange.Text);
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

            // Save to the commercial table
            CommercialListing commercialListing = new CommercialListing
                                                      {
                                                          BaySize = baySize,
                                                          CeilingHgt = ceilingHeight,
                                                          DistToInterc = distanceToInterchange,
                                                          DockSize = dockSize,
                                                          FinAllowSqFt = finishAllowSqFt,
                                                          ForExchange = isForExchange,
                                                          ForLease = isForLease,
                                                          ForSale = isForSale,
                                                          LeasePrice = leasePrice,
                                                          Listing = listing,
                                                          MinAvSqFt = minSqFt,
                                                          MortBalance = mortgageBalance,
                                                          MxContAvSqFt = maxContiguousSqFt,
                                                          NearInterchange = nearInterchange,
                                                          NumDrvInDrs = numDriveInDoors,
                                                          DrvInDrSize = driveInDoorSize,
                                                          NumOfDocks = numDocks,
                                                          NumOfFlrAbvGrnd = numFloorsAboveGround,
                                                          NumOfUnits = numUnits,
                                                          OccupRate = occupancyRate,
                                                          PercentRent = percentRent,
                                                          PreviousUse = previousUse,
                                                          PrkRatPerK = parkRate,
                                                          UseCode = useCode,
                                                          TotAvSqFt = totalAvailableSqFt,
                                                          TotBldgSqFt = totalBuildingSqFt,
                                                          TotParking = totalParking,
                                                          TrafCntPDay = trafficCount,
                                                          WillllRemod = willRemodel,
                                                          YearBuilt = yearBuilt,
                                                          YearRemod = yearRemodeled,
                                                          Zoning = zoning
                                                      };
            facade.Save(commercialListing);

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
            IList<PropertyType> propertyTypes = facade.GetPropertyTypes(ListingType.Commercial);
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

            IList<CommercialFeature> features = facade.GetList<CommercialFeature>();
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
