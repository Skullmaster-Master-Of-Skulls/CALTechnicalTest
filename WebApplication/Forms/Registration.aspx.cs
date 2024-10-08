using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.DataLib;

namespace WebApplication.Forms
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load details sent from submissions page
                if (Request.QueryString["id"] != null)
                {
                    int submissionId;
                    if (int.TryParse(Request.QueryString["id"], out submissionId))
                    {
                        LoadSubmissionData(submissionId);
                    }
                }
            }
        }
        protected void LoadSubmissionData(int submissionId)
        {
            using (var context = new TechnicalTestDbEntities())
            {
                var submission = context.FormSubmissions
                    .Include("DisabilityTypes")
                    .FirstOrDefault(s => s.Id == submissionId);

                if (submission != null)
                {
                    txtFirstName.Text = submission.FirstName;
                    txtLastName.Text = submission.LastName;
                    txtEmail.Text = submission.Email;
                    rblLevelOfStudy.SelectedValue = submission.LevelOfStudy;
                    txtAccessibilityReq.Text = submission.AdditionalAccessibilityRequirements;
                    ddlPreferredPronoun.SelectedValue = submission.PreferredPronoun;
                    rblInternationalStatus.SelectedValue = submission.International ? "true" : "false";
                    
                    if (submission.Consent)
                    {
                        string fullName = $"{submission.FirstName} {submission.LastName}";
                        txtConsentFullName.Text = fullName;
                        txtConfirmConsentFullName.Text = fullName;
                    }

                    foreach (ListItem item in cblDisabilityType.Items)
                    {
                        if (submission.DisabilityTypes.Any(d => d.DisabilityName == item.Text))
                        {
                            item.Selected = true;
                        }
                    }
                }
                else
                {
                    Response.Redirect("List.aspx");
                }
            }
        }

        //Checks to see if at least one checkbox is selected. Should there be a text field that pops up if Other is selected?
        protected void cvDisabilityType_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = cblDisabilityType.Items.Cast<ListItem>().Any(item => item.Selected);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                int submissionId;

                using (var context = new TechnicalTestDbEntities())
                {
                    FormSubmission submission;

                    //Existing submission
                    if (int.TryParse(Request.QueryString["id"], out submissionId))
                    {

                        submission = context.FormSubmissions.FirstOrDefault(s => s.Id == submissionId);
                    }
                    //Create new submission
                    else
                    {
                        submission = new FormSubmission();
                        context.FormSubmissions.Add(submission);
                    }

                    PopulateSubmissionData(submission, context);

                    context.SaveChanges();
                }
                Response.Redirect("List.aspx");
            }
        }

        protected void PopulateSubmissionData(FormSubmission submission, TechnicalTestDbEntities context)
        {
            // Populate form submission data
            submission.FirstName = txtFirstName.Text.Trim();
            submission.LastName = txtLastName.Text.Trim();
            submission.Email = txtEmail.Text.Trim();
            submission.LevelOfStudy = rblLevelOfStudy.SelectedValue;
            submission.AdditionalAccessibilityRequirements = txtAccessibilityReq.Text.Trim();
            submission.PreferredPronoun = ddlPreferredPronoun.SelectedValue;
            submission.International = bool.Parse(rblInternationalStatus.SelectedValue);
            submission.Consent = IsConsentValid();

            // Handle disability types
            submission.DisabilityTypes.Clear(); // Clear existing
            foreach (ListItem item in cblDisabilityType.Items)
            {
                if (item.Selected)
                {
                    var disability = context.DisabilityTypes.FirstOrDefault(d => d.DisabilityName == item.Text);
                    if (disability != null)
                    {
                        submission.DisabilityTypes.Add(disability);
                    }
                }
            }
        }

        protected bool IsConsentValid()
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string expectedFullName = $"{firstName} {lastName}"; 

            string enteredFullName = txtConsentFullName.Text.Trim(); // Full Name entered in Consent
            string confirmFullName = txtConfirmConsentFullName.Text.Trim(); 

            return enteredFullName.Equals(expectedFullName, StringComparison.InvariantCultureIgnoreCase)
                && confirmFullName.Equals(expectedFullName, StringComparison.InvariantCultureIgnoreCase);
        }
        protected void ValidateFullNameMatch(object sender, ServerValidateEventArgs args)
        {
                args.IsValid = IsConsentValid(); 
        }

    }
}
