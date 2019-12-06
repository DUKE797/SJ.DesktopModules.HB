namespace SJ.DesktopModules.HB.XiTPZ
{
    using DataAccess;
    using Infragistics.WebUI.UltraWebNavigator;
    using SJ.UserControls;
    using System;
    using System.Collections;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class BuMGL : DoFormUserControl
    {
        protected HtmlGenericControl divList;
        public int m_nParentId;
        private int nUserId;
        protected HtmlInputHidden returl;
        protected DropDownList sel_ParentId;
        protected DropDownList sel_ParentId_New;
        protected UltraWebTree treeChannel;
        protected HtmlInputText txt_Name;
        protected HtmlInputText txt_Name_New;
        protected HtmlInputText txt_OrderId;
        protected HtmlInputText txt_OrderId_New;

        public BuMGL()
        {
            this.m_nParentId = -1;
            this.nUserId = -1;
            base..ctor();
            return;
        }

        private void __Return(string __strMsg)
        {
            base.Response.Clear();
            base.Response.Write(__strMsg);
            base.Response.End();
            return;
        }

        private string GetRefreshUrl(bool __bIncludePager, bool __bIncludeSearchKey)
        {
            string str;
            string str2;
            string[] strArray;
            bool flag;
            str = PageUtil.GetRefreshUrl(this.Page, new string[] { "rnd", "act", "parentid", "pi", "ps", "skey", "sort", "returl", "id", "id2", "sel" });
            if ((__bIncludeSearchKey == 0) != null)
            {
                goto Label_00A3;
            }
            str = str + string.Format("&skey={0}", HttpUtility.UrlEncode(Util.GetString(base.Request, "skey", "")));
        Label_00A3:
            str2 = (str + string.Format("&sort=" + HttpUtility.UrlEncode(""), new object[0])) + "&ispostback=1";
        Label_00D9:
            return str2;
        }

        public override void InitJQueryRef(UserControl __oC)
        {
            JQueryRef ref2;
            ref2 = (JQueryRef) __oC;
            ref2.set_IncludeCheckBox(1);
            ref2.set_IncludeValidate(1);
            ref2.set_IncludeBootstrap(1);
            return;
        }

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            string str;
            StringBuilder builder;
            ListItem item;
            string str2;
            string str3;
            int num;
            Department department;
            string str4;
            Hashtable hashtable;
            Department department2;
            bool flag;
            IEnumerator enumerator;
            IDisposable disposable;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.m_nParentId = Util.GetInt(base.Request, "parentid", -1);
            str = Util.GetString(base.Request, "act", "");
            if (string.IsNullOrEmpty(str) != null)
            {
                goto Label_03FE;
            }
            if ((("queryparent" == str) == 0) != null)
            {
                goto Label_016A;
            }
            this.sel_ParentId.Items.Clear();
            Department.BindPages(this.sel_ParentId, -1);
            builder = new StringBuilder();
            enumerator = this.sel_ParentId.Items.GetEnumerator();
        Label_009E:
            try
            {
                goto Label_0128;
            Label_00A3:
                item = (ListItem) enumerator.Current;
                str2 = item.Text;
                if ((((item.Value == "-1") != null) ? 0 : ((item.Value == "0") == 0)) != null)
                {
                    goto Label_00ED;
                }
                str2 = "无";
            Label_00ED:
                str3 = string.Format("{0}\t{1}", str2, item.Value);
                if (((builder.Length > 0) == 0) != null)
                {
                    goto Label_011E;
                }
                builder.Append("\n");
            Label_011E:
                builder.Append(str3);
            Label_0128:
                if (enumerator.MoveNext() != null)
                {
                    goto Label_00A3;
                }
                goto Label_0157;
            }
            finally
            {
            Label_013A:
                disposable = enumerator as IDisposable;
                if ((disposable == null) != null)
                {
                    goto Label_0156;
                }
                disposable.Dispose();
            Label_0156:;
            }
        Label_0157:
            this.__Return(builder.ToString());
            goto Label_0476;
        Label_016A:
            if ((("query" == str) == 0) != null)
            {
                goto Label_0206;
            }
            num = Util.GetInt(base.Request, "funcid", -1);
            if (((num < 1) == 0) != null)
            {
                goto Label_01A6;
            }
            num = -1;
        Label_01A6:
            department = Department.Get(num);
            if ((department == null) != null)
            {
                goto Label_01F2;
            }
            str3 = string.Format("OK\t{0}\t{1}\t{2}", department.Name, (int) department.ParentId, (int) department.OrderId);
            this.__Return(str3);
            goto Label_0200;
        Label_01F2:
            this.__Return("");
        Label_0200:
            goto Label_03FD;
        Label_0206:
            if ((("add" == str) == 0) != null)
            {
                goto Label_03A1;
            }
            num = Util.GetInt(base.Request, "funcid", -1);
            if (((num < 1) == 0) != null)
            {
                goto Label_0242;
            }
            num = -1;
        Label_0242:
            hashtable = PageUtil.GetHashFromUrl(Util.GetString(base.Request, "parameter", ""));
            department = Department.Get(num);
            if (((department == null) == 0) != null)
            {
                goto Label_0280;
            }
            department = new Department();
        Label_0280:
            department.Name = hashtable["Name"];
            department.ParentId = Util.pasteInt(hashtable["ParentId"], -1);
            department.OrderId = Util.pasteInt(hashtable["OrderId"], 0);
            if ((string.IsNullOrEmpty(department.Name) == 0) != null)
            {
                goto Label_02F5;
            }
            this.__Return("名称不能为空，请修改！");
        Label_02F5:
            if (((department.OrderId == 0) == 0) != null)
            {
                goto Label_0319;
            }
            department.OrderId = Department.GetNextOrderID(SitePortal.GetCurrentPortalID());
        Label_0319:
            department.PortalId = SitePortal.GetCurrentPortalID();
            department.IsDelete = 2;
            department2 = Department.GetByName(SitePortal.GetCurrentPortalID(), department.ParentId, department.Name);
            if (((department2 == null) ? 1 : (department2.Id == department.Id)) != null)
            {
                goto Label_037F;
            }
            this.__Return(string.Format("名称“{0}”已存在，请修改！", department.Name));
            goto Label_039C;
        Label_037F:
            CommonClassDB.Instance(department).set(department);
            this.__Return("OK");
        Label_039C:
            goto Label_0476;
        Label_03A1:
            if ((("del" == str) == 0) != null)
            {
                goto Label_03FD;
            }
            num = Util.GetInt(base.Request, "funcid", -1);
            if (((num < 1) == 0) != null)
            {
                goto Label_03E5;
            }
            this.__Return("请选择需要删除记录！");
            goto Label_03FB;
        Label_03E5:
            Department.Del(num);
            this.__Return("OK");
        Label_03FB:
            goto Label_0476;
        Label_03FD:;
        Label_03FE:
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            if ((base.IsPostBack == 0) == null)
            {
                goto Label_0476;
            }
            flag = 0;
            department = new Department();
            PageUtil.InitTree(this.Page, this.treeChannel, 0, department);
            PageUtil.SetTreeSel(this.treeChannel, "func" + &this.m_nParentId.ToString());
            this.returl.Value = this.GetRefreshUrl(0, 0);
        Label_0476:
            return;
        }
    }
}

