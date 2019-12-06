namespace SJ.DesktopModules.HB.XiTPZ
{
    using DataAccess;
    using SJ.UserControls;
    using System;
    using System.Collections;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;
    using WWSoft.Web.WebControls;

    public class JueSGL : DoFormUserControl
    {
        protected HtmlInputButton btnAdd;
        protected HtmlInputButton btnCancel;
        protected HtmlTableCell EntityAction;
        protected HtmlInputHidden entityactionparameter;
        private int nId;
        private int nSelId;
        private int nUserId;
        protected PaginationBar PaginationBar1;
        protected Repeater rpt;
        protected TextBox txt_Description;
        protected HtmlInputText txt_OrderId;
        protected HtmlInputText txt_RoleName;

        public JueSGL()
        {
            this.nUserId = -1;
            this.nId = -1;
            this.nSelId = -1;
            base..ctor();
            return;
        }

        private void __BindData()
        {
            SiteRoles[] rolesArray;
            ArrayList list;
            rolesArray = SiteRoles.List(SitePortal.GetCurrentPortalId());
            list = PageUtil.GetPagedResult(rolesArray, this.PaginationBar1.PageIndex - 1, this.PaginationBar1.PageSize);
            this.rpt.DataSource = list;
            this.rpt.DataBind();
            this.PaginationBar1.RecordCount = (int) rolesArray.Length;
            this.PaginationBar1.Visible = (((int) rolesArray.Length) < this.PaginationBar1.PageSize) == 0;
            return;
        }

        protected unsafe void btnAdd_Click(object sender, EventArgs e)
        {
            SiteRoles roles;
            SiteRoles roles2;
            int num;
            string str;
            string[] strArray;
            bool flag;
            int num2;
            if (PageUtil.CheckValid(this, new string[] { "txt_RoleName#请输入角色名称" }) != null)
            {
                goto Label_0025;
            }
            goto Label_0134;
        Label_0025:
            if ((string.IsNullOrEmpty(this.txt_OrderId.Value) == 0) != null)
            {
                goto Label_005D;
            }
            this.txt_OrderId.Value = &SiteRoles.GetNextOrderID(SitePortal.GetCurrentPortalId()).ToString();
        Label_005D:
            roles = SiteRoles.GetByName(SitePortal.GetCurrentPortalId(), this.txt_RoleName.Value);
            if (((roles == null) ? 1 : (roles.Id == this.nId)) != null)
            {
                goto Label_00B0;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "该名称已存在，请检查！", this.txt_RoleName.ClientID);
            goto Label_0134;
        Label_00B0:
            roles2 = SiteRoles.Get(this.nId);
            if (((roles2 == null) == 0) != null)
            {
                goto Label_00CF;
            }
            roles2 = new SiteRoles();
        Label_00CF:
            roles2.PortalId = SitePortal.GetCurrentPortalId();
            roles2.DepartId = -1;
            roles2.IsDepartRole = 2;
            if (((PageUtil.CommonModify(this, roles2, roles2.Id, "", "创建失败，请与系统管理员联系！", "") > 0) == 0) != null)
            {
                goto Label_0134;
            }
            str = this.GetRefreshUrl(1, 1);
            PageUtil.WriteAlertAndRet(this.Page, "", str, "");
        Label_0134:
            return;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string str;
            str = this.GetRefreshUrl(0, 0);
            PageUtil.WriteAlertAndRet(this.Page, "", str, "");
            return;
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            string str;
            str = this.GetRefreshUrl(0, 0);
            base.Response.Redirect(str, 1);
            return;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string str;
            string str2;
            this.PaginationBar1.PageIndex = 1;
            str = PageUtil.SaveSearchConditionToSession(this);
            str2 = this.GetRefreshUrl(1, 0) + "&skey=" + HttpUtility.UrlEncode(str);
            base.Response.Redirect(str2, 1);
            return;
        }

        protected void ChangePageIndex(object sender, ChangePageArgs e)
        {
            string str;
            string str2;
            str = PageUtil.SaveSearchConditionToSession(this);
            str2 = this.GetRefreshUrl(1, 0) + "&skey=" + HttpUtility.UrlEncode(str);
            base.Response.Redirect(str2, 1);
            return;
        }

        private string GetRefreshUrl(bool __bIncludePager, bool __bIncludeSearchKey)
        {
            string str;
            string str2;
            string[] strArray;
            bool flag;
            str = PageUtil.GetRefreshUrl(this.Page, new string[] { "rnd", "act", "pi", "ps", "skey", "sort", "returl", "id", "id2", "sel" });
            if ((__bIncludePager == 0) != null)
            {
                goto Label_00A2;
            }
            str = str + string.Format("&pi={0}&ps={1}", (int) (this.PaginationBar1.PageIndex - 1), (int) this.PaginationBar1.PageSize);
        Label_00A2:
            if ((__bIncludeSearchKey == 0) != null)
            {
                goto Label_00D5;
            }
            str = str + string.Format("&skey={0}", HttpUtility.UrlEncode(Util.GetString(base.Request, "skey", "")));
        Label_00D5:
            str2 = (str + string.Format("&sort=" + HttpUtility.UrlEncode(""), new object[0])) + "&ispostback=1";
        Label_010B:
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

        protected void Page_Load(object sender, EventArgs e)
        {
            string str;
            SiteRoles roles;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.nId = Util.GetInt(base.Request, "id", -1);
            this.nSelId = Util.GetInt(base.Request, "sel", -1);
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            if ((base.IsPostBack == 0) != null)
            {
                goto Label_0063;
            }
            goto Label_0174;
        Label_0063:
            this.btnCancel.Visible = 0;
            if (((this.nId > 0) == 0) != null)
            {
                goto Label_010A;
            }
            str = Util.GetString(base.Request, "act", "");
            if ((("del" == str) == 0) != null)
            {
                goto Label_00C3;
            }
            SiteRoles.Del(this.nId);
            this.nId = -1;
            goto Label_0109;
        Label_00C3:
            if ((("mdy" == str) == 0) != null)
            {
                goto Label_0109;
            }
            roles = SiteRoles.Get(this.nId);
            PageUtil.CommonFillEdit(this, roles);
            this.btnAdd.Value = "更新";
            this.btnCancel.Visible = 1;
        Label_0109:;
        Label_010A:
            this.PaginationBar1.RecordCount = 0x2710;
            this.PaginationBar1.PageIndex = Util.GetInt(base.Request, "pi", 0) + 1;
            this.PaginationBar1.PageSize = Util.GetInt(base.Request, "ps", this.PaginationBar1.DefaultPageSize);
            PageUtil.RestoreSearchConditionFromSession(this.Page);
            this.__BindData();
        Label_0174:
            return;
        }

        protected unsafe void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            SiteRoles roles;
            HtmlInputCheckBox box;
            Label label;
            int num;
            string str;
            string str2;
            string str3;
            bool flag;
            if (((e.Item.ItemType == 2) ? 0 : ((e.Item.ItemType == 3) == 0)) != null)
            {
                goto Label_018F;
            }
            roles = (SiteRoles) e.Item.DataItem;
            PageUtil.CommonFill(e.Item, roles);
            box = (HtmlInputCheckBox) e.Item.FindControl("cbSel");
            if ((box == null) != null)
            {
                goto Label_0080;
            }
            box.Value = &roles.Id.ToString();
        Label_0080:
            label = (Label) e.Item.FindControl("lbl_Id");
            if ((label == null) != null)
            {
                goto Label_00D8;
            }
            num = (e.Item.ItemIndex + 1) + ((this.PaginationBar1.PageIndex - 1) * this.PaginationBar1.PageSize);
            label.Text = &num.ToString();
        Label_00D8:
            label = (Label) e.Item.FindControl("lbl_Operation");
            if ((label == null) != null)
            {
                goto Label_018E;
            }
            if (((this.nId > 0) == 0) != null)
            {
                goto Label_011E;
            }
            label.Text = "&nbsp;";
            goto Label_018D;
        Label_011E:
            str = this.GetRefreshUrl(1, 1);
            str2 = str + "&act=mdy&id=" + &roles.Id.ToString();
            str3 = str + "&act=del&id=" + &roles.Id.ToString();
            label.Text = string.Format("<input type='button' value='修改' onclick=\"fnGo('{0}');return false;\" />&nbsp;", str2);
            label.Text = label.Text + string.Format("<input type='button' value='删除' onclick=\"fnDel('{0}');return false;\" />&nbsp;", str3);
        Label_018D:;
        Label_018E:;
        Label_018F:
            return;
        }
    }
}

