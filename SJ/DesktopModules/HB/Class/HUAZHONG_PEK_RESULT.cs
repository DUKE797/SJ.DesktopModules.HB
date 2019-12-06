namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class HUAZHONG_PEK_RESULT : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public string DBI_ID;
        public string PLANT_NAME;
        public DateTime RESULT_DATE;

        public HUAZHONG_PEK_RESULT()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HUAZHONG_PEK_RESULT huazhong_pek_result;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            huazhong_pek_result = Get(__nID);
            huazhong_pek_result.IsDelete = 1;
            huazhong_pek_result.Deleter = FunUtil.GetCurrentUserID();
            huazhong_pek_result.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(huazhong_pek_result).set(huazhong_pek_result);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HUAZHONG_PEK_RESULT huazhong_pek_result;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            huazhong_pek_result = new HUAZHONG_PEK_RESULT();
            huazhong_pek_result.Id = __nID;
            CommonClassDB.Instance(huazhong_pek_result).delte(huazhong_pek_result);
        Label_0028:
            return;
        }

        public static HUAZHONG_PEK_RESULT Get(int __nID)
        {
            HUAZHONG_PEK_RESULT huazhong_pek_result;
            HUAZHONG_PEK_RESULT huazhong_pek_result2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            huazhong_pek_result2 = null;
            goto Label_0037;
        Label_0010:
            huazhong_pek_result = new HUAZHONG_PEK_RESULT();
            huazhong_pek_result.Id = __nID;
            huazhong_pek_result2 = (HUAZHONG_PEK_RESULT) CommonClassDB.Instance(huazhong_pek_result).get(huazhong_pek_result, huazhong_pek_result.Id);
        Label_0037:
            return huazhong_pek_result2;
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
            str = "HUAZHONG_PEK_RESULT";
        Label_0009:
            return str;
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
            if ((File.Exists(string.Format("{0}HUAZHONG_PEK_RESULT.AutoField", strArray[1])) == 0) != null)
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
            HUAZHONG_PEK_RESULT[] huazhong_pek_resultArray;
            int num;
            bool flag;
            huazhong_pek_resultArray = List();
            if (((huazhong_pek_resultArray == null) ? 0 : ((((int) huazhong_pek_resultArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = huazhong_pek_resultArray[((int) huazhong_pek_resultArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HUAZHONG_PEK_RESULT[] List()
        {
            HUAZHONG_PEK_RESULT huazhong_pek_result;
            HUAZHONG_PEK_RESULT[] huazhong_pek_resultArray;
            huazhong_pek_result = new HUAZHONG_PEK_RESULT();
            huazhong_pek_resultArray = (HUAZHONG_PEK_RESULT[]) CommonClassDB.Instance(huazhong_pek_result).load(huazhong_pek_result, "OrderId");
        Label_0020:
            return huazhong_pek_resultArray;
        }

        public static HUAZHONG_PEK_RESULT[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HUAZHONG_PEK_RESULT huazhong_pek_result;
            HUAZHONG_PEK_RESULT[] huazhong_pek_resultArray;
            HUAZHONG_PEK_RESULT[] huazhong_pek_resultArray2;
            huazhong_pek_result = new HUAZHONG_PEK_RESULT();
            huazhong_pek_resultArray = (HUAZHONG_PEK_RESULT[]) CommonClassDB.Instance(huazhong_pek_result).load(huazhong_pek_result, __nPageIndex, __nPageSize, __strFilter, __strSort);
            huazhong_pek_resultArray2 = huazhong_pek_resultArray;
        Label_0021:
            return huazhong_pek_resultArray2;
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

