using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using ZeroToProgrammer.Tables;
using System.Data;

namespace ZeroToProgrammer
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblError.Text = string.Empty;
            lblError.Visible = false;

            DataTable news;
            try
            {
                news = NewsTable.Get_News();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading from database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            if(news.Rows.Count == 0)
            {
                lblError.Text = "No results found";
                lblError.Visible = true;
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