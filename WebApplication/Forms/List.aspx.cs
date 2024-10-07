using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.DataLib;

namespace WebApplication.Forms
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubmissions();
            }
        }

        private void LoadSubmissions()
        {
            using (var context = new TechnicalTestDbEntities())
            {
                var submissions = context.FormSubmissions
                    .Select(s => new
                    {
                        s.Id,
                        s.FirstName,
                        s.LastName,
                        s.Email,
                        s.LevelOfStudy,
                        s.AdditionalAccessibilityRequirements,
                        DisabilityTypeIds = s.DisabilityTypes.Select(d => d.DisabilityName).ToList() 
                    })
                    .ToList();

                var displaySubmissions = submissions.Select(s => new
                {
                    s.Id,
                    s.FirstName,
                    s.LastName,
                    s.Email,
                    LevelOfStudyDisplay = SplitCamelCase(s.LevelOfStudy),
                    s.AdditionalAccessibilityRequirements,
                    DisabilityTypesDisplay = string.Join(", ", s.DisabilityTypeIds) 
                }).ToList();

                // Bind the submissions to the GridView
                gvSubmissions.DataSource = displaySubmissions;
                gvSubmissions.DataBind();
            }
        }


        protected void gvSubmissions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                int submissionId = Convert.ToInt32(e.CommandArgument);

                Response.Redirect($"ViewSubmission.aspx?id={submissionId}");
            }
        }
        private string SplitCamelCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return System.Text.RegularExpressions.Regex.Replace(input, "(?<!^)([A-Z])", " $1");
        }

    }
}