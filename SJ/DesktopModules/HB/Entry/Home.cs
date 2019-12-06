namespace SJ.DesktopModules.HB.Entry
{
    using DataAccess;
    using SJ.DesktopModules.HB.Class;
    using System;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using WebSiteBase.Basic;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class Home : PageBase
    {
        private int _nPos;
        protected HtmlForm form1;
        protected UserControl JQR1;
        protected Literal ltCenter;
        protected Literal ltLeft;
        protected Literal ltLeft1;
        protected Literal ltLeft2;
        protected Literal ltRight;
        protected Literal ltRight2;
        private int nUserId;
        protected HtmlTable tblTool;
        protected HtmlTableRow tr1;
        protected HtmlTableRow tr2;
        protected HtmlTableRow tr3;

        public Home()
        {
            this.nUserId = -1;
            this._nPos = 1;
            base..ctor();
            return;
        }

        private void __BindData()
        {
            HtmlBlockItem[] itemArray;
            string str;
            StringBuilder builder;
            StringBuilder builder2;
            StringBuilder builder3;
            int num;
            bool flag;
            int num2;
            itemArray = HtmlBlockItem.ListByUserId(0, this.nUserId);
            if (((itemArray == null) ? 0 : ((((int) itemArray.Length) < 1) == 0)) != null)
            {
                goto Label_0029;
            }
            goto Label_0274;
        Label_0029:
            this.tr1.Visible = 0;
            this.tr2.Visible = 0;
            this.tr3.Visible = 0;
            if (((PortalSettings.get_HomeMode() == 3) == 0) != null)
            {
                goto Label_013A;
            }
            this.tr3.Visible = 1;
            str = "";
            builder = new StringBuilder();
            builder2 = new StringBuilder();
            builder3 = new StringBuilder();
            num = 0;
            goto Label_00F0;
        Label_0090:
            str = this.__FormatBlock(num, itemArray[num]);
            switch ((itemArray[num].ColumnNo - 1))
            {
                case 0:
                    goto Label_00C0;

                case 1:
                    goto Label_00CA;

                case 2:
                    goto Label_00D4;
            }
            goto Label_00DF;
        Label_00C0:
            builder.Append(str);
            goto Label_00E9;
        Label_00CA:
            builder2.Append(str);
            goto Label_00E9;
        Label_00D4:
            builder3.Append(str);
            goto Label_00E9;
        Label_00DF:
            builder2.Append(str);
        Label_00E9:
            num += 1;
        Label_00F0:
            if ((num < ((int) itemArray.Length)) != null)
            {
                goto Label_0090;
            }
            this.ltLeft.Text = builder.ToString();
            this.ltCenter.Text = builder2.ToString();
            this.ltRight.Text = builder3.ToString();
            goto Label_0274;
        Label_013A:
            if (((PortalSettings.get_HomeMode() == 2) == 0) != null)
            {
                goto Label_0200;
            }
            this.tr2.Visible = 1;
            str = "";
            builder = new StringBuilder();
            builder3 = new StringBuilder();
            num = 0;
            goto Label_01CB;
        Label_0174:
            str = this.__FormatBlock(num, itemArray[num]);
            switch ((itemArray[num].ColumnNo - 1))
            {
                case 0:
                    goto Label_01A4;

                case 1:
                    goto Label_01B9;

                case 2:
                    goto Label_01AE;
            }
            goto Label_01B9;
        Label_01A4:
            builder.Append(str);
            goto Label_01C4;
        Label_01AE:
            builder3.Append(str);
            goto Label_01C4;
        Label_01B9:
            builder3.Append(str);
        Label_01C4:
            num += 1;
        Label_01CB:
            if ((num < ((int) itemArray.Length)) != null)
            {
                goto Label_0174;
            }
            this.ltLeft2.Text = builder.ToString();
            this.ltRight2.Text = builder3.ToString();
            goto Label_0274;
        Label_0200:
            if (((PortalSettings.get_HomeMode() == 1) == 0) != null)
            {
                goto Label_0274;
            }
            this.tr1.Visible = 1;
            str = "";
            builder = new StringBuilder();
            builder3 = new StringBuilder();
            num = 0;
            goto Label_0254;
        Label_0237:
            str = this.__FormatBlock(num, itemArray[num]);
            builder.Append(str);
            num += 1;
        Label_0254:
            if ((num < ((int) itemArray.Length)) != null)
            {
                goto Label_0237;
            }
            this.ltLeft1.Text = builder.ToString();
        Label_0274:
            return;
        }

        private string __CreateChart(int __nChartType, int __nChartType2, string __strXmlFN, string __strHeight, string __strXLabel, bool __bSingle)
        {
            string str;
            string str2;
            str = base.MapPath("../Data/" + __strXmlFN);
            str2 = __CreateChart(__nChartType, __nChartType2, str, __strHeight, __strXLabel, 0, __bSingle, this._nPos);
        Label_002B:
            return str2;
        }

        public static string __CreateChart(int __nChartType, int __nChartType2, string __strFullFileName, string __strHeight, string __strXLabel, int __nShowValueCurve, bool __bSingle, int __nPos)
        {
            string str;
            StringBuilder builder;
            ChartSettingItem item;
            string str2;
            bool flag;
            str = Util.ReadFile(__strFullFileName, Encoding.UTF8).Replace("\r\n", "").Replace("\n", "").Replace("\r", "");
            builder = new StringBuilder();
            builder.Append(string.Format("<table id='tblChart{0}' cellpadding='0' cellspacing='0' width='100%'><tr><td width='100%' class='content'>", (int) __nPos));
            builder.Append("");
            builder.Append("</td></tr>");
            builder.Append("<tr><td>");
            item = new ChartSettingItem();
            item.Width = "100%";
            item.Height = __strHeight;
            item.XLabel = __strXLabel;
            item.ShowValueCurve = __nShowValueCurve;
            if (((__nChartType == 2) == 0) != null)
            {
                goto Label_00BD;
            }
            item.Title = __strXLabel;
        Label_00BD:
            item.ChartType = __nChartType;
            item.ChartType2 = __nChartType2;
            if ((__bSingle == 0) != null)
            {
                goto Label_00E6;
            }
            builder.Append(ChartUtil.ToHtmlOne(item, str));
            goto Label_00F4;
        Label_00E6:
            builder.Append(ChartUtil.ToHtmlTwo(item, str));
        Label_00F4:
            builder.Append("</td></tr></table>");
            str2 = builder.ToString();
        Label_0109:
            return str2;
        }

        private unsafe string __FormatBlock(int __nIdx, HtmlBlockItem __item)
        {
            string str;
            int num;
            int num2;
            HtmlBlockDefinition definition;
            IHtmlBlockAble able;
            int[] numArray;
            string str2;
            string str3;
            string str4;
            string str5;
            object[] objArray;
            bool flag;
            object obj2;
            str = string.Concat(new object[] { "<div class=mo id=m", (int) __nIdx, " blockitemid=", (int) __item.Id, ">" });
            if (string.IsNullOrEmpty(__item.Title) != null)
            {
                goto Label_00E1;
            }
            str = ((str + "<h1>") + "<table width=100% cellpadding=0 cellspacing=0><tr>") + "<td><img src=\"../../../img/" + ((string.IsNullOrEmpty(__item.Icon) != null) ? "triangle.gif" : __item.Icon) + "\" /></td>";
            flag = 1;
        Label_00A3:
            str = (str + "<td width=\"100%\"><h4>" + __item.Title + "</h4></td>") + "<td></td>";
            str = (str + "</tr></table>") + "</h1>";
        Label_00E1:
            str2 = PageUtil.GetApplicationPath(this.Page) + "Home.aspx?act=load&id=" + ((int) __item.Id);
            flag = 0;
            num = -100;
            num2 = 240;
            if ((__item.Width == 0) != null)
            {
                goto Label_0126;
            }
            num = __item.Width;
        Label_0126:
            if ((__item.Height == 0) != null)
            {
                goto Label_013C;
            }
            num2 = __item.Height;
        Label_013C:
            str3 = &num.ToString();
            str4 = &num2.ToString();
            if (((num < 0) == 0) != null)
            {
                goto Label_016F;
            }
            str3 = string.Format("{0}%", (int) (num * -1));
        Label_016F:
            if (((num2 < 0) == 0) != null)
            {
                goto Label_0190;
            }
            str4 = string.Format("{0}%", (int) (num2 * -1));
        Label_0190:
            str3 = "100%";
            if ((__item.RefreshSecond < 0) != null)
            {
                goto Label_0248;
            }
            obj2 = str;
            str = string.Concat(new object[] { obj2, "<table width=100% cellpadding=0 cellspacing=0 align=center><tr><td><div style='width:", str3, ";height:", str4, ";overflow:auto' id='nr", (int) __item.Id, "' class='nr' h='", (int) num2, "' refreshsecond='", (int) __item.RefreshSecond, "' loadurl=\"", str2, "\">取数据...</div></td></tr></table>" });
            goto Label_02E8;
        Label_0248:
            obj2 = str;
            str = string.Concat(new object[] { obj2, "<table width=100% cellpadding=0 cellspacing=0 align=center><tr><td><div style='width:", str3, ";height:", str4, ";overflow:auto' id='nr", (int) __item.Id, "' class='nr' refreshsecond='", (int) __item.RefreshSecond, "' loadurl2=\"", str2, "\">", GetBlockItemHtml(this, __item.Id), "</div></td></tr></table>" });
        Label_02E8:
            str5 = str + "</div>";
        Label_02FA:
            return str5;
        }

        public static string GetBlockItemHtml(Page __Page, int __nId)
        {
            string str;
            HtmlBlockItem item;
            string str2;
            string str3;
            string str4;
            int num;
            int num2;
            HtmlBlockDefinition definition;
            string str5;
            string str6;
            Type type;
            object obj2;
            IHtmlBlockAble able;
            Exception exception;
            string str7;
            bool flag;
            str = "";
        Label_0007:
            try
            {
                item = HtmlBlockItem.Get(__nId);
                if ((item == null) != null)
                {
                    goto Label_015D;
                }
                if (((item.DefinitionId == -99) == 0) != null)
                {
                    goto Label_00E6;
                }
                str2 = item.Parameter;
                if (((str2.IndexOf("?") > 0) == 0) != null)
                {
                    goto Label_0060;
                }
                str2 = str2 + "&";
                goto Label_006C;
            Label_0060:
                str2 = str2 + "?";
            Label_006C:
                str = Util.GetUrl(str2 + string.Format("fromgeturl={0}", FunUtil.SetLoginSession(__Page)), 120);
                str3 = "<!-- HOMECONTROL BEGIN -->";
                str4 = "<!-- HOMECONTROL END -->";
                num = str.IndexOf(str3);
                if ((num < 0) != null)
                {
                    goto Label_00E3;
                }
                num += str3.Length;
                num2 = str.IndexOf(str4, num);
                if (((num2 > num) == 0) != null)
                {
                    goto Label_00E2;
                }
                str = str.Substring(num, num2 - num);
            Label_00E2:;
            Label_00E3:
                goto Label_015C;
            Label_00E6:
                str5 = HtmlBlockDefinition.Get(item.DefinitionId).EntityName;
                str6 = item.Parameter;
                type = PageUtil.GetType(str5);
                if (((type != null) == 0) != null)
                {
                    goto Label_015B;
                }
                obj2 = Activator.CreateInstance(type);
                if (((obj2 == null) ? 1 : (((obj2 as IHtmlBlockAble) > null) == 0)) != null)
                {
                    goto Label_015A;
                }
                able = (IHtmlBlockAble) obj2;
                str = able.GetHtml(__Page, str6);
            Label_015A:;
            Label_015B:;
            Label_015C:;
            Label_015D:
                goto Label_016E;
            }
            catch (Exception exception1)
            {
            Label_0160:
                exception = exception1;
                str = exception.Message;
                goto Label_016E;
            }
        Label_016E:
            str7 = str;
        Label_0174:
            return str7;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int num;
            string str;
            HB_ShiCZTItem item;
            bool flag;
            this.nUserId = FunUtil.GetCurrentUserID(this.Page);
            if (((PersistenceManager.GlobalPortalId == 3) == 0) != null)
            {
                goto Label_00E7;
            }
            if ((UserRoles.IsUserInRoleName(this.nUserId, "注册用户") == 0) != null)
            {
                goto Label_00DB;
            }
            str = PageUtil.GetDoFormActionUrl(base.Request, "DianChang_ShiCZT_ZhuTZC", "");
            item = HB_ShiCZTItem.GetByUserId(this.nUserId);
            if (((item == null) == 0) != null)
            {
                goto Label_0088;
            }
            PageUtil.WriteAlertAndRet(this.Page, "请先完成主体注册信息填写工作", str, "");
            goto Label_00D8;
        Label_0088:
            if (((item.RecordStatus == 1) == 0) != null)
            {
                goto Label_00B1;
            }
            PageUtil.WriteAlertAndRet(this.Page, "请先提交主体注册信息", str, "");
            goto Label_00D8;
        Label_00B1:
            if (((item.RecordStatus == 2) == 0) != null)
            {
                goto Label_00D8;
            }
            PageUtil.WriteAlertAndRet(this.Page, "请耐心等待交易中心审核主体注册信息", str, "");
        Label_00D8:
            goto Label_00E4;
        Label_00DB:
            this.__BindData();
        Label_00E4:
            goto Label_0116;
        Label_00E7:
            str = PageUtil.GetDoFormActionUrl(base.Request, "DianWang_Home", "");
            PageUtil.WriteAlertAndRet(this.Page, "", str, "");
        Label_0116:
            return;
        }
    }
}

