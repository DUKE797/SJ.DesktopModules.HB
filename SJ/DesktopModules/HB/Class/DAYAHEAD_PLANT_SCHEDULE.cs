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

    public class DAYAHEAD_PLANT_SCHEDULE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime SCHED_DATE;

        public DAYAHEAD_PLANT_SCHEDULE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_plant_schedule = Get(__nID);
            dayahead_plant_schedule.IsDelete = 1;
            dayahead_plant_schedule.Deleter = FunUtil.GetCurrentUserID();
            dayahead_plant_schedule.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_plant_schedule).set(dayahead_plant_schedule);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_plant_schedule = new DAYAHEAD_PLANT_SCHEDULE();
            dayahead_plant_schedule.Id = __nID;
            CommonClassDB.Instance(dayahead_plant_schedule).delte(dayahead_plant_schedule);
        Label_0028:
            return;
        }

        public static DAYAHEAD_PLANT_SCHEDULE Get(int __nID)
        {
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule;
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_plant_schedule2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_plant_schedule = new DAYAHEAD_PLANT_SCHEDULE();
            dayahead_plant_schedule.Id = __nID;
            dayahead_plant_schedule2 = (DAYAHEAD_PLANT_SCHEDULE) CommonClassDB.Instance(dayahead_plant_schedule).get(dayahead_plant_schedule, dayahead_plant_schedule.Id);
        Label_0037:
            return dayahead_plant_schedule2;
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
            str = "DAYAHEAD_PLANT_SCHEDULE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.SCHED_DATE, "日前计划");
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_PLANT_SCHEDULE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["SCHED_DATE"] = "预计划对应的日期";
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
            DAYAHEAD_PLANT_SCHEDULE[] dayahead_plant_scheduleArray;
            int num;
            bool flag;
            dayahead_plant_scheduleArray = List();
            if (((dayahead_plant_scheduleArray == null) ? 0 : ((((int) dayahead_plant_scheduleArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_plant_scheduleArray[((int) dayahead_plant_scheduleArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_PLANT_SCHEDULE[] List()
        {
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule;
            DAYAHEAD_PLANT_SCHEDULE[] dayahead_plant_scheduleArray;
            dayahead_plant_schedule = new DAYAHEAD_PLANT_SCHEDULE();
            dayahead_plant_scheduleArray = (DAYAHEAD_PLANT_SCHEDULE[]) CommonClassDB.Instance(dayahead_plant_schedule).load(dayahead_plant_schedule, "OrderId");
        Label_0020:
            return dayahead_plant_scheduleArray;
        }

        public static DAYAHEAD_PLANT_SCHEDULE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_PLANT_SCHEDULE dayahead_plant_schedule;
            DAYAHEAD_PLANT_SCHEDULE[] dayahead_plant_scheduleArray;
            DAYAHEAD_PLANT_SCHEDULE[] dayahead_plant_scheduleArray2;
            dayahead_plant_schedule = new DAYAHEAD_PLANT_SCHEDULE();
            dayahead_plant_scheduleArray = (DAYAHEAD_PLANT_SCHEDULE[]) CommonClassDB.Instance(dayahead_plant_schedule).load(dayahead_plant_schedule, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_plant_scheduleArray2 = dayahead_plant_scheduleArray;
        Label_0021:
            return dayahead_plant_scheduleArray2;
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

