using System;
using ZeroToProgrammer.Tables;

namespace ZeroToProgrammer
{
    public partial class AddContent : System.Web.UI.Page
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

            if (!Entry_Is_Valid()) return;

            try
            {
                NewsTable.Add(txtTitle.Text, txtContent.Text);
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error saving to database: \n" + ex.Message);
                return;
            }

            Reset_Page();

            MasterPage.SetSuccess("Submission Successful");

        }

        private void Reset_Page()
            {

                // Reset fields
                txtTitle.Text = string.Empty;
                txtContent.Text = string.Empty;

            }

        private bool Entry_Is_Valid()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MasterPage.SetError("Please enter a title");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                MasterPage.SetError("Please enter something into the content area");
                return false;
            }
            return true;
        }
        
    }
}