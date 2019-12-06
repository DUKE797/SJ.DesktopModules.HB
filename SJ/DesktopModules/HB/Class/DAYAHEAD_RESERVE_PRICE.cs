namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class DAYAHEAD_RESERVE_PRICE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public DateTime RESULT_DATE;
        public double UID;

        public DAYAHEAD_RESERVE_PRICE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_reserve_price = Get(__nID);
            dayahead_reserve_price.IsDelete = 1;
            dayahead_reserve_price.Deleter = FunUtil.GetCurrentUserID();
            dayahead_reserve_price.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_reserve_price).set(dayahead_reserve_price);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_reserve_price = new DAYAHEAD_RESERVE_PRICE();
            dayahead_reserve_price.Id = __nID;
            CommonClassDB.Instance(dayahead_reserve_price).delte(dayahead_reserve_price);
        Label_0028:
            return;
        }

        public static DAYAHEAD_RESERVE_PRICE Get(int __nID)
        {
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price;
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_reserve_price2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_reserve_price = new DAYAHEAD_RESERVE_PRICE();
            dayahead_reserve_price.Id = __nID;
            dayahead_reserve_price2 = (DAYAHEAD_RESERVE_PRICE) CommonClassDB.Instance(dayahead_reserve_price).get(dayahead_reserve_price, dayahead_reserve_price.Id);
        Label_0037:
            return dayahead_reserve_price2;
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
            str = "DAYAHEAD_RESERVE_PRICE";
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_RESERVE_PRICE.AutoField", strArray[1])) == 0) != null)
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
            DAYAHEAD_RESERVE_PRICE[] dayahead_reserve_priceArray;
            int num;
            bool flag;
            dayahead_reserve_priceArray = List();
            if (((dayahead_reserve_priceArray == null) ? 0 : ((((int) dayahead_reserve_priceArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_reserve_priceArray[((int) dayahead_reserve_priceArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_RESERVE_PRICE[] List()
        {
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price;
            DAYAHEAD_RESERVE_PRICE[] dayahead_reserve_priceArray;
            dayahead_reserve_price = new DAYAHEAD_RESERVE_PRICE();
            dayahead_reserve_priceArray = (DAYAHEAD_RESERVE_PRICE[]) CommonClassDB.Instance(dayahead_reserve_price).load(dayahead_reserve_price, "OrderId");
        Label_0020:
            return dayahead_reserve_priceArray;
        }

        public static DAYAHEAD_RESERVE_PRICE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_RESERVE_PRICE dayahead_reserve_price;
            DAYAHEAD_RESERVE_PRICE[] dayahead_reserve_priceArray;
            DAYAHEAD_RESERVE_PRICE[] dayahead_reserve_priceArray2;
            dayahead_reserve_price = new DAYAHEAD_RESERVE_PRICE();
            dayahead_reserve_priceArray = (DAYAHEAD_RESERVE_PRICE[]) CommonClassDB.Instance(dayahead_reserve_price).load(dayahead_reserve_price, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_reserve_priceArray2 = dayahead_reserve_priceArray;
        Label_0021:
            return dayahead_reserve_priceArray2;
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

