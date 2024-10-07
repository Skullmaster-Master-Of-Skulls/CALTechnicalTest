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
                string firstName = txtFirstName.Text.Trim();
                string lastName = txtLastName.Text.Trim();
                string email = txtEmail.Text;
                string additionalAccessibilityReq = txtAccessibilityReq.Text;

                List<int> selectedDisabilityTypeIds = cblDisabilityType.Items.Cast<ListItem>()
                    .Where(item => item.Selected)
                    .Select(item =>
                    {
                        int value;
                        return int.TryParse(item.Value, out value) ? value : -1; 
                    })
                    .Where(value => value != -1) // Filter out invalid values
                    .ToList();

                using (var context = new TechnicalTestDbEntities())
                {
                    var submission = new FormSubmission
                    {
                        FirstName = firstName,  
                        LastName = lastName,    
                        Email = email,
                        AdditionalAccessibilityRequirements = additionalAccessibilityReq
                    };

                    foreach (var disabilityTypeId in selectedDisabilityTypeIds)
                    {
                        var disabilityType = context.DisabilityTypes.Find(disabilityTypeId);
                        if (disabilityType != null)
                        {
                            submission.DisabilityTypes.Add(disabilityType);
                        }
                    }

                    context.FormSubmissions.Add(submission);
                    context.SaveChanges(); 
                }
            }
        }

    }
}
