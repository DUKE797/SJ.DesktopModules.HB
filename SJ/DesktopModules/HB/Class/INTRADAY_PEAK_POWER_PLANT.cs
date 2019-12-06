namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class INTRADAY_PEAK_POWER_PLANT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public string DBI_ID;
        public double INTERVEL;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;

        public INTRADAY_PEAK_POWER_PLANT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_peak_power_plant = Get(__nID);
            intraday_peak_power_plant.IsDelete = 1;
            intraday_peak_power_plant.Deleter = FunUtil.GetCurrentUserID();
            intraday_peak_power_plant.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_peak_power_plant).set(intraday_peak_power_plant);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_peak_power_plant = new INTRADAY_PEAK_POWER_PLANT();
            intraday_peak_power_plant.Id = __nID;
            CommonClassDB.Instance(intraday_peak_power_plant).delte(intraday_peak_power_plant);
        Label_0028:
            return;
        }

        public static INTRADAY_PEAK_POWER_PLANT Get(int __nID)
        {
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant;
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_peak_power_plant2 = null;
            goto Label_0037;
        Label_0010:
            intraday_peak_power_plant = new INTRADAY_PEAK_POWER_PLANT();
            intraday_peak_power_plant.Id = __nID;
            intraday_peak_power_plant2 = (INTRADAY_PEAK_POWER_PLANT) CommonClassDB.Instance(intraday_peak_power_plant).get(intraday_peak_power_plant, intraday_peak_power_plant.Id);
        Label_0037:
            return intraday_peak_power_plant2;
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
            str = "INTRADAY_PEAK_POWER_PLANT";
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
            if ((File.Exists(string.Format("{0}INTRADAY_PEAK_POWER_PLANT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0074;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
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
            INTRADAY_PEAK_POWER_PLANT[] intraday_peak_power_plantArray;
            int num;
            bool flag;
            intraday_peak_power_plantArray = List();
            if (((intraday_peak_power_plantArray == null) ? 0 : ((((int) intraday_peak_power_plantArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_peak_power_plantArray[((int) intraday_peak_power_plantArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEAK_POWER_PLANT[] List()
        {
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant;
            INTRADAY_PEAK_POWER_PLANT[] intraday_peak_power_plantArray;
            intraday_peak_power_plant = new INTRADAY_PEAK_POWER_PLANT();
            intraday_peak_power_plantArray = (INTRADAY_PEAK_POWER_PLANT[]) CommonClassDB.Instance(intraday_peak_power_plant).load(intraday_peak_power_plant, "OrderId");
        Label_0020:
            return intraday_peak_power_plantArray;
        }

        public static INTRADAY_PEAK_POWER_PLANT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEAK_POWER_PLANT intraday_peak_power_plant;
            INTRADAY_PEAK_POWER_PLANT[] intraday_peak_power_plantArray;
            INTRADAY_PEAK_POWER_PLANT[] intraday_peak_power_plantArray2;
            intraday_peak_power_plant = new INTRADAY_PEAK_POWER_PLANT();
            intraday_peak_power_plantArray = (INTRADAY_PEAK_POWER_PLANT[]) CommonClassDB.Instance(intraday_peak_power_plant).load(intraday_peak_power_plant, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_peak_power_plantArray2 = intraday_peak_power_plantArray;
        Label_0021:
            return intraday_peak_power_plantArray2;
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

