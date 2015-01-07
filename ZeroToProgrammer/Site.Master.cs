using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ZeroToProgrammer
{
    public partial class Site : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lblError.Visible = false;
            lblSuccess.Visible = false;

            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.Name != null)
                {
                    Label lblUser = new Label();
                    lblUser.Text = HttpContext.Current.User.Identity.Name;
                    divUserInfo.Controls.Add(lblUser);

                    LinkButton lnkLogout = new LinkButton();
                    lnkLogout.Text = "Logout";
                    lnkLogout.Click += Logout;

                    divUserInfo.Controls.Add(lnkLogout);
                }
            }

        }

        private void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // clear authentication cookie
            HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie1.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie1);

            // clear session cookie
            HttpCookie cookie2 = new HttpCookie("ASP.NET_SessionId", "");
            cookie2.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie2);
        }

        public void SetError(string text)
        {
            lblError.Text = text;
            lblError.Visible = true;
        }

        public void SetSuccess(string text)
        {
            lblSuccess.Text = text;
            lblSuccess.Visible = true;
        }

    }
}