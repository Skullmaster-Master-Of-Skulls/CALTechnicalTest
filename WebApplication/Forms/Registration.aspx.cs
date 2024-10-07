using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication.Forms
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void cvDisabilityType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Check if at least one checkbox is selected
            args.IsValid = cblDisabilityType.Items.Cast<ListItem>().Any(item => item.Selected);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Collect data from form controls
                string firstName = txtFirstName.Text;
                string lastName = txtLastName.Text;
                string email = txtEmail.Text;
                string preferredPronouns = ddlPronouns.SelectedValue;
                string levelOfStudy = rblLevelOfStudy.SelectedValue;
                string internationalStatus = rblInternationalStatus.SelectedValue;

                // Collect multi-selection checkbox values
                List<string> disabilityTypes = new List<string>();
                foreach (ListItem item in cblDisabilityType.Items)
                {
                    if (item.Selected)
                    {
                        disabilityTypes.Add(item.Value);
                    }
                }

                string additionalAccessibilityReq = txtAccessibilityReq.Text;
                string consentFullName = txtConsentFullName.Text;
                string confirmFullName = txtConfirmConsentFullName.Text;

                // Perform database save or further processing here...

                // Redirect or display success message
                Response.Redirect("Success.aspx");
            }
        }


    }
}