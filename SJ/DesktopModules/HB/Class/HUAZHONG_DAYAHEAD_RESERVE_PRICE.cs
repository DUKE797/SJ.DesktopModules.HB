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

    public class HUAZHONG_DAYAHEAD_RESERVE_PRICE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime RESULT_DATE;
        public int UID;

        public HUAZHONG_DAYAHEAD_RESERVE_PRICE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            huazhong_dayahead_reserve_price = Get(__nID);
            huazhong_dayahead_reserve_price.IsDelete = 1;
            huazhong_dayahead_reserve_price.Deleter = FunUtil.GetCurrentUserID();
            huazhong_dayahead_reserve_price.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(huazhong_dayahead_reserve_price).set(huazhong_dayahead_reserve_price);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            huazhong_dayahead_reserve_price = new HUAZHONG_DAYAHEAD_RESERVE_PRICE();
            huazhong_dayahead_reserve_price.Id = __nID;
            CommonClassDB.Instance(huazhong_dayahead_reserve_price).delte(huazhong_dayahead_reserve_price);
        Label_0028:
            return;
        }

        public static HUAZHONG_DAYAHEAD_RESERVE_PRICE Get(int __nID)
        {
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price;
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            huazhong_dayahead_reserve_price2 = null;
            goto Label_0037;
        Label_0010:
            huazhong_dayahead_reserve_price = new HUAZHONG_DAYAHEAD_RESERVE_PRICE();
            huazhong_dayahead_reserve_price.Id = __nID;
            huazhong_dayahead_reserve_price2 = (HUAZHONG_DAYAHEAD_RESERVE_PRICE) CommonClassDB.Instance(huazhong_dayahead_reserve_price).get(huazhong_dayahead_reserve_price, huazhong_dayahead_reserve_price.Id);
        Label_0037:
            return huazhong_dayahead_reserve_price2;
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
            str = "HUAZHONG_DAYAHEAD_RESERVE_PRICE";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.RESULT_DATE, "日前备用出清价格");
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
            if ((File.Exists(string.Format("{0}HUAZHONG_DAYAHEAD_RESERVE_PRICE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0052;
        Label_002E:
            hashtable["UID"] = "序号";
            hashtable["RESULT_DATE"] = "出清结果对应日期";
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
            HUAZHONG_DAYAHEAD_RESERVE_PRICE[] huazhong_dayahead_reserve_priceArray;
            int num;
            bool flag;
            huazhong_dayahead_reserve_priceArray = List();
            if (((huazhong_dayahead_reserve_priceArray == null) ? 0 : ((((int) huazhong_dayahead_reserve_priceArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = huazhong_dayahead_reserve_priceArray[((int) huazhong_dayahead_reserve_priceArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static HUAZHONG_DAYAHEAD_RESERVE_PRICE[] List()
        {
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price;
            HUAZHONG_DAYAHEAD_RESERVE_PRICE[] huazhong_dayahead_reserve_priceArray;
            huazhong_dayahead_reserve_price = new HUAZHONG_DAYAHEAD_RESERVE_PRICE();
            huazhong_dayahead_reserve_priceArray = (HUAZHONG_DAYAHEAD_RESERVE_PRICE[]) CommonClassDB.Instance(huazhong_dayahead_reserve_price).load(huazhong_dayahead_reserve_price, "OrderId");
        Label_0020:
            return huazhong_dayahead_reserve_priceArray;
        }

        public static HUAZHONG_DAYAHEAD_RESERVE_PRICE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            HUAZHONG_DAYAHEAD_RESERVE_PRICE huazhong_dayahead_reserve_price;
            HUAZHONG_DAYAHEAD_RESERVE_PRICE[] huazhong_dayahead_reserve_priceArray;
            HUAZHONG_DAYAHEAD_RESERVE_PRICE[] huazhong_dayahead_reserve_priceArray2;
            huazhong_dayahead_reserve_price = new HUAZHONG_DAYAHEAD_RESERVE_PRICE();
            huazhong_dayahead_reserve_priceArray = (HUAZHONG_DAYAHEAD_RESERVE_PRICE[]) CommonClassDB.Instance(huazhong_dayahead_reserve_price).load(huazhong_dayahead_reserve_price, __nPageIndex, __nPageSize, __strFilter, __strSort);
            huazhong_dayahead_reserve_priceArray2 = huazhong_dayahead_reserve_priceArray;
        Label_0021:
            return huazhong_dayahead_reserve_priceArray2;
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

