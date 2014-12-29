using System;
using System.Data;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            Reset_Colors();

            DataTable users;
            try
            {
                users = UsersTable.Get_Users();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading from database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            if (users.Rows.Count == 0)
            {
                lblError.Text = "Please create an account";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Please enter a User Name";

                lblUserName.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Please enter a Password";

                lblPassword.ForeColor = System.Drawing.Color.Red;
                return;
            }

            foreach (DataRow row in users.Rows)
            {
                if (txtUserName.Text == row["user_name"].ToString())
                {
                    if (txtPassword.Text == row["password"].ToString())
                    {
                        // Successful Login
                        Reset_Page();
                        lblSuccess.Visible = true;

                        lblWelcome.Visible = true;

                        DateTime last_login = DateTime.Parse(row["last_login"].ToString());
                        if (!string.IsNullOrWhiteSpace(row["first_name"].ToString()))
                        {
                            lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was at {1: hh:mm} on {1: MM/dd/yy}", row["first_name"].ToString(), last_login);
                            return;
                        }
                        else
                        {
                            lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was {1}", row["user_name"].ToString(), last_login);
                        }
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Incorrect Password";

                        lblPassword.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }
            }

            // User Name match never found
            lblError.Visible = true;
            lblError.Text = "Incorrect Username";

            lblUserName.ForeColor = System.Drawing.Color.Red;
            return;

        }

        private void Reset_Page()
        {

            // Reset Labels
            lblError.Visible = false;
            lblError.Text = string.Empty;
            lblWelcome.Visible = false;
            lblWelcome.Text = string.Empty;
            lblSuccess.Visible = false;
            Reset_Colors();

            // Reset Fields
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

        private void Reset_Colors()
        {

            lblUserName.ForeColor = System.Drawing.Color.Black;
            lblPassword.ForeColor = System.Drawing.Color.Black;

        }

    }
}