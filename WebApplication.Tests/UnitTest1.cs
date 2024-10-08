using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Web.UI.WebControls;
using WebApplication.Forms;

namespace WebApplication.Tests
{
    [TestClass]
    public class RegistrationTests
    {
        private Registration registrationPage;

        [TestInitialize]
        public void TestInitialize()
        {
            registrationPage = new Registration();

            SetPrivateField(registrationPage, "txtFirstName", new TextBox ());
            SetPrivateField(registrationPage, "txtLastName", new TextBox ());
            SetPrivateField(registrationPage, "txtEmail", new TextBox ());
            SetPrivateField(registrationPage, "txtAccessibilityReq", new TextBox ());
            SetPrivateField(registrationPage, "txtConsentFullName", new TextBox ());
            SetPrivateField(registrationPage, "txtConfirmConsentFullName", new TextBox ());
            SetPrivateField(registrationPage, "rblLevelOfStudy", new RadioButtonList { SelectedValue = "" });
            SetPrivateField(registrationPage, "ddlPreferredPronoun", new DropDownList { SelectedValue = "" });
            SetPrivateField(registrationPage, "rblInternationalStatus", new RadioButtonList { SelectedValue = "false" });
        }

        private void SetPrivateField(object target, string fieldName, object value)
        {
            var field = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(target, value);
        }

        private object GetPrivateField(object target, string fieldName)
        {
            var field = target.GetType().GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            return field.GetValue(target);
        }
        //FirstName tests
        [TestMethod]
        public void TestIsFirstNameValid_ValidFirstName_ReturnsTrue()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtFirstName", new TextBox { Text = "John" });

            // Act
            var txtFirstName = (TextBox)GetPrivateField(registrationPage, "txtFirstName");

            // Assert
            Assert.AreEqual("John", txtFirstName.Text, "Expected txtFirstName to be John.");
        }
        [TestMethod]
        public void TestIsFirstNameInvalid_InvalidFirstName_ReturnsFalse()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtFirstName", new TextBox { Text = "" });

            // Act
            var txtFirstName = (TextBox)GetPrivateField(registrationPage, "txtFirstName");

