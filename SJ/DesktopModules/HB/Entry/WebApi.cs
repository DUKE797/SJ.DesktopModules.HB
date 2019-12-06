namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using SJ.DesktopModules.HB.Class;
    using System;
    using System.Web.UI;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class WebApi : Page
    {
        public WebApi()
        {
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

        protected unsafe void Page_Load(object sender, EventArgs e)
        {
            string str;
            string str2;
            bool flag;
            string str3;
            string str4;
            int num;
            int num2;
            int num3;
            int num4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            UserInfo info;
            string str10;
            UserInfo info2;
            int num5;
            UserRoles[] rolesArray;
            UserRoles roles;
            int num6;
            string str11;
            string str12;
            string str13;
            HB_ShiCZTItem item;
            HB_ShiCZTItem item2;
            bool flag2;
            int num7;
            string str14;
            string str15;
            string str16;
            Exception exception;
            bool flag3;
            int num8;
            bool flag4;
            DateTime time;
            UserRoles[] rolesArray2;
            int num9;
            str = "";
        Label_0007:
            try
            {
                str2 = Util.GetString(base.Request, "act", "");
                flag = 0;
                if (flag != null)
                {
                    goto Label_06E8;
                }
                flag = 1;
                if ((("login" == str2) == 0) != null)
                {
                    goto Label_0206;
                }
                if (((this.Session["global_allportal"] == null) == 0) != null)
                {
                    goto Label_0079;
                }
                this.Session["global_allportal"] = SitePortal.GetAllPortal();
            Label_0079:
                str3 = Util.GetString(base.Request, "txtUserName", "");
                str4 = Util.GetString(base.Request, "txtPassword", "");
                num = Util.GetInt(base.Request, "selPortal", 1);
                if ((string.IsNullOrEmpty(str3) == 0) != null)
                {
                    goto Label_00D3;
                }
                str = "请输入用户名！";
                goto Label_0200;
            Label_00D3:
                if ((string.IsNullOrEmpty(str4) == 0) != null)
                {
                    goto Label_00EF;
                }
                str = "请输入用户密码！\ttxtUserName";
                goto Label_01FF;
            Label_00EF:
                if (((num < 1) == 0) != null)
                {
                    goto Label_0109;
                }
                str = "请选择登陆角色！\tselPortal";
                goto Label_01FE;
            Label_0109:
                this.Session["global_pid"] = &num.ToString();
                num2 = FunUtil.Login(this.Page, SitePortal.GetCurrentPortalId(), str3, str4);
                if (((num2 == 0) == 0) != null)
                {
                    goto Label_01A4;
                }
                this.Session["global_pid"] = &num.ToString();
                this.Session["global_pid2"] = &num.ToString();
                this.Session["global_username"] = str3;
                this.Session["global_password"] = str4;
                str = "ok";
                goto Label_01FD;
            Label_01A4:
                num8 = num2;
                switch ((num8 - 1))
                {
                    case 0:
                        goto Label_01CC;

                    case 1:
                        goto Label_01D4;

                    case 2:
                        goto Label_01DC;

                    case 3:
                        goto Label_01E4;

                    case 4:
                        goto Label_01EC;

                    case 5:
                        goto Label_01F4;
                }
                goto Label_01FC;
            Label_01CC:
                str = "帐号不存在\ttxtUserName";
                goto Label_01FC;
            Label_01D4:
                str = "密码错误\ttxtPassword";
                goto Label_01FC;
            Label_01DC:
                str = "输入有误\ttxtUserName";
                goto Label_01FC;
            Label_01E4:
                str = "本帐号已失效，不能登录！\ttxtUserName";
                goto Label_01FC;
            Label_01EC:
                str = "当前IP不能登录本帐号\ttxtUserName";
                goto Label_01FC;
            Label_01F4:
                str = "本站点当前不允许帐号登录！\ttxtUserName";
            Label_01FC:;
            Label_01FD:;
            Label_01FE:;
            Label_01FF:;
            Label_0200:
                goto Label_06E7;
            Label_0206:
                if ((("logout" == str2) == 0) != null)
                {
                    goto Label_026E;
                }
                flag4 = 0;
                PageUtil.SetCookie(this.Page, "GWZKJLMM", &flag4.ToString(), 360);
                PageUtil.SetCookie(this.Page, "GWZKUserInfo", "", 360);
                FunUtil.Logout(this.Page);
                str = "ok";
                goto Label_06E7;
            Label_026E:
                if ((("changeportal" == str2) == 0) != null)
                {
                    goto Label_03A5;
                }
                num = Util.GetInt(base.Request, "pid", PersistenceManager.GlobalPortalId);
                str3 = this.Session["global_username"];
                str4 = this.Session["global_password"];
                num3 = PersistenceManager.GlobalPortalId;
                this.Session["global_pid"] = &num.ToString();
                num2 = FunUtil.Login(this.Page, SitePortal.GetCurrentPortalId(), str3, str4);
                if (((num2 == 0) == 0) != null)
                {
                    goto Label_032E;
                }
                this.Session["global_pid"] = &num.ToString();
                str = "ok";
                goto Label_039F;
            Label_032E:
                this.Session["global_pid"] = &num3.ToString();
                num8 = num2;
                switch ((num8 - 1))
                {
                    case 0:
                        goto Label_036E;

                    case 1:
                        goto Label_0376;

                    case 2:
                        goto Label_037E;

                    case 3:
                        goto Label_0386;

                    case 4:
                        goto Label_038E;

                    case 5:
                        goto Label_0396;
                }
                goto Label_039E;
            Label_036E:
                str = "帐号不存在";
                goto Label_039E;
            Label_0376:
                str = "密码错误";
                goto Label_039E;
            Label_037E:
                str = "输入有误";
                goto Label_039E;
            Label_0386:
                str = "本帐号已失效，不能登录！";
                goto Label_039E;
            Label_038E:
                str = "当前IP不能登录本帐号";
                goto Label_039E;
            Label_0396:
                str = "本站点当前不允许帐号登录！";
            Label_039E:;
            Label_039F:
                goto Label_06E7;
            Label_03A5:
                if ((("register" == str2) == 0) != null)
                {
                    goto Label_06E5;
                }
                num = Util.GetInt(base.Request, "selPortal", 1);
                if ((num == 3) != null)
                {
                    goto Label_03F3;
                }
                str = string.Format("当前仅开放了电厂端系统的用户注册，请返回首页，选择合适的“登陆角色”！", new object[0]);
                goto Label_06E2;
            Label_03F3:
                this.Session["global_pid"] = &num.ToString();
                num4 = SitePortal.GetCurrentPortalId();
                str3 = Util.GetString(base.Request, "txt_UserName", "");
                str5 = Util.GetString(base.Request, "txt_Mobile", "");
                str4 = Util.GetString(base.Request, "txt_PasswordCustom", "");
                str6 = Util.GetString(base.Request, "txt_PasswordCustom2", "");
                str7 = Util.GetString(base.Request, "txtYZM", "");
                str8 = Util.GetString(base.Request, "txt_UserType", "");
                if ((string.IsNullOrEmpty(str3) == 0) != null)
                {
                    goto Label_04C0;
                }
                str = string.Format("请输入用户名！\ttxt_UserName", new object[0]);
                goto Label_052F;
            Label_04C0:
                str9 = this.Session["SJCode"];
                if ((string.IsNullOrEmpty(str9) == 0) != null)
                {
                    goto Label_04FD;
                }
                str = string.Format("验证码已改变，请点“刷新”按钮！\ttxtYZM", new object[0]);
                goto Label_052E;
            Label_04FD:
                if (((str7.ToLower() != str9.ToLower()) == 0) != null)
                {
                    goto Label_052D;
                }
                str = string.Format("验证码不正确，请改正！\ttxtYZM", new object[0]);
            Label_052D:;
            Label_052E:;
            Label_052F:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0563;
                }
                if ((UserInfo.GetUserInfoByUserName(num4, str3) == null) != null)
                {
                    goto Label_0562;
                }
                str = string.Format("用户名“{0}”已存在，请改正！\ttxt_UserName", str3);
            Label_0562:;
            Label_0563:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_05B7;
                }
                if ((str5.Length == 11) != null)
                {
                    goto Label_0595;
                }
                str = string.Format("手机号“{0}”不正确，请改正！\ttxt_Mobile", str5);
                goto Label_05B6;
            Label_0595:
                if (((str4 != str6) == 0) != null)
                {
                    goto Label_05B6;
                }
                str = string.Format("两次输入的密码不匹配，请改正！\ttxt_PasswordCustom", str5);
            Label_05B6:;
            Label_05B7:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_06E1;
                }
                CommonClassDB.ClearAllCache();
                str10 = MD5Encrypt.PasswordEncrypt(str4);
                info2 = new UserInfo();
                info2.PortalId = num4;
                info2.IsDelete = 2;
                info2.IsActive = 1;
                info2.IsSystemUser = 1;
                info2.Status = 1;
                info2.CreateTime = &DateTime.Now.Ticks;
                info2.UserName = str3;
                info2.RealName = str3;
                info2.Mobile = str5;
                info2.Password = str10;
                num5 = CommonClassDB.Instance(info2).set(info2);
                if (((num5 < 1) == 0) != null)
                {
                    goto Label_0673;
                }
                str = string.Format("创建失败，请与管理员联系！", new object[0]);
                goto Label_06E0;
            Label_0673:
                rolesArray = UserRoles.GetUserRolesByUser(num5);
                if ((rolesArray == null) != null)
                {
                    goto Label_06BC;
                }
                rolesArray2 = rolesArray;
                num9 = 0;
                goto Label_06AD;
            Label_0693:
                roles = rolesArray2[num9];
                UserRoles.Del(roles.get_id());
                num9 += 1;
            Label_06AD:
                if ((num9 < ((int) rolesArray2.Length)) != null)
                {
                    goto Label_0693;
                }
            Label_06BC:
                UserRoles.SetUserRole("注册用户", -1, 0, num5);
                FunUtil.AutoLloginUser(this.Page, info2);
                str = "ok";
            Label_06E0:;
            Label_06E1:;
            Label_06E2:
                goto Label_06E7;
            Label_06E5:
                flag = 0;
            Label_06E7:;
            Label_06E8:
                if (flag != null)
                {
                    goto Label_0CB6;
                }
                flag = 1;
                if ((("sumbit_ZhuTXX" == str2) == 0) != null)
                {
                    goto Label_095C;
                }
                num6 = FunUtil.GetCurrentUserID();
                if (((num6 < 1) == 0) != null)
                {
                    goto Label_0735;
                }
                str = string.Format("请重新登陆系统！\ttxt_Code", new object[0]);
            Label_0735:
                num4 = SitePortal.GetCurrentPortalId();
                str11 = Util.GetString(base.Request, "txt_Code", "");
                str12 = Util.GetString(base.Request, "hidden_YingYZZ", "");
                str13 = Util.GetString(base.Request, "hidden_DianLYWXKZ", "");
                if ((((string.IsNullOrEmpty(str11) != null) || (string.IsNullOrEmpty(str12) != null)) ? 0 : (string.IsNullOrEmpty(str13) == 0)) != null)
                {
                    goto Label_07BA;
                }
                str = string.Format("输入不正确，请改正！\ttxt_Code", new object[0]);
            Label_07BA:
                item = HB_ShiCZTItem.GetByUserId(num6);
                if (((item == null) == 0) != null)
                {
                    goto Label_080B;
                }
                item = new HB_ShiCZTItem();
                item.UserId = num6;
                item.Creator = num6;
                item.CreateTime = &DateTime.Now.Ticks;
                item.IsDelete = 2;
                goto Label_082B;
            Label_080B:
                item.Modifier = num6;
                item.ModifyTime = &DateTime.Now.Ticks;
            Label_082B:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0872;
                }
                item2 = HB_ShiCZTItem.GetByName(str11);
                if (((item2 == null) ? 1 : (item2.Id == item.Id)) != null)
                {
                    goto Label_0871;
                }
                str = string.Format("组织机构名称“{0}”已存在，请改正！\ttxt_Code", str11);
            Label_0871:;
            Label_0872:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0956;
                }
                item.Name = str11;
                item.RecordStatus = 1;
                num5 = CommonClassDB.Instance(item).set(item);
                if (((num5 > 0) == 0) != null)
                {
                    goto Label_094F;
                }
                item = HB_ShiCZTItem.Get(num5);
                flag2 = 0;
                if (((str12 != "exist") == 0) != null)
                {
                    goto Label_08FB;
                }
                if ((PageUtil.UploadAttachForBootstrap(this.Page, str12, item, "YingYZZ") == 0) != null)
                {
                    goto Label_08FA;
                }
                flag2 = 1;
            Label_08FA:;
            Label_08FB:
                if (((str13 != "exist") == 0) != null)
                {
                    goto Label_0932;
                }
                if ((PageUtil.UploadAttachForBootstrap(this.Page, str13, item, "DianLYWXKZ") == 0) != null)
                {
                    goto Label_0931;
                }
                flag2 = 1;
            Label_0931:;
            Label_0932:
                if ((flag2 == 0) != null)
                {
                    goto Label_094E;
                }
                CommonClassDB.Instance(item).set(item);
            Label_094E:;
            Label_094F:
                str = "ok";
            Label_0956:
                goto Label_0CB5;
            Label_095C:
                if ((("reject_ZhuTXX" == str2) == 0) != null)
                {
                    goto Label_0AF0;
                }
                num6 = FunUtil.GetCurrentUserID();
                if (((num6 < 1) == 0) != null)
                {
                    goto Label_099C;
                }
                str = string.Format("请重新登陆系统！", new object[0]);
            Label_099C:
                if (FunUtil.CanExecEntityAction(num6, "SJ.DesktopModules.HB.主体信息审核自动实体", "DianChang_ShiCZT_ZhuTAudit") != null)
                {
                    goto Label_09C1;
                }
                str = string.Format("当前用户没有执行该功能权限（{0}）！", str2);
            Label_09C1:
                num7 = Util.GetInt(base.Request, "id", -1);
                str14 = Util.GetString(base.Request, "txt_Reason", "");
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0A1D;
                }
                if (((num7 < 1) == 0) != null)
                {
                    goto Label_0A1C;
                }
                str = string.Format("参数错误！", new object[0]);
            Label_0A1C:;
            Label_0A1D:
                item = HB_ShiCZTItem.Get(num7);
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0A58;
                }
                if (((item == null) == 0) != null)
                {
                    goto Label_0A57;
                }
                str = string.Format("参数错误！", new object[0]);
            Label_0A57:;
            Label_0A58:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0AEA;
                }
                item.Modifier = num6;
                item.ModifyTime = &DateTime.Now.Ticks;
                item.RecordStatus = 0x1f;
                item.Reason = str14;
                if (((CommonClassDB.Instance(item).set(item) > 0) == 0) != null)
                {
                    goto Label_0AE3;
                }
                UserRoles.RemoveUserFromRoleName("发电企业", -1, 0, item.UserId);
                UserRoles.SetUserRole("注册用户", -1, 0, item.UserId);
            Label_0AE3:
                str = "ok";
            Label_0AEA:
                goto Label_0CB5;
            Label_0AF0:
                if ((("audit_ZhuTXX" == str2) == 0) != null)
                {
                    goto Label_0CB3;
                }
                num6 = FunUtil.GetCurrentUserID();
                if (((num6 < 1) == 0) != null)
                {
                    goto Label_0B30;
                }
                str = string.Format("请重新登陆系统！", new object[0]);
            Label_0B30:
                if (FunUtil.CanExecEntityAction(num6, "SJ.DesktopModules.HB.主体信息审核自动实体", "DianChang_ShiCZT_ZhuTAudit") != null)
                {
                    goto Label_0B55;
                }
                str = string.Format("当前用户没有执行该功能权限（{0}）！", str2);
            Label_0B55:
                num7 = Util.GetInt(base.Request, "id", -1);
                str15 = Util.GetString(base.Request, "txt_DiaoDGX_New", "");
                str16 = Util.GetString(base.Request, "txt_EnterDate_New", "");
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0BC8;
                }
                if (((num7 < 1) == 0) != null)
                {
                    goto Label_0BC7;
                }
                str = string.Format("参数错误！", new object[0]);
            Label_0BC7:;
            Label_0BC8:
                item = HB_ShiCZTItem.Get(num7);
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0C03;
                }
                if (((item == null) == 0) != null)
                {
                    goto Label_0C02;
                }
                str = string.Format("参数错误！", new object[0]);
            Label_0C02:;
            Label_0C03:
                if ((string.IsNullOrEmpty(str) == 0) != null)
                {
                    goto Label_0CB0;
                }
                item.Modifier = num6;
                item.ModifyTime = &DateTime.Now.Ticks;
                item.RecordStatus = 3;
                item.DiaoDGX = str15;
                item.EnterDate = &Util.ParseDate(str16, DateTime.Now).Ticks;
                if (((CommonClassDB.Instance(item).set(item) > 0) == 0) != null)
                {
                    goto Label_0CA9;
                }
                UserRoles.RemoveUserFromRoleName("注册用户", -1, 0, item.UserId);
                UserRoles.SetUserRole("发电企业", -1, 0, item.UserId);
            Label_0CA9:
                str = "ok";
            Label_0CB0:
                goto Label_0CB5;
            Label_0CB3:
                flag = 0;
            Label_0CB5:;
            Label_0CB6:
                if (flag != null)
                {
                    goto Label_0CCB;
                }
                str = string.Format("未知的操作：{0}，请与系统管理员联系！", str2);
            Label_0CCB:
                goto Label_0CDC;
            }
            catch (Exception exception1)
            {
            Label_0CCE:
                exception = exception1;
                str = exception.Message;
                goto Label_0CDC;
            }
        Label_0CDC:
            this.__Return(str);
            return;
        }
    }
}

