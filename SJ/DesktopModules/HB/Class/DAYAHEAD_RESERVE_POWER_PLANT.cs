namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class DAYAHEAD_RESERVE_POWER_PLANT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public string DBI_ID;
        public double INTERVEL;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;

        public DAYAHEAD_RESERVE_POWER_PLANT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_reserve_power_plant = Get(__nID);
            dayahead_reserve_power_plant.IsDelete = 1;
            dayahead_reserve_power_plant.Deleter = FunUtil.GetCurrentUserID();
            dayahead_reserve_power_plant.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_reserve_power_plant).set(dayahead_reserve_power_plant);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_reserve_power_plant = new DAYAHEAD_RESERVE_POWER_PLANT();
            dayahead_reserve_power_plant.Id = __nID;
            CommonClassDB.Instance(dayahead_reserve_power_plant).delte(dayahead_reserve_power_plant);
        Label_0028:
            return;
        }

        public static DAYAHEAD_RESERVE_POWER_PLANT Get(int __nID)
        {
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant;
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_reserve_power_plant2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_reserve_power_plant = new DAYAHEAD_RESERVE_POWER_PLANT();
            dayahead_reserve_power_plant.Id = __nID;
            dayahead_reserve_power_plant2 = (DAYAHEAD_RESERVE_POWER_PLANT) CommonClassDB.Instance(dayahead_reserve_power_plant).get(dayahead_reserve_power_plant, dayahead_reserve_power_plant.Id);
        Label_0037:
            return dayahead_reserve_power_plant2;
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
            str = "DAYAHEAD_RESERVE_POWER_PLANT";
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_RESERVE_POWER_PLANT.AutoField", strArray[1])) == 0) != null)
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
            DAYAHEAD_RESERVE_POWER_PLANT[] dayahead_reserve_power_plantArray;
            int num;
            bool flag;
            dayahead_reserve_power_plantArray = List();
            if (((dayahead_reserve_power_plantArray == null) ? 0 : ((((int) dayahead_reserve_power_plantArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_reserve_power_plantArray[((int) dayahead_reserve_power_plantArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_RESERVE_POWER_PLANT[] List()
        {
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant;
            DAYAHEAD_RESERVE_POWER_PLANT[] dayahead_reserve_power_plantArray;
            dayahead_reserve_power_plant = new DAYAHEAD_RESERVE_POWER_PLANT();
            dayahead_reserve_power_plantArray = (DAYAHEAD_RESERVE_POWER_PLANT[]) CommonClassDB.Instance(dayahead_reserve_power_plant).load(dayahead_reserve_power_plant, "OrderId");
        Label_0020:
            return dayahead_reserve_power_plantArray;
        }

        public static DAYAHEAD_RESERVE_POWER_PLANT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_RESERVE_POWER_PLANT dayahead_reserve_power_plant;
            DAYAHEAD_RESERVE_POWER_PLANT[] dayahead_reserve_power_plantArray;
            DAYAHEAD_RESERVE_POWER_PLANT[] dayahead_reserve_power_plantArray2;
            dayahead_reserve_power_plant = new DAYAHEAD_RESERVE_POWER_PLANT();
            dayahead_reserve_power_plantArray = (DAYAHEAD_RESERVE_POWER_PLANT[]) CommonClassDB.Instance(dayahead_reserve_power_plant).load(dayahead_reserve_power_plant, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_reserve_power_plantArray2 = dayahead_reserve_power_plantArray;
        Label_0021:
            return dayahead_reserve_power_plantArray2;
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