            // Assert
            Assert.IsFalse(!string.IsNullOrEmpty(txtFirstName.Text.Trim()), "Expected FirstName to be invalid (empty).");
        }

        //LastName Tests
        [TestMethod]
        public void TestIsLastNameValid_ValidLastName_ReturnsTrue()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtLastName", new TextBox { Text = "Doe" });

            // Act
            var txtLastName = (TextBox)GetPrivateField(registrationPage, "txtLastName");

            // Assert
            Assert.AreEqual("Doe", txtLastName.Text, "Expected txtFirstName to be Doe.");
        }
        [TestMethod]
        public void TestIsLastNameInvalid_InvalidLastName_ReturnsFalse()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtLastName", new TextBox { Text = "" });

            // Act
            var txtLastName = (TextBox)GetPrivateField(registrationPage, "txtLastName");

            // Assert
            Assert.IsFalse(!string.IsNullOrEmpty(txtLastName.Text.Trim()), "Expected LastName to be invalid (empty).");
        }
        //Email Tests
        [TestMethod]
        public void TestIsEmailValid_ValidEmail_ReturnsTrue()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtEmail", new TextBox { Text = "john.doe@example.com" });

            // Act
            var txtEmail = (TextBox)GetPrivateField(registrationPage, "txtEmail");
            bool isValidEmail = System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Assert
            Assert.IsTrue(isValidEmail, "Expected the email to be valid.");
        }
        [TestMethod]
        public void TestIsEmailValid_InvalidEmail_ReturnsFalse()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtEmail", new TextBox { Text = "john.doe@invalid" });

            // Act
            var txtEmail = (TextBox)GetPrivateField(registrationPage, "txtEmail");
            bool isValidEmail = System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            // Assert
            Assert.IsFalse(isValidEmail, "Expected the email to be invalid.");
        }

        //Pronoun Tests
        [TestMethod]
        public void TestPreferredPronoun_SelectedValue_ReturnsTrue()
        {
            // Arrange
            var ddlPreferredPronoun = new DropDownList();
            ddlPreferredPronoun.Items.Add(new ListItem("-- Select --", ""));
            ddlPreferredPronoun.Items.Add(new ListItem("He/Him", "He/Him"));
            ddlPreferredPronoun.Items.Add(new ListItem("She/Her", "She/Her"));
            ddlPreferredPronoun.Items.Add(new ListItem("They/Them", "They/Them"));
            ddlPreferredPronoun.SelectedValue = "He/Him"; 

            SetPrivateField(registrationPage, "ddlPreferredPronoun", ddlPreferredPronoun);

            // Act
            ddlPreferredPronoun = (DropDownList)GetPrivateField(registrationPage, "ddlPreferredPronoun");
            bool isSelected = !string.IsNullOrEmpty(ddlPreferredPronoun.SelectedValue);

            // Assert
            Assert.IsTrue(isSelected, "Expected a preferred pronoun to be selected.");
        }


        [TestMethod]
        public void TestPreferredPronoun_NoSelectedValue_ReturnsFalse()
        {
            // Arrange
            var ddlPreferredPronoun = new DropDownList();
            ddlPreferredPronoun.Items.Add(new ListItem("-- Select --", "")); 
            ddlPreferredPronoun.Items.Add(new ListItem("He/Him", "He/Him"));
            ddlPreferredPronoun.Items.Add(new ListItem("She/Her", "She/Her"));
            ddlPreferredPronoun.Items.Add(new ListItem("They/Them", "They/Them"));

            ddlPreferredPronoun.SelectedValue = "";

            SetPrivateField(registrationPage, "ddlPreferredPronoun", ddlPreferredPronoun);

            // Act
            ddlPreferredPronoun = (DropDownList)GetPrivateField(registrationPage, "ddlPreferredPronoun");
            bool isSelected = !string.IsNullOrEmpty(ddlPreferredPronoun.SelectedValue);

            // Assert
            Assert.IsFalse(isSelected, "Expected no preferred pronoun to be selected.");
        }

        //Level of Study Tests
        [TestMethod]
        public void TestLevelOfStudy_SelectedValue_ReturnsTrue()
        {
            // Arrange
            var rblLevelOfStudy = new RadioButtonList();
            rblLevelOfStudy.Items.Add(new ListItem("High school graduate", "HighSchoolGraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Undergraduate", "Undergraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Graduate", "Graduate"));

            rblLevelOfStudy.SelectedValue = "Undergraduate"; 

            SetPrivateField(registrationPage, "rblLevelOfStudy", rblLevelOfStudy);

            // Act
            rblLevelOfStudy = (RadioButtonList)GetPrivateField(registrationPage, "rblLevelOfStudy");
            bool isSelected = !string.IsNullOrEmpty(rblLevelOfStudy.SelectedValue);

            // Assert
            Assert.IsTrue(isSelected, "Expected a valid level of study to be selected.");
        }

        [TestMethod]
        public void TestLevelOfStudy_NoSelectedValue_ReturnsFalse()
        {
            // Arrange
            var rblLevelOfStudy = new RadioButtonList();
            rblLevelOfStudy.Items.Add(new ListItem("High school graduate", "HighSchoolGraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Undergraduate", "Undergraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Graduate", "Graduate"));

            rblLevelOfStudy.SelectedValue = ""; 

            SetPrivateField(registrationPage, "rblLevelOfStudy", rblLevelOfStudy);

            // Act
            rblLevelOfStudy = (RadioButtonList)GetPrivateField(registrationPage, "rblLevelOfStudy");
            bool isSelected = !string.IsNullOrEmpty(rblLevelOfStudy.SelectedValue);

            // Assert
            Assert.IsFalse(isSelected, "Expected no level of study to be selected.");
        }

        //This one should be impossible to get to
        [TestMethod]
        public void TestLevelOfStudy_InvalidSelectedValue_ReturnsFalse()
        {
            // Arrange
            var rblLevelOfStudy = new RadioButtonList();
            rblLevelOfStudy.Items.Add(new ListItem("High school graduate", "HighSchoolGraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Undergraduate", "Undergraduate"));
            rblLevelOfStudy.Items.Add(new ListItem("Graduate", "Graduate"));

            rblLevelOfStudy.SelectedValue = "InvalidValue"; 

            SetPrivateField(registrationPage, "rblLevelOfStudy", rblLevelOfStudy);

            // Act
            rblLevelOfStudy = (RadioButtonList)GetPrivateField(registrationPage, "rblLevelOfStudy");
            bool isSelected = rblLevelOfStudy.Items.FindByValue(rblLevelOfStudy.SelectedValue) != null;

            // Assert
            Assert.IsFalse(isSelected, "Expected no valid level of study to be selected.");
        }

        //International Tests
        [TestMethod]
        public void TestInternationalStatus_SelectedValueTrue_ReturnsTrue()
        {
            // Arrange
            var rblInternationalStatus = new RadioButtonList();
            rblInternationalStatus.Items.Add(new ListItem("International", "true"));
            rblInternationalStatus.Items.Add(new ListItem("Domestic", "false"));

            rblInternationalStatus.SelectedValue = "true"; 

            SetPrivateField(registrationPage, "rblInternationalStatus", rblInternationalStatus);

            // Act
            rblInternationalStatus = (RadioButtonList)GetPrivateField(registrationPage, "rblInternationalStatus");
            bool isInternational = rblInternationalStatus.SelectedValue == "true";

            // Assert
            Assert.IsTrue(isInternational, "Expected international status to be 'Yes' (true).");
        }

        [TestMethod]
        public void TestInternationalStatus_NoSelectedValue_ReturnsFalse()
        {
            // Arrange
            var rblInternationalStatus = new RadioButtonList();
            rblInternationalStatus.Items.Add(new ListItem("Yes", "true"));
            rblInternationalStatus.Items.Add(new ListItem("No", "false"));

            rblInternationalStatus.SelectedValue = ""; 

            SetPrivateField(registrationPage, "rblInternationalStatus", rblInternationalStatus);

            // Act
            rblInternationalStatus = (RadioButtonList)GetPrivateField(registrationPage, "rblInternationalStatus");
            bool isSelected = !string.IsNullOrEmpty(rblInternationalStatus.SelectedValue);

            // Assert
            Assert.IsFalse(isSelected, "Expected no international status to be selected.");
        }

        //Consent tests
        [TestMethod]
        public void TestIsConsentValid_ValidFullName_ReturnsTrue()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtFirstName", new TextBox { Text = "John" });
            SetPrivateField(registrationPage, "txtLastName", new TextBox { Text = "Doe" });
            SetPrivateField(registrationPage, "txtConsentFullName", new TextBox { Text = "John Doe" });
            SetPrivateField(registrationPage, "txtConfirmConsentFullName", new TextBox { Text = "John Doe" });

            // Act
            bool result = (bool)registrationPage.GetType().GetMethod("IsConsentValid", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(registrationPage, null);

            // Assert
            Assert.IsTrue(result, "Expected IsConsentValid to return true when full name matches.");
        }

        [TestMethod]
        public void TestIsConsentValid_InvalidFullName_ReturnsFalse()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtConsentFullName", new TextBox { Text = "Jane Doe" });
            SetPrivateField(registrationPage, "txtConfirmConsentFullName", new TextBox { Text = "Jane Doe" });

            // Act
            bool result = (bool)registrationPage.GetType().GetMethod("IsConsentValid", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(registrationPage, null);

            // Assert
            Assert.IsFalse(result, "Expected IsConsentValid to return false when full name does not match.");
        }

        [TestMethod]
        public void TestIsConsentValid_ConfirmFullNameMismatch_ReturnsFalse()
        {
            // Arrange
            SetPrivateField(registrationPage, "txtConsentFullName", new TextBox { Text = "John Doe" });
            SetPrivateField(registrationPage, "txtConfirmConsentFullName", new TextBox { Text = "Johnny Doe" });

            // Act
            bool result = (bool)registrationPage.GetType().GetMethod("IsConsentValid", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(registrationPage, null);

            // Assert
            Assert.IsFalse(result, "Expected IsConsentValid to return false when confirmation full name does not match.");
        }
    }
}
