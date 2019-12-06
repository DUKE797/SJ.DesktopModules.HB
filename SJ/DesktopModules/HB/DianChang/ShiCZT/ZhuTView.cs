namespace SJ.DesktopModules.HB.DianChang.ShiCZT
{
    using SJ.DesktopModules.HB.Class;
    using SJ.UserControls;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class ZhuTView : DoFormUserControl
    {
        protected HtmlInputButton btnSumibt;
        protected Literal ltTemplate;
        public Hashtable m_htCommonFill;
        private int nUserId;

        public ZhuTView()
        {
            this.m_htCommonFill = new Hashtable();
            this.nUserId = -1;
            base..ctor();
            return;
        }

        public override void InitJQueryRef(UserControl __oC)
        {
            JQueryRef ref2;
            ref2 = (JQueryRef) __oC;
            ref2.set_IncludeCheckBox(1);
            ref2.set_IncludeValidate(1);
            ref2.set_IncludeBootstrap(1);
            ref2.set_IncludeBootstrap_FileUpload(1);
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo info;
            HB_ShiCZTItem item;
            string str;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.m_htCommonFill["m_strEditUrl"] = PageUtil.GetDoFormActionUrl(base.Request, "DianChang_ShiCZT_ZhuTZC", "");
            this.m_htCommonFill["m_strSubmitUrl"] = PageUtil.GetDoFormActionUrl(base.Request, "DianChang_ShiCZT_ZhuTSubmit", "");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "fileinput.css");
            info = UserInfo.Get(this.nUserId);
            if (((info == null) == 0) != null)
            {
                goto Label_009C;
            }
            goto Label_01BA;
        Label_009C:
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, info, "_User", 0, 0, null);
            item = HB_ShiCZTItem.GetByUserId(this.nUserId);
            if ((item == null) != null)
            {
                goto Label_01BA;
            }
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, item, "", 0, 0, null);
            str = this.ltTemplate.Text;
            if (string.IsNullOrEmpty(item.YingYZZ) != null)
            {
                goto Label_0137;
            }
            this.m_htCommonFill["lblimg_YingYZZ"] = string.Format(str, PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 11));
        Label_0137:
            if (string.IsNullOrEmpty(item.DianLYWXKZ) != null)
            {
                goto Label_0182;
            }
            this.m_htCommonFill["lblimg_DianLYWXKZ"] = string.Format(str, PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 11));
        Label_0182:
            if ((item.RecordStatus == 1) != null)
            {
                goto Label_01B9;
            }
            this.btnSumibt.Disabled = 1;
            this.btnSumibt.Attributes["title"] = "仅录入中记录需要提交审核，请先“修改主体信息”";
        Label_01B9:;
        Label_01BA:
            return;
        }
    }
}

