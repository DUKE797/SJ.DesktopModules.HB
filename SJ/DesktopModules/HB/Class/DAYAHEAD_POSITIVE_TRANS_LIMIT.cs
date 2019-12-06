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

    public class DAYAHEAD_POSITIVE_TRANS_LIMIT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime PRESCHED_DATE;
        public string SECTION_NAME;

        public DAYAHEAD_POSITIVE_TRANS_LIMIT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_positive_trans_limit = Get(__nID);
            dayahead_positive_trans_limit.IsDelete = 1;
            dayahead_positive_trans_limit.Deleter = FunUtil.GetCurrentUserID();
            dayahead_positive_trans_limit.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_positive_trans_limit).set(dayahead_positive_trans_limit);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_positive_trans_limit = new DAYAHEAD_POSITIVE_TRANS_LIMIT();
            dayahead_positive_trans_limit.Id = __nID;
            CommonClassDB.Instance(dayahead_positive_trans_limit).delte(dayahead_positive_trans_limit);
        Label_0028:
            return;
        }

        public static DAYAHEAD_POSITIVE_TRANS_LIMIT Get(int __nID)
        {
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit;
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_positive_trans_limit2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_positive_trans_limit = new DAYAHEAD_POSITIVE_TRANS_LIMIT();
            dayahead_positive_trans_limit.Id = __nID;
            dayahead_positive_trans_limit2 = (DAYAHEAD_POSITIVE_TRANS_LIMIT) CommonClassDB.Instance(dayahead_positive_trans_limit).get(dayahead_positive_trans_limit, dayahead_positive_trans_limit.Id);
        Label_0037:
            return dayahead_positive_trans_limit2;
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
            str = "DAYAHEAD_POSITIVE_TRANS_LIMIT";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "正向限额");
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_POSITIVE_TRANS_LIMIT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0052;
        Label_002E:
            hashtable["SECTION_NAME"] = "断面名称";
            hashtable["PRESCHED_DATE"] = "限额对应的日期";
        Label_0052:
            hashtable2 = hashtable;
        Label_0056:
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
            DAYAHEAD_POSITIVE_TRANS_LIMIT[] dayahead_positive_trans_limitArray;
            int num;
            bool flag;
            dayahead_positive_trans_limitArray = List();
            if (((dayahead_positive_trans_limitArray == null) ? 0 : ((((int) dayahead_positive_trans_limitArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_positive_trans_limitArray[((int) dayahead_positive_trans_limitArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_POSITIVE_TRANS_LIMIT[] List()
        {
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit;
            DAYAHEAD_POSITIVE_TRANS_LIMIT[] dayahead_positive_trans_limitArray;
            dayahead_positive_trans_limit = new DAYAHEAD_POSITIVE_TRANS_LIMIT();
            dayahead_positive_trans_limitArray = (DAYAHEAD_POSITIVE_TRANS_LIMIT[]) CommonClassDB.Instance(dayahead_positive_trans_limit).load(dayahead_positive_trans_limit, "OrderId");
        Label_0020:
            return dayahead_positive_trans_limitArray;
        }

        public static DAYAHEAD_POSITIVE_TRANS_LIMIT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_POSITIVE_TRANS_LIMIT dayahead_positive_trans_limit;
            DAYAHEAD_POSITIVE_TRANS_LIMIT[] dayahead_positive_trans_limitArray;
            DAYAHEAD_POSITIVE_TRANS_LIMIT[] dayahead_positive_trans_limitArray2;
            dayahead_positive_trans_limit = new DAYAHEAD_POSITIVE_TRANS_LIMIT();
            dayahead_positive_trans_limitArray = (DAYAHEAD_POSITIVE_TRANS_LIMIT[]) CommonClassDB.Instance(dayahead_positive_trans_limit).load(dayahead_positive_trans_limit, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_positive_trans_limitArray2 = dayahead_positive_trans_limitArray;
        Label_0021:
            return dayahead_positive_trans_limitArray2;
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

