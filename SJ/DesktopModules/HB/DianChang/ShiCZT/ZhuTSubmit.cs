namespace SJ.DesktopModules.HB.DianChang.ShiCZT
{
    using DataAccess;
    using SJ.DesktopModules.HB.Class;
    using SJ.UserControls;
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Utilities;

    public class ZhuTSubmit : DoFormUserControl
    {
        protected LinkButton btnSubmit;
        protected Label lblTitle;
        private int nUserID;

        public ZhuTSubmit()
        {
            this.nUserID = -1;
            base..ctor();
            return;
        }

        protected unsafe void btnSubmit_Click(object sender, EventArgs e)
        {
            HB_ShiCZTItem item;
            string str;
            string str2;
            DateTime time;
            bool flag;
            item = HB_ShiCZTItem.GetByUserId(this.nUserID);
            item.RecordStatus = 2;
            item.Modifier = this.nUserID;
            item.ModifyTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(item).set(item);
            str = Util.GetString(base.Request, "returl", "");
            if (string.IsNullOrEmpty(str) != null)
            {
                goto Label_007F;
            }
            str2 = "try{top.hideLayer();top.Pop_hide();}catch(e){};top.getActiveFrameRight().src";
            PageUtil.WriteAlertAndRet(this.Page, "", str, str2);
            goto Label_0092;
        Label_007F:
            PageUtil.WriteAlert(this.Page, "提交成功");
        Label_0092:
            return;
        }

        private string GetRefreshUrl()
        {
            string str;
            string str2;
            string[] strArray;
            str2 = PageUtil.GetRefreshUrl(this.Page, new string[] { "rnd", "act", "eid" });
        Label_0031:
            return str2;
        }

        public override void InitJQueryRef(UserControl __oC)
        {
            JQueryRef ref2;
            ref2 = (JQueryRef) __oC;
            ref2.set_IncludeValidate(1);
            return;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            HB_ShiCZTItem item;
            bool flag;
            this.nUserID = FunUtil.GetCurrentUserID(this.Page);
            if ((base.IsPostBack == 0) == null)
            {
                goto Label_0069;
            }
            if (((HB_ShiCZTItem.GetByUserId(this.nUserID) == null) == 0) != null)
            {
                goto Label_004B;
            }
            this.lblTitle.Text = "没有录入市场主体信息！";
            goto Label_0069;
        Label_004B:
            this.lblTitle.Text = string.Format("你将提交市场主体信息审核，请点击“提交”按钮开始提交", new object[0]);
        Label_0069:
            return;
        }
    }
}

