namespace SJ.DesktopModules.HB.XiTPZ
{
    using DataAccess;
    using SJ.UserControls;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;
    using WWSoft.Web.WebControls;

    public class YongHGL : DoFormUserControl
    {
        protected HtmlInputButton btnAdd;
        protected HtmlInputButton btnCancel;
        protected HtmlInputButton btnSubmitP;
        protected HtmlTableCell EntityAction;
        protected HtmlInputHidden entityactionparameter;
        private int nId;
        private int nSelId;
        private int nUserId;
        protected PaginationBar PaginationBar1;
        protected Repeater rpt;
        protected DropDownList sel_Role;
        protected HtmlInputText txt_OrderId;
        protected HtmlInputPassword txt_Password_P;
        protected HtmlInputText txt_RealName;
        protected HtmlInputText txt_UserName;
        protected HtmlInputText txt_UserName_P;

        public YongHGL()
        {
            this.nUserId = -1;
            this.nId = -1;
            this.nSelId = -1;
            base..ctor();
            return;
        }

        private void __BindData()
        {
            UserInfo[] infoArray;
            List<UserInfo> list;
            UserInfo info;
            ArrayList list2;
            UserInfo[] infoArray2;
            int num;
            bool flag;
            infoArray = UserInfo.GetAllActiveUsers();
            list = new List<UserInfo>();
            infoArray2 = infoArray;
            num = 0;
            goto Label_0047;
        Label_0016:
            info = infoArray2[num];
            if (((info.UserName == "host") == 0) == null)
            {
                goto Label_0041;
            }
            list.Add(info);
        Label_0041:
            num += 1;
        Label_0047:
            if ((num < ((int) infoArray2.Length)) != null)
            {
                goto Label_0016;
            }
            infoArray = list.ToArray();
            Array.Sort(infoArray, new UserCompare());
            list2 = PageUtil.GetPagedResult(infoArray, this.PaginationBar1.PageIndex - 1, this.PaginationBar1.PageSize);
            this.rpt.DataSource = list2;
            this.rpt.DataBind();
            this.PaginationBar1.RecordCount = (int) infoArray.Length;
            this.PaginationBar1.Visible = (((int) infoArray.Length) < this.PaginationBar1.PageSize) == 0;
            return;
        }

        private unsafe void __BindRole(ListControl __drp)
        {
            SiteRoles[] rolesArray;
            SiteRoles roles;
            SiteRoles[] rolesArray2;
            int num;
            bool flag;
            __drp.Items.Clear();
            rolesArray = SiteRoles.List(SitePortal.GetCurrentPortalId());
            __drp.Items.Add(new ListItem("--请选择--", ""));
            rolesArray2 = rolesArray;
            num = 0;
            goto Label_0066;
        Label_003A:
            roles = rolesArray2[num];
            __drp.Items.Add(new ListItem(roles.RoleName, &roles.Id.ToString()));
            num += 1;
        Label_0066:
            if ((num < ((int) rolesArray2.Length)) != null)
            {
                goto Label_003A;
            }
            return;
        }

