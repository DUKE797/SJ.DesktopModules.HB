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

    public class INTRADAY_PLANT_SCHEDULE : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime SCHED_DATE;
        public int UINTERVAL;

        public INTRADAY_PLANT_SCHEDULE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_plant_schedule = Get(__nID);
            intraday_plant_schedule.IsDelete = 1;
            intraday_plant_schedule.Deleter = FunUtil.GetCurrentUserID();
            intraday_plant_schedule.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_plant_schedule).set(intraday_plant_schedule);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_plant_schedule = new INTRADAY_PLANT_SCHEDULE();
            intraday_plant_schedule.Id = __nID;
            CommonClassDB.Instance(intraday_plant_schedule).delte(intraday_plant_schedule);
        Label_0028:
            return;
        }

        public static INTRADAY_PLANT_SCHEDULE Get(int __nID)
        {
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule;
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_plant_schedule2 = null;
            goto Label_0037;
        Label_0010:
            intraday_plant_schedule = new INTRADAY_PLANT_SCHEDULE();
            intraday_plant_schedule.Id = __nID;
            intraday_plant_schedule2 = (INTRADAY_PLANT_SCHEDULE) CommonClassDB.Instance(intraday_plant_schedule).get(intraday_plant_schedule, intraday_plant_schedule.Id);
        Label_0037:
            return intraday_plant_schedule2;
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
            str = "INTRADAY_PLANT_SCHEDULE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.SCHED_DATE, "日内计划", this.UINTERVAL);
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
            if ((File.Exists(string.Format("{0}INTRADAY_PLANT_SCHEDULE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0074;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["SCHED_DATE"] = "计划日期";
            hashtable["UINTERVAL"] = "交易时段";
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
            INTRADAY_PLANT_SCHEDULE[] intraday_plant_scheduleArray;
            int num;
            bool flag;
            intraday_plant_scheduleArray = List();
            if (((intraday_plant_scheduleArray == null) ? 0 : ((((int) intraday_plant_scheduleArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_plant_scheduleArray[((int) intraday_plant_scheduleArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PLANT_SCHEDULE[] List()
        {
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule;
            INTRADAY_PLANT_SCHEDULE[] intraday_plant_scheduleArray;
            intraday_plant_schedule = new INTRADAY_PLANT_SCHEDULE();
            intraday_plant_scheduleArray = (INTRADAY_PLANT_SCHEDULE[]) CommonClassDB.Instance(intraday_plant_schedule).load(intraday_plant_schedule, "OrderId");
        Label_0020:
            return intraday_plant_scheduleArray;
        }

        public static INTRADAY_PLANT_SCHEDULE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PLANT_SCHEDULE intraday_plant_schedule;
            INTRADAY_PLANT_SCHEDULE[] intraday_plant_scheduleArray;
            INTRADAY_PLANT_SCHEDULE[] intraday_plant_scheduleArray2;
            intraday_plant_schedule = new INTRADAY_PLANT_SCHEDULE();
            intraday_plant_scheduleArray = (INTRADAY_PLANT_SCHEDULE[]) CommonClassDB.Instance(intraday_plant_schedule).load(intraday_plant_schedule, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_plant_scheduleArray2 = intraday_plant_scheduleArray;
        Label_0021:
            return intraday_plant_scheduleArray2;
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

