namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class INTRADAY_PEAK_POWER_PROV : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public double INTERVEL;
        public string PROV_BUY;
        public string PROV_SELL;
        public DateTime RESULT_DATE;

        public INTRADAY_PEAK_POWER_PROV()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_peak_power_prov = Get(__nID);
            intraday_peak_power_prov.IsDelete = 1;
            intraday_peak_power_prov.Deleter = FunUtil.GetCurrentUserID();
            intraday_peak_power_prov.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_peak_power_prov).set(intraday_peak_power_prov);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_peak_power_prov = new INTRADAY_PEAK_POWER_PROV();
            intraday_peak_power_prov.Id = __nID;
            CommonClassDB.Instance(intraday_peak_power_prov).delte(intraday_peak_power_prov);
        Label_0028:
            return;
        }

        public static INTRADAY_PEAK_POWER_PROV Get(int __nID)
        {
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov;
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_peak_power_prov2 = null;
            goto Label_0037;
        Label_0010:
            intraday_peak_power_prov = new INTRADAY_PEAK_POWER_PROV();
            intraday_peak_power_prov.Id = __nID;
            intraday_peak_power_prov2 = (INTRADAY_PEAK_POWER_PROV) CommonClassDB.Instance(intraday_peak_power_prov).get(intraday_peak_power_prov, intraday_peak_power_prov.Id);
        Label_0037:
            return intraday_peak_power_prov2;
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
            str = "INTRADAY_PEAK_POWER_PROV";
        Label_0009:
            return str;
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
            if ((File.Exists(string.Format("{0}INTRADAY_PEAK_POWER_PROV.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0074;
        Label_002E:
            hashtable["PROV_BUY"] = "买方省份名称";
            hashtable["PROV_SELL"] = "卖方省份名称";
            hashtable["RESULT_DATE"] = "出清结果对应日期";
            hashtable["INTERVEL"] = "出清时段";
        Label_0074:
            hashtable2 = hashtable;
        Label_0078:
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
            INTRADAY_PEAK_POWER_PROV[] intraday_peak_power_provArray;
            int num;
            bool flag;
            intraday_peak_power_provArray = List();
            if (((intraday_peak_power_provArray == null) ? 0 : ((((int) intraday_peak_power_provArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_peak_power_provArray[((int) intraday_peak_power_provArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEAK_POWER_PROV[] List()
        {
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov;
            INTRADAY_PEAK_POWER_PROV[] intraday_peak_power_provArray;
            intraday_peak_power_prov = new INTRADAY_PEAK_POWER_PROV();
            intraday_peak_power_provArray = (INTRADAY_PEAK_POWER_PROV[]) CommonClassDB.Instance(intraday_peak_power_prov).load(intraday_peak_power_prov, "OrderId");
        Label_0020:
            return intraday_peak_power_provArray;
        }

        public static INTRADAY_PEAK_POWER_PROV[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEAK_POWER_PROV intraday_peak_power_prov;
            INTRADAY_PEAK_POWER_PROV[] intraday_peak_power_provArray;
            INTRADAY_PEAK_POWER_PROV[] intraday_peak_power_provArray2;
            intraday_peak_power_prov = new INTRADAY_PEAK_POWER_PROV();
            intraday_peak_power_provArray = (INTRADAY_PEAK_POWER_PROV[]) CommonClassDB.Instance(intraday_peak_power_prov).load(intraday_peak_power_prov, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_peak_power_provArray2 = intraday_peak_power_provArray;
        Label_0021:
            return intraday_peak_power_provArray2;
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

