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

    public class INTRADAY_POSITIVE_TRANS_LIMIT : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime PRESCHED_DATE;
        public string SECTION_NAME;
        public int UINTERVAL;

        public INTRADAY_POSITIVE_TRANS_LIMIT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_positive_trans_limit = Get(__nID);
            intraday_positive_trans_limit.IsDelete = 1;
            intraday_positive_trans_limit.Deleter = FunUtil.GetCurrentUserID();
            intraday_positive_trans_limit.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_positive_trans_limit).set(intraday_positive_trans_limit);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_positive_trans_limit = new INTRADAY_POSITIVE_TRANS_LIMIT();
            intraday_positive_trans_limit.Id = __nID;
            CommonClassDB.Instance(intraday_positive_trans_limit).delte(intraday_positive_trans_limit);
        Label_0028:
            return;
        }

        public static INTRADAY_POSITIVE_TRANS_LIMIT Get(int __nID)
        {
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit;
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_positive_trans_limit2 = null;
            goto Label_0037;
        Label_0010:
            intraday_positive_trans_limit = new INTRADAY_POSITIVE_TRANS_LIMIT();
            intraday_positive_trans_limit.Id = __nID;
            intraday_positive_trans_limit2 = (INTRADAY_POSITIVE_TRANS_LIMIT) CommonClassDB.Instance(intraday_positive_trans_limit).get(intraday_positive_trans_limit, intraday_positive_trans_limit.Id);
        Label_0037:
            return intraday_positive_trans_limit2;
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
            str = "INTRADAY_POSITIVE_TRANS_LIMIT";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "正限额", this.UINTERVAL);
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
            if ((File.Exists(string.Format("{0}INTRADAY_POSITIVE_TRANS_LIMIT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["SECTION_NAME"] = "断面名称";
            hashtable["PRESCHED_DATE"] = "限额对应的日期";
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
            INTRADAY_POSITIVE_TRANS_LIMIT[] intraday_positive_trans_limitArray;
            int num;
            bool flag;
            intraday_positive_trans_limitArray = List();
            if (((intraday_positive_trans_limitArray == null) ? 0 : ((((int) intraday_positive_trans_limitArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_positive_trans_limitArray[((int) intraday_positive_trans_limitArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_POSITIVE_TRANS_LIMIT[] List()
        {
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit;
            INTRADAY_POSITIVE_TRANS_LIMIT[] intraday_positive_trans_limitArray;
            intraday_positive_trans_limit = new INTRADAY_POSITIVE_TRANS_LIMIT();
            intraday_positive_trans_limitArray = (INTRADAY_POSITIVE_TRANS_LIMIT[]) CommonClassDB.Instance(intraday_positive_trans_limit).load(intraday_positive_trans_limit, "OrderId");
        Label_0020:
            return intraday_positive_trans_limitArray;
        }

        public static INTRADAY_POSITIVE_TRANS_LIMIT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_POSITIVE_TRANS_LIMIT intraday_positive_trans_limit;
            INTRADAY_POSITIVE_TRANS_LIMIT[] intraday_positive_trans_limitArray;
            INTRADAY_POSITIVE_TRANS_LIMIT[] intraday_positive_trans_limitArray2;
            intraday_positive_trans_limit = new INTRADAY_POSITIVE_TRANS_LIMIT();
            intraday_positive_trans_limitArray = (INTRADAY_POSITIVE_TRANS_LIMIT[]) CommonClassDB.Instance(intraday_positive_trans_limit).load(intraday_positive_trans_limit, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_positive_trans_limitArray2 = intraday_positive_trans_limitArray;
        Label_0021:
            return intraday_positive_trans_limitArray2;
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

