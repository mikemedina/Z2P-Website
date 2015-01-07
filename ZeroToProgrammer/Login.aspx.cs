﻿using System;
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

            DataTable user;
            try
            {
                user = UsersTable.Get_User(txtUserName.Text);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading from database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            if (BCrypt.Net.BCrypt.Verify(txtPassword.Text, user.Select("password").ToString()))
            {
                // Successful Login
                Reset_Page();
                lblSuccess.Visible = true;

                lblWelcome.Visible = true;

                DateTime last_login = DateTime.Parse(user.Select("last_login").ToString());
                if (!string.IsNullOrWhiteSpace(user.Select("first_name").ToString()))
                {
                    lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was at {1: hh:mm} on {1: MM/dd/yy}", user.Select("first_name").ToString(), last_login);
                    return;
                }
                else
                {
                    lblWelcome.Text = string.Format("Welcome, {0}! Your last visit was {1}", user.Select("user_name").ToString(), last_login);
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Incorrect Password";

                lblPassword.ForeColor = System.Drawing.Color.Red;
                return;
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

            Reset_Colors();

        }

        private void Reset_Colors()
        {

            lblUserName.ForeColor = System.Drawing.Color.Black;
            lblPassword.ForeColor = System.Drawing.Color.Black;

        }

    }
}