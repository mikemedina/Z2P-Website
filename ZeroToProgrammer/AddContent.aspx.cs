using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class AddContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            lblError.Visible = false;
            lblSuccess.Visible = false;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                lblError.Text = "Please enter a title";
                lblError.Visible = true;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                lblError.Text = "Please enter something into the content area";
                lblError.Visible = true;
                return;
            }

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
        }
    }
}