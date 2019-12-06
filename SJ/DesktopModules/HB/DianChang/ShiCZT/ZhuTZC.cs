namespace SJ.DesktopModules.HB.DianChang.ShiCZT
{
    using SJ.DesktopModules.HB.Class;
    using SJ.UserControls;
    using System;
    using System.Collections;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Utilities;

    public class ZhuTZC : DoFormUserControl
    {
        protected Literal ltTemplate;
        public Hashtable m_htCommonFill;
        private int nUserId;

        public ZhuTZC()
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
            ref2.set_IncludeLayerBox(1);
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            UserInfo info;
            HB_ShiCZTItem item;
            string str;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.m_htCommonFill["m_strViewUrl"] = PageUtil.GetDoFormActionUrl(base.Request, "DianChang_ShiCZT_ZhuTView", "");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "fileinput.css");
            info = UserInfo.Get(this.nUserId);
            if (((info == null) == 0) != null)
            {
                goto Label_0076;
            }
            goto Label_0197;
        Label_0076:
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, info, "_User", 0, 0, null);
            item = HB_ShiCZTItem.GetByUserId(this.nUserId);
            if ((item == null) != null)
            {
                goto Label_0197;
            }
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, item, "", 0, 0, null);
            str = this.ltTemplate.Text;
            if (string.IsNullOrEmpty(item.YingYZZ) != null)
            {
                goto Label_012E;
            }
            this.m_htCommonFill["lblimg_YingYZZ"] = string.Format(str, "hidden_YingYZZ", PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 11));
            this.m_htCommonFill["hidden_YingYZZ"] = "exist";
        Label_012E:
            if (string.IsNullOrEmpty(item.DianLYWXKZ) != null)
            {
                goto Label_0196;
            }
            this.m_htCommonFill["lblimg_DianLYWXKZ"] = string.Format(str, "hidden_DianLYWXKZ", PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 11));
            this.m_htCommonFill["hidden_DianLYWXKZ"] = "exist";
        Label_0196:;
        Label_0197:
            return;
        }
    }
}

