﻿using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class AddContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Reset_Labels();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (!Entry_Is_Valid()) return;

            try
            {
                NewsTable.Add(txtTitle.Text, txtContent.Text);
            }
            catch (Exception ex)
            {
                lblError.Text = "Error saving to database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            lblSuccess.Text = "Submission Successful";
            lblSuccess.Visible = true;

            txtTitle.Text = string.Empty;
            txtContent.Text = string.Empty;
        }

        private bool Entry_Is_Valid()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblError.Text = "Please enter a title";
                lblError.Visible = true;
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                lblError.Text = "Please enter something into the content area";
                lblError.Visible = true;
                return false;
            }
            return true;
        }
        
        private void Reset_Labels()
        {
            lblError.Text = string.Empty;
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }
    }
}