namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class Content : PageBase
    {
        protected UserControl BBR1;
        protected HtmlForm form1;
        protected HtmlHead header;
        public string m_strFuncBarBgStyle;
        public string m_strWorkAreaStyle;
        public int nSelFuncId;
        public string strDesktopName;
        public string strDesktopURL;
        public string strSelectedTabId;

        public Content()
        {
            this.nSelFuncId = -1;
            this.strSelectedTabId = "";
            this.m_strFuncBarBgStyle = "";
            this.m_strWorkAreaStyle = "";
            this.strDesktopName = "首页";
            this.strDesktopURL = "Home.aspx";
            base..ctor();
            return;
        }

        private void __InitTabs()
        {
            bool flag;
            if ((PageUtil.get_IsEngPage() == 0) != null)
            {
                goto Label_001A;
            }
            this.strDesktopName = "Desktop";
        Label_001A:
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            FuncTree tree;
            FuncTree[] treeArray;
            FuncTree tree2;
            string str;
            int num;
            bool flag;
            FuncTree[] treeArray2;
            int num2;
            this.nSelFuncId = Util.GetInt(base.Request, "p", 0);
            if (((this.nSelFuncId < 1) == 0) != null)
            {
                goto Label_0031;
            }
            this.nSelFuncId = -1;
        Label_0031:
            if (((this.nSelFuncId > 0) == 0) != null)
            {
                goto Label_010F;
            }
            tree = FuncTree.Get(this.nSelFuncId);
            if ((tree == null) != null)
            {
                goto Label_010E;
            }
            this.strDesktopName = tree.LocalName;
            this.strDesktopURL = FuncTree.GetURLOfFirstValidEntity(this.Page, tree);
            if ((string.IsNullOrEmpty(this.strDesktopURL) == 0) != null)
            {
                goto Label_010D;
            }
            treeArray = FuncTree.GetAllFuncs(tree.Id);
            if (((treeArray == null) ? 1 : ((((int) treeArray.Length) > 0) == 0)) != null)
            {
                goto Label_010C;
            }
            treeArray2 = treeArray;
            num2 = 0;
            goto Label_00FD;
        Label_00C0:
            tree2 = treeArray2[num2];
            str = FuncTree.GetURLOfFirstValidEntity(this.Page, tree2);
            if (string.IsNullOrEmpty(str) != null)
            {
                goto Label_00F6;
            }
            this.strDesktopName = tree2.LocalName;
            this.strDesktopURL = str;
            goto Label_010B;
        Label_00F6:
            num2 += 1;
        Label_00FD:
            if ((num2 < ((int) treeArray2.Length)) != null)
            {
                goto Label_00C0;
            }
        Label_010B:;
        Label_010C:;
        Label_010D:;
        Label_010E:;
        Label_010F:
            if (base.IsPostBack != null)
            {
                goto Label_0162;
            }
            SkinUtil.AdhereStyleSheet(this.Page, "content.css");
            if (((PortalSettings.get_DefaultTypeSub() == 2) == 0) != null)
            {
                goto Label_015A;
            }
            this.m_strFuncBarBgStyle = "style='display:none;'";
            this.m_strWorkAreaStyle = "style='top:0px;'";
        Label_015A:
            this.__InitTabs();
        Label_0162:
            return;
        }
    }
}

