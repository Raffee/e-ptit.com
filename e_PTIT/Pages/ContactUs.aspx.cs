using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace e_PTIT.Pages
{
    public partial class ContactUs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlCountry.DataSource = GetCountry();
            ddlCountry.DataBind();
            ddlCountry.Items.Insert(0, "Select");

        }

        public List<string> GetCountry()
        {
            List<string> list = new List<string>();
            CultureInfo[] cultures =
                        CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures |
                        CultureTypes.SpecificCultures).OrderBy(clt => clt.EnglishName).ToArray();

            List<String> countryNames = new List<string>();

            foreach (CultureInfo ci in cultures)
            {
                try
                {
                    RegionInfo info2 = new RegionInfo(ci.LCID);
                    if (!countryNames.Contains(info2.EnglishName))
                    {
                        countryNames.Add(info2.EnglishName);
                    }
                }
                catch { }
            }
            countryNames.Sort();


            return countryNames;
        }

        protected void SendMail()
        {
            // Gmail Address from where you send the mail
            var fromAddress = "raffee.parseghian@gmail.com";
            // any address where the email will be sending
            var toAddress = "raffee.parseghian@gmail.com";
            //Password of your gmail address
            const string fromPassword = "Password";
            // Passing the values and make a email formate to display
            string subject = "contact us";
            string body = "From: " + txtName.Text + "\n";
            body += "Email: " + txtEmail.Text + "\n";
            body += "Subject: " + subject + "\n";
            body += "Question: \n" + txtMessage.Text + "\n";
            // smtp settings
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.UseDefaultCredentials = false;
                smtp.Host = "smtp.e-ptit.com";
                smtp.Port = 25;
                //smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("info@e-ptit.com", "password");
                smtp.Timeout = 20000;
            }
            // Passing values to smtp object
            smtp.Send(fromAddress, toAddress, subject, body);
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {

            try
            {
                //here on button click what will done 
                SendMail();
                //DisplayMessage.Text = "Your Comments after sending the mail";
                //DisplayMessage.Visible = true;
                //YourSubject.Text = "";
                //YourEmail.Text = "";
                //YourName.Text = "";
                //Comments.Text = "";
            }
            catch (Exception ex) {
                string x = ex.Message;
            }
        }

    }
}