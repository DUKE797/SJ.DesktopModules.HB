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

    public class INTRADAY_PRE_SCHEDULE : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime PRESCHED_DATE;
        public string SECTION_NAME;
        public int UINTERVAL;

        public INTRADAY_PRE_SCHEDULE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_pre_schedule = Get(__nID);
            intraday_pre_schedule.IsDelete = 1;
            intraday_pre_schedule.Deleter = FunUtil.GetCurrentUserID();
            intraday_pre_schedule.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_pre_schedule).set(intraday_pre_schedule);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_pre_schedule = new INTRADAY_PRE_SCHEDULE();
            intraday_pre_schedule.Id = __nID;
            CommonClassDB.Instance(intraday_pre_schedule).delte(intraday_pre_schedule);
        Label_0028:
            return;
        }

        public static INTRADAY_PRE_SCHEDULE Get(int __nID)
        {
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule;
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_pre_schedule2 = null;
            goto Label_0037;
        Label_0010:
            intraday_pre_schedule = new INTRADAY_PRE_SCHEDULE();
            intraday_pre_schedule.Id = __nID;
            intraday_pre_schedule2 = (INTRADAY_PRE_SCHEDULE) CommonClassDB.Instance(intraday_pre_schedule).get(intraday_pre_schedule, intraday_pre_schedule.Id);
        Label_0037:
            return intraday_pre_schedule2;
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
            str = "INTRADAY_PRE_SCHEDULE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "预潮流", this.UINTERVAL);
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
            if ((File.Exists(string.Format("{0}INTRADAY_PRE_SCHEDULE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["SECTION_NAME"] = "断面名称";
            hashtable["PRESCHED_DATE"] = "预计划对应的日期";
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
            INTRADAY_PRE_SCHEDULE[] intraday_pre_scheduleArray;
            int num;
            bool flag;
            intraday_pre_scheduleArray = List();
            if (((intraday_pre_scheduleArray == null) ? 0 : ((((int) intraday_pre_scheduleArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_pre_scheduleArray[((int) intraday_pre_scheduleArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PRE_SCHEDULE[] List()
        {
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule;
            INTRADAY_PRE_SCHEDULE[] intraday_pre_scheduleArray;
            intraday_pre_schedule = new INTRADAY_PRE_SCHEDULE();
            intraday_pre_scheduleArray = (INTRADAY_PRE_SCHEDULE[]) CommonClassDB.Instance(intraday_pre_schedule).load(intraday_pre_schedule, "OrderId");
        Label_0020:
            return intraday_pre_scheduleArray;
        }

        public static INTRADAY_PRE_SCHEDULE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PRE_SCHEDULE intraday_pre_schedule;
            INTRADAY_PRE_SCHEDULE[] intraday_pre_scheduleArray;
            INTRADAY_PRE_SCHEDULE[] intraday_pre_scheduleArray2;
            intraday_pre_schedule = new INTRADAY_PRE_SCHEDULE();
            intraday_pre_scheduleArray = (INTRADAY_PRE_SCHEDULE[]) CommonClassDB.Instance(intraday_pre_schedule).load(intraday_pre_schedule, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_pre_scheduleArray2 = intraday_pre_scheduleArray;
        Label_0021:
            return intraday_pre_scheduleArray2;
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

