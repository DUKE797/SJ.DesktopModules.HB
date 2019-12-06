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

    public class DAYAHEAD_PLANT_PRESCHEDULE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime PRESCHED_DATE;

        public DAYAHEAD_PLANT_PRESCHEDULE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_plant_preschedule = Get(__nID);
            dayahead_plant_preschedule.IsDelete = 1;
            dayahead_plant_preschedule.Deleter = FunUtil.GetCurrentUserID();
            dayahead_plant_preschedule.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_plant_preschedule).set(dayahead_plant_preschedule);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_plant_preschedule = new DAYAHEAD_PLANT_PRESCHEDULE();
            dayahead_plant_preschedule.Id = __nID;
            CommonClassDB.Instance(dayahead_plant_preschedule).delte(dayahead_plant_preschedule);
        Label_0028:
            return;
        }

        public static DAYAHEAD_PLANT_PRESCHEDULE Get(int __nID)
        {
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule;
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_plant_preschedule2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_plant_preschedule = new DAYAHEAD_PLANT_PRESCHEDULE();
            dayahead_plant_preschedule.Id = __nID;
            dayahead_plant_preschedule2 = (DAYAHEAD_PLANT_PRESCHEDULE) CommonClassDB.Instance(dayahead_plant_preschedule).get(dayahead_plant_preschedule, dayahead_plant_preschedule.Id);
        Label_0037:
            return dayahead_plant_preschedule2;
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
            str = "DAYAHEAD_PLANT_PRESCHEDULE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "预计划");
        Label_0016:
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_PLANT_PRESCHEDULE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["PRESCHED_DATE"] = "预计划对应的日期";
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
            DAYAHEAD_PLANT_PRESCHEDULE[] dayahead_plant_prescheduleArray;
            int num;
            bool flag;
            dayahead_plant_prescheduleArray = List();
            if (((dayahead_plant_prescheduleArray == null) ? 0 : ((((int) dayahead_plant_prescheduleArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_plant_prescheduleArray[((int) dayahead_plant_prescheduleArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_PLANT_PRESCHEDULE[] List()
        {
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule;
            DAYAHEAD_PLANT_PRESCHEDULE[] dayahead_plant_prescheduleArray;
            dayahead_plant_preschedule = new DAYAHEAD_PLANT_PRESCHEDULE();
            dayahead_plant_prescheduleArray = (DAYAHEAD_PLANT_PRESCHEDULE[]) CommonClassDB.Instance(dayahead_plant_preschedule).load(dayahead_plant_preschedule, "OrderId");
        Label_0020:
            return dayahead_plant_prescheduleArray;
        }

        public static DAYAHEAD_PLANT_PRESCHEDULE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_PLANT_PRESCHEDULE dayahead_plant_preschedule;
            DAYAHEAD_PLANT_PRESCHEDULE[] dayahead_plant_prescheduleArray;
            DAYAHEAD_PLANT_PRESCHEDULE[] dayahead_plant_prescheduleArray2;
            dayahead_plant_preschedule = new DAYAHEAD_PLANT_PRESCHEDULE();
            dayahead_plant_prescheduleArray = (DAYAHEAD_PLANT_PRESCHEDULE[]) CommonClassDB.Instance(dayahead_plant_preschedule).load(dayahead_plant_preschedule, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_plant_prescheduleArray2 = dayahead_plant_prescheduleArray;
        Label_0021:
            return dayahead_plant_prescheduleArray2;
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

