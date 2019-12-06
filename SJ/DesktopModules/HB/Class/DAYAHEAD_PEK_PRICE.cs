namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class DAYAHEAD_PEK_PRICE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public DateTime RESULT_DATE;

        public DAYAHEAD_PEK_PRICE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_PEK_PRICE dayahead_pek_price;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_pek_price = Get(__nID);
            dayahead_pek_price.IsDelete = 1;
            dayahead_pek_price.Deleter = FunUtil.GetCurrentUserID();
            dayahead_pek_price.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_pek_price).set(dayahead_pek_price);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_PEK_PRICE dayahead_pek_price;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_pek_price = new DAYAHEAD_PEK_PRICE();
            dayahead_pek_price.Id = __nID;
            CommonClassDB.Instance(dayahead_pek_price).delte(dayahead_pek_price);
        Label_0028:
            return;
        }

        public static DAYAHEAD_PEK_PRICE Get(int __nID)
        {
            DAYAHEAD_PEK_PRICE dayahead_pek_price;
            DAYAHEAD_PEK_PRICE dayahead_pek_price2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_pek_price2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_pek_price = new DAYAHEAD_PEK_PRICE();
            dayahead_pek_price.Id = __nID;
            dayahead_pek_price2 = (DAYAHEAD_PEK_PRICE) CommonClassDB.Instance(dayahead_pek_price).get(dayahead_pek_price, dayahead_pek_price.Id);
        Label_0037:
            return dayahead_pek_price2;
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
            str = "DAYAHEAD_PEK_PRICE";
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_PEK_PRICE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0041;
        Label_002E:
            hashtable["RESULT_DATE"] = "出清结果对应日期";
        Label_0041:
            hashtable2 = hashtable;
        Label_0045:
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
            DAYAHEAD_PEK_PRICE[] dayahead_pek_priceArray;
            int num;
            bool flag;
            dayahead_pek_priceArray = List();
            if (((dayahead_pek_priceArray == null) ? 0 : ((((int) dayahead_pek_priceArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_pek_priceArray[((int) dayahead_pek_priceArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_PEK_PRICE[] List()
        {
            DAYAHEAD_PEK_PRICE dayahead_pek_price;
            DAYAHEAD_PEK_PRICE[] dayahead_pek_priceArray;
            dayahead_pek_price = new DAYAHEAD_PEK_PRICE();
            dayahead_pek_priceArray = (DAYAHEAD_PEK_PRICE[]) CommonClassDB.Instance(dayahead_pek_price).load(dayahead_pek_price, "OrderId");
        Label_0020:
            return dayahead_pek_priceArray;
        }

        public static DAYAHEAD_PEK_PRICE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_PEK_PRICE dayahead_pek_price;
            DAYAHEAD_PEK_PRICE[] dayahead_pek_priceArray;
            DAYAHEAD_PEK_PRICE[] dayahead_pek_priceArray2;
            dayahead_pek_price = new DAYAHEAD_PEK_PRICE();
            dayahead_pek_priceArray = (DAYAHEAD_PEK_PRICE[]) CommonClassDB.Instance(dayahead_pek_price).load(dayahead_pek_price, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_pek_priceArray2 = dayahead_pek_priceArray;
        Label_0021:
            return dayahead_pek_priceArray2;
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

