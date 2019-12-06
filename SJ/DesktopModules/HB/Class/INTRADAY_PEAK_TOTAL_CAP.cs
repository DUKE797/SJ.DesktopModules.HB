namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class INTRADAY_PEAK_TOTAL_CAP : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime PRESCHED_DATE;
        public string PROV_NAME;
        public int UINTERVAL;

        public INTRADAY_PEAK_TOTAL_CAP()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_peak_total_cap = Get(__nID);
            intraday_peak_total_cap.IsDelete = 1;
            intraday_peak_total_cap.Deleter = FunUtil.GetCurrentUserID();
            intraday_peak_total_cap.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_peak_total_cap).set(intraday_peak_total_cap);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_peak_total_cap = new INTRADAY_PEAK_TOTAL_CAP();
            intraday_peak_total_cap.Id = __nID;
            CommonClassDB.Instance(intraday_peak_total_cap).delte(intraday_peak_total_cap);
        Label_0028:
            return;
        }

        public static INTRADAY_PEAK_TOTAL_CAP Get(int __nID)
        {
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap;
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_peak_total_cap2 = null;
            goto Label_0037;
        Label_0010:
            intraday_peak_total_cap = new INTRADAY_PEAK_TOTAL_CAP();
            intraday_peak_total_cap.Id = __nID;
            intraday_peak_total_cap2 = (INTRADAY_PEAK_TOTAL_CAP) CommonClassDB.Instance(intraday_peak_total_cap).get(intraday_peak_total_cap, intraday_peak_total_cap.Id);
        Label_0037:
            return intraday_peak_total_cap2;
        }

        public string GetCacheKey()
        {
            string str;
            string str2;
            bool flag;
            str = "";
            if (((base.Id > 0) == 0) != null)
            {
                goto Label_002E;
            }
            str = str + "id=" + ((int) base.Id);
        Label_002E:
            str2 = str;
        Label_0032:
            return str2;
        }

        public string GetCacheTableName()
        {
            string str;
            str = "INTRADAY_PEAK_TOTAL_CAP";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "日内调峰总量", this.UINTERVAL);
        Label_001C:
            return list;
        }

        public Hashtable GetFieldNameHash()
        {
            Hashtable hashtable;
            string[] strArray;
            string str;
            Hashtable hashtable2;
            bool flag;
            hashtable = new Hashtable();
            strArray = CustomerUtil.GetTemplateRootPath();
            if ((File.Exists(string.Format("{0}INTRADAY_PEAK_TOTAL_CAP.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PROV_NAME"] = "省份名称";
            hashtable["PRESCHED_DATE"] = "申报日期";
            hashtable["UINTERVAL"] = "交易时段";
        Label_0063:
            hashtable2 = hashtable;
        Label_0067:
            return hashtable2;
        }

        public Hashtable GetListFieldNameHash()
        {
            Hashtable hashtable;
            hashtable = null;
        Label_0005:
            return hashtable;
        }

        public static int GetNextOrderID()
        {
            INTRADAY_PEAK_TOTAL_CAP[] intraday_peak_total_capArray;
            int num;
            bool flag;
            intraday_peak_total_capArray = List();
            if (((intraday_peak_total_capArray == null) ? 0 : ((((int) intraday_peak_total_capArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_peak_total_capArray[((int) intraday_peak_total_capArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEAK_TOTAL_CAP[] List()
        {
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap;
            INTRADAY_PEAK_TOTAL_CAP[] intraday_peak_total_capArray;
            intraday_peak_total_cap = new INTRADAY_PEAK_TOTAL_CAP();
            intraday_peak_total_capArray = (INTRADAY_PEAK_TOTAL_CAP[]) CommonClassDB.Instance(intraday_peak_total_cap).load(intraday_peak_total_cap, "OrderId");
        Label_0020:
            return intraday_peak_total_capArray;
        }

        public static INTRADAY_PEAK_TOTAL_CAP[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEAK_TOTAL_CAP intraday_peak_total_cap;
            INTRADAY_PEAK_TOTAL_CAP[] intraday_peak_total_capArray;
            INTRADAY_PEAK_TOTAL_CAP[] intraday_peak_total_capArray2;
            intraday_peak_total_cap = new INTRADAY_PEAK_TOTAL_CAP();
            intraday_peak_total_capArray = (INTRADAY_PEAK_TOTAL_CAP[]) CommonClassDB.Instance(intraday_peak_total_cap).load(intraday_peak_total_cap, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_peak_total_capArray2 = intraday_peak_total_capArray;
        Label_0021:
            return intraday_peak_total_capArray2;
        }

        public string CreatorName
        {
            get
            {
                UserInfo info;
                string str;
                bool flag;
                info = UserInfo.Get(base.Creator);
                if (((info == null) == 0) != null)
                {
                    goto Label_0020;
                }
                str = "";
                goto Label_0029;
            Label_0020:
                str = info.RealName;
            Label_0029:
                return str;
            }
        }
    }
}

