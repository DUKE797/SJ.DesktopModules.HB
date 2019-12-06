namespace SJ.DesktopModules.HB.Class
{
    using DataAccess;
    using System;
    using System.Collections;
    using System.IO;
    using WebSiteBase.Class;
    using WebSiteBase.Interface;
    using WebSiteBase.Utilities;

    public class INTRADAY_PEAK_PRICE : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble
    {
        public double INTERVEL;
        public DateTime RESULT_DATE;
        public double UID;

        public INTRADAY_PEAK_PRICE()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            INTRADAY_PEAK_PRICE intraday_peak_price;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            intraday_peak_price = Get(__nID);
            intraday_peak_price.IsDelete = 1;
            intraday_peak_price.Deleter = FunUtil.GetCurrentUserID();
            intraday_peak_price.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(intraday_peak_price).set(intraday_peak_price);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            INTRADAY_PEAK_PRICE intraday_peak_price;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            intraday_peak_price = new INTRADAY_PEAK_PRICE();
            intraday_peak_price.Id = __nID;
            CommonClassDB.Instance(intraday_peak_price).delte(intraday_peak_price);
        Label_0028:
            return;
        }

        public static INTRADAY_PEAK_PRICE Get(int __nID)
        {
            INTRADAY_PEAK_PRICE intraday_peak_price;
            INTRADAY_PEAK_PRICE intraday_peak_price2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            intraday_peak_price2 = null;
            goto Label_0037;
        Label_0010:
            intraday_peak_price = new INTRADAY_PEAK_PRICE();
            intraday_peak_price.Id = __nID;
            intraday_peak_price2 = (INTRADAY_PEAK_PRICE) CommonClassDB.Instance(intraday_peak_price).get(intraday_peak_price, intraday_peak_price.Id);
        Label_0037:
            return intraday_peak_price2;
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
            str = "INTRADAY_PEAK_PRICE";
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
            if ((File.Exists(string.Format("{0}INTRADAY_PEAK_PRICE.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0063;
        Label_002E:
            hashtable["UID"] = "序号";
            hashtable["INTERVEL"] = "出清时段";
            hashtable["RESULT_DATE"] = "出清对应日期";
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
            INTRADAY_PEAK_PRICE[] intraday_peak_priceArray;
            int num;
            bool flag;
            intraday_peak_priceArray = List();
            if (((intraday_peak_priceArray == null) ? 0 : ((((int) intraday_peak_priceArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = intraday_peak_priceArray[((int) intraday_peak_priceArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static INTRADAY_PEAK_PRICE[] List()
        {
            INTRADAY_PEAK_PRICE intraday_peak_price;
            INTRADAY_PEAK_PRICE[] intraday_peak_priceArray;
            intraday_peak_price = new INTRADAY_PEAK_PRICE();
            intraday_peak_priceArray = (INTRADAY_PEAK_PRICE[]) CommonClassDB.Instance(intraday_peak_price).load(intraday_peak_price, "OrderId");
        Label_0020:
            return intraday_peak_priceArray;
        }

        public static INTRADAY_PEAK_PRICE[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            INTRADAY_PEAK_PRICE intraday_peak_price;
            INTRADAY_PEAK_PRICE[] intraday_peak_priceArray;
            INTRADAY_PEAK_PRICE[] intraday_peak_priceArray2;
            intraday_peak_price = new INTRADAY_PEAK_PRICE();
            intraday_peak_priceArray = (INTRADAY_PEAK_PRICE[]) CommonClassDB.Instance(intraday_peak_price).load(intraday_peak_price, __nPageIndex, __nPageSize, __strFilter, __strSort);
            intraday_peak_priceArray2 = intraday_peak_priceArray;
        Label_0021:
            return intraday_peak_priceArray2;
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

