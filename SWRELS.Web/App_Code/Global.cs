using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web;
using System.Web.Security;
using SWRELS.Domain;
using SWRELS.Facade;

public static class Global
{
    public static readonly string[] MonthNames = new[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    public static readonly string[] StateAbbreviations = new[] { "AK", "AL", "AR", "AZ", "CA", "CO", "CT", "DE", "FL", "GA", "HI", "IA", "ID", "IL", "IN", "KS", "KY", "LA", "MA", "MD", "ME", "MI", "MN", "MO", "MS", "MT", "NC", "ND", "NE", "NH", "NJ", "NM", "NV", "NY", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VA", "VT", "WA", "WI", "WV", "WY" };
    public static readonly string[] StateNames = new[] { "Alaska", "Alabama", "Arkansas", "Arizona", "California", "Colorado", "Connecticut", "Delaware", "Florida", "Georgia", "Hawaii", "Iowa", "Idaho", "Illinois", "Indiana", "Kansas", "Kentucky", "Louisiana", "Massachusetts", "Maryland", "Maine", "Michigan", "Minnesota", "Missouri", "Mississippi", "Montana", "North Carolina", "North Dakota", "Nebraska", "New Hampshire", "New Jersey", "New Mexico", "Nevada", "New York", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Virginia", "Vermont", "Washington", "Wisconsin", "West Virginia", "Wyoming" };
    public static readonly string PhotosDirectory = HttpContext.Current.Server.MapPath("~/photos/");
    public const int PhotoLimit = 25;

    public static int GetAgentId()
    {
        int agentId = 0;
        FormsIdentity identity = HttpContext.Current.User.Identity as FormsIdentity;
        if (identity == null || !Int32.TryParse(identity.Ticket.UserData, out agentId))
            FormsAuthentication.RedirectToLoginPage();
        return agentId;
    }

    public static void LogError(Exception ex, string notes)
    {
        // Sanitize error message
        string errorMessage = !String.IsNullOrEmpty(ex.Message) ? ex.Message.Trim() : String.Empty;
        if (errorMessage.Length > 100)
            errorMessage = errorMessage.Substring(0, 100);

        // Write error to database
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            ErrorMsg message = new ErrorMsg { Message = errorMessage, ProgNotes = notes };
            facade.Save(message);
        }
    }

    public static void LogIn(string userName, string password)
    {
        // Validate that user name and password are not empty
        if (String.IsNullOrEmpty(userName) || String.IsNullOrEmpty(password))
        {
            FormsAuthentication.RedirectToLoginPage("error=invalidlogin");
            return;
        }

        // Process login
        using (SwrelsFacade facade = new SwrelsFacade())
        {
            Agent agent = facade.GetAgentByLogin(userName, password);
            if (agent == null)
            {
                FormsAuthentication.RedirectToLoginPage("error=invalidlogin");
                return;
            }

            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, true);
            FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            FormsAuthenticationTicket newAuthTicket = new FormsAuthenticationTicket(authTicket.Version, authTicket.Name, authTicket.IssueDate, authTicket.Expiration, authTicket.IsPersistent, agent.Id.ToString());
            authCookie.Value = FormsAuthentication.Encrypt(newAuthTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
            HttpContext.Current.Response.Redirect(FormsAuthentication.DefaultUrl);
        }
    }

    public static void CreatePhoto(Image image, string filePath)
    {
        // TODO: Figure out the optimum width for listing photos
        const int width = 400;
        int height = image.Height * width / image.Width;

        Bitmap photo = null;
        Graphics photoCanvas = null;
        try
        {
            PixelFormat pixelFormat = image.PixelFormat;
            if (pixelFormat.ToString().Contains("Indexed"))
                pixelFormat = PixelFormat.Format24bppRgb;
            photo = new Bitmap(width, height, pixelFormat);
            photo.SetResolution(72, 72);
            photoCanvas = Graphics.FromImage(photo);
            photoCanvas.SmoothingMode = SmoothingMode.AntiAlias;
            photoCanvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            photoCanvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
            photoCanvas.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
            photo.Save(filePath, ImageFormat.Jpeg);
        }
        finally
        {
            if (photo != null)
                photo.Dispose();
            if (photoCanvas != null)
                photoCanvas.Dispose();
        }
    }

    #region String Conversion Methods
    public static string GetString(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? text.Trim() : null;
    }

    public static DateTime? GetDate(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? Convert.ToDateTime(text.Trim()) : (DateTime?)null;
    }

    public static decimal? GetDecimal(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? Convert.ToDecimal(text.Trim()) : (decimal?)null;
    }

    public static int? GetInt32(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? Convert.ToInt32(text.Trim()) : (int?)null;
    }

    public static short? GetInt16(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? Convert.ToInt16(text.Trim()) : (short?)null;
    }

    public static byte? GetByte(string text)
    {
        return !String.IsNullOrEmpty(text.Trim()) ? Convert.ToByte(text.Trim()) : (byte?)null;
    }
    #endregion
}
