namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using System;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using WebSiteBase.Utilities;

    public class Login : Page
    {
        protected HtmlForm form1;

        public Login()
        {
            base..ctor();
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            string str2;
            string str3;
            bool flag;
            str = Util.GetString(base.Request, "returl", "");
            str2 = Util.GetString(base.Request, "targeturl", "");
            if (((string.IsNullOrEmpty(str2) != null) ? 1 : (str2.IndexOf("%3d") < 0)) != null)
            {
                goto Label_0052;
            }
            str2 = HttpUtility.UrlDecode(str2);
        Label_0052:
            str3 = "Index.aspx";
            str3 = str3 + string.Format("?returl={0}&targeturl={1}&rnd={2}", HttpUtility.UrlEncode(str), HttpUtility.UrlEncode(str2), (int) PageUtil.rnd.Next());
            base.Response.Redirect(str3, 1);
        Label_0094:
            return;
        }
    }
}

