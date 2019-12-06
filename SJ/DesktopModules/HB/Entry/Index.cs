namespace SJ.DesktopModules.HB.Entry
{
    using System;
    using System.Configuration;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Class;
    using WebSiteBase.Controls;
    using WebSiteBase.Utilities;

    public class Index : Page
    {
        protected HtmlInputHidden applicationpath;
        protected Button btnLogin;
        protected Button btnRegister;
        protected Panel divPublicKey;
        protected HtmlForm form1;
        protected HtmlHead header;
        protected ImageBase IBSep;
        protected UserControl JQR1;
        protected Label lblCopyRight;
        protected Label lblPortalName;
        protected Label lblSupport;
        private int nUserId;
        protected DropDownList selPortal;
        protected HtmlTableRow trPortal;
        protected HtmlInputPassword txtPassword;
        protected HtmlInputText txtUserName;

        public Index()
        {
            this.nUserId = -1;
            base..ctor();
            return;
        }

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            string str;
            SitePortal[] portalArray;
            int num;
            SitePortal portal;
            bool flag;
            this.Session["global_pid"] = (int) 0;
            this.nUserId = FunUtil.GetCurrentUserID();
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            this.applicationpath.Value = Globals.get_ApplicationPath();
            str = ConfigurationManager.AppSettings["dbdefaultportal"];
            if ((base.IsPostBack == 0) != null)
            {
                goto Label_0069;
            }
            goto Label_012A;
        Label_0069:
            this.lblPortalName.Text = PortalSettings.get_PortalName();
            portalArray = SitePortal.GetAllPortal();
            if (((portalArray == null) ? 0 : ((((int) portalArray.Length) < 2) == 0)) != null)
            {
                goto Label_00AA;
            }
            this.trPortal.Visible = 0;
            goto Label_012A;
        Label_00AA:
            this.trPortal.Visible = 1;
            this.selPortal.Items.Clear();
            num = 1;
            goto Label_00FE;
        Label_00CD:
            portal = portalArray[num];
            this.selPortal.Items.Add(new ListItem(portal.Title, &portal.id.ToString()));
            num += 1;
        Label_00FE:
            if ((num < ((int) portalArray.Length)) != null)
            {
                goto Label_00CD;
            }
            PageUtil.SetSel(this.selPortal, str);
            this.Session["global_allportal"] = portalArray;
        Label_012A:
            return;
        }
    }
}