        protected unsafe void btnAdd_Click(object sender, EventArgs e)
        {
            UserInfo info;
            UserInfo info2;
            int num;
            int num2;
            UserRoles[] rolesArray;
            UserRoles roles;
            UserRoles roles2;
            string str;
            string[] strArray;
            bool flag;
            int num3;
            UserRoles[] rolesArray2;
            int num4;
            if (PageUtil.CheckValid(this, new string[] { "txt_UserName#请输入用户名" }) != null)
            {
                goto Label_0025;
            }
            goto Label_01CF;
        Label_0025:
            if ((string.IsNullOrEmpty(this.txt_OrderId.Value) == 0) != null)
            {
                goto Label_005D;
            }
            this.txt_OrderId.Value = &UserInfo.GetNextId(SitePortal.GetCurrentPortalId()).ToString();
        Label_005D:
            info = UserInfo.GetUserInfoByUserName(SitePortal.GetCurrentPortalId(), this.txt_UserName.Value);
            if (((info == null) ? 1 : (info.Id == this.nId)) != null)
            {
                goto Label_00B0;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "该用户名已存在，请检查！", this.txt_UserName.ClientID);
            goto Label_01CF;
        Label_00B0:
            info2 = UserInfo.Get(this.nId);
            if (((info2 == null) == 0) != null)
            {
                goto Label_00CF;
            }
            info2 = new UserInfo();
        Label_00CF:
            info2.PortalId = SitePortal.GetCurrentPortalId();
            info2.IsActive = 1;
            info2.IsSystemUser = 1;
            info2.Status = 1;
            info2.IsDelete = 2;
            num = PageUtil.CommonModify(this, info2, info2.Id, "", "创建失败，请与系统管理员联系！", "");
            if (((num > 0) == 0) != null)
            {
                goto Label_01CF;
            }
            num2 = Util.pasteInt(this.sel_Role.SelectedValue, -1);
            rolesArray = UserRoles.GetUserRolesByUser(num);
            rolesArray2 = rolesArray;
            num4 = 0;
            goto Label_0164;
        Label_0148:
            roles = rolesArray2[num4];
            UserRoles.Del(roles.get_id());
            num4 += 1;
        Label_0164:
            if ((num4 < ((int) rolesArray2.Length)) != null)
            {
                goto Label_0148;
            }
            roles2 = new UserRoles();
            roles2.RoleID = num2;
            roles2.UserID = num;
            roles2.DepartmentID = -1;
            CommonClassDB.Instance(roles2).set(roles2);
            UserInfo.ClearAllUsersHash();
            UserInfo.CleanOnlineUsers();
            str = this.GetRefreshUrl(1, 1);
            PageUtil.WriteAlertAndRet(this.Page, "", str, "");
        Label_01CF:
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

        protected void btnSubmitP_ServerClick(object sender, EventArgs e)
        {
            string str;
            string str2;
            UserInfo info;
            bool flag;
            str = this.txt_UserName_P.Value.Trim();
            str2 = this.txt_Password_P.Value.Trim();
            info = UserInfo.GetUserInfoByUserName(SitePortal.GetCurrentPortalID(), str);
            if (((info == null) == 0) == null)
            {
                goto Label_005C;
            }
            info.Password = MD5Encrypt.PasswordEncrypt(str2);
            CommonClassDB.Instance(info).set(info);
            this.__BindData();
        Label_005C:
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

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            string str;
            UserInfo info;
            int num;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.nId = Util.GetInt(base.Request, "id", -1);
            this.nSelId = Util.GetInt(base.Request, "sel", -1);
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            if ((base.IsPostBack == 0) != null)
            {
                goto Label_0063;
            }
            goto Label_01A0;
        Label_0063:
            this.__BindRole(this.sel_Role);
            this.btnCancel.Visible = 0;
            if (((this.nId > 0) == 0) != null)
            {
                goto Label_0136;
            }
            str = Util.GetString(base.Request, "act", "");
            if ((("del" == str) == 0) != null)
            {
                goto Label_00D0;
            }
            UserInfo.Del(this.nId);
            this.nId = -1;
            goto Label_0135;
        Label_00D0:
            if ((("mdy" == str) == 0) != null)
            {
                goto Label_0135;
            }
            info = UserInfo.Get(this.nId);
            PageUtil.CommonFillEdit(this, info);
            num = UserRoles.GetUserFirstRoleId(info.Id);
            PageUtil.SetSel(this.sel_Role, &num.ToString());
            this.btnAdd.Value = "更新";
            this.btnCancel.Visible = 1;
        Label_0135:;
        Label_0136:
            this.PaginationBar1.RecordCount = 0x2710;
            this.PaginationBar1.PageIndex = Util.GetInt(base.Request, "pi", 0) + 1;
            this.PaginationBar1.PageSize = Util.GetInt(base.Request, "ps", this.PaginationBar1.DefaultPageSize);
            PageUtil.RestoreSearchConditionFromSession(this.Page);
            this.__BindData();
        Label_01A0:
            return;
        }

        protected unsafe void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            UserInfo info;
            HtmlInputCheckBox box;
            Label label;
            int num;
            UserRoles[] rolesArray;
            string str;
            UserRoles roles;
            string str2;
            string str3;
            string str4;
            bool flag;
            UserRoles[] rolesArray2;
            int num2;
            if (((e.Item.ItemType == 2) ? 0 : ((e.Item.ItemType == 3) == 0)) != null)
            {
                goto Label_0249;
            }
            info = (UserInfo) e.Item.DataItem;
            PageUtil.CommonFill(e.Item, info);
            box = (HtmlInputCheckBox) e.Item.FindControl("cbSel");
            if ((box == null) != null)
            {
                goto Label_0080;
            }
            box.Value = &info.Id.ToString();
        Label_0080:
            label = (Label) e.Item.FindControl("lbl_Id");
            if ((label == null) != null)
            {
                goto Label_00D8;
            }
            num = (e.Item.ItemIndex + 1) + ((this.PaginationBar1.PageIndex - 1) * this.PaginationBar1.PageSize);
            label.Text = &num.ToString();
        Label_00D8:
            label = (Label) e.Item.FindControl("lbl_DisplayRole");
            if ((label == null) != null)
            {
                goto Label_014E;
            }
            rolesArray = UserRoles.GetUserRolesByUser(info.get_id());
            str = "";
            rolesArray2 = rolesArray;
            num2 = 0;
            goto Label_0136;
        Label_0117:
            roles = rolesArray2[num2];
            str = str + roles.get_RoleName();
            num2 += 1;
        Label_0136:
            if ((num2 < ((int) rolesArray2.Length)) != null)
            {
                goto Label_0117;
            }
            label.Text = str;
        Label_014E:
            label = (Label) e.Item.FindControl("lbl_Info");
            if ((label == null) != null)
            {
                goto Label_0192;
            }
            label.Text = string.Format("<a href='#' onclick=\"fnChangePwd({0}, '{1}');return false;\">设置用户密码</a>", (int) info.get_id(), info.UserName);
        Label_0192:
            label = (Label) e.Item.FindControl("lbl_Operation");
            if ((label == null) != null)
            {
                goto Label_0248;
            }
            if (((this.nId > 0) == 0) != null)
            {
                goto Label_01D8;
            }
            label.Text = "&nbsp;";
            goto Label_0247;
        Label_01D8:
            str2 = this.GetRefreshUrl(1, 1);
            str3 = str2 + "&act=mdy&id=" + &info.Id.ToString();
            str4 = str2 + "&act=del&id=" + &info.Id.ToString();
            label.Text = string.Format("<input type='button' value='修改' onclick=\"fnGo('{0}');return false;\" />&nbsp;", str3);
            label.Text = label.Text + string.Format("<input type='button' value='删除' onclick=\"fnDel('{0}');return false;\" />&nbsp;", str4);
        Label_0247:;
        Label_0248:;
        Label_0249:
            return;
        }

        public class UserCompare : IComparer
        {
            public UserCompare()
            {
                base..ctor();
                return;
            }

            unsafe int IComparer.Compare(object x, object y)
            {
                UserInfo info;
                UserInfo info2;
                int num;
                info = (UserInfo) x;
                info2 = (UserInfo) y;
                num = &info.OrderId.CompareTo(info2.OrderId);
            Label_0023:
                return num;
            }
        }
    }
}

