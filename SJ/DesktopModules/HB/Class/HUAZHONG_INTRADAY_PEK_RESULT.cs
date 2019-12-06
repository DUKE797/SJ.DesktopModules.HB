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

    public class HUAZHONG_INTRADAY_PEK_RESULT : HB_INTRADAY_POWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;
        public int UINTERVAL;

        public HUAZHONG_INTRADAY_PEK_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            huazhong_intraday_pek_result = Get(__nID);
            huazhong_intraday_pek_result.IsDelete = 1;
            huazhong_intraday_pek_result.Deleter = FunUtil.GetCurrentUserID();
            huazhong_intraday_pek_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(huazhong_intraday_pek_result).set(huazhong_intraday_pek_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            huazhong_intraday_pek_result = new HUAZHONG_INTRADAY_PEK_RESULT();
            huazhong_intraday_pek_result.Id = __nID;
            CommonClassDB.Instance(huazhong_intraday_pek_result).delte(huazhong_intraday_pek_result);
        Label_0028:
            return;
        }

        public static HUAZHONG_INTRADAY_PEK_RESULT Get(int __nID)
        {
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result;
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            huazhong_intraday_pek_result2 = null;
            goto Label_0037;
        Label_0010:
            huazhong_intraday_pek_result = new HUAZHONG_INTRADAY_PEK_RESULT();
            huazhong_intraday_pek_result.Id = __nID;
            huazhong_intraday_pek_result2 = (HUAZHONG_INTRADAY_PEK_RESULT) CommonClassDB.Instance(huazhong_intraday_pek_result).get(huazhong_intraday_pek_result, huazhong_intraday_pek_result.Id);
        Label_0037:
            return huazhong_intraday_pek_result2;
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
            str = "HUAZHONG_INTRADAY_PEK_RESULT";
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
            if ((File.Exists(string.Format("{0}HUAZHONG_INTRADAY_PEK_RESULT.AutoField", strArray[1])) == 0) != null)
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
            HUAZHONG_INTRADAY_PEK_RESULT[] huazhong_intraday_pek_resultArray;
            int num;
            bool flag;
            huazhong_intraday_pek_resultArray = List();
            if (((huazhong_intraday_pek_resultArray == null) ? 0 : ((((int) huazhong_intraday_pek_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = huazhong_intraday_pek_resultArray[((int) huazhong_intraday_pek_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HUAZHONG_INTRADAY_PEK_RESULT[] List()
        {
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result;
            HUAZHONG_INTRADAY_PEK_RESULT[] huazhong_intraday_pek_resultArray;
            huazhong_intraday_pek_result = new HUAZHONG_INTRADAY_PEK_RESULT();
            huazhong_intraday_pek_resultArray = (HUAZHONG_INTRADAY_PEK_RESULT[]) CommonClassDB.Instance(huazhong_intraday_pek_result).load(huazhong_intraday_pek_result, "OrderId");
        Label_0020:
            return huazhong_intraday_pek_resultArray;
        }

        public static HUAZHONG_INTRADAY_PEK_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HUAZHONG_INTRADAY_PEK_RESULT huazhong_intraday_pek_result;
            HUAZHONG_INTRADAY_PEK_RESULT[] huazhong_intraday_pek_resultArray;
            HUAZHONG_INTRADAY_PEK_RESULT[] huazhong_intraday_pek_resultArray2;
            huazhong_intraday_pek_result = new HUAZHONG_INTRADAY_PEK_RESULT();
            huazhong_intraday_pek_resultArray = (HUAZHONG_INTRADAY_PEK_RESULT[]) CommonClassDB.Instance(huazhong_intraday_pek_result).load(huazhong_intraday_pek_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            huazhong_intraday_pek_resultArray2 = huazhong_intraday_pek_resultArray;
        Label_0021:
            return huazhong_intraday_pek_resultArray2;
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

