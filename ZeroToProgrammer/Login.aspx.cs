using System;
using System.Data;
using System.Web.Security;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class Login : System.Web.UI.Page
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

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            DataTable user;
            try
            {
                user = UsersTable.Get_User(txtUserName.Text);
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error loading from database: \n" + ex.Message);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                MasterPage.SetError("Please enter a User Name");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MasterPage.SetError("Please enter a Password");
                return;
            }

            if (user.Rows.Count == 0)
            {
                MasterPage.SetError("Incorrect User Name or Password");
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(txtPassword.Text, user.Rows[0]["password"].ToString()))
            {
                // Successful Login
                Reset_Page();
                MasterPage.SetSuccess("Login Successful");
                lblWelcome.Visible = true;

                DateTime last_login = DateTime.Parse(user.Rows[0]["last_login"].ToString());
                if (!string.IsNullOrWhiteSpace(user.Rows[0]["first_name"].ToString()))
                {
                    lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was at {1: hh:mm} on {1: MM/dd/yy}", user.Rows[0]["first_name"].ToString(), last_login);
                }
                else
                {
                    lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was {1}", user.Rows[0]["user_name"].ToString(), last_login);
                }

                UsersTable.Update_Last_Login(user.Rows[0]["user_name"].ToString());

                // Redirects user to the page they were redirected to the login screen from
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, false);

                return;
            }
            else
            {
                MasterPage.SetError("Incorrect User Name or Password");
                return;
            }

        }

        private void Reset_Page()
        {

            // Reset Labels
            lblWelcome.Visible = false;
            lblWelcome.Text = string.Empty;

            // Reset Fields
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

    }
}