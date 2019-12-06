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

    public class INTRADAY_PEK_RESULT : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;
        public int UINTERVAL;

        public INTRADAY_PEK_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEK_RESULT intraday_pek_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_pek_result = Get(__nID);
            intraday_pek_result.IsDelete = 1;
            intraday_pek_result.Deleter = FunUtil.GetCurrentUserID();
            intraday_pek_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_pek_result).set(intraday_pek_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEK_RESULT intraday_pek_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_pek_result = new INTRADAY_PEK_RESULT();
            intraday_pek_result.Id = __nID;
            CommonClassDB.Instance(intraday_pek_result).delte(intraday_pek_result);
        Label_0028:
            return;
        }

        public static INTRADAY_PEK_RESULT Get(int __nID)
        {
            INTRADAY_PEK_RESULT intraday_pek_result;
            INTRADAY_PEK_RESULT intraday_pek_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_pek_result2 = null;
            goto Label_0037;
        Label_0010:
            intraday_pek_result = new INTRADAY_PEK_RESULT();
            intraday_pek_result.Id = __nID;
            intraday_pek_result2 = (INTRADAY_PEK_RESULT) CommonClassDB.Instance(intraday_pek_result).get(intraday_pek_result, intraday_pek_result.Id);
        Label_0037:
            return intraday_pek_result2;
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
            str = "INTRADAY_PEK_RESULT";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.RESULT_DATE, "日内调峰执行情况", this.UINTERVAL);
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
            if ((File.Exists(string.Format("{0}INTRADAY_PEK_RESULT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0074;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["RESULT_DATE"] = "对应日期";
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
            INTRADAY_PEK_RESULT[] intraday_pek_resultArray;
            int num;
            bool flag;
            intraday_pek_resultArray = List();
            if (((intraday_pek_resultArray == null) ? 0 : ((((int) intraday_pek_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_pek_resultArray[((int) intraday_pek_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEK_RESULT[] List()
        {
            INTRADAY_PEK_RESULT intraday_pek_result;
            INTRADAY_PEK_RESULT[] intraday_pek_resultArray;
            intraday_pek_result = new INTRADAY_PEK_RESULT();
            intraday_pek_resultArray = (INTRADAY_PEK_RESULT[]) CommonClassDB.Instance(intraday_pek_result).load(intraday_pek_result, "OrderId");
        Label_0020:
            return intraday_pek_resultArray;
        }

        public static INTRADAY_PEK_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEK_RESULT intraday_pek_result;
            INTRADAY_PEK_RESULT[] intraday_pek_resultArray;
            INTRADAY_PEK_RESULT[] intraday_pek_resultArray2;
            intraday_pek_result = new INTRADAY_PEK_RESULT();
            intraday_pek_resultArray = (INTRADAY_PEK_RESULT[]) CommonClassDB.Instance(intraday_pek_result).load(intraday_pek_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_pek_resultArray2 = intraday_pek_resultArray;
        Label_0021:
            return intraday_pek_resultArray2;
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

