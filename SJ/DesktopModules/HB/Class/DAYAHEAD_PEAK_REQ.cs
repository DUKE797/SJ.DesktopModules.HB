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

    public class DAYAHEAD_PEAK_REQ : HB_DAYAPOWER, ICacheableClass, IAutoFieldAble, IChartClass
    {
        public DateTime PRESCHED_DATE;
        public string PROV_NAME;

        public DAYAHEAD_PEAK_REQ()
        {
            base..ctor();
            return;
        }

        public static unsafe void Del(int __nID)
        {
            DAYAHEAD_PEAK_REQ dayahead_peak_req;
            bool flag;
            DateTime time;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0047;
            }
            dayahead_peak_req = Get(__nID);
            dayahead_peak_req.IsDelete = 1;
            dayahead_peak_req.Deleter = FunUtil.GetCurrentUserID();
            dayahead_peak_req.DeleteTime = &DateTime.Now.Ticks;
            CommonClassDB.Instance(dayahead_peak_req).set(dayahead_peak_req);
        Label_0047:
            return;
        }

        public static void DelTrue(int __nID)
        {
            DAYAHEAD_PEAK_REQ dayahead_peak_req;
            bool flag;
            if (((__nID < 1) == 0) == null)
            {
                goto Label_0028;
            }
            dayahead_peak_req = new DAYAHEAD_PEAK_REQ();
            dayahead_peak_req.Id = __nID;
            CommonClassDB.Instance(dayahead_peak_req).delte(dayahead_peak_req);
        Label_0028:
            return;
        }

        public static DAYAHEAD_PEAK_REQ Get(int __nID)
        {
            DAYAHEAD_PEAK_REQ dayahead_peak_req;
            DAYAHEAD_PEAK_REQ dayahead_peak_req2;
            bool flag;
            if (((__nID < 1) == 0) != null)
            {
                goto Label_0010;
            }
            dayahead_peak_req2 = null;
            goto Label_0037;
        Label_0010:
            dayahead_peak_req = new DAYAHEAD_PEAK_REQ();
            dayahead_peak_req.Id = __nID;
            dayahead_peak_req2 = (DAYAHEAD_PEAK_REQ) CommonClassDB.Instance(dayahead_peak_req).get(dayahead_peak_req, dayahead_peak_req.Id);
        Label_0037:
            return dayahead_peak_req2;
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
            str = "DAYAHEAD_PEAK_REQ";
        Label_0009:
            return str;
        }

        public ArrayList GetChartData(out ArrayList __alFields)
        {
            ArrayList list;
            list = base.GetChartData(__alFields, this.PRESCHED_DATE, "日前调峰需求");
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
            if ((File.Exists(string.Format("{0}DAYAHEAD_PEAK_REQ.AutoField", strArray[1])) == 0) != null)
            {
                goto Label_002E;
            }
            goto Label_0052;
        Label_002E:
            hashtable["PROV_NAME"] = "省份名称";
            hashtable["PRESCHED_DATE"] = "申报日期";
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
            DAYAHEAD_PEAK_REQ[] dayahead_peak_reqArray;
            int num;
            bool flag;
            dayahead_peak_reqArray = List();
            if (((dayahead_peak_reqArray == null) ? 0 : ((((int) dayahead_peak_reqArray.Length) < 1) == 0)) != null)
            {
                goto Label_001F;
            }
            num = 1;
            goto Label_0030;
        Label_001F:
            num = dayahead_peak_reqArray[((int) dayahead_peak_reqArray.Length) - 1].OrderId + 1;
        Label_0030:
            return num;
        }

        public static DAYAHEAD_PEAK_REQ[] List()
        {
            DAYAHEAD_PEAK_REQ dayahead_peak_req;
            DAYAHEAD_PEAK_REQ[] dayahead_peak_reqArray;
            dayahead_peak_req = new DAYAHEAD_PEAK_REQ();
            dayahead_peak_reqArray = (DAYAHEAD_PEAK_REQ[]) CommonClassDB.Instance(dayahead_peak_req).load(dayahead_peak_req, "OrderId");
        Label_0020:
            return dayahead_peak_reqArray;
        }

        public static DAYAHEAD_PEAK_REQ[] List(string __strFilter, string __strSort, int __nPageIndex, int __nPageSize)
        {
            DAYAHEAD_PEAK_REQ dayahead_peak_req;
            DAYAHEAD_PEAK_REQ[] dayahead_peak_reqArray;
            DAYAHEAD_PEAK_REQ[] dayahead_peak_reqArray2;
            dayahead_peak_req = new DAYAHEAD_PEAK_REQ();
            dayahead_peak_reqArray = (DAYAHEAD_PEAK_REQ[]) CommonClassDB.Instance(dayahead_peak_req).load(dayahead_peak_req, __nPageIndex, __nPageSize, __strFilter, __strSort);
            dayahead_peak_reqArray2 = dayahead_peak_reqArray;
        Label_0021:
            return dayahead_peak_reqArray2;
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

