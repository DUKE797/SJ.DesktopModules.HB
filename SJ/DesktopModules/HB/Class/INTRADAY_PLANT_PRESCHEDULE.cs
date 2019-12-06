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

    public class INTRADAY_PLANT_PRESCHEDULE : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime PRESCHED_DATE;
        public int UINTERVAL;

        public INTRADAY_PLANT_PRESCHEDULE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_plant_preschedule = Get(__nID);
            intraday_plant_preschedule.IsDelete = 1;
            intraday_plant_preschedule.Deleter = FunUtil.GetCurrentUserID();
            intraday_plant_preschedule.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_plant_preschedule).set(intraday_plant_preschedule);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_plant_preschedule = new INTRADAY_PLANT_PRESCHEDULE();
            intraday_plant_preschedule.Id = __nID;
            CommonClassDB.Instance(intraday_plant_preschedule).delte(intraday_plant_preschedule);
        Label_0028:
            return;
        }

        public static INTRADAY_PLANT_PRESCHEDULE Get(int __nID)
        {
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule;
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_plant_preschedule2 = null;
            goto Label_0037;
        Label_0010:
            intraday_plant_preschedule = new INTRADAY_PLANT_PRESCHEDULE();
            intraday_plant_preschedule.Id = __nID;
            intraday_plant_preschedule2 = (INTRADAY_PLANT_PRESCHEDULE) CommonClassDB.Instance(intraday_plant_preschedule).get(intraday_plant_preschedule, intraday_plant_preschedule.Id);
        Label_0037:
            return intraday_plant_preschedule2;
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
            str = "INTRADAY_PLANT_PRESCHEDULE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "预计划", this.UINTERVAL);
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
            if ((File.Exists(string.Format("{0}INTRADAY_PLANT_PRESCHEDULE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0074;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["PRESCHED_DATE"] = "预计划对应的日期";
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
            INTRADAY_PLANT_PRESCHEDULE[] intraday_plant_prescheduleArray;
            int num;
            bool flag;
            intraday_plant_prescheduleArray = List();
            if (((intraday_plant_prescheduleArray == null) ? 0 : ((((int) intraday_plant_prescheduleArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_plant_prescheduleArray[((int) intraday_plant_prescheduleArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PLANT_PRESCHEDULE[] List()
        {
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule;
            INTRADAY_PLANT_PRESCHEDULE[] intraday_plant_prescheduleArray;
            intraday_plant_preschedule = new INTRADAY_PLANT_PRESCHEDULE();
            intraday_plant_prescheduleArray = (INTRADAY_PLANT_PRESCHEDULE[]) CommonClassDB.Instance(intraday_plant_preschedule).load(intraday_plant_preschedule, "OrderId");
        Label_0020:
            return intraday_plant_prescheduleArray;
        }

        public static INTRADAY_PLANT_PRESCHEDULE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PLANT_PRESCHEDULE intraday_plant_preschedule;
            INTRADAY_PLANT_PRESCHEDULE[] intraday_plant_prescheduleArray;
            INTRADAY_PLANT_PRESCHEDULE[] intraday_plant_prescheduleArray2;
            intraday_plant_preschedule = new INTRADAY_PLANT_PRESCHEDULE();
            intraday_plant_prescheduleArray = (INTRADAY_PLANT_PRESCHEDULE[]) CommonClassDB.Instance(intraday_plant_preschedule).load(intraday_plant_preschedule, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_plant_prescheduleArray2 = intraday_plant_prescheduleArray;
        Label_0021:
            return intraday_plant_prescheduleArray2;
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

