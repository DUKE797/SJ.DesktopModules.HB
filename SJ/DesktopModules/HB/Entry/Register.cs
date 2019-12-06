namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class Register : Page
    {
        protected HtmlInputHidden applicationpath;
        protected UserControl BBR1;
        protected Button btnRegister;
        protected HtmlInputButton btnSubmit;
        protected CheckBox cbRead;
        protected HtmlForm form1;
        protected HtmlHead header;
        protected Image imgYZM;
        protected Label lbl_PortalName;
        protected Literal ltHtml;
        public string m_strPassword;
        public string m_strPassword2;
        protected PlaceHolder phDefaultRegister;
        protected HtmlInputHidden selPortal;
        protected HtmlTitle title;
        protected HtmlInputText txt_Mobile;
        protected HtmlInputPassword txt_PasswordCustom;
        protected HtmlInputPassword txt_PasswordCustom2;
        protected HtmlInputText txt_UserName;
        protected RadioButtonList txt_UserType;
        protected HtmlInputText txtYZM;

        public Register()
        {
            this.m_strPassword = "";
            this.m_strPassword2 = "";
            base..ctor();
            return;
        }

        protected unsafe void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            int num;
            string str;
            string str2;
            string str3;
            string str4;
            UserInfo info;
            string str5;
            int num2;
            UserRoles[] rolesArray;
            UserRoles roles;
            string str6;
            bool flag;
            string[] strArray;
            DateTime time;
            UserRoles[] rolesArray2;
            int num3;
            num = SitePortal.GetCurrentPortalId();
            this.m_strPassword = this.txt_PasswordCustom.Value.Trim();
            this.m_strPassword2 = this.txt_PasswordCustom2.Value.Trim();
            if (((this.m_strPassword != this.m_strPassword2) == 0) != null)
            {
                goto Label_006F;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "两次输入密码必须一致，请修改！", this.txt_PasswordCustom2.ClientID);
            goto Label_02D9;
        Label_006F:;
            if (PageUtil.CheckValid(this, new string[] { "txt_UserName#请输入登录用户名", "txt_Mobile#请输入手机号", "txtYZM#请输入验证码" }) != null)
            {
                goto Label_00A5;
            }
            goto Label_02D9;
        Label_00A5:
            str = this.txtYZM.Value.Trim();
            str2 = PageUtil.VerifySmartJoinCode(this.Page, str);
            if ((("ok" != str2) == 0) != null)
            {
                goto Label_00F9;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "验证码不正确，请修改！", this.txtYZM.ClientID);
            goto Label_02D9;
        Label_00F9:
            CommonClassDB.ClearAllCache();
            str3 = this.txt_UserName.Value.Trim();
            str4 = this.txt_Mobile.Value.Trim();
            if ((UserInfo.GetUserInfoByUserName(num, str3) == null) != null)
            {
                goto Label_0158;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "用户名已存在，请修改！", this.txt_UserName.ClientID);
            goto Label_02D9;
        Label_0158:
            if ((UserInfo.GetUserInfoByMobile(num, str4) == null) != null)
            {
                goto Label_018F;
            }
            PageUtil.WriteAlertAndFocus(this.Page, "手机号已存在，请修改！", this.txt_Mobile.ClientID);
            goto Label_02D9;
        Label_018F:
            str5 = MD5Encrypt.PasswordEncrypt(this.m_strPassword);
            info = new UserInfo();
            info.PortalId = num;
            info.IsDelete = 2;
            info.IsActive = 1;
            info.IsSystemUser = 1;
            info.CreateTime = &DateTime.Now.Ticks;
            info.RealName = str3;
            info.Password = str5;
            num2 = PageUtil.CommonModify(this, info, info.get_id(), "", "", "");
            if (((num2 < 1) == 0) != null)
            {
                goto Label_022E;
            }
            PageUtil.WriteAlert(this.Page, "创建失败，请与管理员联系！");
            goto Label_02D9;
        Label_022E:
            rolesArray = UserRoles.GetUserRolesByUser(num2);
            if ((rolesArray == null) != null)
            {
                goto Label_0276;
            }
            rolesArray2 = rolesArray;
            num3 = 0;
            goto Label_0267;
        Label_024D:
            roles = rolesArray2[num3];
            UserRoles.Del(roles.get_id());
            num3 += 1;
        Label_0267:
            if ((num3 < ((int) rolesArray2.Length)) != null)
            {
                goto Label_024D;
            }
        Label_0276:
            UserRoles.SetUserRole("注册用户", -1, 0, num2);
            FunUtil.AutoLloginUser(this.Page, info);
            str6 = Util.GetString(base.Request, "returl", "");
            if ((string.IsNullOrEmpty(str6) == 0) != null)
            {
                goto Label_02C1;
            }
            str6 = "../../../Index.aspx";
        Label_02C1:
            PageUtil.WriteAlertAndRet(this.Page, "用户注册成功！", str6, "");
        Label_02D9:
            return;
        }

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            int num;
            bool flag;
            num = Util.GetInt(base.Request, "selPortal", 1);
            this.Session["global_pid"] = &num.ToString();
            this.selPortal.Value = &num.ToString();
            this.applicationpath.Value = Globals.get_ApplicationPath();
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            if ((base.IsPostBack == 0) == null)
            {
                goto Label_0096;
            }
            this.lbl_PortalName.Text = PortalSettings.get_PortalName();
            this.imgYZM.ImageUrl = Globals.ResolveURL("~/MyAccount/LoginVerifyCode.aspx");
        Label_0096:
            return;
        }
    }
}

