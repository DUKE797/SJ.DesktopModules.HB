﻿namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HB_DAYAHEAD_PEK_POWER_PLANT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;

        public HB_DAYAHEAD_PEK_POWER_PLANT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            hb_dayahead_pek_power_plant = Get(__nID);
            hb_dayahead_pek_power_plant.IsDelete = 1;
            hb_dayahead_pek_power_plant.Deleter = FunUtil.GetCurrentUserID();
            hb_dayahead_pek_power_plant.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(hb_dayahead_pek_power_plant).set(hb_dayahead_pek_power_plant);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            hb_dayahead_pek_power_plant = new HB_DAYAHEAD_PEK_POWER_PLANT();
            hb_dayahead_pek_power_plant.Id = __nID;
            CommonClassDB.Instance(hb_dayahead_pek_power_plant).delte(hb_dayahead_pek_power_plant);
        Label_0028:
            return;
        }

        public static HB_DAYAHEAD_PEK_POWER_PLANT Get(int __nID)
        {
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant;
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            hb_dayahead_pek_power_plant2 = null;
            goto Label_0037;
        Label_0010:
            hb_dayahead_pek_power_plant = new HB_DAYAHEAD_PEK_POWER_PLANT();
            hb_dayahead_pek_power_plant.Id = __nID;
            hb_dayahead_pek_power_plant2 = (HB_DAYAHEAD_PEK_POWER_PLANT) CommonClassDB.Instance(hb_dayahead_pek_power_plant).get(hb_dayahead_pek_power_plant, hb_dayahead_pek_power_plant.Id);
        Label_0037:
            return hb_dayahead_pek_power_plant2;
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
            str = "HB_DAYAHEAD_PEK_POWER_PLANT";
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
            hashtable = HB_DAYAPOWER.GetFieldNameHash();
            strArray = CustomerUtil.GetTemplateRootPath();
            if ((File.Exists(string.Format("{0}HB_DAYAHEAD_PEK_POWER_PLANT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
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
            HB_DAYAHEAD_PEK_POWER_PLANT[] hb_dayahead_pek_power_plantArray;
            int num;
            bool flag;
            hb_dayahead_pek_power_plantArray = List();
            if (((hb_dayahead_pek_power_plantArray == null) ? 0 : ((((int) hb_dayahead_pek_power_plantArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = hb_dayahead_pek_power_plantArray[((int) hb_dayahead_pek_power_plantArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HB_DAYAHEAD_PEK_POWER_PLANT[] List()
        {
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant;
            HB_DAYAHEAD_PEK_POWER_PLANT[] hb_dayahead_pek_power_plantArray;
            hb_dayahead_pek_power_plant = new HB_DAYAHEAD_PEK_POWER_PLANT();
            hb_dayahead_pek_power_plantArray = (HB_DAYAHEAD_PEK_POWER_PLANT[]) CommonClassDB.Instance(hb_dayahead_pek_power_plant).load(hb_dayahead_pek_power_plant, "OrderId");
        Label_0020:
            return hb_dayahead_pek_power_plantArray;
        }

        public static HB_DAYAHEAD_PEK_POWER_PLANT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HB_DAYAHEAD_PEK_POWER_PLANT hb_dayahead_pek_power_plant;
            HB_DAYAHEAD_PEK_POWER_PLANT[] hb_dayahead_pek_power_plantArray;
            HB_DAYAHEAD_PEK_POWER_PLANT[] hb_dayahead_pek_power_plantArray2;
            hb_dayahead_pek_power_plant = new HB_DAYAHEAD_PEK_POWER_PLANT();
            hb_dayahead_pek_power_plantArray = (HB_DAYAHEAD_PEK_POWER_PLANT[]) CommonClassDB.Instance(hb_dayahead_pek_power_plant).load(hb_dayahead_pek_power_plant, __nPageIndex, __nPageSize, __strFilter, __strSort);
            hb_dayahead_pek_power_plantArray2 = hb_dayahead_pek_power_plantArray;
        Label_0021:
            return hb_dayahead_pek_power_plantArray2;
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

