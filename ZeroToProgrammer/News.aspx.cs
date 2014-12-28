using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace ZeroToProgrammer
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblError.Text = string.Empty;
            lblError.Visible = false;

            SqlConnection conn = new SqlConnection("Server=MIKES_LAPTOP\\SQLEXPRESS;Database=ZtoP;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand("SELECT title, content, modified_date FROM News", conn);
            SqlDataReader reader;

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error loading from database: \n" + ex.Message;
                lblError.Visible = true;
                return;
            }

            if(!reader.HasRows)
            {
                lblError.Text = "No results found";
                lblError.Visible = true;
                return;
            }

            while(reader.Read())
            {
                Panel panel = new Panel();
                HtmlGenericControl header = new HtmlGenericControl("h2");
                header.InnerHtml = reader.GetString(0);
                panel.Controls.Add(header);

                HtmlGenericControl date = new HtmlGenericControl("p");
                date.InnerHtml = reader.GetDateTime(2).ToString("MM/dd/yy");
                panel.Controls.Add(date);

                HtmlGenericControl body = new HtmlGenericControl("p");
                body.InnerHtml = reader.GetString(1);
                panel.Controls.Add(body);

                pnlNews.Controls.Add(panel);
            }

            reader.Close();
            conn.Close();
        }
    }
}