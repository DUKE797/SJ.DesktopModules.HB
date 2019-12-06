namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class Default : PageBase
    {
        protected HtmlInputHidden applicationpath;
        protected UserControl BBR1;
        protected HtmlForm form1;
        public string FuncsArrayInfo;
        protected UserControl GBR1;
        protected HtmlInputHidden hdCurrentUserId;
        protected HtmlInputHidden hdRefreshTimeSpan;
        protected HtmlInputHidden hdTabMaxNum;
        protected HtmlHead header;
        protected Literal ltlNavTreeFunctions;
        protected Literal ltSiteName;
        protected Literal ltTopMenu;
        public string m_strCurPortal;
        public string m_strNewMessageCount;
        public string m_strOtherPortal;
        public string m_strTopPX;
        public string m_strUrl;
        public string m_strUserIcon;
        public string m_strUserInfo;
        protected HtmlGenericControl navTier;
        protected Panel navTree;
        public int nPortalId;
        public int nSelFuncId;
        public int nUserId;
        protected HtmlTitle title;

        public Default()
        {
            this.nPortalId = 1;
            this.nUserId = -1;
            this.nSelFuncId = -1;
            this.m_strUserIcon = "manbig.png";
            this.m_strUserInfo = "";
            this.m_strNewMessageCount = "";
            this.m_strCurPortal = "";
            this.m_strOtherPortal = "";
            this.m_strTopPX = "56px";
            this.FuncsArrayInfo = "";
            this.m_strUrl = "about:blank";
            base..ctor();
            return;
        }

        private unsafe string __AppendChildFuncs(Hashtable __htFuncTree, FuncTree __parentFunc)
        {
            List<FuncTree> list;
            StringBuilder builder;
            int num;
            string str;
            bool flag;
            int num2;
            list = (List<FuncTree>) __htFuncTree[(int) __parentFunc.Id];
            if (((null == list) == 0) != null)
            {
                goto Label_0030;
            }
            str = "";
            goto Label_015F;
        Label_0030:
            builder = new StringBuilder();
            if (((__parentFunc.DisplayMode == 2) == 0) != null)
            {
                goto Label_0056;
            }
            builder.Append("<ul class=\"two\" style=\"display:block;\">");
            goto Label_0062;
        Label_0056:
            builder.Append("<ul class=\"two\">");
        Label_0062:
            num = 0;
            goto Label_0138;
        Label_0069:
            num2 = 1;
            if (((list[num].Overdue == &num2.ToString()) == 0) != null)
            {
                goto Label_0093;
            }
            goto Label_0134;
        Label_0093:
            this.__OutputFuncInfo(list[num]);
            builder.Append(string.Format("<li{0}>", (__htFuncTree[(int) list[num].Id] == null) ? " class=\"lonely\"" : ""));
            builder.Append(string.Format("<label><a href=\"javascript:;\" funcid=\"{0}\" onclick=\"navigate('{0}');return false;\" hidefocus=\"hidefocus\" style=\"background:url(../../../img/{1}.png) no-repeat left center;\">{2}</a></label>", (int) list[num].Id, list[num].Icon, list[num].LocalName));
            builder.Append(this.__AppendChildFuncs(__htFuncTree, list[num]));
            builder.Append("</li>");
        Label_0134:
            num += 1;
        Label_0138:
            if ((num < list.Count) != null)
            {
                goto Label_0069;
            }
            builder.Append("</ul>");
            str = builder.ToString();
        Label_015F:
            return str;
        }

        private void __InirTopMenu()
        {
            FuncTree[] treeArray;
            List<FuncTree> list;
            int num;
            int num2;
            FuncTree tree;
            string str;
            string str2;
            string str3;
            string str4;
            string str5;
            bool flag;
            object[] objArray;
            this.ltTopMenu.Text = "<ul id='index-nav'>";
            if ((FunUtil.IsAdmin() == 0) != null)
            {
                goto Label_003E;
            }
            this.ltTopMenu.Text = this.ltTopMenu.Text + "<li><a class='runoob-pop' href='../../../Default.aspx' data-id='index' title='首页'><span class='spanTM current'>首页</span></a></li>";
        Label_003E:
            treeArray = FuncTree.GetAllFuncs(-1);
            list = new List<FuncTree>();
            if ((treeArray == null) != null)
            {
                goto Label_005D;
            }
            list.AddRange(treeArray);
        Label_005D:
            num = 0;
            num2 = 0;
            goto Label_01D6;
        Label_0066:
            tree = list[num2];
            if (FunUtil.IsAdmin() != null)
            {
                goto Label_00D9;
            }
            if ((((((tree.Name != "单人模拟") == null) || ((tree.Name != "多人模拟") == null)) || ((tree.Name != "智能Agent仿真") == null)) ? 1 : ((tree.Name != "大数据分析") == 0)) != null)
            {
                goto Label_00D8;
            }
            goto Label_01D2;
        Label_00D8:;
        Label_00D9:
            str = tree.Name;
            str2 = tree.LocalName;
            if ((string.IsNullOrEmpty(FuncTree.GetURLOfFirstValidEntity(this.Page, tree)) == 0) != null)
            {
                goto Label_010F;
            }
            goto Label_01D2;
        Label_010F:
            if (((tree.Overdue == "1") == 0) != null)
            {
                goto Label_012E;
            }
            goto Label_01D2;
        Label_012E:
            if (FunUtil.CanExecFunc(this.nUserId, tree.Id) != null)
            {
                goto Label_014B;
            }
            goto Label_01D2;
        Label_014B:
            if (((num < 10) ? 1 : ((str != "系统维护") == 0)) == null)
            {
                goto Label_01D2;
            }
            num += 1;
            str4 = "runoob-pop";
            str5 = string.Format("<li><a href=\"javascript:;\" funcid=\"{0}\" onclick=\"navigate('{0}');return false;\" hidefocus=\"hidefocus\" align=\"absmiddle\" border=\"0\" class='{3}' /><span class='spanTM'>{2}</span></a></label>", new object[] { (int) tree.Id, tree.Icon, tree.LocalName, str4 });
            this.ltTopMenu.Text = this.ltTopMenu.Text + str5;
        Label_01D2:
            num2 += 1;
        Label_01D6:
            if ((num2 < list.Count) != null)
            {
                goto Label_0066;
            }
            this.ltTopMenu.Text = this.ltTopMenu.Text + "<li><a class='runoob-pop' href='../../../Default.aspx?act=logout' class='runoob-pop'><span class='spanTM'>退出登录</span></a></li>";
            this.ltTopMenu.Text = this.ltTopMenu.Text + "</ul>";
            return;
        }

        private unsafe void __InitLeftMenu()
        {
            FuncTree[] treeArray;
            Hashtable hashtable;
            StringBuilder builder;
            int num;
            FuncTree tree;
            bool flag;
            int num2;
            this.navTree.Visible = 0;
            treeArray = FuncTree.GetAllFuncs(-1);
            if (((treeArray == null) ? 0 : ((((int) treeArray.Length) < 1) == 0)) != null)
            {
                goto Label_0030;
            }
            goto Label_0158;
        Label_0030:
            hashtable = FuncTree.GetAllFuncsHash(this.Page);
            builder = new StringBuilder();
            builder.Append("<ul id=\"menu_tree\">");
            num = 0;
            goto Label_011E;
        Label_0055:
            tree = treeArray[num];
            num2 = 1;
            if (((tree.Overdue == &num2.ToString()) == 0) != null)
            {
                goto Label_007F;
            }
            goto Label_011A;
        Label_007F:
            if ((((tree.Name == "平台管理") == null) ? 1 : FunUtil.IsHost()) == null)
            {
                goto Label_011A;
            }
            if (FunUtil.CanExecFunc(this.nUserId, tree.Id) == null)
            {
                goto Label_011A;
            }
            this.__OutputFuncInfo(tree);
            builder.Append("<li>");
            builder.Append(string.Format("<label><a href=\"javascript:;\" funcid=\"{0}\" onclick=\"navigate('{0}');return false;\" hidefocus=\"hidefocus\" style=\"background:url(../../../img/{1}.png) no-repeat left center;font-size:14px\" align=\"absmiddle\" border=\"0\" />&nbsp;{2}</a></label>", (int) tree.Id, tree.Icon, tree.LocalName));
            builder.Append(this.__AppendChildFuncs(hashtable, tree));
            builder.Append("</li>");
        Label_011A:
            num += 1;
        Label_011E:
            if ((num < ((int) treeArray.Length)) != null)
            {
                goto Label_0055;
            }
            builder.Append("</ul>");
            this.ltlNavTreeFunctions.Text = builder.ToString();
            this.navTree.Visible = 1;
        Label_0158:
            return;
        }

        private void __OutputFuncInfo(FuncTree __func)
        {
            object obj2;
            object[] objArray;
            __func.TargetUrl = FuncTree.GetURLOfFirstValidEntity(this.Page, __func);
            obj2 = this.FuncsArrayInfo;
            this.FuncsArrayInfo = string.Concat(new object[] { obj2, "funcs_array[\"", (int) __func.Id, "\"] = {Id:", (int) __func.Id, ",LocalName:\"", __func.LocalName, "\",Icon:\"", __func.Icon, "\",TargetUrl:\"", __func.TargetUrl, "\"}\n" });
            return;
        }

        protected unsafe void btnLogout_Click(object sender, EventArgs e)
        {
            string str;
            bool flag;
            str = PageUtil.GetIndexPage(this.Page);
            flag = 0;
            PageUtil.SetCookie(this.Page, "GWZKJLMM", &flag.ToString(), 360);
            PageUtil.SetCookie(this.Page, "GWZKUserInfo", "", 360);
            FunUtil.Logout(this.Page);
            PageUtil.WriteAlertAndRet(this.Page, "", str, "");
            return;
        }

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            int num;
            int num2;
            UserInfo info;
            int num3;
            int num4;
            SitePortal[] portalArray;
            int num5;
            int num6;
            SitePortal portal;
            bool flag;
            object[] objArray;
            num = PersistenceManager.GlobalPortalId;
            if (((num < 1) == 0) != null)
            {
                goto Label_0067;
            }
            base.Response.Redirect(string.Concat(new object[] { "Index.aspx?portal=", &num.ToString(), "&u", this.Session["global_username"] }), 1);
            goto Label_02F6;
        Label_0067:
            this.nPortalId = SitePortal.GetCurrentPortalId();
            this.nUserId = FunUtil.GetCurrentUserID();
            this.nSelFuncId = Util.GetInt(base.Request, "p", 0);
            if (((this.nSelFuncId < 1) == 0) != null)
            {
                goto Label_00AD;
            }
            this.nSelFuncId = -1;
        Label_00AD:
            PageUtil.AdhereJS(this.Page, "jquery.js");
            PageUtil.AdhereJS(this.Page, "bootstrap.js");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "style.css");
            this.navTier.Visible = 0;
            if (((PortalSettings.get_DefaultTypeSub() == 2) == 0) != null)
            {
                goto Label_0132;
            }
            this.navTier.Visible = 1;
            this.m_strTopPX = "105px";
            this.__InirTopMenu();
        Label_0132:
            this.__InitLeftMenu();
            this.ltSiteName.Text = PortalSettings.get_PortalName();
            info = UserInfo.Get(this.nUserId);
            if ((info == null) != null)
            {
                goto Label_019C;
            }
            if ((((info.Sex == "2") != null) ? 0 : ((info.Sex == "女") == 0)) != null)
            {
                goto Label_019B;
            }
            this.m_strUserIcon = "womanbig.png";
        Label_019B:;
        Label_019C:
            this.m_strUserInfo = string.Format("欢迎你，{0}", FunUtil.GetCurrentUserName(1));
            this.hdCurrentUserId.Value = &this.nUserId.ToString();
            this.m_strNewMessageCount = "";
            num3 = MessageItem.GetUnreadMessageCount(this.nUserId);
            if (((num3 > 0) == 0) != null)
            {
                goto Label_0203;
            }
            this.m_strNewMessageCount = string.Format("<span style='position:absolute;font-size:10px;background-color:#ff5029;color:#fff;border-radius:13%;right:92px;top:6px;height:12px;padding:0 3px;line-height:12px;text-align:center;cursor:pointer;' onclick='fnJumpShortMessage();'>{0}</span>", (int) num3);
        Label_0203:
            num4 = PersistenceManager.GlobalPortalId;
            portalArray = (SitePortal[]) this.Session["global_allportal"];
            if (((portalArray == null) == 0) != null)
            {
                goto Label_0275;
            }
            num5 = PersistenceManager.GlobalPortalId;
        Label_0237:
            try
            {
                this.Session["global_pid"] = "1";
                portalArray = SitePortal.GetAllPortal();
                goto Label_0273;
            }
            finally
            {
            Label_0258:
                this.Session["global_pid"] = &num5.ToString();
            }
        Label_0273:;
        Label_0275:
            if ((portalArray == null) != null)
            {
                goto Label_02F6;
            }
            num6 = 1;
            goto Label_02E7;
        Label_0286:
            portal = portalArray[num6];
            if (((portal.id == num4) == 0) != null)
            {
                goto Label_02B2;
            }
            this.m_strCurPortal = portal.Title;
            goto Label_02E1;
        Label_02B2:
            this.m_strOtherPortal = this.m_strOtherPortal + string.Format("<li role='presentation'><a role='menuitem' tabindex='-1' href='#' onclick='goChangePortal({0});return false;'>{1}</a></li>", (int) portal.id, portal.Title);
        Label_02E1:
            num6 += 1;
        Label_02E7:
            if ((num6 < ((int) portalArray.Length)) != null)
            {
                goto Label_0286;
            }
        Label_02F6:
            return;
        }
    }
}

