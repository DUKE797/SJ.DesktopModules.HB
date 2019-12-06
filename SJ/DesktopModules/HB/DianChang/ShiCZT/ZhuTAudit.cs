namespace SJ.DesktopModules.HB.DianChang.ShiCZT
{
    using DataAccess;
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

    public class ZhuTAudit : DoFormUserControl
    {
        protected HtmlInputButton btnReject;
        protected Literal ltTemplate;
        public Hashtable m_htCommonFill;
        private int nId;
        private int nUserId;

        public ZhuTAudit()
        {
            this.m_htCommonFill = new Hashtable();
            this.nUserId = -1;
            this.nId = -1;
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
            HB_ShiCZTItem item;
            UserInfo info;
            string str;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            this.nId = Util.GetInt(base.Request, "id", -1);
            this.m_htCommonFill["m_strListUrl"] = PageUtil.GetDoFormActionUrl(base.Request, "DianChang_ShiCZT_ZhuTList", null);
            this.m_htCommonFill["m_strAddOn"] = string.Format("&id={0}&", (int) this.nId);
            SkinUtil.AdhereEntryStyleSheet(this.Page, "bootstrap.min.css");
            SkinUtil.AdhereEntryStyleSheet(this.Page, "fileinput.css");
            if ((base.IsPostBack == 0) != null)
            {
                goto Label_00A5;
            }
            goto Label_01BD;
        Label_00A5:
            item = HB_ShiCZTItem.Get(this.nId);
            info = UserInfo.Get(item.UserId);
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, info, "_User", 0, 0, null);
            PageUtil.CommonFillHash(this.m_htCommonFill, 0, item, "", 0, 0, null);
            str = this.ltTemplate.Text;
            if (string.IsNullOrEmpty(item.YingYZZ) != null)
            {
                goto Label_0140;
            }
            this.m_htCommonFill["lblimg_YingYZZ"] = string.Format(str, PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "YingYZZ", 11));
        Label_0140:
            if (string.IsNullOrEmpty(item.DianLYWXKZ) != null)
            {
                goto Label_018B;
            }
            this.m_htCommonFill["lblimg_DianLYWXKZ"] = string.Format(str, PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 1), PageUtil.GetTypeFieldAttachLink(this.Page, item, "DianLYWXKZ", 11));
        Label_018B:
            this.m_htCommonFill["txt_DiaoDGX_New"] = "省调直调电厂";
            this.m_htCommonFill["txt_EnterDate_New"] = DateTimeUtil.DisplayDefaultDateTime(DateTime.Now, 0);
        Label_01BD:
            return;
        }
    }
}

