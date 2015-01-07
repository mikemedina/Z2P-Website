using System;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ZeroToProgrammer.Tables;
using System.Data;

namespace ZeroToProgrammer
{
    public partial class News : System.Web.UI.Page
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

            Build_News_Section();
            
        }

        private void Build_News_Section()
        {

            DataTable news;
            try
            {
                news = NewsTable.Get_News();
            }
            catch (Exception ex)
            {
                MasterPage.SetError("Error loading from database: \n" + ex.Message);
                return;
            }

            if (news.Rows.Count == 0)
            {
                MasterPage.SetError("No results found");
                return;
            }

            foreach (DataRow row in news.Rows)
            {
                Panel panel = new Panel();
                HtmlGenericControl header = new HtmlGenericControl("h2");
                header.InnerHtml = row["title"].ToString();
                panel.Controls.Add(header);

                HtmlGenericControl date = new HtmlGenericControl("p");
                date.InnerHtml = ((DateTime)row["modified_date"]).ToString("MM/dd/yy");
                panel.Controls.Add(date);

                HtmlGenericControl body = new HtmlGenericControl("p");
                body.InnerHtml = row["content"].ToString();
                panel.Controls.Add(body);

                pnlNews.Controls.Add(panel);
            }

        }
    }
}