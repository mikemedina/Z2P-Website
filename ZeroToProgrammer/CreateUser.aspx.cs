using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class CreateUser : System.Web.UI.Page
    {
        private Site _masterPage;
        private Site MasterPage
        {

            get
            {
                if (_masterPage == null)
                    _masterPage = Page.Master as Site;

                return _masterPage;
            }
            set
            {
                _masterPage = value;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            Reset_Colors();

            if (!Fields_Are_Valid()) return;

            try
            {
                UsersTable.Add(txtUserName.Text, BCrypt.Net.BCrypt.HashPassword(txtPassword.Text), txtEmail.Text,
                               txtFirstName.Text, txtLastName.Text, txtAge.Text);
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error saving to database: \n" + ex.Message);
                return;
            }

            Reset_Page();

            MasterPage.SetSuccess("Account successfully created!");

        }

        private void Reset_Page()
        {

            // Reset Fields
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAge.Text = string.Empty;
            Reset_Colors();

        }

        private void Reset_Colors()
        {

            lblUserName.ForeColor = System.Drawing.Color.Black;
            lblPassword.ForeColor = System.Drawing.Color.Black;
            lblConfirmPassword.ForeColor = System.Drawing.Color.Black;
            lblEmail.ForeColor = System.Drawing.Color.Black;
            lblFirstName.ForeColor = System.Drawing.Color.Black;
            lblLastName.ForeColor = System.Drawing.Color.Black;
            lblAge.ForeColor = System.Drawing.Color.Black;

        }

        private bool Fields_Are_Valid()
        {

            // User Name
            Regex rgx_usr_name = new Regex("[^A-Za-z0-9]");
            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MasterPage.SetError("Please enter a User Name");
                return false;
            }

            if (txtUserName.Text.Length < 6)
            {
                MasterPage.SetError("User Name must be at least 6 characters");
                return false;
            }

            if (rgx_usr_name.IsMatch(txtUserName.Text))
            {
                MasterPage.SetError("User Name must be alphanumeric");
                return false;
            }

            DataTable users;
            try
            {
                users = UsersTable.Get_User_Names();
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error loading from database: \n" + ex.Message);
                return false;
            }

            foreach (DataRow row in users.Rows)
            {
                if (txtUserName.Text == row["user_name"].ToString())
                {
                    MasterPage.SetError("This User Name already exists");
                    lblUserName.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }

            // Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MasterPage.SetError("Please enter a Password");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                MasterPage.SetError("Password must be at least 8 characters");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!(txtPassword.Text.Any(c => char.IsLetter(c))
               && txtPassword.Text.Any(c => char.IsDigit(c))
               && (txtPassword.Text.Any(c => char.IsSymbol(c))
               ||  txtPassword.Text.Any(c => char.IsPunctuation(c)))))
            {
                MasterPage.SetError("Password must contain at least one letter, one number, and one symbol");
                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Confirm Password
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MasterPage.SetError("Please confirm your Password");
                lblConfirmPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                MasterPage.SetError("Passwords do not match");
                lblConfirmPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Email
            try
            {
                var addr = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                MasterPage.SetError("Invalid Email Address");
                lblEmail.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // First Name
            Regex rgx_names = new Regex("[^A-Za-z]");
            if (!string.IsNullOrEmpty(txtFirstName.Text) && rgx_names.IsMatch(txtFirstName.Text))
            {
                MasterPage.SetError("First Name must contain only letters");
                lblFirstName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Last Name
            if (!string.IsNullOrEmpty(txtLastName.Text) && rgx_names.IsMatch(txtLastName.Text))
            {
                MasterPage.SetError("Last Name must contain only letters");
                lblLastName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Age
            if (!txtAge.Text.All(c => char.IsNumber(c)))
            {
                MasterPage.SetError("Age must contain only numbers");
                lblAge.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;

        }
    }
}