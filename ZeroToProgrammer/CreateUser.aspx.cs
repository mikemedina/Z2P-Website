using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class CreateUser : System.Web.UI.Page
    {
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
                lblError.Text = "Error saving to database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            Reset_Page();

            lblSuccess.Visible = true;

        }

        private void Reset_Page()
        {

            // Reset Labels
            lblError.Visible = false;
            lblError.Text = string.Empty;
            lblSuccess.Visible = false;

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
                lblError.Text = "Please enter a User Name";
                lblError.Visible = true;

                lblUserName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtUserName.Text.Length < 6)
            {
                lblError.Text = "User Name must be at least 6 characters";
                lblError.Visible = true;

                lblUserName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (rgx_usr_name.IsMatch(txtUserName.Text))
            {
                lblError.Text = "User Name must be alphanumeric";
                lblError.Visible = true;

                lblUserName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            DataTable users;
            try
            {// TODO Make get_users function in userstable.cs
                users = UsersTable.Get_User(txtUserName.Text);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading from database: \n" + ex.Message;
                lblError.Visible = true;
                return false;
            }

            foreach (DataRow row in users.Rows)
            {
                if (txtUserName.Text == row["user_name"].ToString())
                {
                    lblError.Text = "This User Name already exists";
                    lblError.Visible = true;

                    lblUserName.ForeColor = System.Drawing.Color.Red;
                    return false;
                }
            }

            // Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Text = "Please enter a Password";
                lblError.Visible = true;

                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtPassword.Text.Length < 8)
            {
                lblError.Text = "Password must be at least 8 characters";
                lblError.Visible = true;

                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (!(txtPassword.Text.Any(c => char.IsLetter(c))
               && txtPassword.Text.Any(c => char.IsDigit(c))
               && (txtPassword.Text.Any(c => char.IsSymbol(c))
               ||  txtPassword.Text.Any(c => char.IsPunctuation(c)))))
            {
                lblError.Text = "Password must contain at least one letter, one number, and one symbol";
                lblError.Visible = true;

                lblPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Confirm Password
            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                lblError.Text = "Please confirm your Password";
                lblError.Visible = true;

                lblConfirmPassword.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                lblError.Text = "Passwords do not match";
                lblError.Visible = true;

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
                lblError.Text = "Invalid Email Address";
                lblError.Visible = true;

                lblEmail.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // First Name
            Regex rgx_names = new Regex("[^A-Za-z]");
            if (!string.IsNullOrEmpty(txtFirstName.Text) && rgx_names.IsMatch(txtFirstName.Text))
            {
                lblError.Text = "First Name must contain only letters";
                lblError.Visible = true;

                lblFirstName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Last Name
            if (!string.IsNullOrEmpty(txtLastName.Text) && rgx_names.IsMatch(txtLastName.Text))
            {
                lblError.Text = "Last Name must contain only letters";
                lblError.Visible = true;

                lblLastName.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            // Age
            if (!txtAge.Text.All(c => char.IsNumber(c)))
            {
                lblError.Text = "Age must contain only numbers";
                lblError.Visible = true;

                lblAge.ForeColor = System.Drawing.Color.Red;
                return false;
            }

            return true;

        }
    }
}