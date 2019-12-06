namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class DAYAHEAD_PEK_POWER_PROV : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public string PROV_BUY;
        public string PROV_SELL;
        public DateTime RESULT_DATE;

        public DAYAHEAD_PEK_POWER_PROV()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_pek_power_prov = Get(__nID);
            dayahead_pek_power_prov.IsDelete = 1;
            dayahead_pek_power_prov.Deleter = FunUtil.GetCurrentUserID();
            dayahead_pek_power_prov.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_pek_power_prov).set(dayahead_pek_power_prov);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_pek_power_prov = new DAYAHEAD_PEK_POWER_PROV();
            dayahead_pek_power_prov.Id = __nID;
            CommonClassDB.Instance(dayahead_pek_power_prov).delte(dayahead_pek_power_prov);
        Label_0028:
            return;
        }

        public static DAYAHEAD_PEK_POWER_PROV Get(int __nID)
        {
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov;
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_pek_power_prov2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_pek_power_prov = new DAYAHEAD_PEK_POWER_PROV();
            dayahead_pek_power_prov.Id = __nID;
            dayahead_pek_power_prov2 = (DAYAHEAD_PEK_POWER_PROV) CommonClassDB.Instance(dayahead_pek_power_prov).get(dayahead_pek_power_prov, dayahead_pek_power_prov.Id);
        Label_0037:
            return dayahead_pek_power_prov2;
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
            str = "DAYAHEAD_PEK_POWER_PROV";
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_PEK_POWER_PROV.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PROV_BUY"] = "买方省份名称";
            hashtable["PROV_SELL"] = "卖方省份名称";
            hashtable["RESULT_DATE"] = "出清结果对应日期";
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
            DAYAHEAD_PEK_POWER_PROV[] dayahead_pek_power_provArray;
            int num;
            bool flag;
            dayahead_pek_power_provArray = List();
            if (((dayahead_pek_power_provArray == null) ? 0 : ((((int) dayahead_pek_power_provArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_pek_power_provArray[((int) dayahead_pek_power_provArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_PEK_POWER_PROV[] List()
        {
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov;
            DAYAHEAD_PEK_POWER_PROV[] dayahead_pek_power_provArray;
            dayahead_pek_power_prov = new DAYAHEAD_PEK_POWER_PROV();
            dayahead_pek_power_provArray = (DAYAHEAD_PEK_POWER_PROV[]) CommonClassDB.Instance(dayahead_pek_power_prov).load(dayahead_pek_power_prov, "OrderId");
        Label_0020:
            return dayahead_pek_power_provArray;
        }

        public static DAYAHEAD_PEK_POWER_PROV[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_PEK_POWER_PROV dayahead_pek_power_prov;
            DAYAHEAD_PEK_POWER_PROV[] dayahead_pek_power_provArray;
            DAYAHEAD_PEK_POWER_PROV[] dayahead_pek_power_provArray2;
            dayahead_pek_power_prov = new DAYAHEAD_PEK_POWER_PROV();
            dayahead_pek_power_provArray = (DAYAHEAD_PEK_POWER_PROV[]) CommonClassDB.Instance(dayahead_pek_power_prov).load(dayahead_pek_power_prov, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_pek_power_provArray2 = dayahead_pek_power_provArray;
        Label_0021:
            return dayahead_pek_power_provArray2;
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

