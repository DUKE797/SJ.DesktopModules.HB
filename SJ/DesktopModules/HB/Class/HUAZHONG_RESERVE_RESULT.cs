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

    public class HUAZHONG_RESERVE_RESULT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;

        public HUAZHONG_RESERVE_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            huazhong_reserve_result = Get(__nID);
            huazhong_reserve_result.IsDelete = 1;
            huazhong_reserve_result.Deleter = FunUtil.GetCurrentUserID();
            huazhong_reserve_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(huazhong_reserve_result).set(huazhong_reserve_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            huazhong_reserve_result = new HUAZHONG_RESERVE_RESULT();
            huazhong_reserve_result.Id = __nID;
            CommonClassDB.Instance(huazhong_reserve_result).delte(huazhong_reserve_result);
        Label_0028:
            return;
        }

        public static HUAZHONG_RESERVE_RESULT Get(int __nID)
        {
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result;
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            huazhong_reserve_result2 = null;
            goto Label_0037;
        Label_0010:
            huazhong_reserve_result = new HUAZHONG_RESERVE_RESULT();
            huazhong_reserve_result.Id = __nID;
            huazhong_reserve_result2 = (HUAZHONG_RESERVE_RESULT) CommonClassDB.Instance(huazhong_reserve_result).get(huazhong_reserve_result, huazhong_reserve_result.Id);
        Label_0037:
            return huazhong_reserve_result2;
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
            str = "HUAZHONG_RESERVE_RESULT";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.RESULT_DATE, "日前备用执行情况");
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
            if ((File.Exists(string.Format("{0}HUAZHONG_RESERVE_RESULT.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["PLANT_NAME"] = "电厂名称";
            hashtable["DBI_ID"] = "D5000的ID";
            hashtable["RESULT_DATE"] = "对应日期";
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
            HUAZHONG_RESERVE_RESULT[] huazhong_reserve_resultArray;
            int num;
            bool flag;
            huazhong_reserve_resultArray = List();
            if (((huazhong_reserve_resultArray == null) ? 0 : ((((int) huazhong_reserve_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = huazhong_reserve_resultArray[((int) huazhong_reserve_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HUAZHONG_RESERVE_RESULT[] List()
        {
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result;
            HUAZHONG_RESERVE_RESULT[] huazhong_reserve_resultArray;
            huazhong_reserve_result = new HUAZHONG_RESERVE_RESULT();
            huazhong_reserve_resultArray = (HUAZHONG_RESERVE_RESULT[]) CommonClassDB.Instance(huazhong_reserve_result).load(huazhong_reserve_result, "OrderId");
        Label_0020:
            return huazhong_reserve_resultArray;
        }

        public static HUAZHONG_RESERVE_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HUAZHONG_RESERVE_RESULT huazhong_reserve_result;
            HUAZHONG_RESERVE_RESULT[] huazhong_reserve_resultArray;
            HUAZHONG_RESERVE_RESULT[] huazhong_reserve_resultArray2;
            huazhong_reserve_result = new HUAZHONG_RESERVE_RESULT();
            huazhong_reserve_resultArray = (HUAZHONG_RESERVE_RESULT[]) CommonClassDB.Instance(huazhong_reserve_result).load(huazhong_reserve_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            huazhong_reserve_resultArray2 = huazhong_reserve_resultArray;
        Label_0021:
            return huazhong_reserve_resultArray2;
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

